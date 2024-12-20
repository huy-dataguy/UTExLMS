﻿--List of procedure
use UTExLMS
CREATE PROCEDURE UpdateLecturerInfo
    @IdLecturer INT,
    @FirstName NVARCHAR(50),  -- Cập nhật kích thước để phù hợp với bảng
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @Birthday DATE,
    @Gender NVARCHAR(10),
    @PhoneNum NVARCHAR(15),
    @pass NVARCHAR(15)  -- Cập nhật kích thước để phù hợp với bảng
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
        pass = @pass  -- Nên mã hóa trước khi lưu
    WHERE idLecturer = @IdLecturer;  -- Sử dụng tham số đúng
END


-------------------------

CREATE PROCEDURE AddNewSection
    @idCourse INT,
    @nameSection VARCHAR(100) = 'No content',
    @descript VARCHAR(255) = 'No content'
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @maxIdSection INT;

    -- Tìm idSection cao nhất trong bảng Section cho khóa học
    SELECT @maxIdSection = ISNULL(MAX(idSection), 0)
    FROM Section
    WHERE idCourse = @idCourse;

    -- Thêm section mới vào bảng
    INSERT INTO Section (idSection, idCourse, nameSection, descript)
    VALUES (@maxIdSection + 1, @idCourse, @nameSection, @descript);
END


----------------------------

CREATE PROCEDURE UpdateSection
    @idCourse INT,
    @idSection INT,
    @nameSection VARCHAR(100),
    @descript VARCHAR(255)
AS
BEGIN
    UPDATE Section
    SET nameSection = @nameSection,
        descript = @descript
    WHERE idCourse = @idCourse AND idSection = @idSection;
END;

--------------------------------------

create PROCEDURE AddAssignment (
    @nameAssign VARCHAR(100),
    @statu BIT = 0,  -- Giá trị mặc định là 0
    @startDate DATE,
    @endDate DATE,
    @descript VARCHAR(255),
    @grade FLOAT = 0,  -- Giá trị mặc định là 0
    @idSection INT,
    @idCourse INT
)
AS
BEGIN
	Declare @idAssign INT;
	Select @idAssign = ISNULL(MAX(idElement),0) + 1
	from Element 
	where
	Element.idCourse = @idCourse and Element.idSection = idSection;

	INsert into Element (idElement, idCourse, idSection,nameType)
	values (@idAssign,@idCourse,@idSection,'Assignment');

		INSERT INTO Assignment (
            idAssign,
            nameAssign,
            statu,
            startDate,
            endDate,
            descript,
            grade,
            idSection,
            idCourse
        )
        VALUES (
            @idAssign,
            @nameAssign,
            @statu,  -- Nếu không truyền vào giá trị, sẽ mặc định là 0
            @startDate,
            @endDate,
            @descript,
            @grade,  -- Nếu không truyền vào giá trị, sẽ mặc định là 0
            @idSection,
            @idCourse
        );
        
        PRINT 'Assignment added successfully.';
    
END;

---HHHHHHHHHHHHHHHHHHHHHHHHHHEAD



--------------------

