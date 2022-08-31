create PROCEDURE [dbo].[DeleteResponsesBySurveyId]
	@SurveyId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	--drop table #tmpData

	delete from Answer where id in 
	(select a.Id from Answer a 
	inner join SurveyResponseProfile s on a.SurveyResponseProfileId = s.Id 
	where s.SurveyId = @SurveyId);

	delete from SurveyResponseProfile where SurveyId = @SurveyId; 
END