
-- =============================================
-- Author:		Stiven Bedoya
-- Create date: 13/12/2023
-- Description:	Crud de Customer
-- =============================================
CREATE PROCEDURE SP_Crud_Customer(
	@Accion INT, 
	@Id	INT = NULL,
	@Nombre VARCHAR(40) = NULL,
	@Documento VARCHAR(20) = NULL,
	@Telefno VARCHAR(15) = NULL,
	@Direccion VARCHAR(150) = NULL
)
AS
BEGIN
	--Crear
	IF( @Accion = 1)
	BEGIN
		INSERT INTO [DBO].[Customer](Nombre,Documento,Telefno,Direccion) VALUES(@Nombre,@Documento,@Telefno,@Direccion);
	END
	--Editar
	IF( @Accion = 2)
	BEGIN
		UPDATE [DBO].[Customer] 
		SET Nombre = @Nombre,
			Documento = @Documento,
			Telefno = @Telefno,
			Direccion = @Direccion
		WHERE Id = @Id;
		SELECT Id, Nombre,Documento,Telefno,Direccion FROM [DBO].[Customer] WHERE Id = @Id;
	END
	--Eliminar
	IF( @Accion = 3)
	BEGIN
		DELETE [DBO].[Customer] WHERE Id = @Id;
	END
	--Obtener todos
	IF( @Accion = 4)
	BEGIN
		SELECT Id, Nombre,Documento,Telefno,Direccion FROM [DBO].[Customer];
	END
END
GO