Create procedure AddFile (
    @filePath VARCHAR(255),
    @statu BIT = 0,  -- Giá trị mặc định là 0
    @nameMaterial VARCHAR(100),
    @typeMaterial VARCHAR(50),
    @idSection INT,
    @idCourse INT
    )
    AS
    BEGIN
		Declare @idMaterial INT;
		Select @idMaterial = ISNULL(MAX(idElement),0) + 1
		from Element 
		where
		Element.idCourse = @idCourse and Element.idSection = idSection;
	
		INsert into Element (idElement, idCourse, idSection,nameType)
		values (@idMaterial,@idCourse,@idSection,'Material');
	
			INSERT INTO Material (
				idMaterial,
				filePath,
				statu,
				nameMaterial,
				typeMaterial,
				idSection,
				idCourse
			)
			VALUES (
				@idMaterial,
				@filePath,
				@statu,  -- Nếu không truyền vào giá trị, sẽ mặc định là 0
				@nameMaterial,
				@typeMaterial,
				@idSection,
				@idCourse
			);
			
			PRINT 'Material added successfully.';
		
	END;


    --------------------

    create procedure AddTest (
        @idTest INT,
        @nameTest VARCHAR(100),
		@statu BIT = 0,  -- Giá trị mặc định là 0
		@startDate DATE,
		@endDate DATE,
		@timeLimit INT,
		@descript VARCHAR(255),
		@idSection INT,
		@idCourse INT
	)
    AS
    BEGIN
    Insert into Element (idElement, idCourse, idSection,nameType)
    values (@idTest,@idCourse,@idSection,'Test');
    INSERT INTO Test (
		idTest,
		nameTest,
		statu,
		startDate,
		endDate,
		timeLimit,
		descript,
		idSection,
		idCourse
	)
    VALUES (
		@idTest,
		@nameTest,
		@statu,  -- Nếu không truyền vào giá trị, sẽ mặc định là 0
		@startDate,
		@endDate,
		@timeLimit,
		@descript,
		@idSection,
		@idCourse
	);
    PRINT @idTest;
	END;

	--------------------
Exec AddTest
    @idTest = 59,
    @nameTest = 'a',
    @statu = 0,
    @startDate = '2024-12-12',
    @endDate = '2024-12-12',
    @timeLimit = 120,
    @descript = 'Bai tap',
    @idSection = 3,
    @idCourse = 1


Drop Procedure [dbo].[AddQuestion]
	
CREATE PROCEDURE [dbo].[AddQuestion] 
    @nameQues VARCHAR(255),
    @A VARCHAR(255),
    @B VARCHAR(255),
    @C VARCHAR(255),
    @D VARCHAR(255),
    @trueAns VARCHAR(1),
    @idTest INT,
    @idCourse INT,
    @idSection INT
AS
BEGIN
    DECLARE @idQues INT;

    IF EXISTS (
        SELECT 1
        FROM Question
        WHERE idCourse = @idCourse AND idSection = @idSection AND idTest = @idTest
    )
    BEGIN
        SELECT @idQues = MAX(idQues) + 1
        FROM Question
        WHERE idCourse = @idCourse AND idSection = @idSection AND idTest = @idTest;
    END
    ELSE
    BEGIN
        SET @idQues = 1;
    END

    INSERT INTO Question (
        idQues,
        nameQues,
        A,
        B,
        C,
        D,
        trueAns,
        idTest,
        idSection,
        idCourse
    )
    VALUES (
        @idQues,
        @nameQues,
        @A,
        @B,
        @C,
        @D,
        @trueAns,
        @idTest,
        @idSection,
        @idCourse
    );

    PRINT @idQues;
END;

-------------------


create procedure UpdateQuestion
(
	@idQues INT,
	@nameQues VARCHAR(255),
	@A VARCHAR(255),
	@B VARCHAR(255),
	@C VARCHAR(255),
	@D VARCHAR(255),
	@trueAns VARCHAR(1),
	@idTest INT,
	@idCourse INT,
	@idSection INT
)
AS
BEGIN
	UPDATE Question
	SET nameQues = @nameQues,
		A = @A,
		B = @B,
		C = @C,
		D = @D,
		trueAns = @trueAns
	WHERE idQues = @idQues AND idTest = @idTest AND idSection = @idSection AND idCourse = @idCourse;
END;

-----------------


Create procedure UpdateTest
(
	@idTest INT,
	@nameTest VARCHAR(100),
	@statu BIT,
	@startDate DATE,
	@endDate DATE,
	@timeLimit INT,
	@descript VARCHAR(255),
	@idSection INT,
	@idCourse INT
)
AS
BEGIN
	UPDATE Test
	SET nameTest = @nameTest,
		statu = @statu,
		startDate = @startDate,
		endDate = @endDate,
		timeLimit = @timeLimit,
		descript = @descript
	WHERE idTest = @idTest AND idSection = @idSection AND idCourse = @idCourse;
