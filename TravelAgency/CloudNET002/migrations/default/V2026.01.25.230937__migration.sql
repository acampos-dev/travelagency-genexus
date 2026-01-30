ALTER TABLE [Country] ADD [CountryLastLine] smallint NOT NULL CONSTRAINT CountryLastLineCountry_DEFAULT DEFAULT convert(int, 0);
ALTER TABLE [Country] DROP CONSTRAINT CountryLastLineCountry_DEFAULT;

