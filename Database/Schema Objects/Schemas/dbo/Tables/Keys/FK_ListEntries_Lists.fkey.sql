﻿ALTER TABLE [dbo].[ListEntries]
    ADD CONSTRAINT [FK_ListEntries_Lists] FOREIGN KEY ([List]) REFERENCES [dbo].[Lists] ([ID]) ON DELETE CASCADE ON UPDATE NO ACTION;



