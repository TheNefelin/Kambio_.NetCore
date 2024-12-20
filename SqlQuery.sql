USE dragonra_
GO

DROP TABLE TKUsers
GO
DROP TABLE TKRoles
GO

-- Tables -------------------------------------------------------
-- --------------------------------------------------------------

CREATE TABLE TKRoles (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Role VARCHAR(50) NOT NULL
)
GO

CREATE TABLE TKUsers (
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	Email VARCHAR(100) UNIQUE NOT NULL,
	AuthHash VARCHAR(256),
	AuthSalt VARCHAR(256),
	GoogleToken VARCHAR(256),
	AppleToken VARCHAR(256),
	SqlToken VARCHAR(256),
	RoleId INT NOT NULL,
	FOREIGN KEY (RoleId) REFERENCES TKRoles(Id)
)
GO

-- Data ---------------------------------------------------------
-- --------------------------------------------------------------

INSERT INTO TKRoles
	(Role)
VALUES
	('ADMIN'),
	('USER')
GO

INSERT INTO TKUsers
	(Id, Email, RoleId)
VALUES
	('5a7831c1-d703-476a-8fca-1a4ee0097a2d', 'test@google.com', 2),
	('e02e29ea-3dc5-4785-a606-36004d3db7b4', 'test@apple.com', 2)
GO


-- Query --------------------------------------------------------
-- --------------------------------------------------------------

SELECT * FROM TKRoles
SELECT * FROM TKUsers

SELECT * FROM TKUsers a INNER JOIN TKRoles b ON a.RoleId = b.Id

-- --------------------------------------------------------------
-- --------------------------------------------------------------