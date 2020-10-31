USE [CoffeeAPI]
GO

/****** Object:  StoredProcedure [dbo].[UserRating_Create]    Script Date: 31/10/2020 10:38:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UserRating_Create]
	-- Add the parameters for the stored procedure here
	@comment nvarchar(50),
	@ratingvalue int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		INSERT INTO UserRating
           ([Comment]
           ,[RatingValue])
     VALUES
           (@comment
           ,@ratingvalue)

END
GO


