CREATE TABLE Alberghi(
	albergoID INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(250)NOT NULL UNIQUE,
	indirizzo VARCHAR(250)NOT NULL UNIQUE,
	valutazione INT CHECK(valutazione BETWEEN 1 AND 5)
);

CREATE TABLE Camere (
	cameraID INT PRIMARY KEY IDENTITY(1,1),
	numero INT NOT NULL,
	tipo VARCHAR(250)NOT NULL,
	capienza INT NOT NULL,
	tariffa DECIMAL(10,2)NOT NULL CHECK(tariffa > 0),
	albergoRIF INT NOT NULL,
	FOREIGN KEY (albergoRIF) REFERENCES Alberghi(albergoID)
);
ALTER TABLE Camere ADD CONSTRAINT Check_CapacitaNonNegativa CHECK (capienza >= 0);
ALTER TABLE Camere ADD CONSTRAINT UQ_NumeroCamera_Albergo UNIQUE(numero,albergoRIF);

CREATE TABLE Dipendenti(
	dipendenteID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250)NOT NULL,
	cognome VARCHAR(250)NOT NULL,
	posizione VARCHAR(250)NOT NULL,
	dettagli VARCHAR(250)NOT NULL,
	albergoRIF INT NOT NULL,
	FOREIGN KEY (albergoRIF) REFERENCES Alberghi(albergoID)
);

CREATE TABLE Clienti(
	clienteID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250)NOT NULL,
	cognome VARCHAR(250)NOT NULL,
	contatto VARCHAR(250)NOT NULL
);
ALTER TABLE Clienti ADD CONSTRAINT Check_ContattoNonVuoto CHECK (contatto <> '');

CREATE TABLE Prenotazioni(
	prenotazioneID INT PRIMARY KEY IDENTITY(1,1),
	orario_checkin DATETIME NOT NULL,
	orario_checkout DATETIME,
	clienteRIF INT NOT NULL,
	cameraRIF INT NOT NULL,
	FOREIGN KEY (clienteRIF) REFERENCES Clienti(clienteID),
	FOREIGN KEY (cameraRIF) REFERENCES Camere(cameraID),
);
ALTER TABLE Prenotazioni ADD CONSTRAINT Check_CheckInCheckOut CHECK(orario_checkin < orario_checkout);

CREATE TABLE Facilities(
	facilityID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250)NOT NULL,
	descrizione VARCHAR(250)NOT NULL,
	albergoRIF INT NOT NULL,
	FOREIGN KEY (albergoRIF) REFERENCES Alberghi(albergoID)
);

CREATE TABLE Orari(
	orarioID INT PRIMARY KEY IDENTITY (1,1),
	giorno VARCHAR(50) NOT NULL,
	orario_apertura TIME NOT NULL,
	orario_chiusura TIME NOT NULL,
	facilityRIF INT NOT NULL,
	FOREIGN KEY (facilityRIF) REFERENCES Facilities(facilityID)
);