-- Hotel Rooms

IF DB_ID(N'HotelRoomsDb') IS NULL
    CREATE DATABASE HotelRoomsDb;
GO

USE HotelRoomsDb;
GO

IF OBJECT_ID(N'dbo.Rooms', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Rooms
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        RoomNumber NVARCHAR(4) NOT NULL,
        RoomType NVARCHAR(10) NOT NULL,
        Floor INT NOT NULL,
        PricePerNight DECIMAL(8,2) NOT NULL,
        Status NVARCHAR(10) NOT NULL,
        HasBalcony BIT NOT NULL,
        Description NVARCHAR(150) NOT NULL,
        CONSTRAINT UQ_Rooms_RoomNumber UNIQUE (RoomNumber),
        CONSTRAINT CK_Rooms_RoomType CHECK (RoomType IN (N'Single', N'Double', N'Suite')),
        CONSTRAINT CK_Rooms_Floor CHECK (Floor BETWEEN 1 AND 20),
        CONSTRAINT CK_Rooms_PricePerNight CHECK (PricePerNight BETWEEN 1 AND 10000),
        CONSTRAINT CK_Rooms_Status CHECK (Status IN (N'Free', N'Occupied', N'Cleaning')),
        CONSTRAINT CK_Rooms_Description CHECK (LEN(LTRIM(RTRIM(Description))) > 0),
        CONSTRAINT CK_Rooms_NumberAndFloor CHECK
        (
            LEN(RoomNumber) BETWEEN 3 AND 4
            AND RoomNumber NOT LIKE N'%[^0-9]%'
            AND LEFT(RoomNumber, 1) <> N'0'
            AND TRY_CONVERT(INT, RoomNumber) / 100 = Floor
            AND TRY_CONVERT(INT, RoomNumber) % 100 BETWEEN 1 AND 99
        )
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Rooms)
BEGIN
    INSERT INTO dbo.Rooms
        (RoomNumber, RoomType, Floor, PricePerNight, Status, HasBalcony, Description)
    VALUES
        (N'101', N'Single', 1,  90.00, N'Free',     0, N'Courtyard view / შიდა ეზოს ხედი'),
        (N'102', N'Double', 1, 145.00, N'Occupied', 1, N'Garden view / ბაღის ხედი'),
        (N'103', N'Suite',  1, 290.00, N'Free',     1, N'Sea view with lounge / ზღვის ხედი'),
        (N'104', N'Single', 1,  95.00, N'Cleaning', 0, N'Quiet room / მშვიდი ოთახი'),
        (N'201', N'Double', 2, 155.00, N'Free',     1, N'Garden view with twin beds / ორი საწოლი'),
        (N'202', N'Single', 2, 105.00, N'Occupied', 0, N'City view / ქალაქის ხედი'),
        (N'203', N'Double', 2, 175.00, N'Cleaning', 1, N'Sea view with double bed / ზღვის ხედი'),
        (N'204', N'Suite',  2, 320.00, N'Occupied', 1, N'Family suite / საოჯახო ნომერი'),
        (N'301', N'Single', 3, 110.00, N'Free',     1, N'Mountain view / მთის ხედი'),
        (N'302', N'Double', 3, 165.00, N'Free',     0, N'Courtyard view with twin beds / შიდა ეზო'),
        (N'303', N'Suite',  3, 350.00, N'Occupied', 1, N'Sea view with terrace / ზღვის ხედი'),
        (N'304', N'Single', 3, 100.00, N'Cleaning', 0, N'Compact room with desk / სამუშაო მაგიდა'),
        (N'401', N'Suite',  4, 380.00, N'Free',     1, N'Panoramic city view / პანორამული ხედი'),
        (N'402', N'Double', 4, 180.00, N'Occupied', 1, N'Mountain view with twin beds / მთის ხედი'),
        (N'403', N'Single', 4, 120.00, N'Free',     0, N'Quiet corner room / კუთხის ოთახი'),
        (N'501', N'Suite',  5, 450.00, N'Cleaning', 1, N'Executive suite / დიდი მისაღები'),
        (N'502', N'Double', 5, 195.00, N'Free',     1, N'Rooftop garden view '),
        (N'503', N'Suite',  5, 420.00, N'Occupied', 1, N'Family suite with lounge / საოჯახო ნომერი');
END;
GO
