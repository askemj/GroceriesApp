/* SQL queries til opsætning af tabeldata i "opskrifter" version 1.0 */ 

INSERT INTO Opskriftstype (Opskriftstype.opskriftstype_tekst)
VALUES ("Hovedret"),
	("Basisopskrift"),
    ("Fyld"),
	("Tilbehør"),
    ("Dessert"),
    ("Snack");

INSERT INTO Saeson (Saeson.saeson_navn) 
VALUES ("januar"),
	("februar"),
    ("marts"),
    ("april"),
    ("maj"),
    ("juni"),
    ("juli"),
    ("august"), 
    ("september"),
    ("oktober"),
    ("november"),
    ("december");

INSERT INTO Varetype (varetype_tekst)
VALUES ('Frugt & Grønt'),
	('Brød'), 
    ('Kød & Fisk'), 
    ('Tørvarer'), 
    ('Drikkevarer'), 
    ('Pålæg'), 
    ('Mejeri'), 
    ('Frost'), 
    ('Personlig Pleje'), 
    ('Konserves'), 
    ('Husholdning'), 
    ('Diverse');
    
INSERT INTO Vare (Vare.vare_navn, Vare.Varetype_varetype_id, Vare.basisvare) 
VALUES ('mælk', (SELECT Varetype.varetype_id FROM Varetype WHERE varetype_tekst = 'Mejeri'), 0),
	('A38', (SELECT Varetype.varetype_id FROM Varetype WHERE varetype_tekst = 'Mejeri'), 0),
    ('rugbrød', (SELECT Varetype.varetype_id FROM Varetype WHERE varetype_tekst = 'Brød'), 0),
    ('Sigurd-rugbrød', (SELECT Varetype.varetype_id FROM Varetype WHERE varetype_tekst = 'Brød'), 0),
    ('frugt', (SELECT Varetype.varetype_id FROM Varetype WHERE varetype_tekst = 'Frugt & Grønt'), 0),
    ('salatgrønt', (SELECT Varetype.varetype_id FROM Varetype WHERE varetype_tekst = 'Frugt & Grønt'), 0),
    ('pålæg', (SELECT Varetype.varetype_id FROM Varetype WHERE varetype_tekst = 'Pålæg'), 0),
    ('havregryn', (SELECT Varetype.varetype_id FROM Varetype WHERE varetype_tekst = 'Tørvarer'), 1);
    
INSERT INTO Dagligvarer (Dagligvarer.periode, Dagligvarer.Vare_vare_id) 
VALUES ( 3, (SELECT Vare.vare_id FROM Vare WHERE Vare.vare_navn = 'mælk')),
	( 3, (SELECT Vare.vare_id FROM Vare WHERE Vare.vare_navn = 'A38')),
    ( 3, (SELECT Vare.vare_id FROM Vare WHERE Vare.vare_navn = 'rugbrød')),
    ( 7, (SELECT Vare.vare_id FROM Vare WHERE Vare.vare_navn = 'frugt')),
    ( 7, (SELECT Vare.vare_id FROM Vare WHERE Vare.vare_navn = 'salatgrønt')),
    ( 7, (SELECT Vare.vare_id FROM Vare WHERE Vare.vare_navn = 'pålæg')),
    ( 14, (SELECT Vare.vare_id FROM Vare WHERE Vare.vare_navn = 'havregryn')), 
    ( 14, (SELECT Vare.vare_id FROM Vare WHERE Vare.vare_navn = 'Sigurd-rugbrød'));

INSERT INTO Tilberedningstid (Tilberedningstid.tilberedningstid_tid)
VALUES (10),
	(15),
    (20),
	(30), 
    (45), 
    (60),
    (70),
    (75),
    (80),
    (90),
    (105),
    (120);
    
INSERT INTO Arbejdstid (Arbejdstid.arbejdstid_tid)
VALUES (10), 
	(15), 
    (20), 
	(30), 
    (45), 
    (60), 
    (75), 
    (90), 
    (120);    

INSERT INTO Butik (butik_navn)
VALUES ('Netto'), 
	('SuperBrugsen');

INSERT INTO VaretypeRaekkefoelge (raekkefoelge_sekvens, Varetype_varetype_id, Butik_butik_id)
VALUES (1, 1, 1),
	(2, 2, 1), 
    (3, 3, 1),
    (4, 4, 1),
    (5, 5, 1), 
    (6, 6, 1), 
    (7, 7, 1), 
    (8, 8, 1), 
    (9, 9, 1), 
    (10, 10, 1), 
    (11, 11, 1),  
    (12, 12, 1);