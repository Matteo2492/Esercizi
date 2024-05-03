USE mario
CREATE TABLE Personaggio(
	PersonaggioID INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(250) NOT NULL UNIQUE,
	Categoria VARCHAR(250) NOT NULL CHECK (Categoria IN ('50cc', '100cc', '150cc')),
	Costo INT NOT NULL CHECK (Costo BETWEEN 1 AND 4),
	Descrizione VARCHAR(250) NOT NULL
);

CREATE TABLE Squadra (
	SquadraID INT PRIMARY KEY IDENTITY(1,1),
	Username VARCHAR(250) NOT NULL UNIQUE,
	Crediti INT NOT NULL CHECK (Crediti >= 0 AND Crediti <= 10),
	PersonaggioCinquantaRIF INT UNIQUE,
	PersonaggioCentoRIF INT UNIQUE,
	PersonaggioCentoCinquantaRIF INT UNIQUE,
	FOREIGN KEY (PersonaggioCinquantaRIF) REFERENCES Personaggio(PersonaggioID),
    FOREIGN KEY (PersonaggioCentoRIF) REFERENCES Personaggio(PersonaggioID),
    FOREIGN KEY (PersonaggioCentoCinquantaRIF) REFERENCES Personaggio(PersonaggioID)
);

INSERT INTO Personaggio (Nome,Categoria,Costo,Descrizione) VALUES
('Francuccio','50cc',3,'Spigne forte'),
('Mario','100cc',2,'Spigne Medio'),
('Anna Oxa','150cc',4,'Spigne na cifra'),
('Marcolino pane e vino','50cc',1,'Spigne?'),
('Damioski','100cc',2,'Rifà lo scaffolding'),
('Bryan','150cc',4,'Daddy'),
('Ramil','50cc',3,'Paga na cifra'),
('Valerio','100cc',2,'Odia la droga'),
('Matteo','150cc',4,'Babbeo');

INSERT INTO Squadra (Username,Crediti,PersonaggioCinquantaRIF,PersonaggioCentoRIF,PersonaggioCentoCinquantaRIF) VALUES
('Squadra uno',10,1,2,3),
('Squadra due',10,4,5,6),
('Squadra tre',10,7,8,9);

SELECT*FROM Personaggio
SELECT*FROM Squadra