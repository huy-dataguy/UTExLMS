--Function--
CREATE FUNCTION GetCourses (
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
---------------------------
CREATE FUNCTION GetUpcomingDeadlinesForStudent (
    @studentId INT
)
RETURNS TABLE
AS
RETURN
    SELECT 
        cs.idStudent,
        cs.idCourse,
        COALESCE(a.nameAssign, t.nameTest) AS nameDeadline,  -- Tên deadline từ Assignment hoặc Test
        CASE 
            WHEN a.idAssign IS NOT NULL THEN 'Assignment'  -- Đặt biểu tượng cho Assignment
            WHEN t.idTest IS NOT NULL THEN 'Test'          -- Đặt biểu tượng cho Test
            ELSE NULL
        END AS Deadline, 
        CASE 
            WHEN a.idAssign IS NOT NULL THEN a.startDate
            WHEN t.idTest IS NOT NULL THEN t.startDate
            ELSE NULL
        END AS startTime,  -- Thời gian bắt đầu
        CASE 
            WHEN a.idAssign IS NOT NULL THEN a.endDate
            WHEN t.idTest IS NOT NULL THEN t.endDate
            ELSE NULL
        END AS endTime   -- Thời gian kết thúc
    FROM CourseStudent cs
    LEFT JOIN Assignment a ON cs.idCourse = a.idCourse
    LEFT JOIN Test t ON cs.idCourse = t.idCourse
    WHERE cs.idStudent = @studentId;




	SELECT * FROM GetUpcomingDeadlinesForStudent(102);

	DROP FUNCTION IF EXISTS GetUpcomingDeadlinesForStudent;


