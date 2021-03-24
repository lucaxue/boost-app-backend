CREATE TABLE Users (
  Id SERIAL PRIMARY KEY,
  FirstName VARCHAR(50),
  Surname VARCHAR(50),
  Username VARCHAR(50) UNIQUE,
  Hours INTEGER,
  PartOfGroupsId INTEGER references Groups(Id),
  AdminOfGroupId INTEGER references Groups(Id),
  EventsIds INTEGER []
);

INSERT INTO 
Users(FirstName, Surname, Username, Hours, PartOfGroupsId, AdminOfGroupId, EventsIds)
VALUES
('Luca','Xue','lucaxue', 1, 1, 3,ARRAY [1,2]),
('Jim','Bob','jimbob', 20, 1, 1,ARRAY [1,2]),
('JJ','Hodgins','jj86', 5, 2, 2, ARRAY [1,2]),
('Eleanor','Redmayne','116', 5, 2, null,ARRAY [1,2]);


