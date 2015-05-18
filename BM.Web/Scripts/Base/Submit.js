jQuery.Submit = function (url, form, successMessage, errorMessage, skipUrl, errorUrl) {
    $.ajax({
        type: "post",
        data: $('#' + form).serialize(),
        url: url,
        success: function (data) {
            if (data == "1" && skipUrl != "") {
                window.location = skipUrl;
            }
        },
        error: function (data) {
            alert(data.error)
            window.location = errorUrl;
        }
    });
}