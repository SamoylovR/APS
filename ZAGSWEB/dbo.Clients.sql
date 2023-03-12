CREATE TABLE [dbo].[Clients] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [name]       VARCHAR (100) NOT NULL,
    [surname]    VARCHAR (100) NOT NULL,
    [secondname] VARCHAR (100) NOT NULL,
    [email]      VARCHAR (150) NULL,
    [phone]      VARCHAR (20)  NULL,
    [birthday]   DATE          NOT NULL,
    [Created_at] DATETIME      DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([email] ASC)
);

