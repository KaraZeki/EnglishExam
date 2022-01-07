
$(document).ready(function () {
    GetWebsiteData();
});


function GetWebsiteData() {
    $.ajax({
        type: "GET",
        url: "../Home/GetWebsiteData",
        success: function (data) {
            
            $.each(data, function (index, value) {
                $('#lstBlogTitle').append('<option value="' + value.link + '">' + value.title + '</option>');
            });
        },
        error: function (xhr, err) {

        },
        complete: function () {

        }
        //contentType: 'application/json; charset=utf-8'
    });
        
}

$('#lstBlogTitle').on('change', function (e) {
    var lstBlogTitleData = $('#lstBlogTitle').val();

    $.ajax({
        type: "GET",
        data: {
            link: lstBlogTitleData
        },
        url: "../Home/GetWebBlogText",
        success: function (data) {
            document.getElementById("blogTextArea").value = "";
            document.getElementById("blogTextArea").value = data;
        },
        error: function (xhr, err) {
            
        },
        complete: function () {

        }
       
    });
});

$("#btnCreateExam").click(function () {
    
    var blogTitle= document.getElementById("blogTextArea").value;
    $.ajax({
        type: "POST",
        data: {
            Title: $("#lstBlogTitle").text(),
            ExamText: blogTitle,
            //1
            Questin1: $("#Question1").val(),
            OptionA1: $("#Question1_OptA").val(),
            OptionB1: $("#Question1_OptB").val(),
            OptionC1: $("#Question1_OptC").val(),
            OptionD1: $("#Question1_OptD").val(),
            Answer1: "Option"+$("#Question1CorrectOpt").val(),
            //2
            Questin2:$("#Question2").val(),
            OptionA2:$("#Question2_OptA").val(),
            OptionB2:$("#Question2_OptB").val(),
            OptionC2:$("#Question2_OptC").val(),
            OptionD2:$("#Question2_OptD").val(),
            Answer2: "Option" + $("#Question2CorrectOpt").val(),
            //3
            Questin3:$("#Question3").val(),
            OptionA3:$("#Question3_OptA").val(),
            OptionB3:$("#Question3_OptB").val(),
            OptionC3:$("#Question3_OptC").val(),
            OptionD3:$("#Question3_OptD").val(),
            Answer3: "Option" +$("#Question3CorrectOpt").val(),
            //4
            Questin4:$("#Question4").val(),
            OptionA4:$("#Question4_OptA").val(),
            OptionB4:$("#Question4_OptB").val(),
            OptionC4:$("#Question4_OptC").val(),
            OptionD4:$("#Question4_OptD").val(),
            Answer4: "Option" +$("#Question4CorrectOpt").val(),
        },
        url: "../Home/CreateExam",
        success: function (data) {
            
        },
        error: function (xhr, err) {

        },
        complete: function () {

        }

    });

})
