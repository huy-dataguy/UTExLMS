--Function--

use UTExLMS

Create FUNCTION GetCourses (
    @personId INT,
    @searchTerm NVARCHAR(100),
    @selectedFilter VARCHAR(20)  -- Thêm tham số search term
)
RETURNS TABLE
AS
RETURN (
    SELECT 
        p.idPerson,  -- Dùng idPerson thay vì idStudent
        c.idCourse,
        p.firstName,
        p.lastName,
        c.nameCourse,
        sem.startDate,
        sem.endDate,
        cs.progress,
        c.imgCourse
    FROM 
        CourseStudent cs
        JOIN Course c ON cs.idCourse = c.idCourse
        JOIN Subjects sub ON c.idSubject = sub.idSubject  -- Liên kết bảng Subjects bằng idSubject
        JOIN Semester sem ON sub.idSemester = sem.idSemester
        JOIN Person p ON cs.idStudent = p.idPerson  -- Thay bảng Student bằng bảng Person
    WHERE 
        p.idPerson = @personId  -- Dùng idPerson thay vì idStudent
        AND (
            @selectedFilter = 'All' 
            OR (@selectedFilter = 'Past' AND GETDATE() > sem.endDate)
            OR (@selectedFilter = 'In Progress' AND GETDATE() BETWEEN sem.startDate AND sem.endDate)
        )
        AND (
            @searchTerm IS NULL
            OR c.nameCourse LIKE '%' + @searchTerm + '%'
        )
);


Select * from GetCourses (3, '', 'Past');

---------------------------
drop function GetSectionsByCourse
CREATE FUNCTION GetSectionsByCourse (
    @CourseId INT
)
RETURNS TABLE
AS
RETURN 
(
    SELECT 
        *
    FROM 
        Section s
    WHERE 
        s.idCourse = @CourseId
);
select * from GetSectionsByCourse(1)

CREATE FUNCTION GetElementsByCourseAndSection (
    @CourseId INT, 
    @SectionId INT
)
RETURNS TABLE
AS
RETURN 
(
    SELECT 
        e.idElement,
        CASE 
            WHEN e.nameType = 'Material' THEN m.nameMaterial
            WHEN e.nameType = 'Test' THEN t.nameTest
            WHEN e.nameType = 'Assignment' THEN a.nameAssign
        END AS ElementName,
        e.nameType 
    FROM 
        Element e
    LEFT JOIN 
        Material m ON e.idElement = m.idMaterial 
            AND e.idCourse = m.idCourse 
            AND e.idSection = m.idSection 
            AND e.nameType = 'Material'
    LEFT JOIN 
        Test t ON e.idElement = t.idTest 
            AND e.idCourse = t.idCourse 
            AND e.idSection = t.idSection 
            AND e.nameType = 'Test'
    LEFT JOIN 
        Assignment a ON e.idElement = a.idAssign 
            AND e.idCourse = a.idCourse 
            AND e.idSection = a.idSection 
            AND e.nameType = 'Assignment'
    WHERE 
        e.idCourse = @CourseId 
        AND e.idSection = @SectionId
);

select * from GetElementsByCourseAndSection(1, 1)



