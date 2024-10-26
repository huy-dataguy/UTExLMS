create database UTExLMS

use UTExLMS;


CREATE TABLE Role (
    idRole INT PRIMARY KEY,
    nameRole VARCHAR(100)
);

CREATE TABLE Student (
    idStudent INT PRIMARY KEY,
    email VARCHAR(100),
    birthday DATE,
    gender VARCHAR(10),
    lastName VARCHAR(50),
    firstName VARCHAR(50),
    phoneNum VARCHAR(15),
    idRole INT,
    password VARCHAR(15),  
    FOREIGN KEY (idRole) REFERENCES Role(idRole)
);


CREATE TABLE Lecturer (
    idLecturer INT PRIMARY KEY,
    email VARCHAR(100),
    birthday DATE,
    gender VARCHAR(10),
    lastName VARCHAR(50),
    firstName VARCHAR(50),
    phoneNum VARCHAR(15),
    idRole INT,
    password VARCHAR(15),  
    FOREIGN KEY (idRole) REFERENCES Role(idRole)
);


CREATE TABLE Semester (
    idSemester INT PRIMARY KEY,
    nameSemester VARCHAR(100),
    startDate DATE,
    endDate DATE
);


CREATE TABLE Subject (
    idSubject INT PRIMARY KEY,
    nameSubject VARCHAR(100),
    idSemester INT,  
    FOREIGN KEY (idSemester) REFERENCES Semester(idSemester)
);

--2. Bảng Class, Student 1-n



CREATE TABLE Class (
    idClass INT PRIMARY KEY,
    nameClass VARCHAR(100),
    progress FLOAT,
    idSubject INT,
    idLecturer INT,  
    img VARCHAR(255),  -- URL or file path to the image
    FOREIGN KEY (idSubject) REFERENCES Subject(idSubject),
    FOREIGN KEY (idLecturer) REFERENCES Lecturer(idLecturer)
);

CREATE TABLE StudentClass (
    idStudent INT,
    idClass INT,
    PRIMARY KEY (idStudent, idClass),
    FOREIGN KEY (idStudent) REFERENCES Student(idStudent),
    FOREIGN KEY (idClass) REFERENCES Class(idClass)
);

--5. Bảng Section và Material (1-n)
CREATE TABLE Section (
    idSection INT PRIMARY KEY,
    nameSection VARCHAR(100),
    description VARCHAR(255),
    idClass INT,
    idLecturer INT,  -- Thêm thuộc tính idLecturer ở đây
    FOREIGN KEY (idClass) REFERENCES Class(idClass),
    FOREIGN KEY (idLecturer) REFERENCES Lecturer(idLecturer)  -- Khóa ngoại cho Lecturer
);

--Thế thì biết ở Class nào? có thể truy vấn thông qua idSection, nhưng idSection...
CREATE TABLE Material (
    idMaterial INT PRIMARY KEY,
    filePath VARCHAR(255),
    nameMaterial VARCHAR(100),
    typeMaterial VARCHAR(50),
    idSection INT,
    idLecturer INT,  -- Thêm thuộc tính idLecturer ở đây
    FOREIGN KEY (idSection) REFERENCES Section(idSection),
    FOREIGN KEY (idLecturer) REFERENCES Lecturer(idLecturer)  -- Khóa ngoại cho Lecturer
);

CREATE TABLE Test (
    idTest INT PRIMARY KEY,
    nameTest VARCHAR(100),
    startDate DATE,
    endDate DATE,
    timeLimit INT,
    status VARCHAR(20),
    description VARCHAR(255),
    idSection INT,
    idLecturer INT,  -- Thêm thuộc tính idLecturer ở đây
    FOREIGN KEY (idSection) REFERENCES Section(idSection),
    FOREIGN KEY (idLecturer) REFERENCES Lecturer(idLecturer)  -- Khóa ngoại cho Lecturer
);


CREATE TABLE Question (
    idQues INT PRIMARY KEY,
    nameQues VARCHAR(255),
    A VARCHAR(255),
	B VARCHAR(255),
	C VARCHAR(255),
	D VARCHAR(255),
    trueAns VARCHAR(1),
    idTest INT,
    FOREIGN KEY (idTest) REFERENCES Test(idTest)
);

--7. Bảng StudentAns, Student, Question (1-n, 1-1)


CREATE TABLE StudentAns (
    idAns INT PRIMARY KEY,
    studentAns VARCHAR(1),
    idStudent INT,
    idQues INT,
    FOREIGN KEY (idStudent) REFERENCES Student(idStudent),
    FOREIGN KEY (idQues) REFERENCES Question(idQues)
);


--8. Bảng Assignment, Submission, và quan hệ n-n giữa Assignment và Student
CREATE TABLE Assignment (
    idAssign INT PRIMARY KEY,
    nameAssign VARCHAR(100),
    startDate DATE,
    endDate DATE,
    description VARCHAR(255),
    grade FLOAT,
    idSection INT,
    idLecturer INT,  -- Thêm thuộc tính idLecturer ở đây
    FOREIGN KEY (idSection) REFERENCES Section(idSection),
    FOREIGN KEY (idLecturer) REFERENCES Lecturer(idLecturer)  -- Khóa ngoại cho Lecturer
);


CREATE TABLE AssignmentStudent (
    idAssign INT,
    idStudent INT,
    numAttempts INT,
    totalScore FLOAT,
    totalTimeSpent INT,
    PRIMARY KEY (idAssign, idStudent),
    FOREIGN KEY (idAssign) REFERENCES Assignment(idAssign),
    FOREIGN KEY (idStudent) REFERENCES Student(idStudent)
);



