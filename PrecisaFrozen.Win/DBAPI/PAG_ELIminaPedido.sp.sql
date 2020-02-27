IF OBJECT_ID('PAG_EliminaPedido','P') IS NOT NULL
	DROP PROCEDURE PAG_EliminaPedido
GO
CREATE PROCEDURE [dbo].[PAG_EliminaPedido]
(
@codped AS numeric(18,0) -- Numero de Orden
)
AS

DECLARE @error AS  int
DECLARE @trans AS VARCHAR(50)
DECLARE @pedido as varchar(30)

SET @error=0

BEGIN TRANSACTION @trans
	BEGIN TRY 
		
		SELECT @pedido=pedido FROM Pedidos_ficha WHERE Orden=@codped
	
		DELETE FROM pedcaja  WHERE pc_codped=@codped
		
	 	UPDATE Pedidos_ficha SET codvig='1' WHERE Orden=@codped
	 	
	 	UPDATE rackdeta SET racd_estado='0' WHERE racd_codi in (SELECT pallet FROM Pedidos_detalle WHERE pedido=@pedido)
	 	
	 	UPDATE DetaReceCajas SET caj_ped ='0' FROM DetaReceCajas INNER JOIN detapedcaja ON dpc_codcaja = Caj_cod WHERE dpc_codped=@codped
	 	
	 	INSERT INTO movcajas(movc_fecha, movc_codcaja, movc_codrece, movc_tipo, movc_ndoc)
	 	SELECT GETDATE(), dpc_codcaja, dpc_numpal, 'PA', @codped FROM detapedcaja WHERE dpc_codped=@codped
	 	
	 	
	 	DELETE FROM detapedcaja  WHERE dpc_codped=@codped
	 	
	 	DELETE FROM Pedidos_detalle WHERE pedido=@pedido
	 	
	 	DELETE FROM pedidoguias WHERE pguia_codped=@codped
	 	
	 	DELETE FROM pedidos_prg WHERE prg_orden=@codped
	 	
	 	----Actualiza movcajas
	 	--INSERT INTO movcajas(movc_fecha, movc_codcaja, movc_codrece, movc_tipo, movc_ndoc)
	 	--SELECT GETDATE(), dpc_codcaja, dpc_numpal, 'PA', @codped FROM detapedcaja WHERE dpc_codped=@codped
	 	
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION @trans;
		SELECT 1;
		RETURN;
	END CATCH

SELECT @error
	IF(@error=0)
	BEGIN
		COMMIT TRANSACTION @trans
		SELECT 0;
	END


GO


