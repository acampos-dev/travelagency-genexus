ALTER TABLE [Attractions] ADD [CategoryId] smallint NULL , [AttractionPhoto] VARBINARY(MAX) NOT NULL CONSTRAINT AttractionPhotoAttractions_DEFAULT DEFAULT CONVERT(varbinary(1), ''), [AttractionPhoto_GXI] varchar(2048) NOT NULL CONSTRAINT AttractionPhoto_GXIAttractions_DEFAULT DEFAULT '';
ALTER TABLE [Attractions] DROP CONSTRAINT AttractionPhotoAttractions_DEFAULT;
ALTER TABLE [Attractions] DROP CONSTRAINT AttractionPhoto_GXIAttractions_DEFAULT;
CREATE NONCLUSTERED INDEX [IATTRACTIONS2] ON [Attractions] ([CategoryId] );

CREATE TABLE [Category] ([CategoryId] smallint NOT NULL IDENTITY(1,1), [CategoryName] nchar(50) NOT NULL , PRIMARY KEY([CategoryId]));

ALTER TABLE [Attractions] ADD CONSTRAINT [IATTRACTIONS2] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([CategoryId]);

