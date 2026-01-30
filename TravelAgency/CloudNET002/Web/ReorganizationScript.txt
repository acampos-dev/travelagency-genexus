CREATE TABLE [Supplier] ([SupplierId] smallint NOT NULL IDENTITY(1,1), [SupplierName] nchar(50) NOT NULL , [SupplierAddress] nvarchar(1024) NOT NULL , PRIMARY KEY([SupplierId]));

ALTER TABLE [Attractions] ADD [SupplierId] smallint NOT NULL CONSTRAINT SupplierIdAttractions_DEFAULT DEFAULT convert(int, 0);
ALTER TABLE [Attractions] DROP CONSTRAINT SupplierIdAttractions_DEFAULT;
SET IDENTITY_INSERT [Supplier] ON;
INSERT INTO [Supplier] ([SupplierId], [SupplierName], [SupplierAddress]) SELECT TOP 1 convert(int, 0), ' ', ' ' FROM [Attractions];
SET IDENTITY_INSERT [Supplier] OFF;
CREATE NONCLUSTERED INDEX [IATTRACTIONS3] ON [Attractions] ([SupplierId] );

ALTER TABLE [Attractions] ADD CONSTRAINT [IATTRACTIONS3] FOREIGN KEY ([SupplierId]) REFERENCES [Supplier] ([SupplierId]);

