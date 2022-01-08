
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
    
    var examText = document.getElementById("blogTextArea").value;
   
    var select = document.getElementById('lstBlogTitle');
    var blogTitle = select.options[select.selectedIndex].text;

    if (!Validation()) {
        toastr.warning("please check all content!");
    }
    else {
        $.ajax({
            type: "POST",
            data: {
                Title: blogTitle,
                ExamText: examText,
                //1
                Questin1: $("#Question1").val(),
                OptionA1: $("#Question1_OptA").val(),
                OptionB1: $("#Question1_OptB").val(),
                OptionC1: $("#Question1_OptC").val(),
                OptionD1: $("#Question1_OptD").val(),
                Answer1: "Option" + $("#Question1CorrectOpt").val(),
                //2
                Questin2: $("#Question2").val(),
                OptionA2: $("#Question2_OptA").val(),
                OptionB2: $("#Question2_OptB").val(),
                OptionC2: $("#Question2_OptC").val(),
                OptionD2: $("#Question2_OptD").val(),
                Answer2: "Option" + $("#Question2CorrectOpt").val(),
                //3
                Questin3: $("#Question3").val(),
                OptionA3: $("#Question3_OptA").val(),
                OptionB3: $("#Question3_OptB").val(),
                OptionC3: $("#Question3_OptC").val(),
                OptionD3: $("#Question3_OptD").val(),
                Answer3: "Option" + $("#Question3CorrectOpt").val(),
                //4
                Questin4: $("#Question4").val(),
                OptionA4: $("#Question4_OptA").val(),
                OptionB4: $("#Question4_OptB").val(),
                OptionC4: $("#Question4_OptC").val(),
                OptionD4: $("#Question4_OptD").val(),
                Answer4: "Option" + $("#Question4CorrectOpt").val(),
            },
            url: "../Home/CreateExam",
            success: function (data) {
                if (data.isOk) {
                    
                    toastr.success("Exam has successfully created!")
                    ClearCache();
                } else {
                    toastr.warning(data.message)
                }
            },
            error: function (xhr, err) {

            },
            complete: function () {

            }

        });
    }
   

})

function Validation() {
    if ($("#lstBlogTitle").text() == "Bir Başlık Seç" ||

        //1
        $("#Question1").val() == null ||
        $("#Question1_OptA").val() == null ||
        $("#Question1_OptB").val() == null ||
        $("#Question1_OptC").val() == null ||
        $("#Question1_OptD").val() == null ||
        $("#Question1CorrectOpt").val() == "Doğru Cevap" ||

        //2
        $("#Question2").val() == null ||
        $("#Question2_OptA").val() == null ||
        $("#Question2_OptB").val() == null ||
        $("#Question2_OptC").val() == null ||
        $("#Question2_OptD").val() == null ||
        $("#Question2CorrectOpt").val() == "Doğru Cevap" ||

        //2
        $("#Question3").val() == null ||
        $("#Question3_OptA").val() == null ||
        $("#Question3_OptB").val() == null ||
        $("#Question3_OptC").val() == null ||
        $("#Question3_OptD").val() == null ||
        $("#Question3CorrectOpt").val() == "Doğru Cevap" ||

        //3
        $("#Question4").val() == null ||
        $("#Question4_OptA").val() == null ||
        $("#Question4_OptB").val() == null ||
        $("#Question4_OptC").val() == null ||
        $("#Question4_OptD").val() == null ||
        $("#Question4CorrectOpt").val() == "Doğru Cevap" )
    {
        return false;
    } else {
        return true;
    }
}

function ClearCache() {
    //1
    $("#Question1").val("");
    $("#Question1_OptA").val("");
    $("#Question1_OptB").val("");
    $("#Question1_OptC").val("");
    $("#Question1_OptD").val("");
    $("#Question1CorrectOpt").val("");

    //2
    $("#Question2").val("");
    $("#Question2_OptA").val("");
    $("#Question2_OptB").val("");
    $("#Question2_OptC").val("");
    $("#Question2_OptD").val("");
    $("#Question2CorrectOpt").val("");

    //2
    $("#Question3").val("");
    $("#Question3_OptA").val("");
    $("#Question3_OptB").val("");
    $("#Question3_OptC").val("");
    $("#Question3_OptD").val("");
    $("#Question3CorrectOpt").val("");

    //3
    $("#Question4").val("");
    $("#Question4_OptA").val("");
    $("#Question4_OptB").val("");
    $("#Question4_OptC").val("");
    $("#Question4_OptD").val("");
    $("#Question4CorrectOpt").val("");


}
