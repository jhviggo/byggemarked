CREATE DATABASE byggemarked;

-- Kør: 'Update-Database' i entity framework console
-- Eller start WPF applikationen og Entity framework vil køre dens migrations

INSERT INTO dbo.Customers
VALUES
('Viggo Petersen', 'Test vej', 'viggo@email.com', 'viggo', '12345'),
('Martin Skov', 'Test vej', 'martin@email.com', 'martin', 'asdfg');

INSERT INTO dbo.Hardwares
VALUES
('Hammer', 'Metal hammer med træskaft', 100, 250),
('Boremaskine', 'Generisk boremaskine', 200, 1000),
('Stige', 'Solid metal stige', 200, 500),
('Havetromler', 'Bosch havetromler', 500, 2500),
('Kompostkværne', 'Bosch kompostkværne', 500, 2500),
('Vinkelsliber', 'Bosch vinkelsliber', 350, 1000),
('Gulvslibemaskiner', 'Bosch gulvslibemaskiner', 450, 2000),
('Motorsave', 'Bosch motorsave', 300, 1500);

INSERT INTO dbo.Rentals
VALUES
(1, 1, 'reserveret', '2020-11-14 10:00:00', 3),
(2, 1, 'reserveret', '2020-11-14 10:00:00', 3),
(4, 2, 'reserveret', '2020-12-09 10:00:00', 1),
(7, 2, 'udleveret', '2020-10-05 10:00:00', 2),
(5, 2, 'tilbageleveret', '2020-06-05 10:00:00', 5);