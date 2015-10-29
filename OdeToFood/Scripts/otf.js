﻿/*Hook up JQ to DOM ready event*/
/*This script executes when DOM is ready,
when all HTML is recieved,parrsed, put into memory and
DOM*/
$(function () {
    //Inside this func it's our responibility to handle this form submission
    /*
    ie Collect all params, send them to server, get result back and put it into
    page somewhere.
    */
    var ajaxFormSubmit = function () {
        //Grab a ref to the form that is being submitted
        var $form = $(this);
        //Create options object that will contain attributes we need
        var options = {
            url: $form.attr("action"),
            //GET or POST ?
            type: $form.attr("method"),
            //Data to send along to the server
            //IE collect whatever is submitted and put it into
            //key/value pairs
            data: $form.attr.serialize()
        };
        //Once we have the options - we need to make async call
        //$.ajax is one of the ways to make async call back to the server
        //We pass it all the options, when it's done (callback func), this
        //function will be invoked and reponse from server will be in data obj
        $.ajax(options).done(function(data) {
            //What is DOM element on the page we want to update?
            var $target = $($form.attr("data-otf-target"));
            $target.replaceWith(data);
        });
        //Prevent browser from navigating away, going to the server and
        //redrawing the page (it's default action)
        return false;
    };

    /*Select all forms with this attribute set to true*/
    /*After that when user clicks submit, instead of going back to the server*/
    /*it will come into my JS code (ie call function ajaxFormSubmit*/
    $("form[data-otf-ajax='true]").submit(ajaxFormSubmit);

});