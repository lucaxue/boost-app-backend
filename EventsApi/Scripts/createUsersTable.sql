CREATE TABLE Users (
  Id SERIAL PRIMARY KEY,
  FirstName VARCHAR(50),
  Surname VARCHAR(50),
  Username VARCHAR(50) UNIQUE,
  Hours INTEGER,
  GroupId INTEGER references Group(Id),
  EventsIds INTEGER []
);

INSERT INTO 
Users(FirstName, Surname, Username, Hours, GroupId, EventsIds)
VALUES
()


