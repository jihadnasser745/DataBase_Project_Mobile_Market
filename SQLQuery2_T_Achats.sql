use Vendeur_De_Telephones

select * from Clients
delete from Clients
insert into Clients values(1,'Omar','Omar','Akkar',71803830,'Masculin')
insert into Clients values(2,'Ali','Tleiss','Aazki',76980615,'Masculin')
insert into Clients values(3,'Karim','Dandachi','Tripoli',76395690,'Masculin')
insert into Clients values(4,'Hassan','Obeid','Ain el Tini',03119375,'Masculin')
insert into Clients values(5,'Asma','Tannous','Kefr Habu',79127826,'Femelle')
insert into Clients values(6,'Aline','Abboud','Akkar',76456643,'Femelle')
insert into Clients values(7,'Edward','Tamer','Zgharta',78838642,'Masculin')
insert into Clients values(8,'Ahmad','Iaali','Tripoli',81458378,'Masculin')
insert into Clients values(9,'Tarek','Omran','Tripoli',70464678,'Masculin')
insert into Clients values(10,'Amal','Hammoud','Akkar',71693932,'Femelle')
insert into Clients values(11,'Omar','Ahmad','Akkar',71992939,'Masculin')
insert into Clients values(12,'Abdallah','Safar','Tripoli',78988252,'Masculin')
insert into Clients values(13,'Judy','Akl','Menya',03137248,'Femelle')
insert into Clients values(14,'Houda','Hanna','Rachiin',78927625,'Femelle')
insert into Clients values(15,'Khoder','Ossmane','Akkar',70565833,'Masculin')
insert into Clients values(16,'Mohamad','Dabboussi','Tripoli',70732832,'Masculin')
insert into Clients values(17,'Aline','Habib','Akkar',81110545,'Femelle')
insert into Clients values(18,'Jana','Zaiback','Batrun',71079980,'Femelle')
insert into Clients values(19,'Mohamad','Mohamad','Akkar',81359325,'Masculin')
insert into Clients values(20,'Mira','Khalil','Tripoli',76107345,'Femelle')
insert into Clients values(21,'Saba','Bacha','Zgharta',76373491,'Masculin')
insert into Clients values(22,'Ghada','Bakaraki','Tripoli',79125385,'Femelle')
insert into Clients values(23,'Bachar','El Mhamad','Tripoli',81288067,'Masculin')
insert into Clients values(24,'Aya','Hachem','Tripoli',71059265,'Femelle')
insert into Clients values(25,'Jihad','Nasser','Danniya',71738749,'Masculin')

--create table "T_Achats"(
--"T_ID" "int" NOT NULL ,
--"T_Genre" nvarchar (20) NOT NULL ,
--"T_Entreprise" nvarchar (20) NOT NULL ,
--"Le_Agent" nvarchar (20) NOT NULL ,
--"Date" nvarchar (20) NOT NULL )

select *from T_Achats
delete from T_Achats
insert into T_Achats values(1000,'A10S','Samsung','Qabass','6/25/2020')
insert into T_Achats values(1001,'A20S','Samsung','Qabass','6/25/2020')
insert into T_Achats values(1002,'A20S','Samsung','Qabass','6/25/2020')
insert into T_Achats values(1003,'S20 Ultra','Samsung','Qabass','6/25/2020')
insert into T_Achats values(1004,'Note 10+','Samsung','Qabass','6/25/2020')
insert into T_Achats values(1005,'A31','Samsung','Qabass','6/25/2020')
insert into T_Achats values(1006,'A31','Samsung','Qabass','6/25/2020')
insert into T_Achats values(1007,'A31','Samsung','Qabass','6/25/2020')
insert into T_Achats values(1008,'A51','Samsung','Qabass','6/25/2020')
insert into T_Achats values(1009,'Note 10+','Samsung','Qabass','6/25/2020')
insert into T_Achats values(1010,'Iphone 11 Pro','Apple','Abed Tahan','6/26/2020')
insert into T_Achats values(1011,'Iphone 11 Pro','Apple','Abed Tahan','6/26/2020')
insert into T_Achats values(1012,'Iphone 11 Pro','Apple','Abed Tahan','6/26/2020')
insert into T_Achats values(1013,'Iphone SE(2020)','Apple','Abed Tahan','6/26/2020')
insert into T_Achats values(1014,'Iphone SE(2020)','Apple','Abed Tahan','6/26/2020')
insert into T_Achats values(1015,'Y9S','Huawei','George Sima','6/27/2020')
insert into T_Achats values(1016,'Y9S','Huawei','George Sima','6/27/2020')
insert into T_Achats values(1017,'Y9S','Huawei','George Sima','6/27/2020')
insert into T_Achats values(1018,'Y9 Prime(2019)','Huawei','George Sima','6/27/2020') 
insert into T_Achats values(1019,'Y9 Prime(2019)','Huawei','George Sima','6/27/2020')
insert into T_Achats values(1020,'Y7P 2020','Huawei','George Sima','6/27/2020')
insert into T_Achats values(1021,'Y7P 2020','Huawei','George Sima','6/27/2020')
insert into T_Achats values(1022,'Nova 7 Pro','Huawei','George Sima','6/27/2020')
insert into T_Achats values(1023,'Nova 7 Pro','Huawei','George Sima','6/27/2020')
insert into T_Achats values(1024,'Nova 7 Pro','Huawei','George Sima','6/27/2020')
insert into T_Achats values(1025,'S20 Ultra','Samsung','Qabass','6/25/2020')
insert into T_Achats values(1026,'A10S','Samsung','Qabass','6/25/2020')
insert into T_Achats values(1027,'A51','Samsung','Qabass','6/25/2020')
insert into T_Achats values(1028,'A10S','Samsung','Qabass','6/25/2020')
insert into T_Achats values(1029,'Y9 Prime(2019)','Huawei','George Sima','6/27/2020')

