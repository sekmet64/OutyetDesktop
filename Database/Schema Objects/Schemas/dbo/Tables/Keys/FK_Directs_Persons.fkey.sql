﻿ALTER TABLE [dbo].[Directs]
    ADD CONSTRAINT [FK_Directs_Persons] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Persons] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

