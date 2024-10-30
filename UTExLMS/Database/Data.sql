

use UTExLMS
-- Insert sample data into Roles

INSERT INTO Roles (idRole, nameRole) VALUES 
(1, 'Student'),
(2, 'Lecturer');

-- Insert sample data into Student
INSERT INTO Student (idStudent, email, birthday, gender, lastName, firstName, phoneNum, idRole, pass) VALUES 
(1, 'student1@example.com', '2001-01-01', 'Male', 'Nguyen', 'Van A', '1234567890', 1, 'password1'),
(2, 'student2@example.com', '2002-02-02', 'Female', 'Le', 'Thi B', '0987654321', 1, 'password2');

-- Insert sample data into Lecturer
INSERT INTO Lecturer (idLecturer, email, birthday, gender, lastName, firstName, phoneNum, idRole, pass) VALUES 
(1, 'lecturer1@example.com', '1980-01-01', 'Male', 'Tran', 'Van C', '1234509876', 2, 'securepass1'),
(2, 'lecturer2@example.com', '1985-02-02', 'Female', 'Pham', 'Thi D', '0987651234', 2, 'securepass2');

-- Insert sample data into Semester
INSERT INTO Semester (idSemester, nameSemester, startDate, endDate) VALUES 
(1, 'Fall 2024', '2024-09-01', '2024-12-31'),
(2, 'Spring 2025', '2025-01-15', '2025-05-31');
INSERT INTO Semester (idSemester, nameSemester, startDate, endDate) VALUES 
(3, 'Fall 2024', '2023-09-01', '2023-12-31'),
(4, 'Spring 2025', '2025-01-15', '2025-05-31');


INSERT INTO Semester (idSemester, nameSemester, startDate, endDate) VALUES 

(5, 'Spring 2022', '2024-01-15', '2024-12-31');


-- Insert sample data into Subjects
INSERT INTO Subjects (idSubject, nameSubject, idSemester) VALUES 
(1, 'Mathematics', 1),
(2, 'Physics', 1),
(3, 'Chemistry', 2);
INSERT INTO Subjects (idSubject, nameSubject, idSemester) VALUES 
(4, 'Mathematics', 3),
(5, 'Physics', 4),
(6, 'Chemistry', 3);

INSERT INTO Subjects (idSubject, nameSubject, idSemester) VALUES 
(7, 'Mathematics', 5);

select * from Subjects



-- Insert sample data into Class
INSERT INTO Class (idClass, nameClass, idSubject, idLecturer, imgClass) VALUES 
(1, 'Math Class A', 3, 1, '/images/math_class_a.jpg'),
(2, 'Physics Class B', 4, 2, '/images/math_class_a.jpg'),
(3, 'Math Class B', 4, 1, '/images/math_class_a.jpg'),
(4, 'Math Class C', 3, 1, '/images/math_class_a.jpg'),
(5, 'Math Class D', 4, 1, '/images/math_class_a.jpg'),
(6, 'Math Class E', 3, 1, '/images/math_class_a.jpg');


INSERT INTO Class (idClass, nameClass, idSubject, idLecturer, imgClass) VALUES 
(7, 'Math Class EE', 7, 1, '/images/math_class_a.jpg'),
(8, 'Physics Class EE', 7, 2, '/images/math_class_a.jpg');

select * from Class


INSERT INTO ClassStudent (idStudent, idClass, progress) VALUES 
(1, 2, 80.0),
(2, 2, 90.0),
(2, 3, 95.0),
(2, 4, 33.0),
(1, 3, 90.0),
(1, 1, 90.0),
(1, 4, 33),
(1, 5, 22),
(1, 6, 5);

INSERT INTO ClassStudent (idStudent, idClass, progress) VALUES 
(1, 7, 23.0),
(2, 8, 20.0);

INSERT INTO ClassStudent (idStudent, idClass, progress) VALUES 
(1, 8, 20.0);
select * from ClassStudent


USE UTExLMS;

-- Xóa tất cả bản ghi trong bảng ClassStudent
DELETE FROM ClassStudent;

-- Xóa tất cả bản ghi trong bảng Class
DELETE FROM Class;

-- Xóa tất cả bản ghi trong bảng Subjects
DELETE FROM Subjects;

-- Xóa tất cả bản ghi trong bảng Semester
DELETE FROM Semester;

-- Xóa tất cả bản ghi trong bảng Lecturer
DELETE FROM Lecturer;

-- Xóa tất cả bản ghi trong bảng Student
DELETE FROM Student;

-- Xóa tất cả bản ghi trong bảng Roles
DELETE FROM Roles;
