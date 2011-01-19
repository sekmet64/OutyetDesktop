ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [outyet], FILENAME = '$(DefaultDataPath)$(DatabaseName).mdf', FILEGROWTH = 1024 KB) TO FILEGROUP [PRIMARY];

