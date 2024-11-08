--Function--
Alter FUNCTION GetCourses (
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


Select * from GetCourses (1, '', 'All');

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

