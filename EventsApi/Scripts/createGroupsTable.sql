CREATE TABLE Groups (
  Id SERIAL PRIMARY KEY,
  AdminId INTEGER references Users(Id),
  Name VARCHAR(50) UNIQUE
);

