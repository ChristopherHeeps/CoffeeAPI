USE [CoffeeAPI]
GO

/****** Object:  Table [dbo].[CoffeeUserRating]    Script Date: 31/10/2020 10:26:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CoffeeUserRating](
	[Id] [int] NOT NULL,
	[CoffeeId] [int] IDENTITY(1,1) NOT NULL,
	[UserRatingId] [int] NOT NULL,
 CONSTRAINT [PK_CoffeeUserRating] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CoffeeUserRating]  WITH CHECK ADD  CONSTRAINT [FK_CoffeeUserRating_Coffee] FOREIGN KEY([CoffeeId])
REFERENCES [dbo].[Coffee] ([Id])
GO

ALTER TABLE [dbo].[CoffeeUserRating] CHECK CONSTRAINT [FK_CoffeeUserRating_Coffee]
GO

ALTER TABLE [dbo].[CoffeeUserRating]  WITH CHECK ADD  CONSTRAINT [FK_CoffeeUserRating_UserRating] FOREIGN KEY([UserRatingId])
REFERENCES [dbo].[UserRating] ([Id])
GO

ALTER TABLE [dbo].[CoffeeUserRating] CHECK CONSTRAINT [FK_CoffeeUserRating_UserRating]
GO


