select Nome,Cognome,Eta from IMPIEGATO where Eta > 29; --a

select Nome,Cognome,RedditoMensile from IMPIEGATO where RedditoMensile > 800; --b

Select Nome,Cognome,IDImpiegato,DetrazioneFiscale from IMPIEGATO where DetrazioneFiscale = 1; --c
Select Nome,Cognome,IDImpiegato,DetrazioneFiscale from IMPIEGATO where DetrazioneFiscale = 0; --d

SELECT * FROM IMPIEGATO WHERE Cognome LIKE 'G%' ORDER BY Cognome; --e

SELECT COUNT(*) AS NumeroImpiegati FROM IMPIEGATO --f

SELECT SUM(RedditoMensile) AS TotaleRedditi FROM IMPIEGATO; --g

SELECT AVG(RedditoMensile) AS MediaRedditi FROM IMPIEGATO; --h

SELECT MAX(RedditoMensile) AS MassimoReddito FROM IMPIEGATO; --i

SELECT MIN(RedditoMensile) AS MinimoReddito FROM IMPIEGATO; --j

SELECT * FROM IMPIEGO WHERE Assunzione BETWEEN '2016-01-01' AND '2018-01-01';  --k

DECLARE @TipoImpiego NVARCHAR(50) = 'Developer'; --i
SELECT I.* 
FROM IMPIEGATO I
INNER JOIN IMPIEGO P ON I.IDImpiegato = P.IDImpiegato
WHERE P.TipoImpiego = @TipoImpiego;

SELECT AVG(Eta) AS EtaMedia FROM IMPIEGATO; --







