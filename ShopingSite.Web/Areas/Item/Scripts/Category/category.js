$(document).ready(function () {
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
        var $form = $("#categoryModal").find('#Category');
        var url = $form.attr('action');
        $.ajax(
            {
                type: "POST", //HTTP POST Method  
                url: url,
                data: { //Passing data  
                    Id: $("#Id").val(),
                    Name: $("#Name").val(), //Reading text box values using Jquery   
                    Description: $("#Description").val()

                },
                success: function (data) {
                    successMessage(data.Message);
                    setTimeout(function () { location.reload(); }, 2000);
                }

            });
    });
    $('.delete').click(function () {
        
        var id = $(this).attr('data-id');

        $.confirm({
            title: 'Delete Category!',
            content: 'Are you sure want to delete category?',
            buttons: {
                confirm: function () {
                    $.ajax({
                        url: '/Category/Delete',
                        type: "POST",
                        data: { id: id },
                        success: function (data) {
                            successMessage(data.Message);
                            
                            setTimeout(function () { location.reload(); }, 2000);
                        }
                    });
                },
                cancel: function () {
                    $.alert('Canceled!');
                }
            }
        })
    });

    $('.edit').click(function () {
        
        var Id = $(this).attr('data-id');
        var url = ['/Category/Edit/', Id].join('');
        $.get(url).done(function (data) {
            placeHolderElement.html(data);
            placeHolderElement.find('.modal').modal('show');
            placeHolderElement.find('.modal').find("#Category").attr("action", "/Category/Edit");
        })
    })
}); 