CREATE TABLE Submission (
    idSubmiss INT PRIMARY KEY,
    nameFile VARCHAR(100),
    pathFile VARCHAR(255),
    typeFile VARCHAR(50),
    dateSubmit DATE,
    idAssign INT,
    idStudent INT,
    FOREIGN KEY (idAssign) REFERENCES Assignment(idAssign),
    FOREIGN KEY (idStudent) REFERENCES Student(idStudent)
);

--9. Bảng Discussion, Comment, và quan hệ n-n với Student
CREATE TABLE Discussion (
    idDiscuss INT PRIMARY KEY,
    description VARCHAR(255),
    nameDiscuss VARCHAR(100),
    idSection INT,
    idLecturer INT,  -- Thêm thuộc tính idLecturer ở đây
    FOREIGN KEY (idSection) REFERENCES Section(idSection),
    FOREIGN KEY (idLecturer) REFERENCES Lecturer(idLecturer)  -- Khóa ngoại cho Lecturer
);

CREATE TABLE Comment (
    idCmt INT PRIMARY KEY,
    content VARCHAR(255),
    idDiscuss INT,
    idStudent INT, 
    idLecturer INT,  -- Thêm thuộc tính idLecturer ở đây
    FOREIGN KEY (idDiscuss) REFERENCES Discussion(idDiscuss),
    FOREIGN KEY (idStudent) REFERENCES Student(idStudent),
    FOREIGN KEY (idLecturer) REFERENCES Lecturer(idLecturer)  -- Khóa ngoại cho Lecturer
);

--10. Bảng Lecturer và quan hệ 1-n với nhiều thực thể

--Contraints

ALTER TABLE Student ADD CONSTRAINT UC_StudentEmail UNIQUE (email);
ALTER TABLE Lecturer ADD CONSTRAINT UC_LecturerEmail UNIQUE (email);
ALTER TABLE Student ADD CONSTRAINT UC_StudentPhone UNIQUE (phoneNum);
ALTER TABLE Lecturer ADD CONSTRAINT UC_LecturerPhone UNIQUE (phoneNum);


ALTER TABLE Student ADD CONSTRAINT CK_StudentGender CHECK (gender IN ('Male', 'Female', 'Other'));
ALTER TABLE Lecturer ADD CONSTRAINT CK_LecturerGender CHECK (gender IN ('Male', 'Female', 'Other'));
ALTER TABLE Test ADD CONSTRAINT CK_TestStatus CHECK (status IN ('Open', 'Closed'));
ALTER TABLE Material ADD CONSTRAINT CK_MaterialType CHECK (typeMaterial IN ('pdf', 'doc', 'image', 'link'));

--View
--Danh sách khóa học của sinh viên:

--Danh sách bài kiểm tra theo tuần, tháng:

CREATE VIEW vw_StudentTests AS
SELECT s.idStudent, s.firstName, s.lastName, t.nameTest, t.startDate, t.endDate
FROM Student s
JOIN Class c ON s.idStudent = c.idStudent
JOIN Section sec ON c.idClass = sec.idClass
JOIN Test t ON sec.idSection = t.idSection
WHERE t.startDate >= GETDATE() AND t.endDate <= DATEADD(week, 1, GETDATE());  -- Lọc bài kiểm tra theo tuần

--ds khóa học
CREATE VIEW vw_StudentCourses AS
SELECT 
    s.idStudent, 
    s.firstName, 
    s.lastName, 
    c.nameClass, 
    c.progress, 
	c.img,
    sem.startDate,          
    sem.endDate            
FROM 
    Student s
JOIN 
    Class c ON s.idStudent = c.idStudent
JOIN 
    Subject sub ON c.idSubject = sub.idSubject
JOIN 
    Semester sem ON sub.idSemester = sem.idSemester; 




--Function
--Tính điểm trung bình của sinh viên
CREATE FUNCTION fn_CalculateAvgGrade(@idStudent INT)
RETURNS FLOAT
AS
BEGIN
    DECLARE @avgGrade FLOAT;
    SELECT @avgGrade = AVG(totalScore) FROM Assignment_Student WHERE idStudent = @idStudent;
    RETURN @avgGrade;
END;

--Procedure
--thêm sinh viên vô lớp
CREATE PROCEDURE sp_AddStudentToClass
    @idStudent INT,
    @idClass INT
AS
BEGIN
    INSERT INTO Class (idStudent, idClass)
    VALUES (@idStudent, @idClass);
END;

CREATE TRIGGER trg_UpdateTestStatus
ON Test
AFTER UPDATE
AS
BEGIN
    UPDATE Test
    SET status = 'Closed'
    FROM Test t
    INNER JOIN inserted i ON t.idTest = i.idTest
    WHERE GETDATE() > i.endDate;
END;




CREATE PROCEDURE UpdateLecturerInfo
    @IdLecturer INT,
    @FirstName NVARCHAR(50),  -- Cập nhật kích thước để phù hợp với bảng
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @Birthday DATE,
    @Gender NVARCHAR(10),
    @PhoneNum NVARCHAR(15),
    @Password NVARCHAR(15)  -- Cập nhật kích thước để phù hợp với bảng
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
        Password = @Password  -- Nên mã hóa trước khi lưu
    WHERE idLecturer = @IdLecturer;  -- Sử dụng tham số đúng
END


