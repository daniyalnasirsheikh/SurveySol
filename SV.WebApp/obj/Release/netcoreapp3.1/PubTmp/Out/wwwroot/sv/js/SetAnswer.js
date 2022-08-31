/*const { css } = require("jquery");*/

$(function () {

    var optionsTemplate = "<option value='@val'>@text</option>";
    var selectedOptionsTemplate = "<option value='@val' selected='selected'>@text</option>";
    SetAnswers();

    $('#answers').blur(function () {

        SetAnswers();
    });

    function SetAnswers() {
        
        var selectOptions = optionsTemplate.replace('@val', '').replace('@text', 'Select');
        var answers = $('#answers').val();

        if (answers != null) {

            answers = answers.split('\n');

            if (answers != null && answers.length > 0) {

                for (var i = 0; i < answers.length; i++) {

                    if (answers[i] != '') {

                        if (answers[i] != selectedQuestionAnswer) {
                            selectOptions += optionsTemplate.replace('@val', answers[i]).replace('@text', answers[i]);
                        }
                        else {
                            selectOptions += selectedOptionsTemplate.replace('@val', answers[i]).replace('@text', answers[i]);
                        }


                    }
                }
            }

            $('#logicQuestionSelectionId').html(selectOptions);
        }

    }
});


