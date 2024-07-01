CREATE TABLE [dbo].[Cantiere] (
    [IdCantiere]            INT           IDENTITY (1, 1) NOT NULL,
    [DenominazioneCantiere] NVARCHAR (50) NOT NULL,
    [Indirizzo]             NVARCHAR (50) NOT NULL,
    [Citta]                 NVARCHAR (50) NOT NULL,
    [CAP]                   NCHAR (10)    NOT NULL,
    [PersonaRiferimento]    NVARCHAR (50) NOT NULL,
    [DataInizioLavori]      DATE          NOT NULL,
    [DataFineLavori]        DATE          NOT NULL,
    [LavoriTerminatiSI_NO]  BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([IdCantiere] ASC)
);

