USE [prueba]
GO

/****** Object:  Table [dbo].[detalle_venta]    Script Date: 24/02/2024 12:46:50 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[detalle_venta](
	[id_producto] [int] NOT NULL,
	[id_venta] [int] NOT NULL,
	[renglon] [int] NULL,
 CONSTRAINT [PK_detalle_venta] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC,
	[id_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_venta_productos] FOREIGN KEY([id_producto])
REFERENCES [dbo].[productos] ([id])
GO

ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [FK_detalle_venta_productos]
GO

ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_venta_ventas] FOREIGN KEY([id_venta])
REFERENCES [dbo].[ventas] ([id])
GO

ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [FK_detalle_venta_ventas]
GO

