CREATE TABLE dbo.UserInfo
(
    USER_ID NVARCHAR(10) NOT NULL PRIMARY KEY,
    ROLE NVARCHAR(10) NOT NULL,
    FULL_NAME NVARCHAR(50) NOT NULL,
    USERNAME NVARCHAR(50) NOT NULL,
    EMAIL NVARCHAR(50) NOT NULL,
    MOBILE NVARCHAR(20) NOT NULL,
    PASSWORD NVARCHAR(50) NOT NULL,
    NID NVARCHAR(20) NOT NULL,
    ADDRESS NVARCHAR(50) NOT NULL,
    CREATED_DATE DATE NOT NULL,
    STATUS BIT NOT NULL
);
TRUNCATE TABLE dbo.UserInfo;

INSERT INTO dbo.UserInfo (USER_ID, ROLE, FULL_NAME, USERNAME, EMAIL, MOBILE, PASSWORD, NID, ADDRESS, CREATED_DATE, STATUS)
VALUES
('A-001','admin','MD Shafi Mahmmod','shafi','shafi@gmail.com','01711111111','Shafi@1111','1234567890','Dhaka, Bangladesh',GETDATE(),1),
('A-002','admin','Karim Ahmed','karim_admin','karim@gmail.com','01722222222','Karim@2222','1234567890123','Rajshahi, Bangladesh',GETDATE(),0),
('A-006','admin','Najiyat Islam Reshad','reshad','reshad@gmail.com','01658432505','Reshad@2505','65446246254','Dhaka',GETDATE(),1),
('E-003','employee','Rahim Uddin','rahim','rahim@gmail.com','01811111111','Rahim@1111','2234567890','Chittagong, Bangladesh',GETDATE(),1),
('E-004','employee','Sumaiya Akter','sumaiya_emp','sumaiya@gmail.com','01822222222','Sumaiya@2222','32345678901234567','Khulna, Bangladesh',GETDATE(),1),
('E-005','employee','Hasan Mahmud','hasan_emp','hasan@gmail.com','01833333333','Hasan@3333','4234567890','Sylhet, Bangladesh',GETDATE(),0);


 select * from UserInfo;