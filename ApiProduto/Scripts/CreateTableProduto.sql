﻿CREATE TABLE [dbo].[Produtos](
	[CD_PRODUTO] INT PRIMARY KEY IDENTITY NOT NULL,
    [TX_DESCRICAO] VARCHAR(500) NOT NULL,
	[BL_ATIVO] BIT DEFAULT 1,
	[DT_FABRICACAO] datetime NOT NULL,
	[DT_VALIDADE] datetime NOT NULL,
	[CD_FORNECEDOR] VARCHAR(500) NULL,
	[TX_DESCRICAO_FORNECEDOR] VARCHAR(500) NULL,
	[TX_CNPJ_FORNECEDOR] VARCHAR(500) NULL
)