END;


-----------------

drop procedure if exists GetMaxIdTest;

Create function GetMaxIdTest
(
	@idCourse INT,
	@idSection INT
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		ISNULL(MAX(idTest), 0) AS maxIdTest
	FROM 
		Test
	WHERE 
		idCourse = @idCourse AND idSection = @idSection

);




--CREATE PROCEDURE UpdateStudentAssignment
--    @nameFile VARCHAR(100),
--    @pathFile VARCHAR(255),
--    @typeFile VARCHAR(50),
--    @dateSubmit DATE,
--    @idCourse INT,
--    @idSection INT,
--    @idAssign INT,
--    @idStudent INT
--AS
--BEGIN
--    -- Cập nhật thông tin bài tập đã nộp của sinh viên
--    UPDATE StudentAssignment
--    SET 
--        nameFile = @nameFile,
--        pathFile = @pathFile,
--        typeFile = @typeFile,
--        dateSubmit = @dateSubmit
--    WHERE 
--        idCourse = @idCourse
--        AND idSection = @idSection
--        AND idAssign = @idAssign
--        AND idStudent = @idStudent;

--    -- Kiểm tra nếu không có bản ghi nào được cập nhật (không tìm thấy bản ghi hợp lệ)
--    IF @@ROWCOUNT = 0
--    BEGIN
--        PRINT 'Không tìm thấy bài tập của sinh viên với các tham số trên.';
--    END
--    ELSE
--    BEGIN
--        PRINT 'Cập nhật thành công bài tập của sinh viên.';
--    END
--END;

drop procedure UpdateStudentAssignment
-- Giả sử bạn muốn cập nhật bài tập của sinh viên với ID là 123 cho khóa học, phần học, và bài tập có ID là 1
use UTExLMS
select * from StudentAssignment

CREATE PROCEDURE UpdateStudentAssignment
    @nameFile VARCHAR(100),
    @pathFile VARCHAR(255),
    @typeFile VARCHAR(50),
    @dateSubmit DATE,
    @idCourse INT,
    @idSection INT,
    @idAssign INT,
    @idStudent INT
AS
BEGIN
    -- Cập nhật thông tin bài tập đã nộp của sinh viên
    UPDATE StudentAssignment
    SET 
        nameFile = @nameFile,
        pathFile = @pathFile,
        typeFile = @typeFile,
        dateSubmit = @dateSubmit
    WHERE 
        idCourse = @idCourse
        AND idSection = @idSection
        AND idAssign = @idAssign
        AND idStudent = @idStudent;

    -- Kiểm tra nếu không có bản ghi nào được cập nhật (không tìm thấy bản ghi hợp lệ)
    IF @@ROWCOUNT = 0
    BEGIN
        -- Tạo mới bản ghi nếu không có bản ghi nào được cập nhật
        INSERT INTO StudentAssignment (nameFile, pathFile, typeFile, dateSubmit, idCourse, idSection, idAssign, idStudent)
        VALUES (@nameFile, @pathFile, @typeFile, @dateSubmit, @idCourse, @idSection, @idAssign, @idStudent);

        PRINT 'Không tìm thấy bài tập của sinh viên, tạo mới bản ghi thành công.';
    END
    ELSE
    BEGIN
        PRINT 'Cập nhật thành công bài tập của sinh viên.';
    END
END;

EXEC UpdateStudentAssignment
    @nameFile = 'UpdatedAssignment.pdf',  -- Tên file mới
    @pathFile = 'C:\Assignments\UpdatedAssignment.pdf',  -- Đường dẫn file mới
    @typeFile = 'PDF',  -- Loại file mới
    @dateSubmit = '2024-11-15',  -- Ngày nộp mới
    @idCourse = 1,  -- ID của khóa học
    @idSection = 1,  -- ID của phần học
    @idAssign = 5,  -- ID của bài tập
    @idStudent = 3;  -- ID của sinh viên


	select * from StudentAssignment



	CREATE PROCEDURE [dbo].[AddStudentAnswer]
    @ans VARCHAR(1),
    @idStudent INT,
    @idCourse INT,
    @idSection INT,
    @idTest INT,
    @idQues INT  
