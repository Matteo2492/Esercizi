CREATE TABLE Prodotti(
	prodottoID INT PRIMARY KEY IDENTITY(1,1),
	codice_prodotto UNIQUEIDENTIFIER DEFAULT NEWID(),
	nome VARCHAR (250) UNIQUE NOT NULL,
	quantita INT CHECK (quantita >= 0) DEFAULT 0,
	prezzo DECIMAL(10, 2) CHECK (prezzo > 0) NOT NULL,
	descrizione TEXT,
	categoria VARCHAR(250) CHECK (categoria IN ('strumenti manuali', 'fissaggi e accessori', 'materiali da costruzione')),
);

CREATE TABLE Utente(
	utenteID INT PRIMARY KEY IDENTITY(1,1),
	username VARCHAR(250) UNIQUE NOT NULL,
	nominativo VARCHAR(250) NOT NULL,
	password_utente VARCHAR(250) NOT NULL,
);

SELECT * FROM Prodotti;
SELECT * FROM Utente;

