insert into etudiants values (1,'roblin','lea','12,bd de la liberte','calais',62100,'21345678','2014-09-01',1,'','F','1995-01-14');
insert into etudiants values (2,'macarthur','leon','121,bd gambetta','calais',62100,'21-30-65-09','2014-09-01',1,'','M','1994-04-12');
insert into etudiants values (3,'minol','luc','9,rue des prairies','boulogne',62200,'21-30-20-10','2014-09-01',1,'','M','1997-03-12');
insert into etudiants values (4,'bagnole','sophie','12,rue des capucines','wimereux',62930,'21-89-04-30','2014-09-01',1,'','F','1996-03-21');
insert into etudiants values (5,'bury','marc','67,allee ronde','marcq',62300,'21-90-87-65','2014-09-01',1,'','M','1993-02-05');
insert into etudiants values (6,'vendraux','marc','5,rue de marseille','calais',62100,'21-96-00-09','2013-09-01',1,'a redouble sa premiere annee','M','1996-01-21');
insert into etudiants values (7,'vendermaele','helene','456,rue de paris','boulogne',62200,'21-45-45-60','2014-09-01',1,'','F','1995-03-30');
insert into etudiants values (8,'besson','loic','3,allee carpentier','dunkerque',59300,'28-90-89-78','2014-09-01',2,'','M','1994-05-21');
insert into etudiants values (9,'godart','jean-paul','123,rue de lens','marck',59870,'28-09-87-65','2013-09-01',2,'a double sa seconde annee','M','1993-01-12');
insert into etudiants values (10,'beaux','marie','1,allee des cygnes','dunkerque',59100,'21-30-87-90','2014-09-01',2,null,'F','1996-04-12');
insert into etudiants values (11,'turini','elsa','12,route de paris','boulogne',62200,'21-32-47-97','2014-09-01',2,null,'F','1996-07-17');
insert into etudiants values (12,'torelle','elise','123,vallee du denacre','boulogne',62200,'21-67-86-90','2014-09-01',2,null,'F','1997-04-16');
insert into etudiants values (13,'pharis','pierre','12,avenue foch','calais',62100,'21-21-85-90','2014-09-01',2,null,'M','1996-03-18');
insert into etudiants values (14,'ephyre','luc','12,rue de lyon','calais',62100,'21-35-32-90','2014-09-01',2,null,'M','1995-01-21');
insert into etudiants values (15,'leclercq','jules','12,allee des ravins','boulogne',62200,'21-36-71-92','2014-09-01',2,null,'M','1994-05-19');
insert into etudiants values (16,'dupont','luc','21,avenue monsigny','calais',62200,'21-21-34-99','2014-09-01',2,null,'M','1996-11-02');
insert into etudiants values (17,'marke','loic','312,route de paris','wimereux',62930,'21-87-87-71','2014-09-01',2,null,'M','1996-11-12');
insert into etudiants values (18,'dewa','leon','121,allee des eglantines','dunkerque',59100,'28-30-87-90','2014-09-01',2,null,'M','1997-04-03');

insert into enseignants values (1,'talon','isabelle','MAITRE DE CONFERENCES','12,rue des lilas','marseille',13000,'29-89-76-30','1965-05-30','1991-10-01');
insert into enseignants values (2,'pelletier','séverine','CERTIFIE','213,avenue de londres','calais',62100,'21-54-87-61','1975-04-21','2014-09-01');
insert into enseignants values (3,'roseau','alain','AGREGE','12,allee des mimosas','calais',62100,'21-65-87-43','1960-01-02','1991-10-01');
insert into enseignants values (4,'preux','erick','CERTIFIE','76,rue charles de gaulle','lyon',69000,'30-87-21-54','1969-11-09','1995-10-01');
insert into enseignants values (5,'roussel','philippe','MAITRE DE CONFERENCES','43,rue des cogognes','lille',59000,'28-90-86-64','1966-01-21','1990-10-12');
insert into enseignants values (6,'renaud','leon','MAITRE DE CONFERENCES','34,allee luoia','lille',59000,'28-29-30-31','1968-12-12','1994-10-10');
insert into enseignants values (7,'delignieres','benedicte','MAITRE DE CONFERENCES','124,allee rouids','lyon',69000,'45-87-91-03','1964-10-13','1991-10-01');
insert into enseignants values (8,'robillard','marcel','AGREGE','12,route de paris','lille',59000,'28-28-39-39','1965-12-12','1995-10-01');
insert into enseignants values (9,'savasta','sophie','CERTIFIE','32,rue luois david','calais',62100,'21-78-64-54','1959-10-09','1996-10-01');
insert into enseignants values (10,'cayron','isabelle','AGREGE','56,rue de majorettes','lille',59000,'28-98-59-01','1965-09-09','1993-10-01');
insert into enseignants values (11,'pacou','alain','AGREGE','34,rue monsigny','saint omer',62300,'21-94-63-20','1978-12-01','1998-10-01');

