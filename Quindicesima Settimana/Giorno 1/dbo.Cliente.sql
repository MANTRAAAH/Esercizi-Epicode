CREATE TABLE [dbo].[Cliente] (
    [IdCliente]   INT           IDENTITY (1, 1) NOT NULL,
    [Nome]        NVARCHAR (50) NOT NULL,
    [Cognome]     NVARCHAR (50) NOT NULL,
    [DataNascita] DATE          NOT NULL,
    [Sesso]       CHAR (1)      NULL,
    [CF]          CHAR (16)     NULL,
    [P.IVA]       CHAR (11)     NULL,
    [Attivo]      BIT           NOT NULL,
    [Saldo]       MONEY         NULL,
    PRIMARY KEY CLUSTERED ([IdCliente] ASC)
);

