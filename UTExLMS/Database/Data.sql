﻿USE UTExLMS;

-- Bảng Roles
INSERT INTO Roles (idRole, roleName) VALUES
(1, 'Admin'),
(2, 'Lecturer'),
(3, 'Student');

-- Bảng Person
INSERT INTO Person (idPerson, email, birthday, gender, lastName, firstName, phoneNum, idRole, pass) VALUES
(1, 'admin@example.com', '1980-01-01', 'Male', 'Admin', 'System', '0123456789', 1, 'adminpass'),
(2, 'lecturer1@example.com', '1985-05-20', 'Female', 'Smith', 'Alice', '0987654321', 2, 'lecturerpass'),
(3, 'student1@example.com', '2000-11-15', 'Male', 'Brown', 'John', '0912345678', 3, 'studentpass');
-- Bảng Person
-- Bảng Person
INSERT INTO Person (idPerson, email, birthday, gender, lastName, firstName, phoneNum, idRole, pass)
VALUES 
    (4, 'alice.johnson@example.com', '2000-05-10', 'Female', 'Johnson', 'Alice', '1234567890', 3, 'password123'),
    (5, 'bob.smith@example.com', '1985-11-22', 'Male', 'Smith', 'Bob', '0987654322', 3, 'securepass456'), -- Sửa số điện thoại
    (6, 'carol.taylor@example.com', '1990-07-15', 'Female', 'Taylor', 'Carol', '1122334455', 3, 'mypassword789'),
    (7, 'david.brown@example.com', '1995-03-30', 'Male', 'Brown', 'David', '5566778899', 3, 'adminpass001');

-- Bảng Semester
INSERT INTO Semester (idSemester, nameSemester, startDate, endDate) VALUES
(1, 'Fall 2024', '2024-09-01', '2024-12-31'),
(2, 'Spring 2025', '2025-01-01', '2025-05-31');

select * from Semester
INSERT INTO Semester (idSemester, nameSemester, startDate, endDate) VALUES
(3, 'Fall 2024', '2024-09-01', '2024-9-20');
-- Bảng Subjects
INSERT INTO Subjects (idSubject, nameSubject, idSemester) VALUES
(1, 'Math 101', 1),
(2, 'Computer Science 101', 1);
INSERT INTO Subjects (idSubject, nameSubject, idSemester) VALUES
(3, 'Math 101', 3);
-- Bảng Course
INSERT INTO Course (idCourse, nameCourse, idSubject, idLecturer, imgCourse) VALUES
(1, 'Math 101 - Fall 2024', 1, 2, 'math101.jpg'),
(2, 'CS101 - Fall 2024', 2, 2, 'cs101.jpg');
INSERT INTO Course (idCourse, nameCourse, idSubject, idLecturer, imgCourse) VALUES
(3, 'Math 1 - Fall 2024', 1, 2, 'math101.jpg'),
(4, 'Math 12 - Fall 2024', 1, 2, 'math101.jpg'),
(5, 'Math 14- Fall 2024', 1, 2, 'math101.jpg'),
(6, 'Math 13 - Fall 2024', 1, 2, 'math101.jpg'),
(7, 'Math 15 - Fall 2024', 1, 2, 'math101.jpg'),
(8, 'Math 106 - Fall 2024', 1, 2, 'math101.jpg'),
(9, 'Math 107 - Fall 2024', 1, 2, 'math101.jpg'),
(10, 'Math 108 - Fall 2024', 1, 2, 'math101.jpg');


INSERT INTO Course (idCourse, nameCourse, idSubject, idLecturer, imgCourse) VALUES
(11, 'Math 1 - Fall 2024', 3, 2, 'math101.jpg'),
(12, 'Math 12 - Fall 2024', 3, 2, 'math101.jpg'),
(13, 'Math 14- Fall 2024', 3, 2, 'math101.jpg');
-- Bảng Section
INSERT INTO Section (idSection, idCourse, nameSection, descript) VALUES
(1, 1, 'Introduction to Algebra', 'Basic algebraic concepts'),
(2, 2, 'Introduction to Programming', 'Introduction to Python programming');

