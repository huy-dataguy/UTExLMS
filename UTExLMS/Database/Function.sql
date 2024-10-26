USE UTExLMS



CREATE FUNCTION GetStudentCoursesByFilter (
    @idStudent INT,
    @filterType VARCHAR(10)  -- 'All', 'InProgress', or 'Past'
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        c.nameClass,
        c.progress,
        sem.startDate,
        sem.endDate
    FROM 
        Class c
    JOIN 
        StudentClass sc ON c.idClass = sc.idClass
    JOIN 
        Subject sub ON c.idSubject = sub.idSubject
    JOIN 
        Semester sem ON sub.idSemester = sem.idSemester
    WHERE 
        sc.idStudent = @idStudent
        AND (
            (@filterType = 'All') OR
            (@filterType = 'InProgress' AND GETDATE() BETWEEN sem.startDate AND sem.endDate) OR
            (@filterType = 'Past' AND GETDATE() > sem.endDate)
        )
);
