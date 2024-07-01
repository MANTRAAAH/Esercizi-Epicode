CREATE TABLE [dbo].[Operaio] (
    [IdDipendente]        INT             IDENTITY (1, 1) NOT NULL,
    [Nome]                NVARCHAR (50)   NOT NULL,
    [Cognome]             NVARCHAR (50)   NOT NULL,
    [CF]                  NVARCHAR (16)   NOT NULL,
    [FigliACarico]        INT             NOT NULL,
    [Sposato]             BIT             NOT NULL,
    [LivelloLavorativo]   NVARCHAR (50)   NOT NULL,
    [DescrizioneMansione] NVARCHAR (50)   NOT NULL,
    [Salario]             DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdDipendente] ASC)
);

