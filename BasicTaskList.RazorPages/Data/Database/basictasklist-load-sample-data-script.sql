USE BasicTaskList
GO

INSERT INTO Folders([Name]) VALUES ('Example Folder One: House and yard');
INSERT INTO Folders([Name]) VALUES ('Example Folder Two: Work');
INSERT INTO Folders([Name]) VALUES ('Example Folder Three: Creativity');

INSERT INTO Tasks([Name],Notes,DueDate,IsImportant,IsComplete,FolderId) VALUES ('Wash dishes','Do a better job this time :)',DATEADD(DAY,3,GETDATE()),0,0,(SELECT Id FROM Folders WHERE Folders.Name='Example Folder One: House and yard'));
INSERT INTO Tasks([Name],Notes,DueDate,IsImportant,IsComplete,FolderId) VALUES ('Mow lawn','Set the blade a little higher',DATEADD(DAY,7,GETDATE()),1,0,(SELECT Id FROM Folders WHERE Folders.Name='Example Folder One: House and yard'));
INSERT INTO Tasks([Name],Notes,DueDate,IsImportant,IsComplete,FolderId) VALUES ('Paint dining room','people would like to start eating in there again...',DATEADD(DAY,-1,GETDATE()),0,1,(SELECT Id FROM Folders WHERE Folders.Name='Example Folder One: House and yard'));
INSERT INTO Tasks([Name],Notes,DueDate,IsImportant,IsComplete,FolderId) VALUES ('Give dog a bath','Fifi isnt going to like this',DATEADD(DAY,1,GETDATE()),0,0,(SELECT Id FROM Folders WHERE Folders.Name='Example Folder One: House and yard'));
INSERT INTO Tasks([Name],Notes,DueDate,IsImportant,IsComplete,FolderId) VALUES ('Sweep garage','and the patio',DATEADD(DAY,14,GETDATE()),1,1,(SELECT Id FROM Folders WHERE Folders.Name='Example Folder One: House and yard'));
INSERT INTO Tasks([Name],Notes,DueDate,IsImportant,IsComplete,FolderId) VALUES ('Schedule meetings','remember to keep Wednesday afternoons free!',DATEADD(DAY,5,GETDATE()),1,0,(SELECT Id FROM Folders WHERE Folders.Name='Example Folder Two: Work'));
INSERT INTO Tasks([Name],Notes,DueDate,IsImportant,IsComplete,FolderId) VALUES ('Catch up on emails','keep an eye out for a message from IT',DATEADD(DAY,3,GETDATE()),0,0,(SELECT Id FROM Folders WHERE Folders.Name='Example Folder Two: Work'));
INSERT INTO Tasks([Name],Notes,DueDate,IsImportant,IsComplete,FolderId) VALUES ('Send thank you to marketing','they need to know how good a job they did',DATEADD(DAY,12,GETDATE()),0,1,(SELECT Id FROM Folders WHERE Folders.Name='Example Folder Two: Work'));
INSERT INTO Tasks([Name],Notes,DueDate,IsImportant,IsComplete,FolderId) VALUES ('Review LinkedIn feed','Id like to do this more often',DATEADD(DAY,1,GETDATE()),1,0,(SELECT Id FROM Folders WHERE Folders.Name='Example Folder Two: Work'));
INSERT INTO Tasks([Name],Notes,DueDate,IsImportant,IsComplete,FolderId) VALUES ('List of books for mentees','have ready for next weekly meeting',DATEADD(DAY,-3,GETDATE()),0,0,(SELECT Id FROM Folders WHERE Folders.Name='Example Folder Two: Work'));
INSERT INTO Tasks([Name],Notes,DueDate,IsImportant,IsComplete,FolderId) VALUES ('Write blog posts','schedule them to go out each month',DATEADD(DAY,0,GETDATE()),1,1,(SELECT Id FROM Folders WHERE Folders.Name='Example Folder Three: Creativity'));
INSERT INTO Tasks([Name],Notes,DueDate,IsImportant,IsComplete,FolderId) VALUES ('Touch up photos from the park','most just need cropping',DATEADD(DAY,1,GETDATE()),0,0,(SELECT Id FROM Folders WHERE Folders.Name='Example Folder Three: Creativity'));
INSERT INTO Tasks([Name],Notes,DueDate,IsImportant,IsComplete,FolderId) VALUES ('Review social media strategy','look for changes from the last version',DATEADD(DAY,5,GETDATE()),0,0,(SELECT Id FROM Folders WHERE Folders.Name='Example Folder Three: Creativity'));
INSERT INTO Tasks([Name],Notes,DueDate,IsImportant,IsComplete,FolderId) VALUES ('Renew software subscriptions','2 year plan offers the best price',DATEADD(DAY,10,GETDATE()),1,0,(SELECT Id FROM Folders WHERE Folders.Name='Example Folder Three: Creativity'));
INSERT INTO Tasks([Name],Notes,DueDate,IsImportant,IsComplete,FolderId) VALUES ('Look for alternative blogging platforms','Id like one that is more robust',DATEADD(DAY,0,GETDATE()),0,1,(SELECT Id FROM Folders WHERE Folders.Name='Example Folder Three: Creativity'));