INSERT INTO Section (idSection, idCourse, nameSection, descript) VALUES
(3, 1, 'Introduction to Programming111111111111', 'Introduction to Python programming'),
(4, 1, 'Introduction to Programming2222222222', 'Introduction to Python programming'),
(5, 1, 'Introduction to Programming333333333', 'Introduction to Python programming'),
(6, 1, 'Introduction to Programming444444444', 'Introduction to Python programming'),
(7, 1, 'Introduction to Programming555555555', 'Introduction to Python programming'),
(8, 1, 'Introduction to Programming6666666', 'Introduction to Python programming');




-- Bảng Element

INSERT INTO Element (idElement, idCourse, idSection, nameType) VALUES
(144, 1, 1, 'Assignment'),
(164, 1, 1, 'Assignment');

select *from Element
INSERT INTO Element (idElement, idCourse, idSection, nameType) VALUES
(1, 1, 1, 'Material'),
(2, 1, 1, 'Material');
INSERT INTO Element (idElement, idCourse, idSection, nameType) VALUES
(1, 2, 2, 'Material'),
(2, 2, 2, 'Material');

INSERT INTO Element (idElement, idCourse, idSection, nameType) VALUES
(8, 1, 3, 'Material'),
(7, 1, 3, 'Material');

INSERT INTO Element (idElement, idCourse, idSection, nameType) VALUES
(3, 1, 1, 'Test'),
(4, 1, 1, 'Test');

INSERT INTO Element (idElement, idCourse, idSection, nameType) VALUES
(5, 1, 1, 'Assignment');

INSERT INTO Element (idElement, idCourse, idSection, nameType) VALUES
(21, 1, 1, 'Assignment'),
(24, 1, 1, 'Assignment');
-- Bảng Material
INSERT INTO Material (idMaterial, filePath, statu, nameMaterial, typeMaterial, idSection, idCourse) VALUES
(1, '/materials/algebra.pdf', 1, 'Algebra Basics', 'PDF', 1, 1),
(2, '/materials/python_intro.pdf', 1, 'Python Intro', 'PDF', 1, 1);
INSERT INTO Material (idMaterial, filePath, statu, nameMaterial, typeMaterial, idSection, idCourse) VALUES
(7, '/materials/algebra.pdf', 1, 'Algebra Basics', 'PDF', 3, 1),
(8, '/materials/python_intro.pdf', 1, 'Python Intro', 'PDF', 3, 1);
-- Bảng Test
INSERT INTO Test (idTest, nameTest, statu, startDate, endDate, timeLimit, descript, idSection, idCourse) VALUES
(3, 'Algebra Test', 1, '2024-09-10', '2024-09-11', 60, 'Basic algebra test', 1, 1),
(4, 'Python Test', 0, '2024-09-20', '2024-09-21', 90, 'Intro to Python test', 1, 1);

-- Bảng Question
INSERT INTO Question (idQues, nameQues, A, B, C, D, trueAns, idTest, idSection, idCourse) VALUES
(1, 'What is 2+2?', '3', '4', '5', '6', 'B', 3, 1, 1),
(2, 'What is the capital of France?', 'Berlin', 'Madrid', 'Paris', 'Rome', 'C', 3, 1, 1);

-- Bảng StudentAns
INSERT INTO StudentAns (idPerson, ans, isTrue, idQues, idTest, idSection, idCourse) VALUES
(3, 'B', 1, 1, 3, 1, 1),
(3, 'C', 1, 2, 3, 1, 1);

select * from Assignment
-- Bảng Assignment
INSERT INTO Assignment (idAssign, nameAssign, statu, startDate, endDate, descript, grade, idSection, idCourse) VALUES
(144, 'Algebra Homework', 1, '2024-09-01', '2024-09-05', 'Solve basic algebra problems', NULL, 1, 1),
(164, 'Python Project', 0, '2024-09-10', '2024-09-15', 'Introductory Python project', NULL, 1, 1);

