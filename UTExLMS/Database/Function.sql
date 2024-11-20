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


Create FUNCTION GetCourseLecture(
    @personId INT,
    @searchTerm NVARCHAR(100),
    @selectedFilter VARCHAR(20)  -- Thêm tham số search term
)
RETURNS TABLE
AS
RETURN (
    SELECT 
        p.idPerson,  -- Dùng idPerson thay vì idStudent
        cs.idCourse,
        p.firstName,
        p.lastName,
        cs.nameCourse,
        sem.startDate,
        sem.endDate,
        cs.imgCourse
    FROM 
        Course cs
        JOIN Subjects sub ON cs.idSubject = sub.idSubject  -- Liên kết bảng Subjects bằng idSubject
        JOIN Semester sem ON sub.idSemester = sem.idSemester
        JOIN Person p ON cs.idLecturer = p.idPerson  -- Thay bảng Student bằng bảng Person
    WHERE 
        p.idPerson = @personId  -- Dùng idPerson thay vì idStudent
        AND (
            @selectedFilter = 'All' 
            OR (@selectedFilter = 'Past' AND GETDATE() > sem.endDate)
            OR (@selectedFilter = 'In Progress' AND GETDATE() BETWEEN sem.startDate AND sem.endDate)
        )
        AND (
            @searchTerm IS NULL
            OR cs.nameCourse LIKE '%' + @searchTerm + '%'
        )
);



--Select * from GetCourses (3, '', 'Past');


use UTExLMS

CREATE FUNCTION GetStudentsByCourse(@CourseId INT)
RETURNS TABLE
AS
RETURN (
    SELECT 
        p.idPerson,
		p.email,
		p.birthday,
		p.gender,
		p.lastName,
        p.firstName,
		p.phoneNum,
		p.idRole,
		p.pass
    FROM Person p
    JOIN CourseStudent cs ON cs.IdStudent = p.IdPerson
    WHERE cs.IdCourse = @CourseId
);

--select * from GetStudentsByCourse (1)

---------------------------
--drop function GetStudentsByCourse
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
--select * from GetSectionsByCourse(1)
--select * from Discussion

--CREATE FUNCTION GetElementsByCourseAndSection (
--    @CourseId INT, 
--    @SectionId INT,
--    @IdPerson INT
--)
--RETURNS TABLE
--AS
--RETURN 
--(
--    SELECT 
--        e.idElement,
--        CASE 
--            WHEN e.nameType = 'Material' THEN m.nameMaterial
--            WHEN e.nameType = 'Test' THEN t.nameTest
--            WHEN e.nameType = 'Assignment' THEN a.nameAssign
--            WHEN e.nameType = 'Discussion' THEN d.nameDiscuss
--        END AS ElementName,
--        e.nameType,
--        @CourseId AS idCourse,   
--        @SectionId AS idSection,
--        @IdPerson AS IdStudent
--    FROM 
--        Element e
--    LEFT JOIN 
--        Material m ON e.idElement = m.idMaterial 
--            AND e.idCourse = m.idCourse 
--            AND e.idSection = m.idSection 
--            AND e.nameType = 'Material'
--    LEFT JOIN 
--        Test t ON e.idElement = t.idTest 
--            AND e.idCourse = t.idCourse 
--            AND e.idSection = t.idSection 
--            AND e.nameType = 'Test'
--    LEFT JOIN 
--        Assignment a ON e.idElement = a.idAssign 
--            AND e.idCourse = a.idCourse 
--            AND e.idSection = a.idSection 
--            AND e.nameType = 'Assignment'
--    LEFT JOIN 
--        Discussion d ON e.idElement = d.idDiscuss
--            AND e.idCourse = d.idCourse
--            AND e.idSection = d.idSection
--            AND e.nameType = 'Discussion'
--    WHERE 
--        e.idCourse = @CourseId 
--        AND e.idSection = @SectionId
--);

