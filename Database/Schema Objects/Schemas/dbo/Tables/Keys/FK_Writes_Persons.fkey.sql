﻿ALTER TABLE [dbo].[Writes]
    ADD CONSTRAINT [FK_Writes_Persons] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Persons] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

