$(document).ready(function () {
    //Reference: https://codeseven.github.io/toastr/
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-center",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "10000",
        "extendedTimeOut": "2000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    var successMessage = function (msg) {
        
        toastr.success(msg);
    };
    var errorMessage = function (msg) {
        debugger
        toastr.error(msg);
    };
    var infoMessage = function (msg) {
        toastr.info(msg);
    };
    var warningMessage = function (msg) {
        toastr.warning(msg);
    };

});