CREATE FUNCTION GetElementsByCourseAndSection (
    @CourseId INT, 
    @SectionId INT,
    @IdPerson INT
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
            WHEN e.nameType = 'Discussion' THEN d.nameDiscuss
            ELSE NULL
        END AS ElementName,
        e.nameType,
        @CourseId AS idCourse,   
        @SectionId AS idSection,
        @IdPerson AS IdStudent
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
    LEFT JOIN 
        Discussion d ON e.idElement = d.idDiscuss
            AND e.idCourse = d.idCourse
            AND e.idSection = d.idSection
            AND e.nameType = 'Discussion'
    WHERE 
        e.idCourse = @CourseId 
        AND e.idSection = @SectionId
);

--select * from GetElementsByCourseAndSection(1, 1, 3)
--select * from Assignment

--drop function GetElementsByCourseAndSection
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



--Huyyyyyyyyyyyyyyyyyyy
CREATE FUNCTION GetMaterialByElement (
    @idCourse INT,
    @idSection INT,
    @idElement INT
)
RETURNS TABLE
AS
RETURN
    SELECT m.idMaterial, m.filePath, m.statu, m.nameMaterial, m.typeMaterial, m.idSection, m.idCourse
    FROM Material m
    INNER JOIN Element e ON m.idCourse = e.idCourse AND m.idSection = e.idSection AND m.idMaterial = e.idElement
    WHERE e.idCourse = @idCourse
      AND e.idSection = @idSection
      AND e.idElement = @idElement;

select * from GetMaterialByElement(1, 1, 1)



CREATE FUNCTION GetAssignmentByElement (
    @idCourse INT,
    @idSection INT,
    @idElement INT
)
RETURNS TABLE
AS
RETURN
    SELECT a.idAssign, a.nameAssign, a.statu, a.startDate, a.endDate, a.descript, a.grade, a.idSection, a.idCourse
    FROM Assignment a
    INNER JOIN Element e ON a.idCourse = e.idCourse AND a.idSection = e.idSection
    WHERE e.idCourse = @idCourse
      AND e.idSection = @idSection
      AND e.idElement = @idElement;

select * from GetAssignmentByElement(1,1,1)



--CREATE PROCEDURE UpdateAssignmentByElement (
--    @idCourse INT,
--    @idSection INT,
--    @idElement INT,
--    @nameAssign NVARCHAR(255),  -- Tên bài tập
--    @statu NVARCHAR(50),        -- Trạng thái
--    @startDate DATETIME,        -- Ngày bắt đầu
--    @endDate DATETIME,          -- Ngày kết thúc
--    @descript NVARCHAR(500),    -- Mô tả
--    @grade INT                  -- Điểm
--)
--AS
--BEGIN
--    -- Cập nhật thông tin bài tập
--    UPDATE a
--    SET
--        a.nameAssign = @nameAssign,
--        a.statu = @statu,
--        a.startDate = @startDate,
--        a.endDate = @endDate,
--        a.descript = @descript,
--        a.grade = @grade
--    FROM Assignment a
--    INNER JOIN Element e ON a.idCourse = e.idCourse AND a.idSection = e.idSection
--    WHERE e.idCourse = @idCourse
--      AND e.idSection = @idSection
--      AND e.idElement = @idElement;

--    -- Kiểm tra xem có bản ghi nào được cập nhật không
--    IF @@ROWCOUNT = 0
--    BEGIN
--        PRINT 'Không tìm thấy bài tập để cập nhật.';
--    END
--    ELSE
--    BEGIN
--        PRINT 'Cập nhật bài tập thành công.';
--    END
--END
----pahir xoa thoiiiiiiiiiiii


CREATE FUNCTION GetAssignmentSubmited (
    @idCourse INT,
    @idSection INT,
    @idElement INT,
    @idStudent INT
)
RETURNS TABLE
AS
RETURN
    SELECT 
        sa.nameFile,
        sa.pathFile,
        sa.typeFile,
        sa.dateSubmit,
        sa.idCourse,
        sa.idSection,
        sa.idAssign,
        sa.idStudent
    FROM 
        StudentAssignment sa
    INNER JOIN Assignment a 
        ON sa.idCourse = a.idCourse
        AND sa.idSection = a.idSection
        AND sa.idAssign = a.idAssign
    INNER JOIN Element e 
        ON a.idCourse = e.idCourse
        AND a.idSection = e.idSection
        AND e.idElement = @idElement
    WHERE 
        sa.idCourse = @idCourse
        AND sa.idSection = @idSection
        AND sa.idStudent = @idStudent;

