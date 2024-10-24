use UTExLMS;

INSERT INTO Role (idRole, nameRole) VALUES 
(1, 'Student'),
(2, 'Lecturer'),
(3, 'Admin');

-- Thêm sinh viên
INSERT INTO Student (idStudent, email, birthday, gender, lastName, firstName, phoneNum, idRole) VALUES 
(1, 'student1@example.com', '2001-01-15', 'Male', 'Nguyen', 'An', '0901123456', 1),
(2, 'student2@example.com', '2002-02-20', 'Female', 'Le', 'Binh', '0902987654', 1);

-- Thêm giảng viên
INSERT INTO Lecturer (idLecturer, email, birthday, gender, lastName, firstName, phoneNum, idRole) VALUES 
(1, 'lecturer1@example.com', '1980-03-10', 'Male', 'Tran', 'Cuong', '0903344556', 2),
(2, 'lecturer2@example.com', '1975-07-22', 'Female', 'Pham', 'Duyen', '0909876543', 2);

INSERT INTO Semester (idSemester, nameSemester, startDate, endDate) VALUES 
(1, 'Fall 2024', '2024-09-01', '2024-12-31'),
(2, 'Spring 2025', '2025-01-01', '2025-05-31');



INSERT INTO Subject (idSubject, nameSubject, idSemester) VALUES 
(1, 'Mathematics', 1),
(2, 'Physics', 1),
(3, 'Computer Science', 2);


INSERT INTO Class (idClass, nameClass, progress, idStudent, idSubject, idLecturer) VALUES 
(1, 'Math Class A', 0.75, 1, 1, 1),
(2, 'Physics Class B', 0.60, 1, 2, 1),
(3, 'Chemistry Class C', 0.80, 1, 2, 1),
(4, 'Biology Class D', 0.85, 1, 2, 1);


INSERT INTO Section (idSection, nameSection, description, idClass, idLecturer) VALUES 
(1, 'Chapter 1: Algebra', 'Introduction to Algebra', 1, 1),
(2, 'Chapter 2: Mechanics', 'Physics mechanics basics', 2, 2);

INSERT INTO Material (idMaterial, filePath, nameMaterial, typeMaterial, idSection, idLecturer) VALUES 
(1, '/materials/math_algebra.pdf', 'Algebra Basics', 'pdf', 1, 1),
(2, '/materials/physics_mechanics.pdf', 'Mechanics Concepts', 'pdf', 2, 2);

INSERT INTO Test (idTest, nameTest, startDate, endDate, timeLimit, status, description, idSection, idLecturer) VALUES 
(1, 'Algebra Test', '2024-10-25', '2024-10-30', 60, 'Open', 'Basic algebra concepts', 1, 1),
(2, 'Mechanics Test', '2024-11-05', '2024-11-10', 90, 'Open', 'Fundamentals of mechanics', 2, 2);


INSERT INTO Question (idQues, nameQues, A, B, C, D, trueAns, idTest) VALUES 
(1, 'What is 2 + 2?', '3', '4', '5', '6', 'B', 1),
(2, 'What is Newton\ first law?', 'Inertia', 'Gravity', 'Friction', 'Mass', 'A', 2);


INSERT INTO StudentAns (idAns, studentAns, idStudent, idQues) VALUES 
(1, 'B', 1, 1),
(2, 'A', 2, 2);


INSERT INTO Assignment (idAssign, nameAssign, startDate, endDate, description, grade, idSection, idLecturer) VALUES 
(1, 'Algebra Assignment', '2024-10-15', '2024-10-25', 'Solve algebra problems', 100, 1, 1),
(2, 'Mechanics Assignment', '2024-11-01', '2024-11-10', 'Mechanics problem set', 100, 2, 2);

INSERT INTO Assignment_Student (idAssign, idStudent, numAttempts, totalScore, totalTimeSpent) VALUES 
(1, 1, 1, 90, 120),
(2, 2, 2, 85, 180);


INSERT INTO Submission (idSubmiss, nameFile, pathFile, typeFile, dateSubmit, idAssign, idStudent) VALUES 
(1, 'algebra_assignment.pdf', '/submissions/algebra_assignment.pdf', 'pdf', '2024-10-24', 1, 1),
(2, 'mechanics_assignment.docx', '/submissions/mechanics_assignment.docx', 'docx', '2024-11-09', 2, 2);


INSERT INTO Discussion (idDiscuss, description, nameDiscuss, idSection, idLecturer) VALUES 
(1, 'Discuss algebra topics', 'Algebra Discussion', 1, 1),
(2, 'Discuss mechanics concepts', 'Mechanics Discussion', 2, 2);

INSERT INTO Comment (idCmt, content, idDiscuss, idStudent, idLecturer) VALUES 
(1, 'This topic is difficult.', 1, 1, NULL),
(2, 'Can you explain more about Newton\law?', 2, 2, NULL);


select * from class