IF OBJECT_ID('FuncSolMenor','FN') IS NOT NULL
	DROP FUNCTION FuncSolMenor
GO
CREATE FUNCTION FuncSolMenor
( 
	@Rut NVARCHAR(9),
	@Contrato NVARCHAR(7),
	@FInicio DATE,
	@FTermino DATE,
	@Medida INT
)
RETURNS FLOAT AS BEGIN


	DECLARE @data TABLE (despacho NVARCHAR(7), fpre_nped NVARCHAR(7), fecha VARCHAR(10), fdes_totsopo INT,
	                     ddes_unidades INT, ddes_codsopo INT, ddes_peso FLOAT, despachos INT, ddes_tons FLOAT)


	-- 
	--  DESPACHOS ASOCIADOS A PEDIDOS DE 24 HORAS
	--
	INSERT INTO @data 
	SELECT despacho, fpre_nped As pedido, CAST(CONVERT(DATE,fdes_fecha) As VARCHAR) fecha, fdes_totsopo As pallet,
	       SUM(ddes_unidades), COUNT(ddes_codsopo), SUM(ddes_peso), COUNT(DISTINCT despacho), ROUND(SUM(ddes_peso)/1000,2) 
	  FROM Precisa.dbo.cincuenta 
	 INNER JOIN Precisa.dbo.fichdespa ON fdes_codi = despacho
	 INNER JOIN Precisa.dbo.detadespa ON ddes_codpred = fdes_codpred
	 INNER JOIN Precisa.dbo.fichpred ON fpre_codi = fdes_codpred
	  LEFT JOIN Precisa.dbo.pedidos_ficha ON orden = fpre_nped
	 WHERE cincuenta.cliente = @Rut 
	   AND fdes_fecha BETWEEN @FInicio AND @FTermino
	   AND cincuenta = 1 
	   AND ddes_contcli = @Contrato
	 GROUP BY despacho,fdes_fecha,fdes_totsopo,fpre_nped


	-- 
	--  DESPACHOS ASOCIADOS A PEDIDOS NORMALES, UNIDOS A UN PEDIDO DE 24 HORAS
	--
	INSERT INTO @data 
	SELECT fdes_codi, pedidos_24_horas.orden AS pedido, CAST(CONVERT(DATE,fdes_fecha) As VARCHAR) fecha, fdes_totsopo As pallet,
		   SUM(ddes_unidades), COUNT(ddes_codsopo), SUM(ddes_peso), COUNT(DISTINCT fdes_codi), ROUND(SUM(ddes_peso)/1000,2) 
	  FROM Precisa.dbo.fichdespa 
	 INNER JOIN Precisa.dbo.detadespa ON ddes_codpred = fdes_codpred
	 INNER JOIN Precisa.dbo.fichpred ON fpre_codi = fdes_codpred
     INNER JOIN Precisa.dbo.pedidos_ficha ON orden = fpre_nped
	 INNER JOIN Precisa.dbo.Pedidos_24_Horas ON pedidos_24_horas.orden = CAST(LEFT(ordenconjunta,CHARINDEX('-',ordenconjunta) - 1) AS INT)
	 WHERE fdes_rutcli = @Rut 
	   AND fdes_fecha BETWEEN @FInicio AND @FTermino
	   AND ddes_contcli = @Contrato
	   AND ordenconjunta IS NOT NULL
	 GROUP BY fdes_codi,fdes_fecha,fdes_totsopo,pedidos_24_horas.orden


	DECLARE @SUMA FLOAT;
	SET @SUMA = (SELECT CASE
					WHEN @Medida=1 THEN SUM(ddes_unidades)
					WHEN @Medida=2 THEN COUNT(ddes_codsopo)
					WHEN @Medida=3 THEN SUM(ddes_peso)
					WHEN @Medida=4 THEN COUNT(DISTINCT despacho)
					WHEN @Medida=5 THEN ROUND(SUM(ddes_peso)/1000,2)
				  END
				 FROM @data)

	IF @SUMA IS NULL
	BEGIN
		SET @SUMA=0
	END

	RETURN @SUMA
END
GO
