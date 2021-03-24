CREATE TABLE Events (
  Id SERIAL PRIMARY KEY,
  Name VARCHAR(50),
  Description TEXT,
  ExerciseType VARCHAR(100),
  Location POINT,
  Time TIMESTAMPZ,
  Intensity VARCHAR(50),
  GroupId INTEGER references Group(Id)
);
