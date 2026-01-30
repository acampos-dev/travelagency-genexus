ALTER TABLE [Flight] ADD [AirlineId] smallint NULL;
CREATE NONCLUSTERED INDEX [IFLIGHT3] ON [Flight] ([AirlineId] );

CREATE TABLE [Airline] ([AirlineId] smallint NOT NULL IDENTITY(1,1), [AirlineName] nchar(50) NOT NULL , [AirlineDiscountPercentage] smallint NOT NULL , PRIMARY KEY([AirlineId]));

ALTER TABLE [Flight] ADD CONSTRAINT [IFLIGHT3] FOREIGN KEY ([AirlineId]) REFERENCES [Airline] ([AirlineId]);

