USE [CoffeeAPI]
GO

/****** Object:  StoredProcedure [dbo].[UserRating_GetUserRating]    Script Date: 31/10/2020 10:40:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UserRating_GetUserRating]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, Comment, RatingValue  FROM UserRating
	WHERE Id = @id
END
GO


