-- on définit un nouvaeu delimiteur
DELIMITER |
CREATE PROCEDURE test2()
BEGIN
	select * from clients; -- les instructions sont écrites normalement
    select * from articles;
END | -- on met un pipe pour terminer le create
DELIMITER ; -- on redéfinit le delimiter par defaut

