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