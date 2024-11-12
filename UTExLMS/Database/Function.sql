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


CREATE FUNCTION GetElementPreviews(
    @input_idSection INT,
    @input_idCourse INT
)
RETURNS TABLE
AS
RETURN
    SELECT 
        E.idSection,
        E.idCourse,
        E.idElement,
        CASE 
            WHEN M.idMaterial IS NOT NULL THEN 'MaterialIcon'  -- Đặt biểu tượng cho Material
            WHEN T.idTest IS NOT NULL THEN 'TestIcon'          -- Đặt biểu tượng cho Test
            WHEN D.idDiscuss IS NOT NULL THEN 'DiscussionIcon' -- Đặt biểu tượng cho Discussion
            WHEN A.idAssign IS NOT NULL THEN 'AssignmentIcon'  -- Đặt biểu tượng cho Assignment
            ELSE NULL
        END AS icon,
        CASE 
            WHEN M.idMaterial IS NOT NULL THEN M.nameMaterial
            WHEN T.idTest IS NOT NULL THEN T.nameTest
            WHEN D.idDiscuss IS NOT NULL THEN D.nameDiscuss
            WHEN A.idAssign IS NOT NULL THEN A.nameAssign
            ELSE NULL
        END AS ElementName
    FROM Element E
    LEFT JOIN Material M ON E.idElement = M.idMaterial AND E.idCourse = M.idCourse AND E.idSection = M.idSection
    LEFT JOIN Test T ON E.idElement = T.idTest AND E.idCourse = T.idCourse AND E.idSection = T.idSection
    LEFT JOIN Discussion D ON E.idElement = D.idDiscuss AND E.idCourse = D.idCourse AND E.idSection = D.idSection
    LEFT JOIN Assignment A ON E.idElement = A.idAssign AND E.idCourse = A.idCourse AND E.idSection = A.idSection
    WHERE E.idSection = @input_idSection AND E.idCourse = @input_idCourse;


-----------------------------

Create function GetQuestions
(
	@idTest INT,
    @idCourse INT,
    @idSection INT
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		*
	FROM 
		Question q
	WHERE 
		q.idTest = @idTest AND q.idCourse = @idCourse AND q.idSection = @idSection
);

