DROP TABLE Utenti
DROP TABLE Corsi
DROP TABLE Prenotazioni
DROP TABLE PrenotazioniUtenti
CREATE TABLE Utenti(
	UtenteID INT PRIMARY KEY IDENTITY(1,1),
	Codice VARCHAR(250) UNIQUE NOT NULL,
	Nominativo VARCHAR(250) UNIQUE NOT NULL,
	PasswordUtente VARCHAR(100) NOT NULL
);

CREATE TABLE Corsi(
    CorsoID INT PRIMARY KEY IDENTITY(1,1),
    Codice VARCHAR(250) UNIQUE DEFAULT CONCAT('CORSO_', CONVERT(VARCHAR(36), NEWID())),
    Nome VARCHAR(250) UNIQUE NOT NULL,
    Descrizione VARCHAR(250) NOT NULL,
    Tipo VARCHAR(250) NOT NULL CHECK (Tipo IN ('principiante', 'intermedio', 'avanzato')),
    DataInizioCorso DATETIME NOT NULL,
    Durata TIME NOT NULL, -- Duration of the course (e.g., 1 hour)
    Posti INT NOT NULL CHECK (Posti >= 0),
    CONSTRAINT CK_Data CHECK (DataInizioCorso < DATEADD(HOUR, 1, DataInizioCorso))
);

CREATE TABLE Prenotazioni(
    PrenotazioneID INT PRIMARY KEY IDENTITY,
	Codice VARCHAR(250) UNIQUE DEFAULT CONCAT('PRENOTAZIONE_', CONVERT(VARCHAR(36), NEWID())),
    DataPrenotazione DATETIME DEFAULT GETDATE(),  
    CorsoRIF INT NOT NULL,
    FOREIGN KEY (CorsoRIF) REFERENCES Corsi(CorsoID) 
);

CREATE TABLE PrenotazioniUtenti (
    PrenotazioneUtenteID INT PRIMARY KEY IDENTITY(1,1),
    PrenotazioneID INT NOT NULL,
    UtenteID INT NOT NULL,
    FOREIGN KEY (PrenotazioneID) REFERENCES Prenotazioni(PrenotazioneID),
    FOREIGN KEY (UtenteID) REFERENCES Utenti(UtenteID),
    CONSTRAINT UQ_PrenotazioneUtente UNIQUE (PrenotazioneID, UtenteID)
);

-- Inserting users
INSERT INTO Utenti (Codice, Nominativo, PasswordUtente)
VALUES 
('USR001', 'John Doe', 'password123'),
('USR002', 'Jane Smith', 'gymlover456'),
('USR003', 'Michael Johnson', 'fitness789');

-- Inserting courses
INSERT INTO Corsi (Codice, Nome, Descrizione, Tipo, DataInizioCorso, Durata, Posti)
VALUES 
('CORSO_1', 'Yoga Class', 'Relax and rejuvenate with our yoga sessions', 'principiante', '2024-05-01 10:00:00', '01:00:00', 20),
('CORSO_2', 'Cardio Blast', 'High-intensity cardio workout for fat burning', 'avanzato', '2024-05-03 18:00:00', '01:30:00', 15),
('CORSO_3', 'Strength Training', 'Build muscle and strength with our weightlifting program', 'intermedio', '2024-05-05 16:00:00', '01:15:00', 10);

-- Inserting bookings
INSERT INTO Prenotazioni (CorsoRIF)
VALUES 
(1), -- John Doe books Yoga Class
(2), -- Jane Smith books Cardio Blast
(3); -- Michael Johnson books Strength Training

-- Associating bookings with users
INSERT INTO PrenotazioniUtenti (PrenotazioneID, UtenteID)
VALUES 
(1, 1), -- John Doe's booking for Yoga Class
(2, 2), -- Jane Smith's booking for Cardio Blast
(3, 3); -- Michael Johnson's booking for Strength Training


	SELECT * FROM Utenti
	SELECT * FROM Corsi
	SELECT * FROM Prenotazioni
	SELECT* FROM PrenotazioniUtenti