select * from T_Vendus
delete from T_Vendus

insert into T_Vendus values(1000,'A10S','Samsung',210000,'CTC','1 an','Chine','Noire','Vendee')
insert into T_Vendus values(1001,'A20S','Samsung',240000,'CTC','1 an','Chine','Bleu','Vendee')
insert into T_Vendus values(1002,'A20S','Samsung',240000,'CTC','1 an','Chine','Rouge','A vendre')
insert into T_Vendus values(1003,'S20 Ultra','Samsung',2000000,'CTC','1 an','Chine','Oree','Vendee')
insert into T_Vendus values(1004,'Note 10+','Samsung',1875000,'CTC','1 an','Chine','Noire','Vendee')
insert into T_Vendus values(1005,'A31','Samsung',390000,'CTC','1 an','Chine','Bleu','Vendee')
insert into T_Vendus values(1006,'A31','Samsung',390000,'CTC','1 an','Chine','Bleu','Vendee')
insert into T_Vendus values(1007,'A31','Samsung',390000,'CTC','1 an','Chine','Oree','A vendre')
insert into T_Vendus values(1008,'A51','Samsung',450000,'CTC','1 an','Chine','Noire','A vendre')
insert into T_Vendus values(1009,'Note 10+','Samsung',1875000,'CTC','1 an','Chine','Blanc','A vendre')
insert into T_Vendus values(1010,'Iphone 11 Pro','Apple',1500000,'Apple','1 an','USA','Rouge','Vendee')
insert into T_Vendus values(1011,'Iphone 11 Pro','Apple',1500000,'Apple','1 an','USA','Blanc','Vendee')
insert into T_Vendus values(1012,'Iphone 11 Pro','Apple',1500000,'Apple','1 an','USA','Noire','A vendre')
insert into T_Vendus values(1013,'Iphone SE(2020)','Apple',600000,'Apple','1 an','USA','Blanc','A vendre')
insert into T_Vendus values(1014,'Iphone SE(2020)','Apple',600000,'Apple','1 an','USA','Noire','Vendee')
insert into T_Vendus values(1015,'Y9S','Huawei',480000,'Huawei','1 an','Chine','Noire','Vendee')
insert into T_Vendus values(1016,'Y9S','Huawei',480000,'Huawei','1 an','Chine','Rouge','Vendee')
insert into T_Vendus values(1017,'Y9S','Huawei',480000,'Huawei','1 an','Chine','Bleu','A vendre')
insert into T_Vendus values(1018,'Y9 Prime(2019)','Huawei',360000,'Huawei','1 an','Chine','Noire','Vendee')
insert into T_Vendus values(1019,'Y9 Prime(2019)','Huawei',360000,'Huawei','1 an','Chine','Bleu','A vendre')
insert into T_Vendus values(1020,'Y7P 2020','Huawei',345000,'Huawei','1 an','Chine','Bleu','Vendee')
insert into T_Vendus values(1021,'Y7P 2020','Huawei',345000,'Huawei','1 an','Chine','Blanc','A vendre')
insert into T_Vendus values(1022,'Nova 7 Pro','Huawei',705000,'Huawei','1 an','Chine','Noire','Vendee')
insert into T_Vendus values(1023,'Nova 7 Pro','Huawei',705000,'Huawei','1 an','Chine','Rouge','A vendre')
insert into T_Vendus values(1024,'Nova 7 Pro','Huawei',705000,'Huawei','1 an','Chine','Violet','A vendre')
insert into T_Vendus values(1025,'S20 Ultra','Samsung',2000000,'CTC','1 an','Chine','Noire','A vendre')
insert into T_Vendus values(1026,'A10S','Samsung',210000,'CTC','1 an','Chine','Oree','A vendre')
insert into T_Vendus values(1027,'A51','Samsung',450000,'CTC','1 an','Chine','Noire','A vendre')
insert into T_Vendus values(1028,'A10S','Samsung',210000,'CTC','1 an','Chine','Blanc','A vendre')
insert into T_Vendus values(1029,'Y9 Prime(2019)','Huawei',360000,'Huawei','1 an','Chine','Bleu','A vendre')
