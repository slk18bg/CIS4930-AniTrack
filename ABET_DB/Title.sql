CREATE TABLE [dbo].[Title]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GenreId] INT NULL, 
    [TitleName] VARCHAR(50) NULL, 
    [Episodes] INT NULL, 
    [YearReleased] INT NULL, 
    [AverageRating] FLOAT NULL, 
    CONSTRAINT [FK_Title_ToGenre] FOREIGN KEY ([GenreId]) REFERENCES [Genre]([Id]) ON DELETE CASCADE
)
