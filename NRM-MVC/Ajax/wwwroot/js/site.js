// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function GetList() {
    $.ajax({
        url: "/Person/GetList",
        type: "GET",
        success: function (response) {
            $("#list").html(response); 
            $("#Create").html("");
            $("#Update").html("");
        }
    })
}

function GetCreatePartial() {
    $.ajax({
        url: "/Person/AddPerson",
        type: "GET",
        success: function (response) {
            $("#list").html("");
            $("#Create").html(response);
        }
    })
}


function AddPerson() {
    let personData = {
        firstName: $("#create-name").val(),
        lastName: $("#create-last-name").val()
    }

    $.ajax({
        url: "/Person/AddPerson",
        type: "POST",
        data: personData,
        dataType:"json",
        success: function (response) {
            if (response == "Ok") {
                $("#Create").html("");
                GetList();
            }           
        }
    })
}

function GetUpdatePartial(id) {
    $.ajax({
        url: "/Person/UpdatePerson/"+id,
        type: "GET",
        success: function (response) {
            $("#list").html("");
            $("#Update").html(response);
        }
    })
}

function UpdatePerson(id) {
    let personData = {
        id:id,
        firstName: $("#update-name").val(),
        lastName: $("#update-last-name").val()
    }

    $.ajax({
        url: "/Person/UpdatePerson",
        type: "POST",
        data: personData,
        dataType: "json",
        success: function (response) {
            if (response == "Ok") {
                $("#Update").html("");
                GetList();
            }
        }
    })
}

function DeletePerson(id) {
    $.ajax({
        url: "/Person/DeletePerson/"+id,
        type: "GET",
        success: function (response) {
            if (response == "Ok") {
                GetList();
            }
        }
    })
}
