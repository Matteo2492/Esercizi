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

-- Inserting data into Alberghi table
INSERT INTO Alberghi (nome, indirizzo, valutazione) VALUES
('Hotel Milano', 'Via Roma 123, Milano', 4),
('Grand Hotel', 'Piazza Grande 1, Roma', 5),
('Seaside Resort', 'Via Spiaggia 5, Napoli', 4);

-- Inserting data into Camere table
INSERT INTO Camere (numero, tipo, capienza, tariffa, albergoRIF) VALUES
(101, 'Singola', 1, 100.00, 1),
(201, 'Doppia', 2, 150.00, 1),
(102, 'Singola', 1, 120.00, 2),
(202, 'Doppia', 2, 180.00, 2),
(103, 'Singola', 1, 90.00, 3),
(203, 'Doppia', 2, 140.00, 3);

-- Inserting data into Dipendenti table
INSERT INTO Dipendenti (nome, cognome, posizione, dettagli, albergoRIF) VALUES
('Marco', 'Rossi', 'Receptionist', 'Day shift', 1),
('Laura', 'Bianchi', 'Receptionist', 'Night shift', 1),
('Giuseppe', 'Verdi', 'Housekeeper', 'Floor 1', 2),
('Sara', 'Neri', 'Housekeeper', 'Floor 2', 2),
('Luca', 'Gialli', 'Receptionist', 'Day shift', 3),
('Anna', 'Marroni', 'Receptionist', 'Night shift', 3);

-- Inserting data into Clienti table
INSERT INTO Clienti (nome, cognome, contatto) VALUES
('Mario', 'Verdi', 'mario@example.com'),
('Giulia', 'Bianchi', 'giulia@example.com'),
('Paolo', 'Russo', 'paolo@example.com');

-- Inserting data into Prenotazioni table
INSERT INTO Prenotazioni (orario_checkin, orario_checkout, clienteRIF, cameraRIF) VALUES
('2024-03-15T14:00:00', '2024-03-17T10:00:00', 1, 1), 
('2024-04-20T12:00:00', '2024-04-25T10:00:00', 2, 4), 
('2024-05-10T15:00:00', '2024-05-12T12:00:00', 3, 5);

-- Inserting data into Facilities table
INSERT INTO Facilities (nome, descrizione, albergoRIF) VALUES
('Pool', 'Outdoor swimming pool', 3),
('Gym', 'Fitness center', 2),
('Restaurant', 'Fine dining restaurant', 1);

-- Inserting data into Orari table
INSERT INTO Orari (giorno, orario_apertura, orario_chiusura, facilityRIF) VALUES
('Monday', '09:00', '21:00', 3),
('Tuesday', '09:00', '21:00', 3),
('Wednesday', '09:00', '21:00', 3),
('Thursday', '09:00', '21:00', 3),
('Friday', '09:00', '22:00', 3),
('Saturday', '10:00', '22:00', 3),
('Sunday', '10:00', '22:00', 3);

SELECT * FROM Camere;
SELECT * FROM Prenotazioni;
SELECT * FROM Alberghi;
SELECT * FROM Dipendenti;
SELECT * FROM Clienti;
SELECT * FROM Facilities;
SELECT * FROM Orari;

SELECT * FROM Clienti 
	JOIN Prenotazioni ON Clienti.clienteID = Prenotazioni.clienteRIF
	JOIN Camere On Prenotazioni.cameraRIF = Camere.albergoRIF;