-- vwSaldosPalletCustodia
-- Saldo actual de pallets en custodia por cliente y contrato
--
IF OBJECT_ID('vwSaldosPalletCustodia') IS NOT NULL
	DROP VIEW vwSaldosPalletCustodia
GO
CREATE VIEW vwSaldosPalletCustodia
AS
	WITH ult_mov AS
	(
		SELECT rut_cliente, contrato, MAX(ID) AS lastid
		  FROM control_pallet
		 GROUP BY rut_cliente, contrato
	)
	SELECT a.rut_cliente, a.contrato, a.saldo
	  FROM control_pallet a
	 INNER JOIN ult_mov b ON b.lastid = a.id
GO
