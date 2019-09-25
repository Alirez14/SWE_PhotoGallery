USE Photographer


SELECT * FROM Photos

alter table Photos drop FilePath Varchar(50) Null default ''

DECLARE @NUM INT = 7;
Declare @id int = 42

WHILE @NUM <10
BEGIN
	Update Photos Set FilePath = '/Photos/Sina_Barakati/pic' + Convert(varchar(50),@NUM) + '.jpg' Where Id = @id;
	SET @NUM = @NUM + 1;
	Set @id = @id + 1;
END



delete from Photos where Id = 41