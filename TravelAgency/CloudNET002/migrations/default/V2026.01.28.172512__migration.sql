CREATE TABLE [Flight] ([FlightId] smallint NOT NULL IDENTITY(1,1), [FlightDepartureAirportId] smallint NOT NULL , [FlightArrivalAirportId] smallint NOT NULL , PRIMARY KEY([FlightId]));
CREATE NONCLUSTERED INDEX [IFLIGHT1] ON [Flight] ([FlightDepartureAirportId] );
CREATE NONCLUSTERED INDEX [IFLIGHT2] ON [Flight] ([FlightArrivalAirportId] );

CREATE TABLE [Airport] ([AirportId] smallint NOT NULL IDENTITY(1,1), [AirPortName] nchar(50) NOT NULL , [CountryId] smallint NOT NULL , [CityId] smallint NOT NULL , PRIMARY KEY([AirportId]));
CREATE NONCLUSTERED INDEX [IAIRPORT1] ON [Airport] ([CountryId] ,[CityId] );

ALTER TABLE [Airport] ADD CONSTRAINT [IAIRPORT1] FOREIGN KEY ([CountryId], [CityId]) REFERENCES [CountryCity] ([CountryId], [CityId]);

ALTER TABLE [Flight] ADD CONSTRAINT [IFLIGHT2] FOREIGN KEY ([FlightArrivalAirportId]) REFERENCES [Airport] ([AirportId]);
ALTER TABLE [Flight] ADD CONSTRAINT [IFLIGHT1] FOREIGN KEY ([FlightDepartureAirportId]) REFERENCES [Airport] ([AirportId]);