INSERT INTO Assignment (idAssign, nameAssign, statu, startDate, endDate, descript, grade, idSection, idCourse) VALUES
(15, 'Algebra Homework', 1, '2024-09-01', '2024-09-05', 'Solve basic algebra problems', NULL, 1, 1),
(16, 'Python Project', 0, '2024-09-10', '2024-09-15', 'Introductory Python project', NULL, 1, 1);
INSERT INTO Assignment (idAssign, nameAssign, statu, startDate, endDate, descript, grade, idSection, idCourse) VALUES
(21, 'Algebra Homework', 1, '2024-09-01', '2024-09-05', 'Solve basic algebra problems', NULL, 1, 1),
(24, 'Python Project', 0, '2024-09-10', '2024-09-15', 'Introductory Python project', NULL, 1, 1);

-- Bảng StudentTest
INSERT INTO StudentTest (idStudent, idCourse, idSection, idTest, totalScore) VALUES
(3, 1, 1, 3, 95.0),
(3, 1, 1, 4, 88.0);

--chưa làm tới đây
-- Bảng StudentAssignment
INSERT INTO StudentAssignment (nameFile, pathFile, typeFile, dateSubmit, idCourse, idSection, idAssign, idStudent) VALUES
('homework1.pdf', '/submissions/algebra_homework1.pdf', 'PDF', '2024-09-04', 1, 1, 1, 3);
('project1.zip', '/submissions/python_project1.zip', 'ZIP', '2024-09-14', 2, 2, 2, 3);


-- Bảng Discussion
INSERT INTO Discussion (idDiscuss, descript, nameDiscuss, idSection, idCourse) VALUES
(1, 'Discuss Algebra topics', 'Algebra Discussion', 1, 1),
(2, 'Discuss Python concepts', 'Python Discussion', 2, 2);

-- Bảng Comment
INSERT INTO Comment (idCmt, content, commentDate, idCourse, idSection, idDiscuss, idPerson) VALUES
(1, 'This is a great topic!', '2024-09-02 10:00:00', 1, 1, 1, 3),
(2, 'I love Python!', '2024-09-15 15:30:00', 2, 2, 2, 3);

-- Bảng CourseStudent
INSERT INTO CourseStudent (idStudent, idCourse, progress) VALUES
(3, 1, 75.0),
(3, 2, 85.0);
INSERT INTO CourseStudent (idStudent, idCourse, progress) VALUES
(3, 3, 75.0),
(3, 4, 75.0),
(3, 5, 75.0),
(3, 6, 75.0),
(3, 7, 75.0),
(3, 10, 75.0),
(3, 8, 75.0),
(3, 9, 85.0);

INSERT INTO CourseStudent (idStudent, idCourse, progress) VALUES
(3, 11, 75.0),
(3, 12, 75.0),
(3, 13, 75.0);

-- Bảng Studied
INSERT INTO Studied (idPerson, idCourse, idSection, idElement) VALUES
(3, 1, 1, 1),
(3, 2, 2, 2);

-- Bảng CourseLecturer
INSERT INTO CourseLecturer (idLecturer, idCourse) VALUES
(2, 1),
(2, 2);


INSERT INTO Element (idElement, idCourse, idSection, nameType) VALUES
(7, 1, 1, 'Discussion');
INSERT INTO Element (idElement, idCourse, idSection, nameType) VALUES
(8, 1, 1, 'Discussion');


-- Bảng Discussion
INSERT INTO Discussion (idDiscuss, descript, nameDiscuss, idSection, idCourse)
VALUES 
    (7, 'Discussion about the lecture on algebra', 'Algebra Discussion', 1, 1),
    (8, 'Discussion about the lab experiment on optics', 'Optics Lab Discussion', 1, 1);

	select * from Discussion

-- Bảng Comment
INSERT INTO Comment (idCmt, content, commentDate, idCourse, idSection, idDiscuss, idPerson)
VALUES 
    (1, 'I really enjoyed this algebra discussion.', '2024-11-14 10:30:00', 1, 1, 7, 4),
    (2, 'The lab on optics was very informative.', '2024-11-14 11:00:00', 1, 1, 7, 5),
    (3, 'Great insights on organic chemistry reactions.', '2024-11-14 12:15:00', 1, 1, 8, 3),
    (4, 'I loved the biology workshop, it was very interactive.', '2024-11-14 13:45:00', 1, 1, 8, 4);


	select * from Comment