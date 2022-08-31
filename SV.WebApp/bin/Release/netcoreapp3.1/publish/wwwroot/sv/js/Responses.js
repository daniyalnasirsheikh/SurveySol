

$(function () {

    $('#surveysDDL').change(function () {
        var surveyId = $(this).val();

        if (surveyId != '0') {

            LoadSurveyResponses(surveyId);
        }
        else {
            $('#responsesDiv').html('');
        }
    });

});


function LoadSurveyResponses(surveyId) {

    $.ajax({
        url: '/surveystatistic/responses/' + surveyId,
        //data: { 'id': questionId, 'answerText': selectedText },
        success: function (data) {

            $('#responsesDiv').html(data);
        },
        error: function (error) {

            $('#responsesDiv').html('');
        }
    });

}


