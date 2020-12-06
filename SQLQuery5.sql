/****** Script for SelectTopNRows command from SSMS  ******/
Insert into Additions(CreatedOn, IsDeleted, Name, Value)
values (GETDATE(), 0, 1, 30),
	(GETDATE(), 0, 2, 30),
	(GETDATE(), 0, 3, 30)
