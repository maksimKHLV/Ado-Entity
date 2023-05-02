CREATE DATABASE VegetablesAndFruits
USE VegetablesAndFruits

CREATE TABLE VegetablesAndFruitsTable(
	[id] int identity(1,1) PRIMARY KEY,
	[Name] nvarchar(max) NOT NULL CHECK([Name] NOT LIKE N''),
	[Type] nvarchar(10) NOT NULL CHECK([Type] NOT LIKE N''),
	[Color] nvarchar(30) NOT NULL CHECK([Color] NOT LIKE N''),
	[Coloricity] int NOT NULL CHECK([Coloricity] > 0)
) 
INSERT INTO VegetablesAndFruitsTable(Name,Type,Color,Coloricity) VALUES('Banana','Fruit','yellow',50)
INSERT INTO VegetablesAndFruitsTable(Name,Type,Color,Coloricity) VALUES('Lemon','Fruit','yellow',28)
INSERT INTO VegetablesAndFruitsTable(Name,Type,Color,Coloricity) VALUES('Watermelon','Fruit','green',79)
INSERT INTO VegetablesAndFruitsTable(Name,Type,Color,Coloricity) VALUES('Apple','Fruit','red',32)
INSERT INTO VegetablesAndFruitsTable(Name,Type,Color,Coloricity) VALUES('Orange','Fruit','orange',43)
INSERT INTO VegetablesAndFruitsTable(Name,Type,Color,Coloricity) VALUES('Pineapple','Fruit','yellow',231)
INSERT INTO VegetablesAndFruitsTable(Name,Type,Color,Coloricity) VALUES('Carrot','Vegetable','orange',24)
INSERT INTO VegetablesAndFruitsTable(Name,Type,Color,Coloricity) VALUES('Tomato','Vegetable','red',50)
INSERT INTO VegetablesAndFruitsTable(Name,Type,Color,Coloricity) VALUES('Potato','Vegetable','brown',58)
INSERT INTO VegetablesAndFruitsTable(Name,Type,Color,Coloricity) VALUES('Garlic','Vegetable','white',40)
INSERT INTO VegetablesAndFruitsTable(Name,Type,Color,Coloricity) VALUES('Cucumber','Vegetable','green',47)

