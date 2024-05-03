USE Chattero
CREATE TABLE Utente( 
	utenteID INT PRIMARY KEY IDENTITY(1,1),
	codice_utente VARCHAR(250) DEFAULT NEWID(), 
	username VARCHAR(250) NOT NULL UNIQUE, 
	passw VARCHAR(250) NOT NULL,
	isDeleted DATETIME NULL
);
INSERT INTO Utente (username, passw) VALUES ('user1', 'password1');
INSERT INTO Utente (username, passw) VALUES ('user2', 'password2');
INSERT INTO Utente (username, passw) VALUES ('user3', 'password3');
INSERT INTO Utente (username, passw) VALUES ('user4', 'password4');
INSERT INTO Utente (username, passw) VALUES ('user5', 'password5');
INSERT INTO Utente (username, passw) VALUES ('user6', 'password6');
INSERT INTO Utente (username, passw) VALUES ('user7', 'password7');
INSERT INTO Utente (username, passw) VALUES ('user8', 'password8');
INSERT INTO Utente (username, passw) VALUES ('user9', 'password9');
INSERT INTO Utente (username, passw) VALUES ('user10', 'password10');

SELECT * FROM Utente