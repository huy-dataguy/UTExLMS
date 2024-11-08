CREATE DATABASE UTExLMS;
USE UTExLMS;

-- Table Roles
CREATE TABLE Roles (
    idRole INT PRIMARY KEY,
    roleName VARCHAR(50)
);

-- Table Person
CREATE TABLE Person (
    idPerson INT PRIMARY KEY,
    email VARCHAR(100) UNIQUE,
    birthday DATE,
    gender VARCHAR(10),
    lastName VARCHAR(50),
    firstName VARCHAR(50),
    phoneNum VARCHAR(15) UNIQUE,
    idRole INT,
    pass VARCHAR(50),
    CHECK (gender IN ('Male', 'Female', 'Other')),
    FOREIGN KEY (idRole) REFERENCES Roles(idRole) 
        ON DELETE CASCADE 
        ON UPDATE CASCADE
);

-- Table Semester
CREATE TABLE Semester (
    idSemester INT PRIMARY KEY,
    nameSemester VARCHAR(100),
    startDate DATE,
    endDate DATE
);

-- Table Subjects
CREATE TABLE Subjects (
    idSubject INT PRIMARY KEY,
    nameSubject VARCHAR(100),
    idSemester INT,
    FOREIGN KEY (idSemester) REFERENCES Semester(idSemester)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

-- Table Course
CREATE TABLE Course (
    idCourse INT PRIMARY KEY,
    nameCourse VARCHAR(100),
    idSubject INT,
    idLecturer INT,
    imgCourse VARCHAR(255),
    FOREIGN KEY (idSubject) REFERENCES Subjects(idSubject)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (idLecturer) REFERENCES Person(idPerson)
        ON DELETE SET NULL 
        ON UPDATE CASCADE
);

-- Table Section
CREATE TABLE Section (
    idSection INT,
    idCourse INT,
    nameSection VARCHAR(100),
    descript VARCHAR(255),
    PRIMARY KEY (idCourse, idSection),
    FOREIGN KEY (idCourse) REFERENCES Course(idCourse)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

-- Table Element
CREATE TABLE Element (
    idElement INT,
    idCourse INT,
    idSection INT,
    PRIMARY KEY (idElement, idCourse, idSection),
    FOREIGN KEY (idCourse, idSection) REFERENCES Section(idCourse, idSection)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

-- Table Material
CREATE TABLE Material (
    idMaterial INT,
    filePath VARCHAR(255),
    statu BIT DEFAULT 0,
    nameMaterial VARCHAR(100),
    typeMaterial VARCHAR(50),
    idSection INT,
    idCourse INT,
    PRIMARY KEY (idMaterial, idCourse, idSection),
    FOREIGN KEY (idMaterial, idCourse, idSection) REFERENCES Element(idElement, idCourse, idSection)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);


-- Table Test
CREATE TABLE Test (
    idTest INT,
    nameTest VARCHAR(100),
    statu BIT DEFAULT 0,
    startDate DATE,
    endDate DATE,
    timeLimit INT,
    descript VARCHAR(255),
    idSection INT,
    idCourse INT,
    PRIMARY KEY (idTest, idCourse, idSection),
    FOREIGN KEY (idTest, idCourse, idSection) REFERENCES Element(idElement, idCourse, idSection)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

-- Table Question
CREATE TABLE Question (
    idQues INT,
    nameQues VARCHAR(255),
    A VARCHAR(255),
    B VARCHAR(255),
    C VARCHAR(255),
    D VARCHAR(255),
    trueAns VARCHAR(1),
    idTest INT,
    idSection INT,
    idCourse INT,
    PRIMARY KEY (idQues, idTest, idCourse, idSection),
    FOREIGN KEY (idTest, idCourse, idSection) REFERENCES Test(idTest, idCourse, idSection)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

-- Table StudentAns
CREATE TABLE StudentAns (
    idPerson INT,
    ans VARCHAR(1),
    isTrue BIT DEFAULT 0,
    idQues INT,
    idTest INT,
    idSection INT,
    idCourse INT,
    PRIMARY KEY (idPerson, idCourse, idSection, idTest, idQues),
    FOREIGN KEY (idPerson) REFERENCES Person(idPerson)
        ON DELETE NO Action
        ON UPDATE NO Action,
    FOREIGN KEY (idQues, idTest,idCourse, idSection ) REFERENCES Question( idQues,idTest, idCourse, idSection)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

-- Table Assignment
CREATE TABLE Assignment (
    idAssign INT,
    nameAssign VARCHAR(100),
    statu BIT DEFAULT 0,
    startDate DATE,
    endDate DATE,
    descript VARCHAR(255),
    grade FLOAT,
    idSection INT,
    idCourse INT,
    PRIMARY KEY (idCourse, idSection, idAssign),
    FOREIGN KEY (idCourse, idSection) REFERENCES Section(idCourse, idSection)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

-- Table StudentTest
CREATE TABLE StudentTest (
    idStudent INT,
    idCourse INT,
    idSection INT,
    idTest INT,
    totalScore FLOAT,
    PRIMARY KEY (idStudent, idCourse, idSection, idTest),
    FOREIGN KEY (idTest,idCourse, idSection) REFERENCES Test(idTest, idCourse, idSection)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (idStudent) REFERENCES Person(idPerson)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION
);

-- Table StudentAssignment
CREATE TABLE StudentAssignment (
    nameFile VARCHAR(100),
    pathFile VARCHAR(255),
    typeFile VARCHAR(50),
    dateSubmit DATE,
    idCourse INT,
    idSection INT,
    idAssign INT,
    idStudent INT,
    PRIMARY KEY (idStudent, idCourse, idSection, idAssign),
    FOREIGN KEY (idCourse, idSection, idAssign) REFERENCES Assignment(idCourse, idSection, idAssign)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (idStudent) REFERENCES Person(idPerson)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION
);

-- Table Discussion
CREATE TABLE Discussion (
    idDiscuss INT,
    descript VARCHAR(255),
    nameDiscuss VARCHAR(100),
    idSection INT,
    idCourse INT,
    PRIMARY KEY (idCourse, idSection, idDiscuss),
    FOREIGN KEY (idCourse, idSection) REFERENCES Section(idCourse, idSection)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

-- Table Comment
CREATE TABLE Comment (
    idCmt INT,
    content VARCHAR(255),
    commentDate DATETIME,
    idCourse INT,
    idSection INT,
    idDiscuss INT,
    idPerson INT,
    PRIMARY KEY (idCmt),
    FOREIGN KEY (idCourse, idSection, idDiscuss) REFERENCES Discussion(idCourse, idSection, idDiscuss)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    FOREIGN KEY (idPerson) REFERENCES Person(idPerson)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);



-- Table CourseStudent
CREATE TABLE CourseStudent (
    idStudent INT,
    idCourse INT,
    progress FLOAT,
    PRIMARY KEY (idStudent, idCourse),
    FOREIGN KEY (idStudent) REFERENCES Person(idPerson)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    FOREIGN KEY (idCourse) REFERENCES Course(idCourse)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

-- Table Studied
CREATE TABLE Studied (
    idPerson INT,
    idCourse INT,
    idSection INT,
    idElement INT,
    PRIMARY KEY (idPerson, idCourse, idSection, idElement),
    FOREIGN KEY (idPerson) REFERENCES Person(idPerson)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    FOREIGN KEY (idElement,idCourse, idSection) REFERENCES Element(idElement,idCourse, idSection)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

-- Table CourseLecturer
Create TABLE CourseLecturer (
    idLecturer INT,
    idCourse INT,
    PRIMARY KEY (idLecturer, idCourse),
    FOREIGN KEY (idLecturer) REFERENCES Person(idPerson)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    FOREIGN KEY (idCourse) REFERENCES Course(idCourse)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);
