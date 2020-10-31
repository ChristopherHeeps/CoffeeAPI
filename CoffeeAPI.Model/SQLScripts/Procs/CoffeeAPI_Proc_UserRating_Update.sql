USE [CoffeeAPI]
GO

/****** Object:  StoredProcedure [dbo].[UserRating_Update]    Script Date: 31/10/2020 10:44:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UserRating_Update]
	-- Add the parameters for the stored procedure here
	@id int,
	@comment nvarchar(50),
	@ratingValue int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE UserRating
	SET Comment = @comment,
	RatingValue = @ratingValue
	WHERE Id = @id
END
GO


