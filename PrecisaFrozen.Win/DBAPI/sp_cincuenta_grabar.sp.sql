IF OBJECT_ID('SP_Cincuenta_Grabar','P') IS NOT NULL
	DROP PROCEDURE SP_Cincuenta_Grabar
GO
create proc SP_Cincuenta_Grabar(
	@Npred varchar(10),
	@Ndesp varchar(10),
	@RutCli varchar(10),
	@Carga varchar(10),
	@Cincuenta int,
	@Fec varchar(10)
)
as
begin
	update cincuenta
	set despacho=@Ndesp,cliente=@RutCli,
		carga=@Carga,cincuenta=@Cincuenta,
		fecha=CONVERT(DATETIME, @Fec, 103)
	where folio=@Npred

	if(@@ROWCOUNT=0)
	begin
		insert into cincuenta(
			folio,despacho,cliente,
			carga,cincuenta,fecha
		)values(
			@Npred,@Ndesp,@RutCli,
			@Carga,@Cincuenta,CONVERT(DATETIME, @Fec, 103)
		)
	end
end
GO