--select * from GetAssignmentSubmited (1,1,1,3)






CREATE FUNCTION GetDiscussion (
    @idCourse INT,
    @idSection INT,
    @idElement INT
)
RETURNS TABLE
AS
RETURN (
    SELECT *
    FROM Discussion
    WHERE idCourse = @idCourse 
      AND idSection = @idSection 
      AND idDiscuss = @idElement
);


select * from GetDiscussion(1,1,8)
CREATE FUNCTION GetAllComment(
    @idCourse INT,
    @idSection INT,
    @idDiscuss INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        c.idCmt,
        c.content,
        c.commentDate,
        c.idCourse,
        c.idSection,
        c.idDiscuss,
        c.idPerson,
        p.firstName AS PersonFirstName,
        p.lastName AS PersonLastName,
        d.nameDiscuss AS DiscussionName,
        d.descript AS DiscussionDescription
    FROM 
        Comment c
    JOIN 
        Person p ON c.idPerson = p.idPerson
    JOIN 
        Discussion d ON c.idCourse = d.idCourse 
                     AND c.idSection = d.idSection 
                     AND c.idDiscuss = d.idDiscuss
    WHERE 
        c.idCourse = @idCourse 
        AND c.idSection = @idSection 
        AND c.idDiscuss = @idDiscuss
);

--drop function GetAllComment
--select * from GetAllComment(1,1,8);


CREATE FUNCTION GetPersonInfoById
(
    @idPerson INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        idPerson,
        email,
        birthday,
        gender,
        lastName,
        firstName,
        phoneNum,
        idRole,
        pass
    FROM 
        Person
    WHERE 
        idPerson = @idPerson
);


--select * from GetPersonInfoById(3);


CREATE PROCEDURE CreateNewComment
    @content VARCHAR(255),
    @commentDate DATETIME,
    @idCourse INT,
    @idSection INT,
    @idDiscuss INT,
    @idPerson INT
AS
BEGIN
    DECLARE @NewIdCmt INT;

    -- Lấy giá trị idCmt lớn nhất hiện tại và tăng lên 1
    SELECT @NewIdCmt = COALESCE(MAX(idCmt), 0) + 1 FROM Comment;

    -- Chèn bình luận mới với idCmt mới
    INSERT INTO Comment (idCmt, content, commentDate, idCourse, idSection, idDiscuss, idPerson)
    VALUES (@NewIdCmt, @content, @commentDate, @idCourse, @idSection, @idDiscuss, @idPerson);

    -- In ra idCmt mới để xác nhận chèn thành công
    SELECT @NewIdCmt AS NewCommentId;
END;

-- Gọi thủ tục để tạo một bình luận mới
EXEC CreateNewComment 
    @content = 'This is a sample comment',
    @commentDate = '2024-11-14 15:45:00',
    @idCourse = 1,
    @idSection = 1,
    @idDiscuss = 7,
    @idPerson = 3;

	select * from Discussion



CREATE FUNCTION GetAllDeadlinesForStudent (
    @studentId INT
)
RETURNS TABLE
AS
RETURN
    SELECT 
        cs.idStudent,
        cs.idCourse,
        a.nameAssign AS nameDeadline,       -- Tên deadline từ bảng Assignment
        'Assignment' AS Type,       -- Loại deadline là Assignment
        a.startDate AS startTime,           -- Thời gian bắt đầu
        a.endDate AS endTime                -- Thời gian kết thúc
    FROM CourseStudent cs
    LEFT JOIN Assignment a ON cs.idCourse = a.idCourse
    WHERE cs.idStudent = @studentId

    UNION ALL

    SELECT 
        cs.idStudent,
        cs.idCourse,
        t.nameTest AS nameDeadline,         -- Tên deadline từ bảng Test
        'Test' AS Type,             -- Loại deadline là Test
        t.startDate AS startTime,           -- Thời gian bắt đầu
        t.endDate AS endTime                -- Thời gian kết thúc
    FROM CourseStudent cs
    LEFT JOIN Test t ON cs.idCourse = t.idCourse
    WHERE cs.idStudent = @studentId;