AS
BEGIN
    DECLARE @trueAns VARCHAR(1);
    DECLARE @isCorrect BIT;

    -- Lấy đáp án đúng 
    SELECT @trueAns = trueAns
    FROM Question
    WHERE idQues = @idQues
      AND idTest = @idTest
      AND idCourse = @idCourse
      AND idSection = @idSection;

    -- Tính toán giá trị isTrue
    SET @isCorrect = CASE
        WHEN @ans = @trueAns THEN 1
        ELSE 0
    END;

    -- Kiểm tra hàng đó đã có tồn tại trong bảng StudentAns
    IF EXISTS (
        SELECT 1 
        FROM StudentAns
        WHERE idPerson = @idStudent
          AND idQues = @idQues
          AND idTest = @idTest
          AND idCourse = @idCourse
          AND idSection = @idSection
    )
    BEGIN
        -- Nếu đã tồn tại thì update
        UPDATE StudentAns
        SET ans = @ans,
            isTrue = @isCorrect
        WHERE idPerson = @idStudent
          AND idQues = @idQues
          AND idTest = @idTest
          AND idCourse = @idCourse
          AND idSection = @idSection;
    END
    ELSE
    BEGIN
        -- Chưa tồn tại thì insert
        INSERT INTO StudentAns (idPerson, idQues, ans, isTrue, idTest, idCourse, idSection)
        VALUES (@idStudent, @idQues, @ans, @isCorrect, @idTest, @idCourse, @idSection);
    END
END;





CREATE PROCEDURE [dbo].[CalculateStudentScore]
    @p_idStudent INT,
    @p_idCourse INT,
    @p_idSection INT,
    @p_idTest INT
AS
BEGIN
    DECLARE @correctAnswers INT = 0;
    DECLARE @totalQuestions INT = 0;
    DECLARE @finalScore FLOAT = 0.0;

    -- Đếm tổng số câu trả lời chính xác
    SELECT @correctAnswers = COUNT(*)
    FROM StudentAns
    WHERE idPerson = @p_idStudent
      AND idCourse = @p_idCourse
      AND idSection = @p_idSection
      AND idTest = @p_idTest
      AND isTrue = 1;

    -- Đếm tổng số câu trả lời
    SELECT @totalQuestions = COUNT(*)
    FROM Question
    WHERE idTest = @p_idTest
      AND idCourse = @p_idCourse
      AND idSection = @p_idSection;

    -- Tính toán điểm số cuối cùng 
IF @totalQuestions > 0
    BEGIN
        SET @finalScore = ROUND(CAST(@correctAnswers AS FLOAT) / @totalQuestions * 10, 1);
    END
    ELSE
    BEGIN
        SET @finalScore = 0;
    END;

    -- Kiểm tra đã tồn tại chưa 
    IF EXISTS (
        SELECT 1
        FROM StudentTest
        WHERE idStudent = @p_idStudent
          AND idCourse = @p_idCourse
          AND idSection = @p_idSection
          AND idTest = @p_idTest
    )
    BEGIN
        -- Nếu đã có thì update
        UPDATE StudentTest
        SET totalScore = @finalScore
        WHERE idStudent = @p_idStudent
          AND idCourse = @p_idCourse
          AND idSection = @p_idSection
          AND idTest = @p_idTest;
    END
    ELSE
    BEGIN
        -- Chưa thì insert
        INSERT INTO StudentTest (idStudent, idCourse, idSection, idTest, totalScore)
        VALUES (@p_idStudent, @p_idCourse, @p_idSection, @p_idTest, @finalScore);
    END
END;

select * from StudentTest