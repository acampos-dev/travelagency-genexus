ALTER TABLE [Attractions] ADD [CityId] smallint NULL;
DROP INDEX [IATTRACTIONS1] ON [Attractions];
CREATE NONCLUSTERED INDEX [IATTRACTIONS1] ON [Attractions] ([CountryId] ,[CityId] );

ALTER TABLE [Attractions] ADD CONSTRAINT [IATTRACTIONS1] FOREIGN KEY ([CountryId], [CityId]) REFERENCES [CountryCity] ([CountryId], [CityId]);

