CREATE TABLE [FlightSeat] ([FlightId] smallint NOT NULL , [FlightSeatId] smallint NOT NULL , [FlightSeatChar] nchar(1) NOT NULL , [FlightSeatLocation] nchar(1) NOT NULL , PRIMARY KEY([FlightId], [FlightSeatId], [FlightSeatChar]));

ALTER TABLE [FlightSeat] ADD CONSTRAINT [IFLIGHTSEAT1] FOREIGN KEY ([FlightId]) REFERENCES [Flight] ([FlightId]);

