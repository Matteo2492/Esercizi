```Sql
CREATE TABLE Categoria (
    CategoriaID INT PRIMARY KEY IDENTITY(1,1),
    Nome VARCHAR(250) NOT NULL UNIQUE
);

CREATE TABLE Prodotto (
    ProdottoID INT PRIMARY KEY IDENTITY (1,1),
    Nome VARCHAR(250)NOT NULL UNIQUE,
    Descrizione VARCHAR(250)NOT NULL,
	CategoriaRIF INT NOT NULL,
	FOREIGN KEY (CategoriaRIF) REFERENCES Categoria(CategoriaID) ON DELETE CASCADE
);

CREATE TABLE Variazione (
    VariazioneID INT PRIMARY KEY IDENTITY (1,1),
	Codice INT NOT NULL,
	Prezzo DECIMAL(10, 2)NOT NULL CHECK(Prezzo > 0),
	PrezzoOfferta DECIMAL(10, 2) CHECK(PrezzoOfferta > 0),
    DataInizioOfferta DATE,
    DataFineOfferta DATE,
    Colore VARCHAR(250) NOT NULL,
    Taglia VARCHAR(6) NOT NULL,
    Quantita INT NOT NULL CHECK(Quantita >= 0),
	ImmagineLink VARCHAR(250),
    ProdottoRIF INT NOT NULL,
    FOREIGN KEY (ProdottoRIF) REFERENCES Prodotto(ProdottoID) ON DELETE CASCADE
);

CREATE TABLE Utente (
	UtenteID INT PRIMARY KEY IDENTITY(1,1),
    Nominativo VARCHAR(250)NOT NULL,
	Indirizzo VARCHAR(250) NOT NULL,
    Email VARCHAR(250) NOT NULL UNIQUE,
);

CREATE TABLE Ordine (
    OrdineID INT PRIMARY KEY IDENTITY(1,1),
    DataOrdine DATE DEFAULT CURRENT_TIMESTAMP,
    Stato VARCHAR(250) NOT NULL,
	PrezzoTotale DECIMAL(10, 2) NOT NULL CHECK (PrezzoTotale > 0),
    UtenteRIF INT NOT NULL,
    FOREIGN KEY (UtenteRIF) REFERENCES Utente(UtenteID) ON DELETE CASCADE,
);

CREATE TABLE OrdineVariazione(
	OrdineVariazioneID INT PRIMARY KEY IDENTITY(1,1),
	QuantitaVariazione INT NOT NULL CHECK (QuantitaVariazione > 0),
	VariazioneRIF INT NOT NULL,
	OrdineRIF INT NOT NULL,
	FOREIGN KEY (VariazioneRIF) REFERENCES Variazione(VariazioneID) ON DELETE CASCADE,
	FOREIGN KEY (OrdineRIF) REFERENCES Ordine(OrdineID) ON DELETE CASCADE
);

-- Inserts for Categoria table
INSERT INTO Categoria (Nome) VALUES ('Magliette');
INSERT INTO Categoria (Nome) VALUES ('Pantaloni');
INSERT INTO Categoria (Nome) VALUES ('Scarpe');

-- Inserts for Prodotto table
INSERT INTO Prodotto (Nome, Descrizione, CategoriaRIF) VALUES ('Maglietta Rossa', 'Maglietta rossa a maniche corte', 1);
INSERT INTO Prodotto (Nome, Descrizione, CategoriaRIF) VALUES ('Jeans Blu', 'Jeans blu aderenti', 2);
INSERT INTO Prodotto (Nome, Descrizione, CategoriaRIF) VALUES ('Scarpe da Ginnastica', 'Scarpe da ginnastica bianche', 3);

-- Inserts for Variazione table
INSERT INTO Variazione (Codice, Prezzo, Colore, Taglia, Quantita, ProdottoRIF) VALUES (12345, 29.99, 'Rosso', 'M', 50, 1);
INSERT INTO Variazione (Codice, Prezzo, Colore, Taglia, Quantita, ProdottoRIF) VALUES (54321, 49.99, 'Blu', 'L', 30, 2);
INSERT INTO Variazione (Codice, Prezzo, Colore, Taglia, Quantita, ProdottoRIF) VALUES (98765, 79.99, 'Bianco', '42', 20, 3);

-- Inserts for Utente table
INSERT INTO Utente (Nominativo, Indirizzo, Email) VALUES ('Mario Rossi', 'Via Roma 123', 'mario@example.com');
INSERT INTO Utente (Nominativo, Indirizzo, Email) VALUES ('Giulia Bianchi', 'Corso Italia 456', 'giulia@example.com');

-- Inserts for Ordine table
INSERT INTO Ordine (Stato, PrezzoTotale, UtenteRIF) VALUES ('In attesa di pagamento', 79.99, 1);
INSERT INTO Ordine (Stato, PrezzoTotale, UtenteRIF) VALUES ('Consegnato', 49.99, 2);

-- Inserts for OrdineVariazione table
INSERT INTO OrdineVariazione (QuantitaVariazione, VariazioneRIF, OrdineRIF) VALUES (2, 1, 1);
INSERT INTO OrdineVariazione (QuantitaVariazione, VariazioneRIF, OrdineRIF) VALUES (1, 2, 2);


SELECT * FROM Categoria;
SELECT * FROM Prodotto;
```
