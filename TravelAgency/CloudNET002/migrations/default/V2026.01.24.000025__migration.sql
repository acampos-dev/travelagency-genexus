CREATE TABLE [CountryCity] ([CountryId] smallint NOT NULL , [CityId] smallint NOT NULL , [CityName] nchar(50) NOT NULL , PRIMARY KEY([CountryId], [CityId]));

ALTER TABLE [CountryCity] ADD CONSTRAINT [ICOUNTRYCITY1] FOREIGN KEY ([CountryId]) REFERENCES [Country] ([CountryId]);

