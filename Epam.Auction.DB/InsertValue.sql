INSERT Roles (Name)
VALUES ('admin')

INSERT Roles (Name)
VALUES ('user')



INSERT Users VALUES 
('25.05.2001', 'Pupa', '23.09.2012', 'jndsjvn@gmail.com'),
('05.03.1953', 'Iosif', '10.01.2021', 'nodsijj@gmail.com'),
('30.07.2010', 'Borat', '12.12.2020', 'kjijifew23@ya.ru'),
('11.01.1960', 'Lyndon', '16.01.2021', 'mkvidm@gmail.com'),
('08.03.1999', 'Anakin', '10.12.2013', 'okvosv@gmail.com'),
('28.01.1961', 'Kylo', '28.06.2006', 'ijfewim@ya.ru')



INSERT Lots VALUES 
('Flashlight', '24.02.2011', 93974.37, 'A good flashlight, and most importantly - it shines'),
('Crown', '13.01.2014', 1512.76, 'The crown worn by Louis LXXXI himself'),
('Mirror', '15.05.2016', 20019.60, 'The mirror in which Vlad Dracula was reflected'),
('Telescope', '02.03.2021', 4743.04, 'Galileo Galilei Telescope'),
('Mask', '28.11.2008', 30392.26, 'This mask was worn by Corvo Attano'),
('Coin', '23.01.2009', 646.00, 'Just a cool coin')



INSERT UsersToLots VALUES
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



INSERT AccountDetails VALUES
('maegl', HASHBYTES('SHA2_512','87k5J')),
('denas', HASHBYTES('SHA2_512','KaO3Y')),
('mehahan', HASHBYTES('SHA2_512','067rT')),
('tuod', HASHBYTES('SHA2_512','K8SAo')),
('bora', HASHBYTES('SHA2_512','gp2GJ')),
('dili', HASHBYTES('SHA2_512','7jCD7'))

INSERT AccountsToRole VALUES 
(1,1),
(2,2),
(1,3),
(1,4),
(2,5),
(1,6)