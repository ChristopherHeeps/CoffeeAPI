USE [CoffeeAPI]
GO

/****** Object:  StoredProcedure [dbo].[Coffee_Create]    Script Date: 31/10/2020 10:27:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Coffee_Create]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Coffee (name)
	VALUES (@Name)
END
GO


