
-- =============================================
-- Author:		Stiven Bedoya
-- Create date: 13/12/2023
-- Description:	Crud de Order
-- =============================================
CREATE PROCEDURE SP_Crud_Order(
	@Accion INT, 
	@Id	INT = NULL,
	@IdCustomer INT = NULL,
	@Descripcion VARCHAR(20) = NULL	
)
AS
BEGIN
	--Crear
	IF( @Accion = 1)
	BEGIN
		INSERT INTO [DBO].[Order](IdCustomer,Descripcion) VALUES(@IdCustomer,@Descripcion);
	END
	--Editar
	IF( @Accion = 2)
	BEGIN
		UPDATE [DBO].[Order]
		SET IdCustomer = @IdCustomer,
			Descripcion = @Descripcion
		WHERE Id = @Id;
		SELECT Id, IdCustomer,Descripcion FROM [DBO].[Order] WHERE Id = @Id;
	END
	--Eliminar
	IF( @Accion = 3)
	BEGIN
		DELETE [DBO].[Order] WHERE Id = @Id;
	END
	--Obtener todos
	IF( @Accion = 4)
	BEGIN
		SELECT Id, IdCustomer,Descripcion FROM [DBO].[Order];
	END
	--Delete By  idCustomer
	IF( @Accion = 5)
	BEGIN
		DELETE [DBO].[Order] WHERE IdCustomer = @IdCustomer;
	END
END
GO
