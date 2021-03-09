/* SQL queries til ta query eksisterende data i "opskrifter" version 1.0 */ 

UPDATE Ret 
SET Ret.Tilberedningstid_tilberedningstid_id = 1
WHERE Ret.ret_navn = "Banankage";

SELECT Ret.ret_navn FROM Ret WHERE Ret.ret_id = 29;

SELECT * FROM Rest;
SELECT * FROM RetBrugerRest;
SELECT Ret.noter, Ret.antal_portioner
FROM Ret
WHERE Ret.ret_navn = "Test Agurkesalat";

/* nedenstående returnerer 'N/A' når _id er null i Ret */
SELECT COALESCE(
	(SELECT Tilberedningstid.tilberedningstid_tid FROM Tilberedningstid, Ret 
		WHERE Tilberedningstid.tilberedningstid_id = Ret.Tilberedningstid_tilberedningstid_id
        AND Ret.ret_navn = "Test Agurkesalat"),
        'N/A') 
        AS 'Tilberedningstid';


/* problem er at man ikke kan bruge AND statements når en af værdierne er null !!!!!!!!!!! */ 

SELECT Ret.noter, Ret.antal_portioner, Tilberedningstid.tilberedningstid_tid, Arbejdstid.arbejdstid_tid, Opskriftstype.opskriftstype_tekst 
FROM Ret, Tilberedningstid, Arbejdstid, Opskriftstype
WHERE ( Ret.Tilberedningstid_tilberedningstid_id = Tilberedningstid.tilberedningstid_id OR Ret.Tilberedningstid_tilberedningstid_id is null )
AND ( Ret.Arbejdstid_arbejdstid_id = Arbejdstid.arbejdstid_id OR Ret.Arbejdstid_arbejdstid_id is null )
AND ( Ret.Opskriftstype_opskriftstype_id = Opskriftstype.opskriftstype_id OR Ret.Opskriftstype_opskriftstype_id is null )
AND Ret.ret_navn = "Test creme brulee";

SELECT * FROM Ret;

SELECT RetVare.maengde, Enhed.enhed_navn, Vare.vare_navn, Varetype.varetype_tekst, Vare.basisvare
FROM Ret, RetVare, Enhed, Vare, Varetype
WHERE Ret.ret_id = RetVare.Ret_ret_id
AND Vare.vare_id = RetVare.Vare_vare_id
AND Enhed.enhed_id = RetVare.Enhed_enhed_id
AND Vare.Varetype_varetype_id = Varetype.varetype_id
AND Ret.ret_navn = 'One Pot Pasta - Serranoskinke, soltørret tomat & basilikum';

/* query daglivarer */ 
SELECT * FROM Dagligvarer;

SELECT Vare.vare_navn, Varetype.varetype_tekst FROM Vare, Varetype, Dagligvarer
WHERE Vare.vare_id = Dagligvarer.dagligvare_id
AND Varetype.varetype_id = Vare.Varetype_varetype_id;