create table empleados(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Codigo nvarchar(5) NOT NULL,
	Apellido nvarchar(50) NOT NULL,
	Nombre nvarchar(50) NOT NULL,
	FechaAlta DateTime NULL,
	IdTipoDto Int NULL foreign key references tiposDocumentos(Id),
	NumDocumento int NULL,
	Estado varchar(1) default 'A' NOT NULL
)


create table tiposDocumentos (
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Descripcion varchar(50) not null,
	Estado varchar(1) default 'A' NOT NULL
)

insert into tiposDocumentos (Descripcion) values
('DNI'), ('Pasaporte')

create procedure SP_SaveEmpleado
	@Codigo nvarchar(5), @Apellido nvarchar(50), @Nombre nvarchar(50), @FechaAlta nvarchar(50), @TipoDto int, @NumDto int
as
begin

IF EXISTS (SELECT * FROM Empleados WHERE Codigo =@Codigo) 
BEGIN
   update Empleados set 
	Apellido = @Apellido, Nombre = @Nombre,	FechaAlta = @FechaAlta, IdTipoDto = @TipoDto, NumDocumento = @NumDto
	where Codigo = @Codigo
END
ELSE
BEGIN
    insert into Empleados(Codigo, Apellido,	Nombre,	FechaAlta, IdTipoDto, NumDocumento)
	values(@Codigo, @Apellido, @Nombre, @FechaAlta, @TipoDto, @NumDto)
END

end

--SP_SaveEmpleado '0002', 'mansilla', 'mabel', '2021-07-07', 1, 25752599