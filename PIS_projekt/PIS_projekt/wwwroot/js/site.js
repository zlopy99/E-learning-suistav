//document.getElementById("one").id = "shelter_image"
$(window).on("load", function () {
    $(".loader-wrapper, .loader").fadeOut(1000);
    
});

ShowPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal("show");
        }
    })
}

JQueryAjaxPost = form => {

    try {
        $.ajax({
            type: "POST",
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid == true) {
                    $("#form-modal .modal-body").html('');
                    $("#form-modal .modal-title").html('');
                    $("#form-modal").modal("hide");
                }
                else {
                    $("#form-modal .modal-body").html(res.html);
                }
            },
            error: function (err) {
                consloe.log("Error2 je:",err);
            }
        })
    }
    catch (e) {
        console.log("Error je:",e);
    }

    return false;
}

JQueryAjaxDelete = form => {
    if (confirm("Jeste li sigurni?")) {
        try {
            $.ajax({
                type: "POST",
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $("#form-modal .modal-body").html(res.html);
                },
                error: function (err) {
                    consloe.log("Error2 je:", err);
                }
            })
        }
        catch (e) {
            console.log(e);
        }
    }
    return false;
}