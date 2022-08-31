


function RatingClick(mood, refElement) {

    var targetValue = $('#' + refElement).val();
    $('#' + refElement).val(mood);

    $('#terrible').removeClass('rating-selected');
    $('#bad').removeClass('rating-selected');
    $('#okay').removeClass('rating-selected');
    $('#good').removeClass('rating-selected');
    $('#great').removeClass('rating-selected');

    if (mood == 1) {

        $('#terrible').addClass('rating-selected');
    }
    else if (mood == 2) {

        $('#bad').addClass('rating-selected');
    }
    else if (mood == 3) {

        $('#okay').addClass('rating-selected');
    }
    else if (mood == 4) {

        $('#good').addClass('rating-selected');
    }
    else if (mood == 5) {

        $('#great').addClass('rating-selected');
    }

    //$('#btn-submit').removeAttr('disabled');
    //$('#btn-submit').removeClass('disabledBtn');

    if (targetValue !== null || targetValue == '') {

        var fieldName = $('#' + refElement).prop('name').replace('.', '').replace('[', '').replace(']', '');
        $('#' + fieldName + '-ErrorLbl')[0].innerText = '';
    }

}

function SubmitRating() {

    $('#SaveBtn').click();
}
