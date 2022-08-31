
$(function () {

    $('.chartDDL').change(function () {

        var questionId = $('option:selected', this).attr('data-questionId');
        var chartType = $('option:selected', this).attr('data-chartType');

        if (chartType != 0) {

            $.ajax({
                url: '/surveystatistic/chart',
                data: { 'chartType': chartType, 'questionId': questionId },
                success: function (data) {

                    $('#chart-' + questionId).html(data);
                },
                error: function (error) {

                    $('#chart-' + questionId).html('');
                }
            });
        }
        else {
            $('#chart-' + questionId).html('');
        }



    });

});

function PrintToPDF() {
    var SectionToPrint = document.getElementById('sectionToPrint');
    html2pdf().from(SectionToPrint).set
        ({
            margin: [30, 10, 5, 10],
            filename: 'Survey-Dashboard.pdf',
            pagebreak: { mode: ['avoid-all', 'css', 'legacy'] },
            jsPDF: { orientation: 'portrait', unit: 'pt', format: 'letter', compressPDF: true }
        }).save()

}

function PrintPDF() {

    $('.buttonHolder').html('');
    $('.buttonHolder').addClass('buttonHolder1');
    $('.buttonHolder').removeClass('buttonHolder');
    $('.emptySpaceBtn').hide();
    $('.dashboard-firstInnerdiv').addClass('extendFirstHeight');
    $('.dashboard-innerdiv').addClass('extendHeight');

    var buttonHtml = '<button class="primaryAction" type="button" onclick="PrintPDF()">Print</button>';

    var HTML_Width = document.body.clientWidth;
    var HTML_Height = document.body.clientHeight;
    var top_left_margin = 15;
    var PDF_Width = HTML_Width + (top_left_margin * 2);
    var PDF_Height = (PDF_Width * 1.5) + (top_left_margin * 2);
    debugger;
    var canvas_image_width = HTML_Width;
    var canvas_image_height = HTML_Height;

    var totalPDFPages = Math.ceil(HTML_Height / PDF_Height) - 1;

    html2canvas(document.body, { allowTaint: true }).then(function (canvas) {
        canvas.getContext('2d');

        console.log(canvas.height + "  " + canvas.width);


        var imgData = canvas.toDataURL("image/jpeg", 1.0);

        var pdf = new jsPDF('p', 'pt', [PDF_Width, PDF_Height]);
        pdf.addImage(imgData, 'JPG', top_left_margin, top_left_margin, canvas_image_width, canvas_image_height);
        pdf.addImage(imgData, 'JPG', top_left_margin, top_left_margin, canvas_image_width, canvas_image_height);

        for (var i = 1; i <= totalPDFPages; i++) {
            pdf.addPage(PDF_Width, PDF_Height);
            var margin = -(PDF_Height * i) + (top_left_margin * 4);
            pdf.addImage(imgData, 'JPG', top_left_margin, margin, canvas_image_width, canvas_image_height);
        }

        pdf.save("survey-dashboard.pdf");

        $('.buttonHolder1').addClass('buttonHolder');
        $('.buttonHolder1').removeClass('buttonHolder1');
        $('.dashboard-innerdiv').removeClass('extendHeight');
        $('.dashboard-firstInnerdiv').removeClass('extendFirstHeight');
        $('.buttonHolder').html(buttonHtml);
        $('.emptySpaceBtn').show();
    });



}

function AddEmtpySpace(refElem) {

    $($(refElem).parents('div')[0]).append('<div class="emptySpace">&nbsp;</div>');
}