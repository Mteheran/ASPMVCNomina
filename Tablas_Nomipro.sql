Create database NOMIPRO;

USE NOMIPRO;

Create table Hora_Adicional ( IdHora_Adicional INT CONSTRAINT PK_Id_Hora_Adicional PRIMARY KEY,
Nombre VARCHAR (45),
Valor_Hora DECIMAL (38));

Create table Parafiscal ( Id_Parafiscal INT CONSTRAINT PK_Id_parafiscal primary key,
Nombre VARCHAR (45),
Valor VARCHAR (45));

Create table Cargo ( Id_Cargo INT CONSTRAINT PK_Id_Cargo Primary Key,
Nombre Varchar (45),
Estado INT,
Valor_Cargo DECIMAL (38));

Create table Empleado (Id_Empleado INT CONSTRAINT PK_Id_Empleado Primary Key,
Nombre Varchar (45),
Apellido Varchar(45),
Correo Varchar (45),
Telefono Int,
Numero_De_Documento Int,
Tipo_De_Documento Int,
Id_Cargo INT CONSTRAINT FK_Id_Cargo FOREIGN  KEY REFERENCES Cargo,
Estado INT);

Create Table Control_Pago (Id_Control_Pago INT CONSTRAINT PK_Id_Control_Pago Primary Key,
Id_Parafiscal INT CONSTRAINT FK_Id_Parafiscal FOREIGN KEY REFERENCES Parafiscal,
Id_Hora_Adicional INT CONSTRAINT FK_Id_hora_Adicional FOREIGN KEY REFERENCES Hora_Adicional);

Create Table Nomina ( Id_Nomina INT CONSTRAINT PK_Id_Nomina Primary Key,
Valor_Apagar DECIMAL (38),
Subtotal DECIMAL (38),
Mes VARCHAR (45),
Id_Empleado INT CONSTRAINT Fk_Id_Empleado FOREIGN KEY REFERENCES Empleado,
Id_Control_Pago INT CONSTRAINT Fk_Id_Control_Pago FOREIGN KEY REFERENCES Control_Pago);