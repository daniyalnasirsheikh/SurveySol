
$(function () {

    var questionId = $('#questionId').val();

    if (questionId != 0) {

        $('#Type option').each(function () {
            if ($(this)[0].innerText == 'Logic') {
                $(this)[0].remove(); 
            }
        });
    }

});