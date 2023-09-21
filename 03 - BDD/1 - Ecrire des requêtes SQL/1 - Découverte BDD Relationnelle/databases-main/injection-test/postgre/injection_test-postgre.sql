
CREATE TABLE IF NOT EXISTS "user" (
  id serial not NULL,
 firstname varchar(20) NOT NULL DEFAULT '',
  lastname varchar(20) NOT NULL DEFAULT '',
  email varchar(20) NOT NULL DEFAULT '',
  country varchar(20) DEFAULT 'France',
  "password" varchar(20) NOT NULL DEFAULT '',
  PRIMARY KEY (id)
);

INSERT INTO "user" (id, firstname, lastname, email, country, password) VALUES
	(1, 'Dizzy', 'Gillepsie', 'dizzy@gmail.com', 'USA', 'dizzy123'),
	(4, 'Ada', 'Lovelace', 'lovelace@gmail.com', 'UK', 'ada123'),
	(5, 'Richard', 'Stallman', 'stallman@freedom.com', 'USA', 'richard123'),
	(6, 'Alan', 'Turing', 'turing@gmail.com', 'UK', 'alan123');

ALTER SEQUENCE user_id_seq RESTART WITH 8;