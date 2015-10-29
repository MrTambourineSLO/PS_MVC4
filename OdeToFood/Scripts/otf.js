/*Hook up JQ to DOM ready event*/
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
            data: $form.serialize()
        };
        //Once we have the options - we need to make async call
        //$.ajax is one of the ways to make async call back to the server
        //We pass it all the options, when it's done (callback func), this
        //function will be invoked and reponse from server will be in data obj
        $.ajax(options).done(function(data) {
            //What is DOM element on the page we want to update?
            var $target = $($form.attr("data-otf-target"));
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
        });
        //Prevent browser from navigating away, going to the server and
        //redrawing the page (it's default action)
        return false;
    };
    //Ui is param that autocomplete passes in -see documentation
    var submitAutocompleteForm = function(event,ui) {
        var $input = $(this);//again - this will point to what DOM el we're interacting w/
        $input.val(ui.item.label);//Manually select input value (to make sure)
        //Find the form via parent and submit it
        var $form = $input.parents("form:first");
        $form.submit();
    };
    var createAutocomplete = function() {
        //For each input that it finds with data-otf-autocomplete attrib.
        //it will invoke this function and pass along that single input as
        //the $(this) reference [$input - dollar sign is only to allow JQ functionality]
        var $input = $(this);
        var options = {
            //Source option is only necessary it tells autocomplete where to
            //get the data
            source: $input.attr("data-otf-autocomplete"),
            //When user selects something from dropdown call a function ....
            select: submitAutocompleteForm
        };
        $input.autocomplete(options);
    };

    /*Select all forms with this attribute set to true*/
    /*After that when user clicks submit, instead of going back to the server*/
    /*it will come into my JS code (ie call function ajaxFormSubmit*/
    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-otf-autocomplete]").each(createAutocomplete);
});