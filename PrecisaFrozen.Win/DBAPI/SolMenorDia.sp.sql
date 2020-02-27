IF OBJECT_ID('SolMenordia','P') IS NOT NULL
	DROP PROCEDURE SolMenordia
GO
CREATE PROCEDURE SolMenordia
( 
	@Rut NVARCHAR(9),
	@Contrato NVARCHAR(7),
	@Inicio DATE,
	@Termino DATE
)
AS BEGIN

	SET NOCOUNT ON

	DECLARE @data TABLE (despacho NVARCHAR(7), fpre_nped NVARCHAR(7), fecha VARCHAR(10), fdes_totsopo INT)

	-- 
	--  DESPACHOS ASOCIADOS A PEDIDOS DE 24 HORAS
	--
	INSERT INTO @data 
	SELECT despacho, fpre_nped As pedido, CAST(CONVERT(DATE,fdes_fecha) As VARCHAR) fecha, fdes_totsopo As pallet
	  FROM Precisa.dbo.cincuenta 
	 INNER JOIN Precisa.dbo.fichdespa ON fdes_codi = despacho
	 INNER JOIN Precisa.dbo.detadespa ON ddes_codpred = fdes_codpred
	 INNER JOIN Precisa.dbo.fichpred ON fpre_codi = fdes_codpred
	  LEFT JOIN Precisa.dbo.pedidos_ficha ON orden = fpre_nped
	 WHERE cincuenta.cliente = @Rut 
	   AND fdes_fecha BETWEEN @Inicio AND @Termino
	   AND cincuenta = 1 
	   AND ddes_contcli = @Contrato
	 GROUP BY despacho,fdes_fecha,fdes_totsopo,fpre_nped


	-- 
	--  DESPACHOS ASOCIADOS A PEDIDOS NORMALES, UNIDOS A UN PEDIDO DE 24 HORAS
	--
	INSERT INTO @data 
	SELECT fdes_codi, pedidos_24_horas.orden AS pedido, CAST(CONVERT(DATE,fdes_fecha) As VARCHAR) fecha, fdes_totsopo As pallet
	  FROM Precisa.dbo.fichdespa 
	 INNER JOIN Precisa.dbo.detadespa ON ddes_codpred = fdes_codpred
	 INNER JOIN Precisa.dbo.fichpred ON fpre_codi = fdes_codpred
     INNER JOIN Precisa.dbo.pedidos_ficha ON orden = fpre_nped
	 INNER JOIN Precisa.dbo.Pedidos_24_Horas ON pedidos_24_horas.orden = CAST(LEFT(ordenconjunta,CHARINDEX('-',ordenconjunta) - 1) AS INT)
	 WHERE fdes_rutcli = @Rut 
	   AND fdes_fecha BETWEEN @Inicio AND @Termino
	   AND ddes_contcli = @Contrato
	   AND ordenconjunta IS NOT NULL
	 GROUP BY fdes_codi,fdes_fecha,fdes_totsopo,pedidos_24_horas.orden


    --
	--  TOTALES
	--
	INSERT INTO @data
	SELECT '',null,'TOTAL',COUNT(fdes_totsopo)
	  FROM @data

	SELECT * FROM @data

	RETURN
END
/******FIN SOLICITUD MENOR A 24 HORAS******/
GO
