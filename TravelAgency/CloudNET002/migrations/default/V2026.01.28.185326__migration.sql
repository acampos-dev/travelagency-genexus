ALTER TABLE [Flight] ADD [FlightPrice] money NOT NULL CONSTRAINT FlightPriceFlight_DEFAULT DEFAULT convert(int, 0), [FlightDiscountPercentage] smallint NOT NULL CONSTRAINT FlightDiscountPercentageFlight_DEFAULT DEFAULT convert(int, 0);
ALTER TABLE [Flight] DROP CONSTRAINT FlightPriceFlight_DEFAULT;
ALTER TABLE [Flight] DROP CONSTRAINT FlightDiscountPercentageFlight_DEFAULT;

