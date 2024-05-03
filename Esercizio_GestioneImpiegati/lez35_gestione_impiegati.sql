USE acc_lez35_gestione_impiegati
CREATE TABLE Provincia(
	ProvinciaID INT PRIMARY KEY IDENTITY(1,1),
	Sigla VARCHAR(2) UNIQUE NOT NULL
);
CREATE TABLE Citta(
	CittaID INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(250) UNIQUE NOT NULL,
	ProvinciaRIF INT NOT NULL,

	FOREIGN KEY (ProvinciaRIF) REFERENCES Provincia(ProvinciaID) ON DELETE CASCADE
);
CREATE TABLE Reparto(
	RepartoID INT PRIMARY KEY IDENTITY (1,1),
	Nome VARCHAR(250) UNIQUE NOT NULL,
);
CREATE TABLE Impiegato(
    ImpiegatoID INT PRIMARY KEY IDENTITY(1,1),
    Matricola VARCHAR(250) UNIQUE NOT NULL,
    Nome VARCHAR(250) NOT NULL,
    Cognome VARCHAR(250) NOT NULL,
    DataNasc DATETIME NOT NULL,
    Ruolo VARCHAR(250) NOT NULL,
    Indirizzo VARCHAR(250) NOT NULL,
    RepartoRIF INT NOT NULL,
    CittaRIF VARCHAR(250) NOT NULL,
    ProvinciaRIF VARCHAR(250) NOT NULL,

    FOREIGN KEY (RepartoRIF) REFERENCES Reparto(RepartoID) ON DELETE CASCADE,
);
 -- Inserimento di tre province
INSERT INTO Provincia (Sigla) VALUES ('RM'); -- Roma
INSERT INTO Provincia (Sigla) VALUES ('MI'); -- Milano
INSERT INTO Provincia (Sigla) VALUES ('NA'); -- Napoli

-- Inserimento di tre città, ciascuna legata a una provincia esistente
INSERT INTO Citta (Nome, ProvinciaRIF) VALUES ('Roma', 1); -- Roma (ProvinciaID 1)
INSERT INTO Citta (Nome, ProvinciaRIF) VALUES ('Milano', 2); -- Milano (ProvinciaID 2)
INSERT INTO Citta (Nome, ProvinciaRIF) VALUES ('Napoli', 3); -- Napoli (ProvinciaID 3)

-- Inserimento di tre reparti
INSERT INTO Reparto (Nome) VALUES ('Vendite');
INSERT INTO Reparto (Nome) VALUES ('Amministrazione');
INSERT INTO Reparto (Nome) VALUES ('Produzione');

-- Inserimento di due impiegati, ciascuno legato a un reparto, una città e una provincia esistenti
INSERT INTO Impiegato (Matricola, Nome, Cognome, DataNasc, Ruolo, Indirizzo, RepartoRIF, CittaRIF, ProvinciaRIF) 
VALUES ('123456', 'Mario', 'Rossi', '1990-01-01', 'Venditore', 'Via Roma 1', 1, 'Roma', 'RM');

INSERT INTO Impiegato (Matricola, Nome, Cognome, DataNasc, Ruolo, Indirizzo, RepartoRIF, CittaRIF, ProvinciaRIF) 
VALUES ('789012', 'Giuseppe', 'Verdi', '1985-05-10', 'Contabile', 'Via Milano 2', 2, 'Milano', 'MI');

-- Inserimento di un altro impiegato, legato a un reparto, una città e una provincia esistenti
INSERT INTO Impiegato (Matricola, Nome, Cognome, DataNasc, Ruolo, Indirizzo, RepartoRIF, CittaRIF, ProvinciaRIF) 
VALUES ('345678', 'Maria', 'Bianchi', '1985-05-10', 'Segretaria', 'Via Napoli 3', 3, 'Napoli', 'NA');



 SELECT * FROM Provincia;
 SELECT * FROM Impiegato;
