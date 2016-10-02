function onBegin() {
    $("#searchResult").hide();
     $('input[type="submit"]').prop("disabled", true);
}

function onComplete() {
    $("#searchResult").show();

     $('input[type="submit"]').prop("disabled", false);

}
function onSuccess() {
$("#username").val("");
}

function onFailure() {
    //alert("Something went wrong!!");
}


function validateForm() {
    var x = $("#username").val();
    if (x == "") {
        command: toastr["warning"]("Please Enter username to search");

        toastr.options = {
            "closeButton": true,
            "debug": false,

            "positionClass": "toast-top-center",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut",


            "newestOnTop": false,
            "progressBar": false,
            "preventDuplicates": true,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing"



        }

        return false;
    } else {
        return true;
    }
}


var glower = $(".imglow");
window.setInterval(function() {  
    glower.toggleClass("active");
}, 1000);