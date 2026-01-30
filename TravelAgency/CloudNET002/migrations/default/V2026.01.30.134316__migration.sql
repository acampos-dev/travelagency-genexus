CREATE TABLE [SupplierAttraction] ([SupplierId] smallint NOT NULL , [AttractionId] smallint NOT NULL , [SupplierAttractionDate] datetime NOT NULL , PRIMARY KEY([SupplierId], [AttractionId]));
CREATE NONCLUSTERED INDEX [ISUPPLIERATTRACTION1] ON [SupplierAttraction] ([AttractionId] );
INSERT INTO [SupplierAttraction] ([SupplierId], [AttractionId], [SupplierAttractionDate]) SELECT [SupplierId], [AttractionId], convert( DATETIME, '17530101', 112 ) FROM [Attractions] T  WHERE NOT EXISTS (SELECT 1 FROM [SupplierAttraction] WHERE SupplierId= T.SupplierId AND AttractionId= T.AttractionId);

DROP INDEX [IATTRACTIONS3] ON [Attractions];
ALTER TABLE [Attractions] DROP CONSTRAINT [IATTRACTIONS3];
ALTER TABLE [Attractions] DROP COLUMN [SupplierId];

ALTER TABLE [SupplierAttraction] ADD CONSTRAINT [ISUPPLIERATTRACTION2] FOREIGN KEY ([SupplierId]) REFERENCES [Supplier] ([SupplierId]);
ALTER TABLE [SupplierAttraction] ADD CONSTRAINT [ISUPPLIERATTRACTION1] FOREIGN KEY ([AttractionId]) REFERENCES [Attractions] ([AttractionId]);

