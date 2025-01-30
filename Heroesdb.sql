CREATE DATABASE HeroesDb;

USE HeroesDb;

CREATE TABLE heroes (
    id INT PRIMARY KEY,
    name NVARCHAR(100),
    alterego NVARCHAR(100),
    description NVARCHAR(255)
);

INSERT INTO heroes (id, name, alterego, description) VALUES (1, 'Clark Kent', 'Superman', 'Superhéroe de Krypton con poderes sobrehumanos.');
INSERT INTO heroes (id, name, alterego, description) VALUES (2, 'Bruce Wayne', 'Batman', 'Vigilante de Gotham City, experto en artes marciales y tecnología.');
INSERT INTO heroes (id, name, alterego, description) VALUES (3, 'Diana Prince', 'Wonder Woman', 'Princesa amazona con fuerza y habilidades extraordinarias.');
INSERT INTO heroes (id, name, alterego, description) VALUES (4, 'Barry Allen', 'The Flash', 'Velocista escarlata con la capacidad de moverse a velocidades increíbles.');
INSERT INTO heroes (id, name, alterego, description) VALUES (5, 'Hal Jordan', 'Green Lantern', 'Miembro del Green Lantern Corps con un anillo de poder.');