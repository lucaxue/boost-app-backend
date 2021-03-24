CREATE TABLE Groups (
  Id SERIAL PRIMARY KEY,
  Name VARCHAR(50) UNIQUE
);

INSERT INTO Groups
  (Name) 
VALUES 
  ('Weekend Warriors'),
  ('Young Mums'),
  ('Beat the Bulge');

