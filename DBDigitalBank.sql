
create database DBDigitalBank
 go

 use DBDigitalBank
 go

 create table Usuario(
 IdUsuario int primary key identity,
 Nombre varchar(100),
 FechaNacimiento date,
 Sexo char(1) 
 )
 go

 create table Log(
 IdUsuario int,
 Fecha date,
 Metodo varchar(30)
 )
 go



---  funciones ---
create function fn_usuarios()
returns table
as
return
(
	select u.IdUsuario, u.Nombre, convert(char(10),u.FechaNacimiento,103)[FechaNacimiento], u.Sexo
	from Usuario u
)
go

create function fn_usuario(@idUsuario int)
returns table
as
return
(
	select u.IdUsuario, u.Nombre, convert(char(10),u.FechaNacimiento,103)[FechaNacimiento], u.Sexo
	from Usuario u
	where u.IdUsuario = @idUsuario
)
go


---  procedimiento almacenados ---
create procedure sp_CrearUsuario(
@Nombre varchar(100),
@FechaNacimiento varchar(10),
@Sexo char(1)
)
as
begin
	set dateformat dmy
	insert into Usuario(Nombre,FechaNacimiento,Sexo)
	values(@Nombre,convert(date,@FechaNacimiento),@Sexo)
end
go


create or replace procedure sp_EditarUsuario(
@IdUsuario int,
@Nombre varchar(100),
@FechaNacimiento varchar(10),
@Sexo char(1)
)
as
begin
	set dateformat dmy
	update Usuario set
	Nombre = @Nombre,
	FechaNacimiento = @FechaNacimiento,
	Sexo = @Sexo
	where IdUsuario = @IdUsuario
end
go 

create procedure sp_EliminarUsuario(
@IdUsuario int
)
as
begin
	delete from Usuario where IdUsuario = @IdUsuario
end
go

create procedure sp_CrearLog(
@IdUsuario int,
@Fecha varchar(10),
@Metodo varchar(30)
)
as
begin
	set dateformat dmy
	insert into Log(IdUsuario,Fecha,Metodo)
	values(@IdUsuario,convert(date,@Fecha),@Metodo)
end
go