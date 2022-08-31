

var progressbar = $("#progressbar"),
    progressLabel = $(".progress-label");

$(function () {

    $('#screen-1, .footer-1').show();



    progressbar.progressbar({
        value: false,
        change: function () {
            progressLabel.text(progressbar.progressbar("value") + "%");
        },
        complete: function () {
            progressLabel.text("Complete!");
        }
    });



    //setTimeout(progress, 2000);

});

function progress() {
    var val = progressbar.progressbar("value") || 0;

    progressbar.progressbar("value", val + 2);

    if (val < 99) {
        setTimeout(progress, 80);
    }
}

function LoadLogicQuestion(questionId, selectedText) {

    $.ajax({
        url: '/survey/previewquestion/' + questionId,
        data: { 'id': questionId, 'answerText': selectedText },
        success: function (data) {

            $('.logicalQuestion-' + questionId).html(data);
        },
        error: function (error) {

            $('.logicalQuestion-' + questionId).html('');
        }
    });

}

function IsMultipleChoiceValid(currentScreenName) {

    var output = true;

    $('#' + currentScreenName + ' [id*=multi]').each(function () {
        var requiredClass = $(this)[0].className;

        if (requiredClass == 'multiRequired') {

            var fieldValue = $(this)[0].value;

            if (fieldValue == null || fieldValue == '') {

                var fieldName = $(this)[0].name.replace('.', '').replace('[', '').replace(']', '');
                $('#' + fieldName + '-ErrorLbl')[0].innerText = 'This field is required';
                output = false;
            }
        }
    });

    return output
}

function IsSemanticValid(currentScreenName) {

    var output = true;

    $('#' + currentScreenName + ' [id*=semantic]').each(function () {
        var requiredClass = $(this)[0].className;

        if (requiredClass == 'multiRequired') {

            var fieldValue = $(this)[0].value;

            if (fieldValue == null || fieldValue == '') {

                var fieldName = $(this)[0].name.replace('.', '').replace('[', '').replace(']', '');
                $('#' + fieldName + '-ErrorLbl')[0].innerText = 'This field is required';
                output = false;
            }
        }
    });

    return output
}

function IsMatrixMultiSelectValid(currentScreenName) {

    var output = true;

    $('#' + currentScreenName + ' [id*=matrixMultiSelect]').each(function () {
        var requiredClass = $(this)[0].className;

        if (requiredClass == 'multiRequired') {

            var fieldValue = $(this)[0].value;

            if (fieldValue == null || fieldValue == '') {

                var fieldName = $(this)[0].name.replace('.', '').replace('[', '').replace(']', '');
                $('#' + fieldName + '-ErrorLbl')[0].innerText = 'This field is required';
                output = false;
            }
        }
    });

    return output
}

function IsRatingValid(currentScreenName) {

    var output = true;

    $('#' + currentScreenName + ' [id*=ratingQuestion]').each(function () {
        var requiredClass = $(this)[0].className;

        if (requiredClass == 'multiRequired') {

            var fieldValue = $(this)[0].value;

            if (fieldValue == null || fieldValue == '') {

                var fieldName = $(this)[0].name.replace('.', '').replace('[', '').replace(']', '');
                $('#' + fieldName + '-ErrorLbl')[0].innerText = 'This field is required';
                output = false;
            }
        }
    });

    return output
}


function IsSurveyPreviewFormValid() {

    var isSuccess = true;
    var currentScreenName = '';

    $('[id*=screen]').each(function () {

        if ($(this).is(':visible')) {
            currentScreenName = $(this).prop('id');
        }
    });

    if (!$('#surveyForm').valid()) {
        isSuccess = false;
    }

    if (!IsMultipleChoiceValid(currentScreenName)) {
        isSuccess = false;
    }

    if (!IsMatrixMultiSelectValid(currentScreenName)) {
        isSuccess = false;
    }

    if (!IsRatingValid(currentScreenName)) {
        isSuccess = false;
    }

    if (!IsSemanticValid(currentScreenName)) {
        isSuccess = false;
    }
    
    return isSuccess;
}

function ShowPage(pageNo, totalPages) {

    if (!IsSurveyPreviewFormValid()) {
        return false;
    }

    $('[id*=screen]').each(function () {
        $(this).hide();
    });

    $('[id*=footer]').each(function () {
        $(this).hide();
    });

    $('#screen-' + pageNo + ', .footer-' + pageNo).show();
    window.scrollTo(0, 0);

    var percentage = Math.floor(((pageNo - 1) / totalPages) * 100);

    progressbar.progressbar("value", percentage);

}


function SetAnswerForMultipleChoice(target, refElement) {

    var val = $(refElement).val();
    var targetVal = $('#' + target).val();    

    if ($(refElement).prop('checked')) {
        targetVal = targetVal + '\n' + val;
    }
    else {
        targetVal = targetVal.replace(val, '');
    }

    targetVal = targetVal.trim();
    $('#' + target).val(targetVal);

    if (targetVal !== null || targetVal == '') {

        var fieldName = $('#' + target).prop('name').replace('.', '').replace('[', '').replace(']', '');
        $('#' + fieldName + '-ErrorLbl')[0].innerText = '';
    }
}

function SetAnswerForSemantic(target, refElement) {

    var val = $(refElement).val();
    var targetVal = $('#' + target).val();
    var output = '';

    var header = val.split(',')[0];

    var values = targetVal.split('\n');

    for (var i = 0; i < values.length; i++) {
        if (values[i].split(',')[0] !== header) {
            output = output + values[i] + '\n';
        }
    }

    output = output + val + '\n';
    output = output.trim();
    $('#' + target).val(output);

    if (targetVal !== null || targetVal == '') {

        var fieldName = $('#' + target).prop('name').replace('.', '').replace('[', '').replace(']', '');
        $('#' + fieldName + '-ErrorLbl')[0].innerText = '';
    }
}

function SetAnswerForMatrixMultiSelect(target, refElement) {

    var val = $(refElement).val();
    var targetVal = $('#' + target).val();

    if ($(refElement).prop('checked')) {
        targetVal = targetVal + '\n' + val;
    }
    else {
        targetVal = targetVal.replace(val, '');
    }

    targetVal = targetVal.trim();
    $('#' + target).val(targetVal);

    if (targetVal !== null || targetVal == '') {

        var fieldName = $('#' + target).prop('name').replace('.', '').replace('[', '').replace(']', '');
        $('#' + fieldName + '-ErrorLbl')[0].innerText = '';
    }
}

