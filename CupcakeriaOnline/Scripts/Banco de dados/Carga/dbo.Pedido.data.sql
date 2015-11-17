SET IDENTITY_INSERT [dbo].[Pedido] ON
INSERT INTO [dbo].[Pedido] ([pk_idPedido], [fk_idCliente], [statusPedido], [vlrTotalPedido], [dataPedido], [fk_idEndereco]) VALUES (1, 1, 0, 64, N'2015-11-15 06:06:36', 1)
INSERT INTO [dbo].[Pedido] ([pk_idPedido], [fk_idCliente], [statusPedido], [vlrTotalPedido], [dataPedido], [fk_idEndereco]) VALUES (2, 1, 1, 12, N'2015-11-16 11:20:29', 2)
INSERT INTO [dbo].[Pedido] ([pk_idPedido], [fk_idCliente], [statusPedido], [vlrTotalPedido], [dataPedido], [fk_idEndereco]) VALUES (3, 1, 1, 80, N'2015-11-17 09:03:15', 1)
INSERT INTO [dbo].[Pedido] ([pk_idPedido], [fk_idCliente], [statusPedido], [vlrTotalPedido], [dataPedido], [fk_idEndereco]) VALUES (4, 2, 0, 31.2, N'2015-11-17 09:36:26', 3)
INSERT INTO [dbo].[Pedido] ([pk_idPedido], [fk_idCliente], [statusPedido], [vlrTotalPedido], [dataPedido], [fk_idEndereco]) VALUES (5, 2, 0, 42.5, N'2015-11-17 09:36:52', 3)
INSERT INTO [dbo].[Pedido] ([pk_idPedido], [fk_idCliente], [statusPedido], [vlrTotalPedido], [dataPedido], [fk_idEndereco]) VALUES (6, 5, 0, 83, N'2015-11-17 09:38:09', 5)
INSERT INTO [dbo].[Pedido] ([pk_idPedido], [fk_idCliente], [statusPedido], [vlrTotalPedido], [dataPedido], [fk_idEndereco]) VALUES (7, 5, 1, 21.3, N'2015-11-17 09:38:33', 6)
INSERT INTO [dbo].[Pedido] ([pk_idPedido], [fk_idCliente], [statusPedido], [vlrTotalPedido], [dataPedido], [fk_idEndereco]) VALUES (8, 6, 0, 45.6, N'2015-11-17 09:39:31', 8)
INSERT INTO [dbo].[Pedido] ([pk_idPedido], [fk_idCliente], [statusPedido], [vlrTotalPedido], [dataPedido], [fk_idEndereco]) VALUES (9, 6, 1, 40, N'2015-11-17 09:40:06', 7)
SET IDENTITY_INSERT [dbo].[Pedido] OFF
