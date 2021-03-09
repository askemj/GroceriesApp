/* sql ny/ændring af opskrift query designet til opskriftsdatabase version 1.0 */ 

SELECT * FROM opskrifter;

describe RetVare;

/* 			Indsæt selve opskriften i "Ret" 		*/  
SET @retnavn = "TEST Pastinakfad",
	@noter = 'En velsmagende test',
    @tilberedningstidID = (SELECT tilberedningstid_id FROM Tilberedningstid WHERE tilberedningstid_tid = 90), 
    @arbejdstidID = (SELECT arbejdstid_id FROM Arbejdstid WHERE arbejdstid_tid = 10), 
    @antalPortioner = 2, 
    @opskriftstypeID = (SELECT opskriftstype_id FROM Opskriftstype WHERE opskriftstype_tekst = "Dessert");
    
/* UPDATING A RECIPE ! 
UPDATE Ret
SET Ret.ret_navn = @retnavn,
    Ret.noter = @noter, 
    Ret.Tilberedningstid_tilberedningstid_id = @tilberedningstidID,
    Ret.Arbejdstid_arbejdstid_id = @arbejdstidID,
    Ret.antal_portioner = @antalPortioner,
    Ret.Opskriftstype_opskriftstype_id = @opskriftstypeID
WHERE ret_id = 1; */ 
    
    
INSERT INTO Ret (Ret.ret_navn, Ret.noter, Ret.Tilberedningstid_tilberedningstid_id,
	Ret.Arbejdstid_arbejdstid_id, Ret.antal_portioner, Ret.Opskriftstype_opskriftstype_id )
VALUES (@retnavn, @noter, @tilberedningstidID, @arbejdstidID, @antalPortioner, @opskriftstypeID);
/* ON DUPLICATE KEY UPDATE
	Ret.ret_navn = @retnavn,
    Ret.noter = @noter, 
    Ret.Tilberedningstid_tilberedningstid_id = @tilberedningstidID,
    Ret.Arbejdstid_arbejdstid_id = @arbejdstidID,
    Ret.antal_portioner = @antalPortioner,
    Ret.Opskriftstype_opskriftstype_id = @opskriftstypeID; */ 
SELECT ret_id FROM Ret WHERE ret_navn = @retnavn; 

/* 		indsæt Tag	*/
SET @tag = "Smat", 
	@opskriftsID = 1;
INSERT INTO Tag (Tag.tag_tekst)
VALUES (@tag)
ON DUPLICATE KEY UPDATE
	Tag.tag_tekst = @tag;
SET @tagID = (SELECT tag_id FROM Tag WHERE tag_tekst = @tag);

INSERT INTO RetTag (Ret_ret_id, Tag_tag_id) 
VALUES (@opskriftsID, @tagID) 
ON DUPLICATE KEY UPDATE 
	RetTag.Ret_ret_id = @opskriftsID,
    RetTag.Tag_tag_id = @tagID; 
    
    
/* 		indsæt Vare 	*/ 
SET @retID = 1,
	@varenavn = 'agurk', 
	@varetypeID = (SELECT varetype_id FROM Varetype WHERE varetype_tekst = 'Frugt & Grønt'),
    @enhed = 'stk.',
    @maengde = 3
    ; 
INSERT INTO Vare (vare_navn, Varetype_varetype_id)
VALUES (@varenavn, @varetypeID)
ON DUPLICATE KEY UPDATE
	Vare.vare_navn = @varenavn,
    Vare.VareType_varetype_id = @varetypeID;
SET @vareID = (SELECT vare_id FROM Vare WHERE vare_navn = @varenavn); 

INSERT INTO Enhed (enhed_navn)
VALUES (@enhed)
ON DUPLICATE KEY UPDATE
	Enhed.enhed_navn = @enhed;
SET @enhedID = (SELECT enhed_id FROM Enhed WHERE enhed_navn = @enhed);

INSERT INTO RetVare (maengde, Enhed_enhed_id, Ret_ret_id, Vare_vare_id) 
VALUES (@maengde, @enhedID, @retID, @vareID)
ON DUPLICATE KEY UPDATE
	RetVare.maengde = @maengde,
    RetVare.Enhed_enhed_id = @enhedID, 
    RetVare.Ret_ret_id = @retID, 
    RetVare.Vare_vare_id = @vareID;
    
    
/* 		indsæt Twist  		*/ 
SET @retID = 1,
	@varenavn = 'romanesco', 
	@varetypeID = (SELECT varetype_id FROM Varetype WHERE varetype_tekst = 'Frugt & Grønt'),
    @enhed = 'stk.',
    @maengde = 1
    ; 
INSERT INTO Vare (vare_navn, Varetype_varetype_id)
VALUES (@varenavn, @varetypeID)
ON DUPLICATE KEY UPDATE
	Vare.vare_navn = @varenavn,
    Vare.VareType_varetype_id = @varetypeID;
