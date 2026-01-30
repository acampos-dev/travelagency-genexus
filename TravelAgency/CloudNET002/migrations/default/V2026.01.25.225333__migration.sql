ALTER TABLE [Customer] ADD [CustomerAddedDate] datetime NOT NULL CONSTRAINT CustomerAddedDateCustomer_DEFAULT DEFAULT convert( DATETIME, '17530101', 112 );
ALTER TABLE [Customer] DROP CONSTRAINT CustomerAddedDateCustomer_DEFAULT;

