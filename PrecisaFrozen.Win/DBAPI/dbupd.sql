ALTER TABLE fichrece ADD frec_numsopcustodia SMALLINT 
GO
UPDATE fichrece SET frec_numsopcustodia = 0
GO
ALTER TABLE fichrece ADD frec_codsopcustodia VARCHAR(3)
GO



ALTER TABLE fichdespa ADD fdesp_numsopadic SMALLINT 
GO
UPDATE fichdespa SET fdesp_numsopadic = 0
GO
ALTER TABLE fichdespa ADD fdesp_codsopadic VARCHAR(3)
GO
