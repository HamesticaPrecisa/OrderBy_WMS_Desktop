ALTER TABLE fichrece ADD frec_numsopcustodia SMALLINT 
GO
ALTER TABLE fichrece ADD CONSTRAINT df_fichrece_frec_numsopcustodia DEFAULT 0 FOR frec_numsopcustodia
GO
UPDATE fichrece SET frec_numsopcustodia = 0
GO
ALTER TABLE fichrece ADD frec_codsopcustodia VARCHAR(3)
GO
ALTER TABLE fichrece ADD CONSTRAINT df_fichrece_frec_codsopcustodia DEFAULT '' FOR frec_codsopcustodia
GO
UPDATE fichrece SET frec_codsopcustodia = ''
GO



ALTER TABLE fichdespa ADD fdes_numsopadic SMALLINT 
GO
ALTER TABLE fichdespa ADD CONSTRAINT df_fichdespa_fdes_numsopadic DEFAULT 0 FOR fdes_numsopadic
GO
UPDATE fichdespa SET fdes_numsopadic = 0
GO
ALTER TABLE fichdespa ADD fdesp_codsopadic VARCHAR(3)
GO
ALTER TABLE fichdespa ADD CONSTRAINT df_fichdespa_fdes_codsopadic DEFAULT '' FOR fdes_codsopadic
GO
UPDATE fichdespa SET fdes_codsopadic = ''
GO


ALTER TABLE control_pallet ADD idarriendo INT
GO
ALTER TABLE control_pallet_log ADD idarriendo INT
GO

ALTER TABLE detapred ADD dpre_cajsel INT
GO
ALTER TABLE detapred ADD CONSTRAINT df_detapred_dpre_cajsel DEFAULT 0 FOR dpre_cajsel
GO
CREATE INDEX ix_detapred_dpre_cajsel ON detapred(dpre_cajsel)
GO

ALTER TABLE tmpdetapred ADD dpre_cajsel INT 
GO
ALTER TABLE tmpdetapred ADD CONSTRAINT df_tmpdetapred_dpre_cajsel DEFAULT 0 FOR dpre_cajsel
GO
