﻿$(document).ready(function () {
    //var mainBody = $('.content-wrapper');
    //mainBody.find("#create").on('click', create);
    // Attach Button click event listener 
    var placeHolderElement = $('#placeHolderElement');
    $('.btn-success[data-toggle="ajax-modal"]').click(function () {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeHolderElement.html(data);
            placeHolderElement.find('.modal').modal('show');
        })
    })
    $("#btnSubmit").click(function () {

        $.ajax(
            {
                type: "POST", //HTTP POST Method  
                url: "Category/Create", // Controller/View   
                data: { //Passing data  
                    Name: $("#Name").val(), //Reading text box values using Jquery   
                    Description: $("#Description").val()

                },
                success: function (data) {
                    console.log(data);
                    successMessage(data.Message);

                }

            });
    });
    $('#btn-delete').click(function () {
        debugger
        var id = $(this).attr('data-id');

        $.confirm({
            title: 'Delete Category!',
            content: 'Are you sure want to delete category?',
            buttons: {
                confirm: function () {
                    $.ajax({
                        url: 'Category/Delete',
                        type: "POST",
                        data: { id: id },
                        success: function () {
                            // does some stuff here...
                        }
                    });
                },
                cancel: function () {
                    $.alert('Canceled!');
                }
            }
        })
    });
}); 