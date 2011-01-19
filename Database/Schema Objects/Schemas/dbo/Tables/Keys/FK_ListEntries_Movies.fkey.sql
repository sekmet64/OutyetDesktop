ALTER TABLE [dbo].[ListEntries]
    ADD CONSTRAINT [FK_ListEntries_Movies] FOREIGN KEY ([Movie]) REFERENCES [dbo].[Movies] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

