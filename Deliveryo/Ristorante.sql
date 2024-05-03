USE Deliveryo
CREATE TABLE Utente(
	utenteID INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(250) NOT NULL,
	email VARCHAR(250) UNIQUE NOT NULL,
	passwordUtente VARCHAR(250) NOT NULL
);

CREATE TABLE Ristorante(
	ristoranteID INT PRIMARY KEY IDENTITY(1,1),
	codice VARCHAR(250) UNIQUE NOT NULL,
	nome VARCHAR(250) NOT NULL,
	tipoCucina VARCHAR(250) NOT NULL CHECK (tipoCucina IN ('italiano', 'cinese', 'messicano')),
	descrizione TEXT NOT NULL,
	orarioApertura TIME NOT NULL,
	orarioChiusura TIME NOT NULL
);

CREATE TABLE Menu(
	menuID INT PRIMARY KEY IDENTITY(1,1),
	codice VARCHAR(250) UNIQUE NOT NULL,
	ristoranteRIF INT NOT NULL,
	FOREIGN KEY (ristoranteRIF) REFERENCES Ristorante (ristoranteID) ON DELETE CASCADE,
);

CREATE TABLE Piatto(
	piattoID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL,
	descrizione TEXT,
	prezzo DECIMAL(10,2),
	menuRIF INT NOT NULL,
	quantita INT DEFAULT 0,
	FOREIGN KEY (menuRIF) REFERENCES Menu (menuID)  ON DELETE CASCADE,
);

CREATE TABLE Ordini(
	ordineID INT PRIMARY KEY IDENTITY(1,1),
	codice VARCHAR(250) UNIQUE NOT NULL,
	dataOrdine DATETIME NOT NULL,
	dataOraConsegnaPrevista DATETIME NOT NULL,
	utenteRIF INT NOT NULL,
	FOREIGN KEY (utenteRIF) REFERENCES Utente (utenteID) ON DELETE CASCADE,
);

CREATE TABLE OrdiniPiatti(
	ordineRIF INT NOT NULL,
	piattoRIF INT NOT NULL,
	FOREIGN KEY (ordineRIF) REFERENCES Ordini (ordineID) ON DELETE CASCADE,
	FOREIGN KEY (piattoRIF) REFERENCES Piatto (piattoID) ON DELETE CASCADE,
	PRIMARY KEY (ordineRIF,piattoRIF)
);

INSERT INTO Utente (nome, email, passwordUtente)
VALUES ('Mario Rossi', 'mario@example.com', 'password123'),
       ('Giovanna Bianchi', 'giovanna@example.com', 'securepass'),
       ('Luigi Verdi', 'luigi@example.com', 'strongpassword');
INSERT INTO Ristorante (codice, nome, tipoCucina, descrizione, orarioApertura, orarioChiusura)
VALUES ('RIST001', 'Pizzeria da Luigi', 'italiano', 'La migliore pizza in città', '10:00', '22:00'),
       ('RIST002', 'Ristorante Cinese Yang', 'cinese', 'Autentica cucina cinese', '11:30', '23:00'),
       ('RIST003', 'Taco Loco', 'messicano', 'I migliori taco della città', '12:00', '21:30');
INSERT INTO Menu (codice, ristoranteRIF)
VALUES ('MENU001', 1),
       ('MENU002', 2),
       ('MENU003', 3);
INSERT INTO Piatto (nome, descrizione, prezzo, menuRIF, quantita)
VALUES ('Pizza Margherita', 'Mozzarella, pomodoro e basilico', 8.50, 1, 50),
       ('Anatra all arancia', 'Anatra cotta alla perfezione con salsa arancia', 15.99, 2, 30),
       ('Taco al pastor', 'Tortilla con carne di maiale marinata', 6.99, 3, 40);

INSERT INTO Ordini (codice, dataOrdine, dataOraConsegnaPrevista, utenteRIF)
VALUES ('ORD001', '28-04-2024 13:45:00', '28-04-2024 14:30:00', 1),
       ('ORD002', '28-04-2024 18:20:00', '28-04-2024 19:15:00', 2),
       ('ORD003', '28-04-2024 20:10:00', '28-04-2024 21:00:00', 5);



INSERT INTO OrdiniPiatti (ordineRIF, piattoRIF)
VALUES (12, 1), -- Ordine 1, Piatto 1 (Pizza Margherita)
       (11, 2), -- Ordine 2, Piatto 2 (Anatra all'arancia)
       (13, 3); -- Ordine 3, Piatto 3 (Taco al pastor)


SELECT * FROM Utente
SELECT * FROM Ristorante
SELECT * FROM Menu
SELECT * FROM Piatto
SELECT * FROM Ordini
SELECT * FROM OrdiniPiatti

 