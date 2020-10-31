USE [CoffeeAPI]
GO

/****** Object:  StoredProcedure [dbo].[CoffeeUserRating_GetAllUserRatingsForCoffee]    Script Date: 31/10/2020 10:48:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CoffeeUserRating_GetAllUserRatingsForCoffee] 
	-- Add the parameters for the stored procedure here
	@coffeeId int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT UserRatingId FROM CoffeeUserRating
	WHERE coffeeId = @coffeeId
END
GO


