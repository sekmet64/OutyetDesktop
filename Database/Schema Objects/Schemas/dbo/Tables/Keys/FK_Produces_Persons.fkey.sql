﻿ALTER TABLE [dbo].[Produces]
    ADD CONSTRAINT [FK_Produces_Persons] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Persons] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

