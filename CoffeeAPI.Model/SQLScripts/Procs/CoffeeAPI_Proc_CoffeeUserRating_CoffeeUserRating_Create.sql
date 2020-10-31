USE [CoffeeAPI]
GO

/****** Object:  StoredProcedure [dbo].[CoffeeUserRating_Create]    Script Date: 31/10/2020 10:51:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CoffeeUserRating_Create]

	-- Add the parameters for the stored procedure here
	@coffeeId int,
	@userRatingId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO CoffeeUserRating
	(coffeeId, userRatingId)
	VALUES
	(
		@coffeeId,
		@userRatingId
	)
END
GO


