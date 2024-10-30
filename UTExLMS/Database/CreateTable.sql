create database UTExLMS

use UTExLMS;



CREATE TABLE Roles (
    idRole INT PRIMARY KEY,
    nameRole VARCHAR(100)
);

CREATE TABLE Student (
    idStudent INT PRIMARY KEY,
    email VARCHAR(100) UNIQUE,
    birthday DATE,
    gender VARCHAR(10),
    lastName VARCHAR(50),
    firstName VARCHAR(50),
    phoneNum VARCHAR(15) UNIQUE,
    idRole INT,

    pass VARCHAR(15),  -- Thêm cột pass ở đây
    FOREIGN KEY (idRole) REFERENCES Roles(idRole),
	CHECK (gender IN ('Male', 'Female', 'Other'))
);
CREATE TABLE Lecturer (
    idLecturer INT PRIMARY KEY,
    email VARCHAR(100) UNIQUE,
    birthday DATE,
    gender VARCHAR(10),
    lastName VARCHAR(50),
    firstName VARCHAR(50),
    phoneNum VARCHAR(15) UNIQUE,
    idRole INT,

    pass VARCHAR(255),  -- Thêm cột pass ở đây với chiều dài 255 cho an toàn
    FOREIGN KEY (idRole) REFERENCES Roles(idRole),
	CHECK (gender IN ('Male', 'Female', 'Other'))
);


CREATE TABLE Semester (
    idSemester INT PRIMARY KEY,
    nameSemester VARCHAR(100),
    startDate DATE,
    endDate DATE
);


CREATE TABLE Subjects (
    idSubject INT PRIMARY KEY,
    nameSubject VARCHAR(100),
    idSemester INT,  
    FOREIGN KEY (idSemester) REFERENCES Semester(idSemester)
);

--2. Bảng Class, Student 1-n

CREATE TABLE Class (
    idClass INT PRIMARY KEY,
    nameClass VARCHAR(100),
    idSubject INT,
    idLecturer INT,  
    FOREIGN KEY (idSubject) REFERENCES Subjects(idSubject),  -- Khóa ngoại cho Subjects
    FOREIGN KEY (idLecturer) REFERENCES Lecturer(idLecturer)  -- Khóa ngoại cho Lecturer

);

ALTER TABLE Class
ADD imgClass VARCHAR(255); 





--5. Bảng Section và Material (1-n)
CREATE TABLE Section (
    idSection INT PRIMARY KEY,
    nameSection VARCHAR(100),
    descript VARCHAR(255),
    idClass INT,
    idLecturer INT,  -- Thêm thuộc tính idLecturer ở đây
    FOREIGN KEY (idClass) REFERENCES Class(idClass),
    FOREIGN KEY (idLecturer) REFERENCES Lecturer(idLecturer)  -- Khóa ngoại cho Lecturer
);

--Thế thì biết ở Class nào? có thể truy vấn thông qua idSection, nhưng idSection...
CREATE TABLE Material (
    idMaterial INT PRIMARY KEY,
    filePath VARCHAR(255),
	statu BIT default 0,
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
    statu BIT default 0,
	startDate DATE,
    endDate DATE,
    timeLimit INT,
    descript VARCHAR(255),
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
    statu BIT default 0,
	startDate DATE,
    endDate DATE,
    descript VARCHAR(255),
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
    descript VARCHAR(255),
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

CREATE TABLE ClassStudent (
    idStudent INT,
    idClass INT,
    progress FLOAT,
    PRIMARY KEY (idStudent, idClass),
    FOREIGN KEY (idStudent) REFERENCES Student(idStudent),
    FOREIGN KEY (idClass) REFERENCES Class(idClass)
);

--CREATE PROCEDURE UpdateLecturerInfo
--    @IdLecturer INT,
--    @FirstName NVARCHAR(50),  -- Cập nhật kích thước để phù hợp với bảng
--    @LastName NVARCHAR(50),
--    @Email NVARCHAR(100),
--    @Birthday DATE,
--    @Gender NVARCHAR(10),
--    @PhoneNum NVARCHAR(15),
--    @pass NVARCHAR(15)  -- Cập nhật kích thước để phù hợp với bảng
--AS
--BEGIN
--    SET NOCOUNT ON;

--    UPDATE Lecturer
--    SET FirstName = @FirstName,
--        LastName = @LastName,
--        Email = @Email,
--        Birthday = @Birthday,
--        Gender = @Gender,
--        PhoneNum = @PhoneNum,
--        pass = @pass  -- Nên mã hóa trước khi lưu
--    WHERE idLecturer = @IdLecturer;  -- Sử dụng tham số đúng
--END


