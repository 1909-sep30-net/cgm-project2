INSERT INTO "User"("FirstName", "LastName", "Street", "City", "State", "Zip", "Admin") VALUES 
	('Fred', 'Weasley', '123 Street', 'Gonzales', 'LA', '70737', true),
	('George', 'Weasley', '456 Street', 'Dallas', 'TX', '87654', true),
	('Harry', 'Potter', '789 Street', 'Denver', 'CO', '23456', false),
	('Ron', 'Weasley', '321 Road', 'Houstan', 'TX', '87656', false),
	('Hermione', 'Granger', '654 Road', 'Tampa', 'FL', '30303', false);
	
INSERT INTO "Title"("TitleString", "CreatorId") VALUES
	('Which Disney Princess Are You?', 1),
	('Are You a Faster Coder Than Nick Escalona?', 4);

INSERT INTO "Category"("Rank","CategoryString", "CategoryDescription","TitleId") VALUES
	(1, 'Ariel','Ariel is a mermaid who lives under the sea',1),
	(2,'Snow White','Snow White has seven dwarves',1),
	(3,'Jasmine','Jasmine is from Aladdin',1),
	(1,'No','You are not faster than Mr. Escals',2),
	(2,'Yes','You are faster than Mr.Escals',2);

INSERT INTO "Question"("QuestionString", "TitleId") VALUES
	('Are you pretty?', 1),
	('Are you smart?', 1),
	('Do you struggle to keep up in class?', 2),
	('Do you struggle to keep up with home study?', 2),
	('Do you experience extreme deflation of ego?', 2),
	('Do you suffer from tangents of anger?', 2);

INSERT INTO "Answer"("AnswerString","Weight","QuestionId","CategoryId") VALUES
	('Yes', 1, 3, 1),
	('No', 1, 3, 2),
	('Yes', 1, 3, 3),
	('No', 1, 3, 2),
	('Yes', 1, 3, 4),
	('Yes', 1, 4, 4),
	('Yes', 1, 5, 4),
	('Yes', 1, 6, 4);

INSERT INTO "Result"("Score","TakerId","TitleId") VALUES
	(1,1,1),
	(2,2,2),
	(3,3,1),
	(4,4,2);

SELECT * FROM "User";	
SELECT * FROM "Title";
SELECT * FROM "Category";
SELECT * FROM "Question";
SELECT * FROM "Answer";
SELECT * FROM "Result";