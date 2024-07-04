CREATE TABLE IMPIEGATO (
    IDImpiegato INT IDENTITY(1,1) PRIMARY KEY,
    Cognome NVARCHAR(50),
    Nome NVARCHAR(50),
    CodiceFiscale NVARCHAR(16),
    Eta INT,
    RedditoMensile DECIMAL(10, 2),
    DetrazioneFiscale BIT
);

CREATE TABLE IMPIEGO (
    IDImpiego INT IDENTITY(1,1) PRIMARY KEY,
    TipoImpiego NVARCHAR(50),
    Assunzione DATETIME,
    IDImpiegato INT FOREIGN KEY REFERENCES IMPIEGATO(IDImpiegato)
);

