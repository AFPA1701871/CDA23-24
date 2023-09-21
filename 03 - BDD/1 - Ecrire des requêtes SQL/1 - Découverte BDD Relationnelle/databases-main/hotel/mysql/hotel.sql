-- Script à compléter
-- Plusieurs tables sont à ajouter, vous pouvez vous servir du modèle logique de données pour les retrouver

-- Attention : 
-- Pour les noms de table ou de colonne vous ne pourrez pas utiliser les mots-clefs utilisé par le langage SQL
-- Voici un liste des mots clefs interdits : https://www.postgresql.org/docs/current/sql-keywords-appendix.html
-- si toutefois vous souhaitez utiliser un mot clef considéré interdit vous pouvez utiliser des guillemets.

-- Ne pas oublier les contraintes d'intégrités suivantes :
-- * contraintes de clefs étrangères 
-- * contraintes de clefs primaires
-- * contraintes de domaine  (ou type)

DROP TABLE if exists public.booking CASCADE;

DROP TABLE if exists public.client CASCADE;

DROP TABLE if exists public.hotel CASCADE;

DROP TABLE if exists public.room CASCADE;

DROP TABLE if exists public.station CASCADE;

CREATE TABLE station (
	id SERIAL PRIMARY KEY,
	"name" VARCHAR(50),
	altitude INT
);

CREATE TABLE hotel (
	id 			SERIAL primary KEY,
	station_id 		INT,
	"name" 		VARCHAR(50),
	category 	INT,
	address		VARCHAR(50),
	city 		VARCHAR(50), 
	FOREIGN KEY (station_id) REFERENCES station(id)
);

CREATE TABLE room (
	id 			SERIAL primary KEY, 
	hotel_id 		INT,
	"number" 		VARCHAR(50),
	capacity 	INT,
	"type"		INT, 
	FOREIGN KEY (hotel_id) REFERENCES hotel(id)
);

CREATE TABLE client (
	id 			SERIAL primary KEY, 
	first_name 		VARCHAR(50),
	last_name 		VARCHAR(50),
	address 		VARCHAR(50),
	city 		VARCHAR(50)
);

CREATE TABLE booking (
	id 			SERIAL primary KEY, 
	room_id 		INT,
	client_id		INT,
	booking_date	DATE,
	stay_start_date	DATE,
	stay_end_date	DATE,
	price 		INT,
	deposit		INT, 
	FOREIGN KEY (room_id) REFERENCES room(id),
	FOREIGN KEY (client_id) REFERENCES client(id)
);

-- Tables à insérer ici

INSERT INTO station (id, "name", altitude) VALUES (1, 'La Montagne', 2500);
INSERT INTO station (id, "name", altitude) VALUES (2, 'Le Sud', 200);
INSERT INTO station (id, "name", altitude) VALUES (3, 'La Plage', 10);

INSERT INTO hotel (id, station_id, name, category, address, city) VALUES (1, 1, 'Le Magnifique', 3, 'rue du bas', 'Pralo');
INSERT INTO hotel (id, station_id, name, category, address, city) VALUES (2, 1, 'Hotel du haut', 1, 'rue du haut', 'Pralo');
INSERT INTO hotel (id, station_id, name, category, address, city) VALUES (3, 2, 'Le Narval', 3, 'place de la liberation', 'Vonten');
INSERT INTO hotel (id, station_id, name, category, address, city) VALUES (4, 2, 'Les Pissenlis', 4, 'place du 14 juillet', 'Bretou');
INSERT INTO hotel (id, station_id, name, category, address, city) VALUES (5, 2, 'RR Hotel', 5, 'place du bas', 'Bretou');
INSERT INTO hotel (id, station_id, name, category, address, city) VALUES (6, 2, 'La Brique', 2, 'place du haut', 'Bretou');
INSERT INTO hotel (id, station_id, name, category, address, city) VALUES (7, 3, 'Le Beau Rivage', 3, 'place du centre', 'Toras');

INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('001', 1, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('002', 1, 3, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('003', 1, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('101', 1, 1, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('102', 1, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('103', 1, 3, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('201', 1, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('202', 1, 7, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('203', 1, 1, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('001', 2, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('002', 2, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('003', 2, 1, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('101', 2, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('102', 2, 1, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('103', 2, 3, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('201', 2, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('202', 2, 4, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('203', 2, 4, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('001', 3, 3, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('002', 3, 1, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('003', 3, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('101', 3, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('102', 3, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('103', 3, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('201', 3, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('202', 3, 4, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('203', 3, 4, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('001', 4, 4, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('002', 4, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('003', 4, 4, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('101', 4, 1, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('102', 4, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('103', 4, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('201', 4, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('202', 4, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('203', 4, 3, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('001', 5, 3, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('002', 5, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('003', 5, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('101', 5, 1, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('102', 5, 4, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('103', 5, 1, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('201', 5, 2, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('202', 5, 4, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('203', 5, 4, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('001', 6, 1, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('002', 6, 1, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('003', 6, 1, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('101', 6, 1, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('102', 6, 1, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('103', 6, 1, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('201', 6, 1, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('202', 6, 1, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('203', 6, 1, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('001', 7, 1, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('002', 7, 5, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('003', 7, 5, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('101', 7, 5, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('102', 7, 5, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('103', 7, 5, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('201', 7, 5, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('202', 7, 5, 1);
INSERT INTO room ("number", hotel_id, capacity, "type") VALUES ('203', 7, 5, 1);

INSERT INTO client (last_name, first_name, address, city) VALUES ('Doe', 'John', '', 'LA');
INSERT INTO client (last_name, first_name, address, city) VALUES ('Homme', 'Josh', '', 'Palm Desert');
INSERT INTO client (last_name, first_name, address, city) VALUES ('Paul', 'Weller', '', 'Londres');
INSERT INTO client (last_name, first_name, address, city) VALUES ('White', 'Jack', '', 'Detroit');
INSERT INTO client (last_name, first_name, address, city) VALUES ('Claypool', 'Les', '', 'San Francisco');
INSERT INTO client (last_name, first_name, address, city) VALUES ('Squire', 'Chris', '', 'Londres');
INSERT INTO client (last_name, first_name, address, city) VALUES ('Wood', 'Ronnie', '', 'Londres');

INSERT INTO booking (room_id, client_id, booking_date, stay_start_date, stay_end_date, price, deposit) VALUES (1, 1, '2022-01-10', '2022-07-01', '2022-07-15', 2400, 800);
INSERT INTO booking (room_id, client_id, booking_date, stay_start_date, stay_end_date, price, deposit) VALUES (2, 2, '2022-01-10', '2022-07-01', '2022-07-15', 3400, 100);
INSERT INTO booking (room_id, client_id, booking_date, stay_start_date, stay_end_date, price, deposit) VALUES (1, 3, '2022-01-10', '2022-07-01', '2022-07-15', 400, 50);
INSERT INTO booking (room_id, client_id, booking_date, stay_start_date, stay_end_date, price, deposit) VALUES (2, 4, '2022-01-10', '2022-07-01', '2022-07-15', 7200, 1800);
INSERT INTO booking (room_id, client_id, booking_date, stay_start_date, stay_end_date, price, deposit) VALUES (3, 5, '2022-01-10', '2022-07-01', '2022-07-15', 1400, 450);
INSERT INTO booking (room_id, client_id, booking_date, stay_start_date, stay_end_date, price, deposit) VALUES (4, 6, '2022-01-10', '2022-07-01', '2022-07-15', 2400, 780);
INSERT INTO booking (room_id, client_id, booking_date, stay_start_date, stay_end_date, price, deposit) VALUES (4, 6, '2022-01-10', '2022-07-01', '2022-07-15', 500, 80);
INSERT INTO booking (room_id, client_id, booking_date, stay_start_date, stay_end_date, price, deposit) VALUES (4, 1, '2022-01-10', '2022-07-01', '2022-07-15', 40, 0);