SET @vareID = (SELECT vare_id FROM Vare WHERE vare_navn = @varenavn); 

INSERT INTO Enhed (enhed_navn)
VALUES (@enhed)
ON DUPLICATE KEY UPDATE
	Enhed.enhed_navn = @enhed;
SET @enhedID = (SELECT enhed_id FROM Enhed WHERE enhed_navn = @enhed);

/* INSERT INTO Twist (Twist.maengde, Twist.Enhed_enhed_id, Twist.Ret_ret_id, Twist.Vare_vare_id)
VALUES (@maengde, @enhedID, @retID, @vareID)
ON DUPLICATE KEY UPDATE 
	Twist.maengde = @maengde, 
    Twist.Enhed_enhed_id = @enhedID,
    Twist.Ret_ret_id = @retID, 
    Twist.Vare_vare_id = @vareID; */


SELECT * from Twist;
DELETE FROM Twist WHERE Ret_ret_id = 10 AND Vare_vare_id = 134;

ALTER TABLE Twist
MODIFY maengde  DECIMAL(5, 2) Null;

SET @maengde = 1.5, 
	@enhedID = 1, 
    @retID = 10, 
    @vareID = 134;
    
INSERT INTO Twist (maengde, Enhed_enhed_id, Ret_ret_id, Vare_vare_id) 
VALUES (@maengde, @enhedID, @retID, @vareID)
ON DUPLICATE KEY UPDATE
	Twist.maengde = @maengde,
    Twist.Enhed_enhed_id = @enhedID, 
    Twist.Ret_ret_id = @retID, 
    Twist.Vare_vare_id = @vareID;

/* SELECT * FROM Rest;
DELETE FROM Rest WHERE Rest.rest_id = 3;
ALTER TABLE Rest
ADD constraint UC_restnavn UNIQUE (rest_navn); *

/* 		indsæt rest 	*/ 
SET @rest = "bananmos",
	@retID = 1; 

INSERT INTO Rest (rest_navn) 
VALUES (@rest) 
ON DUPLICATE KEY UPDATE 
	Rest.rest_navn = @rest;

SET @restID = (SELECT rest_id FROM Rest WHERE rest_navn = @rest); 

INSERT INTO RetBrugerRest (Ret_ret_id, Rest_rest_id) 
VALUES (@retID, @restID)
ON DUPLICATE KEY UPDATE 
	RetBrugerRest.Ret_ret_id = @retID,
    RetBrugerRest.Rest_rest_id = @restID;

INSERT INTO RetRest (Ret_ret_id, Rest_rest_id)
VALUES (@retID, @restID) 
ON DUPLICATE KEY UPDATE 
	RetRest.Ret_ret_id = @retID, 
    RetRest.Rest_rest_id = @restID; 

SELECT * FROM Rest;
SELECT * FROM RetRest;

SELECT * FROM RetVare;

/* Deleting items in linktables */ 
DELETE FROM RetVare WHERE RetVare.Ret_ret_id = 1
	AND RetVare.Vare_vare_id = (SELECT vare_id FROM Vare WHERE vare_navn = "majs"); 
    
/* Deleting recipe */ 
SELECT * FROM Ret;

SET @retID = 1;
DELETE FROM RetTag WHERE RetTag.Ret_ret_id = @retID;
DELETE FROM RetVare WHERE RetVare.Ret_ret_id  = @retID;
DELETE FROM Twist WHERE Twist.Ret_ret_id = @retID;
DELETE FROM RetBrugerRest WHERE RetBrugerRest.Ret_ret_id = @retID;
DELETE FROM RetLaverRest WHERE RetLaverRest.Ret_ret_id  = @retID;
DELETE FROM Ret WHERE Ret.ret_id = @retID;

/* Insert into log */ 
SELECT * FROM Vare;

INSERT INTO Enhed (Enhed.enhed_navn)
VALUES ('stk.');

INSERT INTO Log (Log.log_dato) VALUES (DEFAULT);
SET @log_id = last_insert_id();

INSERT INTO LogVare (LogVare.Log_log_id, LogVare.maengde, LogVare.Enhed_enhed_id, LogVare.Vare_vare_id, LogVare.Ret_ret_id)
VALUES (@log_id, 1, 1, 5, 1);

SELECT * FROM LogVare;

/* 		BETA BETA BETA 		*/
/* SET @vareID = (SELECT vare_id FROM Vare WHERE vare_navn = "agurk");
INSERT INTO VareSaeson (VareSaeson.Vare_vare_id, VareSaeson.Saeson_saeson_id) 
VALUES (@vareID, 5),
	(@vareID, 6),
    (@vareID, 7);
 SELECT * FROM VareSaeson; */
