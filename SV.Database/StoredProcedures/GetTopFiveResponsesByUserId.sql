
CREATE PROCEDURE GetTopFiveResponsesByUserId 
	@UserId nvarchar(450)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	--drop table #tmpData

	select * into #tmpData from (

	Select srp.* from dbo.SurveyResponseProfile srp 
	inner join dbo.Survey s on srp.SurveyId = s.Id
	left join dbo.UserShareSurvey uss on uss.SurveyId = srp.Id
	where s.UserId = @UserId

	) as x

	Select * from #tmpData
	order by Id desc
	OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY;
END
GO
