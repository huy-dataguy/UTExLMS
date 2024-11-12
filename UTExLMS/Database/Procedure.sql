--List of procedure
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

Create PROCEDURE AddAssignment (
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

	INsert into Element (idElement, idCourse, idSection)
	values (@idAssign,@idCourse,@idSection);

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





