Create Database UTExLMS

USE UTExLMS;


-- Bảng Roles
CREATE TABLE Roles (
    idRole INT PRIMARY KEY,
    nameRole VARCHAR(100)
);

-- Bảng Student
CREATE TABLE Student (
    idStudent INT PRIMARY KEY,
    email VARCHAR(100) UNIQUE,
    birthday DATE,
    gender VARCHAR(10),
    lastName VARCHAR(50),
    firstName VARCHAR(50),
    phoneNum VARCHAR(15) UNIQUE,
    idRole INT,
    pass VARCHAR(15),
    FOREIGN KEY (idRole) REFERENCES Roles(idRole),
    CHECK (gender IN ('Male', 'Female', 'Other'))
);

-- Bảng Lecturer
CREATE TABLE Lecturer (
    idLecturer INT PRIMARY KEY,
    email VARCHAR(100) UNIQUE,
    birthday DATE,
    gender VARCHAR(10),
    lastName VARCHAR(50),
    firstName VARCHAR(50),
    phoneNum VARCHAR(15) UNIQUE,
    idRole INT,
    pass VARCHAR(255),
    FOREIGN KEY (idRole) REFERENCES Roles(idRole),
    CHECK (gender IN ('Male', 'Female', 'Other'))
);

-- Bảng Semester
CREATE TABLE Semester (
    idSemester INT PRIMARY KEY,
    nameSemester VARCHAR(100),
    startDate DATE,
    endDate DATE
);

-- Bảng Subjects
CREATE TABLE Subjects (
    idSubject INT PRIMARY KEY,
    nameSubject VARCHAR(100),
    idSemester INT,
    FOREIGN KEY (idSemester) REFERENCES Semester(idSemester)
);

-- Bảng Course
CREATE TABLE Course (
    idCourse INT PRIMARY KEY,
    nameCourse VARCHAR(100),
    idSubject INT,
    idLecturer INT,
    imgCourse VARCHAR(255),
    FOREIGN KEY (idSubject) REFERENCES Subjects(idSubject),
    FOREIGN KEY (idLecturer) REFERENCES Lecturer(idLecturer)
);

-- Bảng Section
CREATE TABLE Section (
    idSection INT,
    idCourse INT,
    nameSection VARCHAR(100),
    descript VARCHAR(255),
    PRIMARY KEY (idSection, idCourse),
    FOREIGN KEY (idCourse) REFERENCES Course(idCourse)
);

-- Bảng Material
CREATE TABLE Material (
    idMaterial INT PRIMARY KEY,
    filePath VARCHAR(255),
    statu BIT DEFAULT 0,
    nameMaterial VARCHAR(100),
    typeMaterial VARCHAR(50),
    idSection INT,
    idCourse INT,
    FOREIGN KEY (idSection, idCourse) REFERENCES Section(idSection, idCourse)
);

-- Bảng Test
CREATE TABLE Test (
    idTest INT PRIMARY KEY,
    nameTest VARCHAR(100),
    statu BIT DEFAULT 0,
    startDate DATE,
    endDate DATE,
    timeLimit INT,
    descript VARCHAR(255),
    idSection INT,
    idCourse INT,
    FOREIGN KEY (idSection, idCourse) REFERENCES Section(idSection, idCourse)
);

-- Bảng Question
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

-- Bảng StudentAns
CREATE TABLE StudentAns (
    idAns INT PRIMARY KEY,
    studentAns VARCHAR(1),
    idStudent INT,
    idQues INT,
    FOREIGN KEY (idStudent) REFERENCES Student(idStudent),
    FOREIGN KEY (idQues) REFERENCES Question(idQues)
);

-- Bảng Assignment
CREATE TABLE Assignment (
    idAssign INT PRIMARY KEY,
    nameAssign VARCHAR(100),
    statu BIT DEFAULT 0,
    startDate DATE,
    endDate DATE,
    descript VARCHAR(255),
    grade FLOAT,
    idSection INT,
    idCourse INT,
    FOREIGN KEY (idSection, idCourse) REFERENCES Section(idSection, idCourse)
);

-- Bảng AssignmentStudent
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

-- Bảng Submission
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

-- Bảng Discussion
CREATE TABLE Discussion (
    idDiscuss INT PRIMARY KEY,
    descript VARCHAR(255),
    nameDiscuss VARCHAR(100),
    idSection INT,
    idCourse INT,
    FOREIGN KEY (idSection, idCourse) REFERENCES Section(idSection, idCourse)
);

-- Bảng Comment
CREATE TABLE Comment (
    idCmt INT PRIMARY KEY,
    content VARCHAR(255),
    idDiscuss INT,
    idStudent INT,
    idLecturer INT,
    FOREIGN KEY (idDiscuss) REFERENCES Discussion(idDiscuss),
    FOREIGN KEY (idStudent) REFERENCES Student(idStudent),
    FOREIGN KEY (idLecturer) REFERENCES Lecturer(idLecturer)
);

-- Bảng CourseStudent
CREATE TABLE CourseStudent (
    idStudent INT,
    idCourse INT,
    progress FLOAT,
    PRIMARY KEY (idStudent, idCourse),
    FOREIGN KEY (idStudent) REFERENCES Student(idStudent),
    FOREIGN KEY (idCourse) REFERENCES Course(idCourse)
);
