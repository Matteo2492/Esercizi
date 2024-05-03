USE acc_lez28_eventi;
CREATE TABLE Partecipanti (
	PartecipanteID INT PRIMARY KEY IDENTITY (1,1),
	Nome VARCHAR(250) NOT NULL,
	Contatto VARCHAR(250) NOT NULL UNIQUE
);

CREATE TABLE Risorse(
	RisorsaID INT PRIMARY KEY IDENTITY (1,1),
	NomeRisorsa VARCHAR(250) NOT NULL,
	Tipo VARCHAR(250) NOT NULL,
	Quantita INT NOT NULL,
	Costo FLOAT NOT NULL,
	Fornitore VARCHAR(250) NOT NULL
);

CREATE TABLE Eventi (
	EventiID INT PRIMARY KEY IDENTITY (1,1),
	PartecipanteRIF INT,
	RisorseRIF INT NOT NULL,
	NomeEvento VARCHAR(250) NOT NULL,
	Descrizione VARCHAR(250),
	DataEvento DATETIME NOT NULL,
	Luogo VARCHAR(250) NOT NULL,
	Capacita INT NOT NULL
	FOREIGN KEY (PartecipanteRIF) REFERENCES Partecipanti(PartecipanteID),
	FOREIGN KEY (RisorseRIF) REFERENCES Risorse(RisorsaID)
);

SELECT * FROM Partecipanti;
SELECT * FROM Risorse;
SELECT * FROM Eventi;