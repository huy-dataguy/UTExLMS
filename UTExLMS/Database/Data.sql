USE UTExLMS;

-- Chèn dữ liệu vào bảng Student
INSERT INTO Student (idStudent, email, birthday, gender, lastName, firstName, phoneNum, pass)
VALUES 
    (1, 'student1@utex.edu', '2000-01-01', 'Male', 'Nguyen', 'An', '0912345678', 'password1'),
    (2, 'student2@utex.edu', '2001-02-15', 'Female', 'Le', 'Binh', '0912345679', 'password2');

-- Chèn dữ liệu vào bảng Lecturer
INSERT INTO Lecturer (idLecturer, email, birthday, gender, lastName, firstName, phoneNum, pass)
VALUES 
    (1, 'lecturer1@utex.edu', '1980-05-10', 'Male', 'Tran', 'Quang', '0912345680', 'password1'),
    (2, 'lecturer2@utex.edu', '1978-08-20', 'Female', 'Do', 'Minh', '0912345681', 'password2');

-- Chèn dữ liệu vào bảng Semester
INSERT INTO Semester (idSemester, nameSemester, startDate, endDate)
VALUES 
    (1, 'Spring 2024', '2024-01-01', '2024-05-31'),
    (2, 'Fall 2024', '2024-09-01', '2024-12-31');

-- Chèn dữ liệu vào bảng Subjects
INSERT INTO Subjects (idSubject, nameSubject, idSemester)
VALUES 
    (1, 'Mathematics', 1),
    (2, 'Computer Science', 2);

-- Chèn dữ liệu vào bảng Course
INSERT INTO Course (idCourse, nameCourse, idSubject, idLecturer, imgCourse)
VALUES 
    (1, 'Calculus 101', 1, 1, 'calculus.jpg'),
    (2, 'Introduction to Programming', 2, 2, 'programming.jpg');


INSERT INTO Section (idSection, idCourse, nameSection, descript) VALUES
	(1, 1, 'Introduction to Course', 'Overview and objectives of the course'),
	(2, 1, 'Chapter 1: Basics', 'Introduction to fundamental concepts'),
    (3, 1, 'Chapter 2: Advanced Topics', 'Detailed study of advanced topics'),
    (4, 1, 'Practical Exercises', 'Hands-on practice to reinforce learning'),
    (5, 1, 'Project Guidelines', 'Instructions for the course project'),
    (6, 1, 'Final Review', 'Summary and revision for the course assessment');



Select * from Section
-- Chèn dữ liệu vào bảng Material
INSERT INTO Material (idMaterial, filePath, statu, nameMaterial, typeMaterial, idSection, idCourse)
VALUES 
    (1, 'path/to/file1.pdf', 1, 'Limits Notes', 'PDF', 1, 1),
    (2, 'path/to/file2.pdf', 0, 'Python Basics', 'PDF', 2, 2);

-- Chèn dữ liệu vào bảng Test
INSERT INTO Test (idTest, nameTest, statu, startDate, endDate, timeLimit, descript, idSection, idCourse)
VALUES 
    (1, 'Limits Test', 1, '2024-02-01', '2024-02-10', 60, 'Test on limits', 1, 1),
    (2, 'Python Basics Quiz', 1, '2024-10-01', '2024-10-15', 30, 'Quiz on Python basics', 2, 2);

-- Chèn dữ liệu vào bảng Question
INSERT INTO Question (idQues, nameQues, A, B, C, D, trueAns, idTest, idSection, idCourse)
VALUES 
    (1, 'What is the limit of 1/x as x approaches 0?', '0', 'Infinity', '1', '-1', 'B', 1, 1, 1),
    (2, 'What is the output of print(2 + 3)?', '2', '5', '23', 'Error', 'B', 2, 2, 2);

-- Chèn dữ liệu vào bảng StudentAns
INSERT INTO StudentAns (idStudent, ans, idQues, idTest, idSection, idCourse)
VALUES 
    (1, 'B', 1, 1, 1, 1),
    (2, 'B', 2, 2, 2, 2);

-- Chèn dữ liệu vào bảng Assignment
INSERT INTO Assignment (idAssign, nameAssign, statu, startDate, endDate, descript, grade, idSection, idCourse)
VALUES 
    (1, 'Limits Assignment', 1, '2024-02-11', '2024-02-20', 'Assignment on limits', 100, 1, 1),
    (2, 'Python Project', 0, '2024-10-20', '2024-11-01', 'Simple Python project', 100, 2, 2);

-- Chèn dữ liệu vào bảng StudentAssignment
INSERT INTO StudentAssignment (idSubmiss, nameFile, pathFile, typeFile, dateSubmit, idCourse, idSection, idAssign, idStudent)
VALUES 
    (1, 'limits_work.pdf', 'path/to/limits_work.pdf', 'PDF', '2024-02-15', 1, 1, 1, 1),
    (2, 'python_project.zip', 'path/to/python_project.zip', 'ZIP', '2024-11-01', 2, 2, 2, 2);

-- Chèn dữ liệu vào bảng Discussion
INSERT INTO Discussion (idDiscuss, descript, nameDiscuss, idSection, idCourse)
VALUES 
    (1, 'Discussion about limits', 'Limits Discussion', 1, 1),
    (2, 'Discussion about Python', 'Python Discussion', 2, 2);

-- Chèn dữ liệu vào bảng LecturerDiscussion
INSERT INTO LecturerDiscussion (content, commentDate, idCourse, idSection, idDiscuss, idLecturer)
VALUES 
    ('Please review the limit concepts.', '2024-02-05', 1, 1, 1, 1),
    ('Python basics are important.', '2024-10-05', 2, 2, 2, 2);

-- Chèn dữ liệu vào bảng StudentDiscussion
INSERT INTO StudentDiscussion (content, commentDate, idCourse, idSection, idDiscuss, idStudent)
VALUES 
    ('I have a question about limits.', '2024-02-06', 1, 1, 1, 1),
    ('Can someone explain Python loops?', '2024-10-06', 2, 2, 2, 2);

-- Chèn dữ liệu vào bảng CourseStudent
INSERT INTO CourseStudent (idStudent, idCourse, progress)
VALUES 
    (1, 1, 50.0),
    (2, 2, 75.0);

-- Chèn dữ liệu vào bảng CourseLecturer
INSERT INTO CourseLecturer (idLecturer, idCourse)
VALUES 
    (1, 1),
    (2, 2);
