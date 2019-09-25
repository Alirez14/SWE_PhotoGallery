// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#Edit").click(function() {
    $("#edit").show();
});


$("#Editiptc").click(function() {
    $("#editiptc").show();
});


$("#Editexif").click(function () {
    $("#editexif").show();
});

$("#Delete").click(function () {
    $("#delete").show();
});


$("#Gallery").click(function (e) {
    e.preventDefault();
    $.ajax({
        url: "/Home",
        type: "GET",
        success: function () {
            window.location.replace("/Home/Gallery");
        }
    });

});

function myFunction(imgs) {
    var expandImg = document.getElementById("expandedImg");
    var editpic = document.getElementById("editphoto");
    var iptc = document.getElementById("ipicText");
    editpic.setAttribute("value", imgs.id);
    expandImg.src = imgs.src;
    iptc.innerHTML = imgs.alt;
    expandImg.parentElement.style.display = "block";
}


$("#editphoto").click(function (e) {
    e.preventDefault();
    var value = $("#editphoto").val();
    $.ajax({
        url: "EditPhoto/"+ value ,
        type: "GET",
        success: function () {
            window.location.href = "EditPhoto/" + value ;
        }
    });

});