create database Vendeur_De_Telephones


create table "Ventes" (
"T_ID" "int" NULL Primary key ,
"C_ID" "int" NOT NULL ,
"Date" nvarchar(20) NOT NULL ,
"Off_%" "int" NULL ,
"Acc_Type" nvarchar (20) NULL ,
"Acc_Prix" "float" NULL ,
"Prix_Totale" "float" NOT NULL default(0) ,
"Paiment" "float" NOT NULL default(0) )


create table "Clients" (
"C_ID" "int" Primary key NOT NULL ,
"Prenom" nvarchar (15) NOT NUll ,
"Nom" nvarchar (15) NOT NULL ,
"Ville" nvarchar (40) NOT NULL ,
"Nombre_Telephonique" "int" NULL ,
"Sexe" nvarchar (10) NOT NULL )


create table "Dettes" (
"C_ID" "int" NOT NULL Primary key ,
"Paiment_Net" "float" NOT NULL ,
"Dettes_Totale" "float" NOT NULL ,
"Reste" "float" NOT NULL )


create table "T_Vendus" (
"T_ID" "int" Primary key NOT NULL ,
"T_Genre" nvarchar (20) NOT NULL ,
"T_Entreprise" nvarchar (20) NOT NULL ,
"Prix" "float" NOT NULL ,
"Garantie" nvarchar (20) NULL ,
"Temps_Garantie" nvarchar (20) NULL ,
"Pays_de_creation" nvarchar (20) NOT NULL ,
"Couleur" nvarchar (20) NOT NULL ,
"VendeeAvendre" nvarchar (10) NOT NULL )


create table "Accessoires" (
"Acc_type" nvarchar (20) NOT NULL ,
"T_Genre" nvarchar (20) NOT NULL ,
"Acc_Entreprise" nvarchar (20) NOT NULL ,
"Prix_Unite" "float" NOT NULL ,
"Stockage" "int" NOT NULL default(0) )


create table "T_Caracteristiques" (
"T_Genre" nvarchar (20) NOT NULL Primary key ,
"T_Entreprise" nvarchar (20) NOT NULL ,
"System" nvarchar (20) NOT NULL ,
"Espace" nvarchar (20) NOT NULL ,
"RAM" nvarchar (20) NOT NULL ,
"Camera" nvarchar (20) NOT NULL ,
"Camera_Frontale" nvarchar (20) NOT NULL ,
"Taille_Ecran" nvarchar (20) NOT NULL ,
"Stock" "int" NOT NULL default(0) )


create table "Offres" (
"T_ID" "int" Primary key NOT NULL ,
"Off_%" "int" NULL ,
"Prix_Ancien" "float" NOT NULL ,
"Prix_Nouvelle" "float" NOT NULL default(0) )


create table "T_Achats"(
"T_ID" "int" Primary key NOT NULL ,
"T_Genre" nvarchar (20) NOT NULL ,
"T_Entreprise" nvarchar (20) NOT NULL ,
"Le_Agent" nvarchar(20) NOT NULL ,
"Date" nvarchar(20) NOT NULL )