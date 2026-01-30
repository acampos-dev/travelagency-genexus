CREATE TABLE [Country] ([CountryId] smallint NOT NULL IDENTITY(1,1), [CountryName] nchar(50) NOT NULL , PRIMARY KEY([CountryId]));

CREATE TABLE [Attractions] ([AttractionId] smallint NOT NULL IDENTITY(1,1), [AttractionName] nchar(50) NOT NULL , [CountryId] smallint NOT NULL , PRIMARY KEY([AttractionId]));
CREATE NONCLUSTERED INDEX [IATTRACTIONS1] ON [Attractions] ([CountryId] );

ALTER TABLE [Attractions] ADD CONSTRAINT [IATTRACTIONS1] FOREIGN KEY ([CountryId]) REFERENCES [Country] ([CountryId]);

