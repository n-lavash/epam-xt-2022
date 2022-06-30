------------------- ROLE ---------------------------------------
INSERT Role (Name_Role)
VALUES ('admin')

INSERT Role (Name_Role)
VALUES ('user')
------------------- ROLE ---------------------------------------

------------------- USER ---------------------------------------
INSERT Users VALUES 
(1, '25.05.2001', 'Pupa', '23.09.2012', 'jndsjvn@gmail.com'),
(2, '05.03.1953', 'Iosif', '10.01.2021', 'nodsijj@gmail.com'),
(3, '30.07.2010', 'Borat', '12.12.2020', 'kjijifew23@ya.ru'),
(4, '11.01.1960', 'Lyndon', '16.01.2021', 'mkvidm@gmail.com'),
(5, '08.03.1999', 'Anakin', '10.12.2013', 'okvosv@gmail.com'),
(6, '28.01.1961', 'Kylo', '28.06.2006', 'ijfewim@ya.ru')
------------------- USER ---------------------------------------

-------------------- LOT ---------------------------------------
INSERT Lot VALUES 
('Flashlight', '24.02.2011', 93974.37, 'A good flashlight, and most importantly - it shines'),
('Crown', '13.01.2014', 1512.76, 'The crown worn by Louis LXXXI himself'),
('Mirror', '15.05.2016', 20019.60, 'The mirror in which Vlad Dracula was reflected'),
('Telescope', '02.03.2021', 4743.04, 'Galileo Galilei Telescope'),
('Mask', '28.11.2008', 30392.26, 'This mask was worn by Corvo Attano'),
('Coin', '23.01.2009', 646.00, 'Just a cool coin')
-------------------- LOT ---------------------------------------

------------------- USER_LOT -----------------------------------
INSERT User_Lot VALUES
(6, 2),
(6, 3),
(2, 5),
(2, 4),
(5, 3),
(2, 6),
(1, 5),
(3, 4),
(2, 3),
(4, 4),
(1, 2),
(4, 1)
------------------- USER_LOT -----------------------------------

---------------- ACCOUNT_DETAILS -------------------------------
INSERT AccountDetails VALUES
(1, 'maegl', '87k5J'),
(2, 'denas', 'KaO3Y'),
(3, 'mehahan', '067rT'),
(4, 'tuod', 'K8SAo'),
(5, 'bora', 'gp2GJ'),
(6, 'dili', '7jCD7')
---------------- ACCOUNT_DETAILS -------------------------------

----------------- ACCOUNT_ROLE ---------------------------------
INSERT Account_Role VALUES 
(1,1),
(2,2),
(1,3),
(1,4),
(2,5),
(1,6)
----------------- ACCOUNT_ROLE ---------------------------------