/*entree des modules*/

insert into modules values (1,'informatique',15);
insert into modules values (2,'mathematiques',5);
insert into modules values (3,'EOG',5);
insert into modules values (4,'LEC',5);


/*entree des matieres*/

insert into matieres values (1,'anglais',4,2);
insert into matieres values (2,'BD',1,5);
insert into matieres values (3,'UNIX',1,5);
insert into matieres values (4,'access',1,1);
insert into matieres values (5,'bureautique',1,2);
insert into matieres values (6,'C',1,5);
insert into matieres values (7,'Prog avancee',1,3);
insert into matieres values (8,'mathematiques',2,1);
insert into matieres values (9,'expression',4,2);
insert into matieres values (10,'ACSI',1,7);
insert into matieres values (11,'economie',3,2);
insert into matieres values (12,'gestion',3,2);
insert into matieres values (13,'algorithmique',1,5);
insert into matieres values (14,'architecture',1,3);

/* entree des epreuves */
insert into epreuves values (1,'interro anglais',9,1,'2014-09-12',1,1);
insert into epreuves values (2,'partiel maths',3,8,'2014-09-13',3,1);
insert into epreuves values (3,'partiel BD',1,2,'2014-09-18',4,2);
insert into epreuves values (4,'partiel UNIX',7,3,'2014-10-01',3,2);
insert into epreuves values (5,'interro BD',1,2,'2014-10-12',1,2);
insert into epreuves values (6,'interro maths',3,8,'2014-10-12',4,1);


/*entree des note*/

insert into avoir_note values (null,1,1,15);
insert into avoir_note values (null,2,1,08);
insert into avoir_note values (null,3,1,07);
insert into avoir_note values (null,4,1,11);
insert into avoir_note values (null,5,1,15);
insert into avoir_note values (null,6,1,16);
insert into avoir_note values (null,7,1,01);
insert into avoir_note values (null,17,1,06);
insert into avoir_note values (null,18,1,11);
insert into avoir_note values (null,1,2,12);
insert into avoir_note values (null,2,2,12);
insert into avoir_note values (null,3,2,03);
insert into avoir_note values (null,4,2,15);
insert into avoir_note values (null,5,2,09);
insert into avoir_note values (null,6,2,11);
insert into avoir_note values (null,7,2,13);
insert into avoir_note values (null,17,2,19);
insert into avoir_note values (null,18,2,06);
insert into avoir_note values (null,8,3,8);
insert into avoir_note values (null,9,3,14);
insert into avoir_note values (null,10,3,14);
insert into avoir_note values (null,11,3,11);
insert into avoir_note values (null,12,3,06);
insert into avoir_note values (null,13,3,03);
insert into avoir_note values (null,14,3,20);
insert into avoir_note values (null,15,3,12);
insert into avoir_note values (null,16,3,11);
insert into avoir_note values (null,8,4,07);
insert into avoir_note values (null,9,4,11);
insert into avoir_note values (null,10,4,12);
insert into avoir_note values (null,11,4,03);
insert into avoir_note values (null,12,4,20);
insert into avoir_note values (null,13,4,12);
insert into avoir_note values (null,14,4,10);
insert into avoir_note values (null,15,4,8);
insert into avoir_note values (null,16,4,10);
insert into avoir_note values (null,17,4,08);

/*entree dans faire_cours */

insert into faire_cours values (null,1,2,2);
insert into faire_cours values (null,1,10,2);
insert into faire_cours values (null,2,4,1);
insert into faire_cours values (null,2,5,1);
insert into faire_cours values (null,2,11,1);
insert into faire_cours values (null,2,11,2);
insert into faire_cours values (null,3,8,2);
insert into faire_cours values (null,3,13,1);
insert into faire_cours values (null,4,14,1);
insert into faire_cours values (null,5,12,1);
insert into faire_cours values (null,5,12,2);
insert into faire_cours values (null,6,3,2);
insert into faire_cours values (null,6,3,1);
insert into faire_cours values (null,6,6,2);
insert into faire_cours values (null,7,13,1);
insert into faire_cours values (null,7,7,2);
insert into faire_cours values (null,7,3,2);
insert into faire_cours values (null,8,10,1);
insert into faire_cours values (null,8,13,1);
insert into faire_cours values (null,9,1,1);
insert into faire_cours values (null,9,1,2);
insert into faire_cours values (null,10,9,1);
insert into faire_cours values (null,10,9,2);
insert into faire_cours values (null,11,8,1);
