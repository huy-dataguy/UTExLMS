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

CREATE FUNCTION GetSectionsByCourseId
(
    @idCourse INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        s.idSection,
        s.nameSection,
        s.descript
    FROM 
        Section s
    WHERE 
        s.idCourse = @idCourse
);



