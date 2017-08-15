create schema history
go
-- Add the columns in which 'temporality' will be stored (basically, the start and end 'applicability' times for the row)
ALTER TABLE [Address]
   ADD  
        SysStartTime datetime2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
         SysEndTime   datetime2(0) NOT NULL DEFAULT CONVERT(datetime2 (0), '9999-12-31 23:59:59')
GO
ALTER TABLE [Address]
   ADD
      PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime);  
GO
ALTER TABLE [Address]
       ALTER COLUMN SysStartTime ADD HIDDEN
GO
ALTER TABLE [Address]
       ALTER COLUMN SysEndTime ADD HIDDEN
GO
-- Change any foreign key references from this table which have CASCADE DELETE or CASCADE UPDATE to have action 'None'
-- Enable system_versioning
ALTER TABLE [Address]  
   SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = history.[Address]))
GO

