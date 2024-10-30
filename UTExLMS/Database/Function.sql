USE UTExLMS


drop function GetStudentCoursesByStatus

--CREATE FUNCTION GetStudentCoursesByStatus (
--    @studentId INT,
--    @status VARCHAR(20)
--)
--RETURNS TABLE
--AS
--RETURN (
--    SELECT 
--        s.idStudent,
--        c.idClass,
--		s.firstName,
--		s.lastName,
--        c.nameClass,
--        sem.startDate,
--        sem.endDate,
--		cs.progress,
--		c.imgClass
--    FROM 
--        ClassStudent cs
--        JOIN Class c ON cs.idClass = c.idClass
--        JOIN Subjects sub ON c.idSubject = sub.idSubject
--        JOIN Semester sem ON sub.idSemester = sem.idSemester
--        JOIN Student s ON cs.idStudent = s.idStudent
--    WHERE 
--        s.idStudent = @studentId
--        AND (
--            @status = 'All' 
--            OR (@status = 'Past' AND GETDATE() > sem.endDate)
--            OR (@status = 'In Progress' AND GETDATE() BETWEEN sem.startDate AND sem.endDate)
--        )
--);





--SELECT * FROM GetStudentCoursesByStatus(1, 'Past');

--SELECT * FROM GetStudentCoursesByStatus(1, 'All');
--SELECT * FROM GetStudentCoursesByStatus(1, 'In Progress');

DROP FUNCTION IF EXISTS GetStudentCoursesByStatus;

CREATE FUNCTION GetStudentCoursesByStatus (
    @studentId INT,
    @status VARCHAR(20),
    @searchTerm NVARCHAR(100)  -- Thêm tham số search term
)
RETURNS TABLE
AS
RETURN (
    SELECT 
        s.idStudent,
        c.idClass,
        s.firstName,
        s.lastName,
        c.nameClass,
        sem.startDate,
        sem.endDate,
        cs.progress,
        c.imgClass
    FROM 
        ClassStudent cs
        JOIN Class c ON cs.idClass = c.idClass
        JOIN Subjects sub ON c.idSubject = sub.idSubject  -- Liên kết bảng Subjects bằng idSubject
        JOIN Semester sem ON sub.idSemester = sem.idSemester
        JOIN Student s ON cs.idStudent = s.idStudent
    WHERE 
        s.idStudent = @studentId
        AND (
            @status = 'All' 
            OR (@status = 'Past' AND GETDATE() > sem.endDate)
            OR (@status = 'In Progress' AND GETDATE() BETWEEN sem.startDate AND sem.endDate)
        )
        AND (
            @searchTerm IS NULL
            OR c.nameClass LIKE '%' + @searchTerm + '%'
        )
);

SELECT * FROM GetStudentCoursesByStatus(1, 'All', 'c');
SELECT * FROM GetStudentCoursesByStatus(1, 'All', NULL);




CREATE PROCEDURE UpdateLecturerInfo
    @IdLecturer INT,
    @FirstName NVARCHAR(50),  -- Cập nhật kích thước để phù hợp với bảng
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @Birthday DATE,
    @Gender NVARCHAR(10),
    @PhoneNum NVARCHAR(15),
    @pass NVARCHAR(15)  -- Cập nhật kích thước để phù hợp với bảng
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Lecturer
    SET FirstName = @FirstName,
        LastName = @LastName,
        Email = @Email,
        Birthday = @Birthday,
        Gender = @Gender,
        PhoneNum = @PhoneNum,
        pass = @pass  -- Nên mã hóa trước khi lưu
    WHERE idLecturer = @IdLecturer;  -- Sử dụng tham số đúng
END