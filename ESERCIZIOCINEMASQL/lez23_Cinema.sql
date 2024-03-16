DROP TABLE IF EXISTS Employee
DROP TABLE IF EXISTS Review
DROP TABLE IF EXISTS Customer
DROP TABLE IF EXISTS Ticket
DROP TABLE IF EXISTS Showtime
DROP TABLE IF EXISTS Movie
DROP TABLE IF EXISTS Theater
DROP TABLE IF EXISTS Cinema
CREATE TABLE Cinema (
CinemaID INT PRIMARY KEY IDENTITY,
Name VARCHAR(100) NOT NULL,
Address VARCHAR(255) NOT NULL,
Phone VARCHAR(20)
);
CREATE TABLE Theater (
TheaterID INT PRIMARY KEY IDENTITY,
CinemaID INT,
Name VARCHAR(50) NOT NULL,
Capacity INT NOT NULL,
ScreenType VARCHAR(50),
FOREIGN KEY (CinemaID) REFERENCES Cinema(CinemaID)
);
CREATE TABLE Movie (
MovieID INT PRIMARY KEY IDENTITY,
Title VARCHAR(255) NOT NULL,
Director VARCHAR(100),
ReleaseDate DATE,
DurationMinutes INT,
Rating VARCHAR(5)
);
CREATE TABLE Showtime (
ShowtimeID INT PRIMARY KEY IDENTITY,
MovieID INT,
TheaterID INT,
ShowDateTime DATETIME NOT NULL,
Price DECIMAL(5,2) NOT NULL,
FOREIGN KEY (MovieID) REFERENCES Movie(MovieID),
FOREIGN KEY (TheaterID) REFERENCES Theater(TheaterID)
);
CREATE TABLE Customer (
CustomerID INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Email VARCHAR(100),
PhoneNumber VARCHAR(20)
);
CREATE TABLE Ticket (
TicketID INT PRIMARY KEY IDENTITY,
SeatNumber VARCHAR(10) NOT NULL,
PurchasedDateTime DATETIME NOT NULL,
CustomerID INT,
ShowtimeID INT,
FOREIGN KEY (ShowtimeID) REFERENCES Showtime(ShowtimeID),
FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

CREATE TABLE Review (
ReviewID INT PRIMARY KEY IDENTITY,
MovieID INT,
CustomerID INT,
ReviewText TEXT,
Rating INT CHECK (Rating >= 1 AND Rating <= 5),
ReviewDate DATETIME NOT NULL,
FOREIGN KEY (MovieID) REFERENCES Movie(MovieID),
FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

CREATE TABLE Employee (
EmployeeID INT PRIMARY KEY IDENTITY,
CinemaID INT,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Position VARCHAR(50),
HireDate DATE,
FOREIGN KEY (CinemaID) REFERENCES Cinema(CinemaID)
);

INSERT INTO Cinema (Name, Address, Phone) VALUES
    ('Moderno','Via moderna', '3334445555'),
    ('Astoria','Via astoria', '3334445556'),
    ('Buster','Via buster', '3334445557');

INSERT INTO Theater (CinemaID, Name, Capacity, ScreenType) VALUES
    (1,'Sala 1',50,'normale'),
    (1,'Sala 2',50,'3D'),
    (1,'Sala 3',50,'normale'),
    (2,'Sala A',50,'3D'),
    (2,'Sala B',50,'normale'),
    (2,'Sala C',50,'3D'),
    (3,'Sala A1',50,'normale'),
    (3,'Sala A2',50,'3D'),
    (3,'Sala A3',50,'normale');

INSERT INTO Movie (Title, ReleaseDate, Director, DurationMinutes, Rating) VALUES
    ('Colpo di fortuna','2023-02-16','Steven spielberg',90,'16+'),
    ('Shrek II','2016-03-21','Dreamworks',110,'3+'),
    ('Puss in boots','2022-10-01','Dreamworks',90,'16+');

INSERT INTO Showtime (MovieID, TheaterID, ShowDateTime, Price) VALUES
    (2,6,'2024-04-20T18:00:00',6.00),
    (1,8,'2024-04-22T20:00:00',8.50),
    (3,2,'2024-04-27T19:30:00',9.00);

INSERT INTO Customer (FirstName, LastName, PhoneNumber, Email) VALUES
    ('Giangiacomo','della Villa','3412345672','bad.boi@libero.it'),
    ('Sten','Onesis',null,null),
    ('Claudio','Ma','0612345670','clad.ma@gmail.com');
INSERT INTO Ticket (CustomerID, ShowtimeID, PurchasedDateTime, SeatNumber) VALUES
    (1,1,'2024-04-20T17:50:00','12'),
    (1,2,'2024-04-20T19:50:00','27'),
    (2,1,'2024-04-20T17:50:00','13'),
    (2,3,'2024-04-20T19:10:00','14'),
    (3,2,'2024-04-20T17:50:00','43'),
    (3,2,'2024-04-20T17:50:00','1');

INSERT INTO Review (MovieID, CustomerID, Rating, ReviewText, ReviewDate) VALUES
    (2,1,5,'5/7 Perfect score','2024-04-21T17:50:00'),
    (1,2,3,'Non mi piaceva il doppiaggio','2024-04-24T15:30:00'),
    (3,3,1,'Che schifo','2024-04-30T12:00:00');

INSERT INTO Employee (CinemaID, FirstName, LastName, Position, HireDate) VALUES
    (1,'Clara','Cheno','Receptonist','2020-02-10'),
    (1,'Cross','Ta','CEO','2020-01-01'),
    (2,'Paul','Camiseria','Manutezione','2022-09-09'),
    (2,'Maccio','Capatonda','Manger','2019-01-13'),
    (3,'Halo','Masterchief','Sicurezza','2021-06-19'),
    (3,'Todd','Howard','PR','2016-03-10');
--Creare una vista FilmsInProgrammation che mostri i titoli dei film, la data di inizio
--programmazione, la durata e la classificazione per et�. Questa vista aiuter� il personale e i clienti a
--vedere rapidamente quali film sono attualmente in programmazione.

CREATE VIEW FilmsInProgrammation  AS
	SELECT Title, ShowDateTime, DurationMinutes, Rating FROM Movie
	JOIN Showtime ON Movie.MovieID = ShowTime.MovieID;

	SELECT * FROM FilmsInProgrammation
--Vista Posti Disponibili per Spettacolo
--Creare una vista AvailableSeatsForShow che, per ogni spettacolo, mostri il numero totale di
--posti nella sala e quanti sono ancora disponibili. Questa vista � essenziale per il personale alla
--biglietteria per gestire le vendite dei biglietti.
DROP VIEW IF EXISTS AvailableSeatsForShow
CREATE VIEW AvailableSeatsForShow AS
	SELECT Title, ShowDateTime, Capacity, (Capacity - (SELECT COUNT(*) FROM Ticket WHERE Showtime.ShowtimeID = Ticket.ShowtimeID))
	AS PostiDisponibili 
	FROM Theater
	JOIN Showtime ON Theater.TheaterID = Showtime.TheaterID
	JOIN Movie ON Showtime.MovieID = Movie.MovieID

	SELECT * FROM AvailableSeatsForShow
--Vista Incassi Totali per Film
--Generare una vista TotalEarningsPerMovie che elenchi ogni film insieme agli incassi totali
--generati. Questa informazione � cruciale per la direzione per valutare il successo commerciale dei film.
DROP VIEW IF EXISTS TotalEarningsPerMovie
CREATE VIEW TotalEarningsPerMovie AS
	SELECT Title, Price *(SELECT COUNT(*) FROM Ticket WHERE Showtime.ShowtimeID = Ticket.ShowtimeID) AS Incassi
	FROM Movie
	JOIN Showtime ON Movie.MovieID = Showtime.MovieID

	SELECT * FROM TotalEarningsPerMovie
--Creare una vista RecentReviews che mostri le ultime recensioni lasciate dai clienti, includendo il
--titolo del film, la valutazione, il testo della recensione e la data. Questo permetter� al personale e
--alla direzione di monitorare il feedback dei clienti in tempo reale.

CREATE VIEW RecentReviews AS
	SELECT Title, Reviewtext, ReviewDate, Review.Rating 
	FROM Movie
	JOIN Review ON Movie.MovieID = Review.MovieID

	SELECT * FROM RecentReviews
--Creare una stored procedure PurchaseTicket che permetta di acquistare un biglietto per uno
--spettacolo, specificando l'ID dello spettacolo, il numero del posto e l'ID del cliente. La procedura
--dovrebbe verificare la disponibilit� del posto e registrare l'acquisto
DROP PROCEDURE PurchaseTicket
CREATE PROCEDURE PurchaseTicket 
@showtimeIDValue INT,
@seatnumberValue INT,
@custumerIDValue INT
AS
	BEGIN
		
		BEGIN TRY
			BEGIN TRANSACTION 
			DECLARE @cont INT
			SELECT @cont = COUNT(*) FROM Ticket
			JOIN Showtime ON Showtime.ShowtimeID = Ticket.ShowtimeID
			WHERE Ticket.SeatNumber = @seatnumberValue AND Showtime.ShowtimeID = @showtimeIDValue 

			IF @cont <= 0
				INSERT INTO Ticket(SeatNumber, PurchasedDateTime, CustomerID, ShowTimeID)
				VALUES (@seatnumberValue,CURRENT_TIMESTAMP, @custumerIDValue,@showtimeIDValue)

			COMMIT TRANSACTION
		END TRY

		BEGIN CATCH
			PRINT 'ERRORE'
			ROLLBACK
		END CATCH

	END
	EXEC PurchaseTicket @showtimeIDValue = 1, @seatnumberValue = 1, @custumerIDValue = 1;
	SELECT * FROM Ticket
--Implementare una stored procedure UpdateMovieSchedule che permetta di aggiornare gli orari
--degli spettacoli per un determinato film. Questo include la possibilit� di aggiungere o rimuovere
--spettacoli dall'agenda.
DROP PROCEDURE UpdateMovieSchedule
CREATE PROCEDURE UpdateMovieSchedule 
@showdatetimeValue DATE,
@showtimeIDValue INT = NULL,
@movieIDValue INT,
@showtimetheaterValue INT,
@showtimepriceValue DECIMAL,
@check BIT = 'true'
AS
	BEGIN
		
		BEGIN TRY
			BEGIN TRANSACTION 
			DECLARE @cont INT
			SELECT @cont = COUNT(*) FROM Showtime
			WHERE Showtime.ShowDateTime = @showdatetimeValue AND Showtime.MovieID = @movieIDValue AND Showtime.ShowtimeID = @showtimeIDValue
				IF @cont = 0 AND @showdatetimeValue > CURRENT_TIMESTAMP AND @showtimeIDValue IS NULL
				INSERT INTO Showtime(MovieID,TheaterID,ShowDateTime,Price)
				VALUES (@movieIDValue,@showtimetheaterValue,@showdatetimeValue,@showtimepriceValue)
				ELSE
				UPDATE Showtime SET 
				ShowDateTime = @showdatetimeValue
				WHERE Showtime.ShowtimeID = @showtimeIDValue  AND Showtime.MovieID = @movieIDValue 
				IF @check = 'false'
				DELETE FROM Showtime
				WHERE Showtime.ShowDateTime = @showdatetimeValue AND Showtime.MovieID = @movieIDValue AND Showtime.ShowtimeID = @showtimeIDValue
			COMMIT TRANSACTION
		END TRY

		BEGIN CATCH
			PRINT 'ERRORE'
			ROLLBACK
		END CATCH

	END
	EXEC UpdateMovieSchedule @showdatetimeValue =  '2025-01-20T23:00:00', @showtimeIDValue = 8,@showtimepriceValue = 10,@showtimetheaterValue = 1,@movieIDValue = 1,@check = 'false'
	SELECT * FROM Showtime
--Sviluppare una stored procedure InsertNewMovie che consenta di inserire un nuovo film nel
--sistema, richiedendo tutti i dettagli pertinenti come titolo, regista, data di uscita, durata e
--classificazione.

CREATE PROCEDURE InsertNewMovie
@movietitleValue VARCHAR(250),
@moviedirectorValue VARCHAR(100),
@moviereleasedateValue DATETIME,
@moviedurationValue INT,
@movieratingValue VARCHAR(5)
AS
	BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				INSERT INTO Movie (Title,Director,ReleaseDate,DurationMinutes,Rating)
				VALUES (@movietitleValue,@moviedirectorValue,@moviedurationValue,@movieratingValue)
			COMMIT TRANSACTION
		END TRY

		BEGIN CATCH
			PRINT 'ERRORE'
			ROLLBACK
		END CATCH
	END

--Creare una stored procedure SubmitReview che consenta ai clienti di lasciare una recensione per
--un film, comprensiva di valutazione, testo e data. Questa procedura dovrebbe verificare che il
--cliente abbia effettivamente acquistato un biglietto per il film in questione prima di permettere la
--pubblicazione della recensione.

CREATE PROCEDURE SubmitReview
@clienteidValue INT,
@reviewtextValue TEXT,
@ratingValue INT,
@reviewdateValue DATE,
@movieidValue INT
AS
	BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				DECLARE @cont INT
				SELECT @cont = COUNT(*) FROM Ticket
				JOIN Showtime ON Showtime.ShowTimeID = Ticket.ShowTimeID
				WHERE Ticket.CustomerID = @clienteidValue AND Ticket.ShowtimeID = ShowTime.ShowTimeID
				IF @cont > 0 
				INSERT INTO Review (MovieID, CustomerID,ReviewText,ReviewDate,Rating)
				VALUES (@movieidValue,@clienteidValue,@reviewtextValue,@reviewdateValue,@ratingValue)
			COMMIT TRANSACTION
		END TRY

		BEGIN CATCH
		END CATCH
	END

