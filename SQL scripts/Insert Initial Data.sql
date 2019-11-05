INSERT INTO "User"("FirstName", "LastName", "Street", "City", "State", "Zip", "Admin") VALUES 
	('Fred', 'Weasley', '123 Street', 'Gonzales', 'LA', '70737', true),
	('George', 'Weasley', '456 Street', 'Dallas', 'TX', '87654', true),
	('Harry', 'Potter', '789 Street', 'Denver', 'CO', '23456', false),
	('Ron', 'Weasley', '321 Road', 'Houstan', 'TX', '87656', false),
	('Hermione', 'Granger', '654 Road', 'Tampa', 'FL', '30303', false);
	
INSERT INTO "Title"("TitleString", "CreatorId") VALUES
	('Which Disney Princess Are You?', 1),
	('Are You a Faster Coder Than Nick Escalona?', 4);

	



SELECT * FROM "User";	
SELECT * FROM "Title";