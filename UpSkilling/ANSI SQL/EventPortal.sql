CREATE DATABASE EventPortal;
GO

USE EventPortal;
GO

CREATE TABLE Events (
    EventId   INT PRIMARY KEY,
    EventName VARCHAR(100) NOT NULL,
    EventDate DATE NOT NULL,
    Venue     VARCHAR(150) NOT NULL
);

CREATE TABLE Participants (
    ParticipantId INT PRIMARY KEY,
    Name          VARCHAR(100) NOT NULL,
    Email         VARCHAR(100) NOT NULL,
    Phone         VARCHAR(15) NOT NULL,
    EventId       INT NOT NULL,
    FOREIGN KEY (EventId) REFERENCES Events(EventId)
);

INSERT INTO Events (EventId, EventName, EventDate, Venue)
VALUES
    (1, 'Tech Workshop',     '2025-08-10', 'Chennai Convention Centre'),
    (2, 'Annual Sports Day', '2025-08-18', 'City Stadium, Bangalore'),
    (3, 'Cultural Fest',     '2025-08-25', 'Open Air Theatre, Mumbai');

INSERT INTO Participants (ParticipantId, Name, Email, Phone, EventId)
VALUES
    (1, 'Alice Johnson', 'alice@example.com',  '9876543210', 1),
    (2, 'Bob Smith',     'bob@example.com',    '9876543211', 2),
    (3, 'Carol Davis',   'carol@example.com',  '9876543212', 1),
    (4, 'David Lee',     'david@example.com',  '9876543213', 3),
    (5, 'Eva Martin',    'eva@example.com',    '9876543214', 2);

SELECT * FROM Events;

SELECT * FROM Participants;

SELECT * FROM Participants WHERE EventId = 1;

SELECT * FROM Events ORDER BY EventDate ASC;

SELECT * FROM Participants ORDER BY Name ASC;

UPDATE Events
SET Venue = 'Anna Centenary Library, Chennai'
WHERE EventId = 1;

DELETE FROM Participants
WHERE ParticipantId = 5;

SELECT
    e.EventId,
    e.EventName,
    e.EventDate,
    e.Venue,
    p.Name        AS ParticipantName,
    p.Email       AS ParticipantEmail,
    p.Phone       AS ParticipantPhone
FROM Events e
INNER JOIN Participants p ON e.EventId = p.EventId
ORDER BY e.EventName ASC;

SELECT
    e.EventName,
    COUNT(p.ParticipantId) AS TotalParticipants
FROM Events e
INNER JOIN Participants p ON e.EventId = p.EventId
GROUP BY e.EventName;
