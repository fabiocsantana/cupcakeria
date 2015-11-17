CREATE TABLE [dbo].[Administrador] (
    [pk_idAdministracao] INT             IDENTITY (1, 1) NOT NULL,
    [loginAdmSenha]      NVARCHAR (4000) NULL,
    [loginAdmSalt]       NVARCHAR (4000) NULL,
    CONSTRAINT [PK_dbo.Administrador] PRIMARY KEY CLUSTERED ([pk_idAdministracao] ASC)
);


CREATE TABLE [dbo].[Cliente] (
    [pk_idCliente]    INT             IDENTITY (1, 1) NOT NULL,
    [nomeCliente]     NVARCHAR (MAX)  NOT NULL,
    [dataNascCliente] DATETIME        NOT NULL,
    [telCliente]      NVARCHAR (10)   NOT NULL,
    [emailCliente]    NVARCHAR (MAX)  NOT NULL,
    [loginUsuSenha]   NVARCHAR (4000) NULL,
    [loginUsuSalt]    NVARCHAR (4000) NULL,
    CONSTRAINT [PK_dbo.Cliente] PRIMARY KEY CLUSTERED ([pk_idCliente] ASC)
);


CREATE TABLE [dbo].[Endereco] (
    [pk_idEndereco]  INT            IDENTITY (1, 1) NOT NULL,
    [fk_idCliente]   INT            NOT NULL,
    [cepEndereco]    NVARCHAR (8)   NOT NULL,
    [logrEndereco]   NVARCHAR (MAX) NOT NULL,
    [numEndereco]    FLOAT (53)     NOT NULL,
    [complEndereco]  NVARCHAR (MAX) NULL,
    [bairroEndereco] NVARCHAR (MAX) NOT NULL,
    [cidEndereco]    NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.Endereco] PRIMARY KEY CLUSTERED ([pk_idEndereco] ASC),
    CONSTRAINT [FK_dbo.Endereco_dbo.Cliente_fk_idCliente] FOREIGN KEY ([fk_idCliente]) REFERENCES [dbo].[Cliente] ([pk_idCliente]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_fk_idCliente]
    ON [dbo].[Endereco]([fk_idCliente] ASC);


CREATE TABLE [dbo].[Massa] (
    [pk_idMassa]      INT            IDENTITY (1, 1) NOT NULL,
    [descrMassa]      NVARCHAR (MAX) NOT NULL,
    [valorUnitMassa]  FLOAT (53)     NOT NULL,
    [dtCadastroMassa] DATETIME       NULL,
    [dispMassa]       BIT            NOT NULL,
    CONSTRAINT [PK_dbo.Massa] PRIMARY KEY CLUSTERED ([pk_idMassa] ASC)
);


CREATE TABLE [dbo].[Recheio] (
    [pk_idRecheio]      INT            IDENTITY (1, 1) NOT NULL,
    [descrRecheio]      NVARCHAR (MAX) NOT NULL,
    [valorUnitRecheio]  FLOAT (53)     NOT NULL,
    [dtCadastroRecheio] DATETIME       NULL,
    [dispRecheio]       BIT            NOT NULL,
    CONSTRAINT [PK_dbo.Recheio] PRIMARY KEY CLUSTERED ([pk_idRecheio] ASC)
);


CREATE TABLE [dbo].[Cobertura] (
    [pk_idCobertura]      INT            IDENTITY (1, 1) NOT NULL,
    [descrCobertura]      NVARCHAR (MAX) NOT NULL,
    [valorUnitCobertura]  FLOAT (53)     NOT NULL,
    [dtCadastroCobertura] DATETIME       NULL,
    [dispCobertura]       BIT            NOT NULL,
    CONSTRAINT [PK_dbo.Cobertura] PRIMARY KEY CLUSTERED ([pk_idCobertura] ASC)
);


CREATE TABLE [dbo].[Pedido] (
    [pk_idPedido]    INT        IDENTITY (1, 1) NOT NULL,
    [fk_idCliente]   INT        NULL,
    [statusPedido]   BIT        NULL,
    [vlrTotalPedido] FLOAT (53) NULL,
    [dataPedido]     DATETIME   NULL,
    [fk_idEndereco]  INT        NULL,
    CONSTRAINT [PK_dbo.Pedido] PRIMARY KEY CLUSTERED ([pk_idPedido] ASC),
    CONSTRAINT [FK_dbo.Pedido_dbo.Cliente_fk_idCliente] FOREIGN KEY ([fk_idCliente]) REFERENCES [dbo].[Cliente] ([pk_idCliente]),
    CONSTRAINT [FK_dbo.Pedido_dbo.Endereco_fk_idEndereco] FOREIGN KEY ([fk_idEndereco]) REFERENCES [dbo].[Endereco] ([pk_idEndereco])
);


GO
CREATE NONCLUSTERED INDEX [IX_fk_idCliente]
    ON [dbo].[Pedido]([fk_idCliente] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_fk_idEndereco]
    ON [dbo].[Pedido]([fk_idEndereco] ASC);


CREATE TABLE [dbo].[Cupcake Pedido] (
    [pk_idCupcake]      INT        IDENTITY (1, 1) NOT NULL,
    [fk_idMassa]        INT        NOT NULL,
    [fk_idRecheio]      INT        NOT NULL,
    [fk_idCobertura]    INT        NOT NULL,
    [valorCupcake]      FLOAT (53) NOT NULL,
    [fk_idPedido]       INT        DEFAULT ((0)) NOT NULL,
    [valorTotalCupcake] FLOAT (53) DEFAULT ((0)) NOT NULL,
    [qtdeItem]          INT        DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.Cupcake Pedido] PRIMARY KEY CLUSTERED ([pk_idCupcake] ASC),
    CONSTRAINT [FK_dbo.Cupcake Pedido_dbo.Massa_fk_idMassa] FOREIGN KEY ([fk_idMassa]) REFERENCES [dbo].[Massa] ([pk_idMassa]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Cupcake Pedido_dbo.Recheio_fk_idRecheio] FOREIGN KEY ([fk_idRecheio]) REFERENCES [dbo].[Recheio] ([pk_idRecheio]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Cupcake Pedido_dbo.Cobertura_fk_idCobertura] FOREIGN KEY ([fk_idCobertura]) REFERENCES [dbo].[Cobertura] ([pk_idCobertura]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Cupcake Pedido_dbo.Pedido_fk_idPedido] FOREIGN KEY ([fk_idPedido]) REFERENCES [dbo].[Pedido] ([pk_idPedido]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_fk_idMassa]
    ON [dbo].[Cupcake Pedido]([fk_idMassa] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_fk_idRecheio]
    ON [dbo].[Cupcake Pedido]([fk_idRecheio] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_fk_idCobertura]
    ON [dbo].[Cupcake Pedido]([fk_idCobertura] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_fk_idPedido]
    ON [dbo].[Cupcake Pedido]([fk_idPedido] ASC);

