-- Trigger tạo thông báo khi bài tập được thêm vào
create  TRIGGER trg_CreateNotification_Assignment
ON Assignment
AFTER INSERT
AS
BEGIN
    INSERT INTO NotificationPanel (idStudent, idCourse, idSection, idElement, typeElement, nameElement, startDate, endDate, notificationDate)
    SELECT 
        cs.idStudent,
        a.idCourse,
        a.idSection,
        a.idAssign AS idElement,
        e.nameType AS typeElement,
        a.nameAssign AS nameElement,
        a.startDate,
        a.endDate,
        GETDATE() AS notificationDate
    FROM Inserted a
    JOIN Element e ON a.idAssign = e.idElement AND a.idCourse = e.idCourse AND a.idSection = e.idSection
    JOIN CourseStudent cs ON cs.idCourse = a.idCourse;
END;

-- Trigger tạo thông báo khi bài kiểm tra được thêm vào
CREATE TRIGGER trg_CreateNotification_Test
ON Test
AFTER INSERT
AS
BEGIN
    INSERT INTO NotificationPanel (idStudent, idCourse, idSection, idElement, typeElement, nameElement, startDate, endDate, notificationDate)
    SELECT 
        cs.idStudent,
        t.idCourse,
        t.idSection,
        t.idTest AS idElement,
        e.nameType AS typeElement,
        t.nameTest AS nameElement,
        t.startDate,
        t.endDate,
        GETDATE() AS notificationDate
    FROM Inserted t
    JOIN Element e ON t.idTest = e.idElement AND t.idCourse = e.idCourse AND t.idSection = e.idSection
    JOIN CourseStudent cs ON cs.idCourse = t.idCourse;
END;

-- Trigger đánh dấu hoàn thành khi sinh viên làm bài tập
CREATE TRIGGER trg_CompleteNotification
ON StudentAssignment
AFTER INSERT
AS
BEGIN
    UPDATE np
    SET np.isCompleted = 1
    FROM NotificationPanel np
    JOIN Inserted i ON np.idStudent = i.idStudent
                    AND np.idCourse = i.idCourse
                    AND np.idSection = i.idSection
                    AND np.idElement = i.idAssign;
END;

-- Trigger đánh dấu hoàn thành khi sinh viên làm bài kiểm tra
CREATE TRIGGER trg_CompleteNotificationTest
ON StudentTest
AFTER INSERT
AS
BEGIN
    UPDATE np
    SET np.isCompleted = 1
    FROM NotificationPanel np
    JOIN Inserted i ON np.idStudent = i.idStudent
                    AND np.idCourse = i.idCourse
                    AND np.idSection = i.idSection
                    AND np.idElement = i.idTest;
END;
