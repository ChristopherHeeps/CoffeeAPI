USE [CoffeeAPI]
GO

/****** Object:  StoredProcedure [dbo].[CoffeeUserRating_Delete]    Script Date: 31/10/2020 10:53:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CoffeeUserRating_Delete]
	-- Add the parameters for the stored procedure here
	@coffeeId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM CoffeeUserRating
	WHERE CoffeeId = @coffeeId
END
GO


