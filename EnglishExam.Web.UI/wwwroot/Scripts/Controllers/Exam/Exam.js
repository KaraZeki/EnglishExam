﻿
$(document).ready(function () {
 
});


$("#btnComplateExam").click(function () {
    CheckExam();
})

function CheckExam() {
    
    //Selected Answer
    var option1 = $('input[type=radio][name=btnradio_1]:checked').attr('id');
    var option2 = $('input[type=radio][name=btnradio_2]:checked').attr('id');
    var option3 = $('input[type=radio][name=btnradio_3]:checked').attr('id');
    var option4 = $('input[type=radio][name=btnradio_4]:checked').attr('id');

    //Answer Splitted
    var answer1 = option1.split("_")[0];
    var answer2 = option2.split("_")[0];
    var answer3 = option3.split("_")[0];
    var answer4 = option4.split("_")[0];

    //Selected Question Id
    var question1Id = $("#question_1").val();
    var question2Id = $("#question_2").val();
    var question3Id = $("#question_3").val();
    var question4Id = $("#question_4").val();


    $.ajax({
        type: "POST",
        url: "../Exam/CheckExam",
        data: {
            question1Id:question1Id,
            question2Id:question2Id,
            question3Id:question3Id,
            question4Id:question4Id,
            answer1:answer1,
            answer2:answer2,
            answer3:answer3,
            answer4:answer4,

        },
        success: function (data) {
            console.log("data", data)
            var counter = 1;
            $.each(data, function (index, value) {
                console.log("data.IsCorrect", value.isCorrect, "", value.userAnswer, "", value.correctAnswer)
                if (value.isCorrect) {

                    //$('#' + value.correctAnswer + '_' + counter).text("").toggleClass("btn-outline-primary btn-outline-Danger");
                    $("#lbl_" + value.correctAnswer + '_' + counter).removeClass("btn btn-outline-primary").addClass("btn btn-outline-success active");
                    //console.log($('#' + value.correctAnswer + '_' + counter).val());
                }
                else {
                    $("#lbl_" + value.userAnswer + '_' + counter).removeClass("btn btn-outline-primary").addClass("btn btn-outline-danger active");
                    //console.log($('#' + value.userAnswer + '_' + counter).val());
                }
                counter++;
                console.log(counter);
              
            });
        },
        error: function (xhr, err) {

        },
        complete: function () {

        }
        
    });

}