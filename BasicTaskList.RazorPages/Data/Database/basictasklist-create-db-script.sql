USE master
GO

DECLARE @SQL nvarchar(1000);
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = N'BasicTaskList')
BEGIN
    SET @SQL = N'USE BasicTaskList;

                 ALTER DATABASE BasicTaskList SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                 USE master;

                 DROP DATABASE BasicTaskList;';
    EXEC (@SQL);
END;

CREATE DATABASE BasicTaskList
GO

USE BasicTaskList
GO

CREATE TABLE Folders
(
	Id					int				IDENTITY(1,1)		NOT NULL,
	[Name]				varchar(255)						NOT NULL,
	 
	CONSTRAINT PK_Folders PRIMARY KEY(Id)	
)
GO

CREATE TABLE Tasks
(
	Id					int				IDENTITY(1,1)		NOT NULL,
	[Name]				varchar(255)						NOT NULL,
	Notes				varchar(255)						NULL,
	DueDate				date								NOT NULL,
	IsComplete			bit									NOT NULL,
	IsImportant			bit									NOT NULL,
	FolderId			int									NOT NULL,
	
	CONSTRAINT PK_Tasks PRIMARY KEY(Id),
	CONSTRAINT FK_Tasks_Folders FOREIGN KEY(FolderId) REFERENCES Folders(Id),
)
GO
