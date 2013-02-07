//http://www.codeproject.com/Articles/422573/Model-Validation-in-ASP-NET-MVC

jQuery.validator.addMethod('future', function (value, element, params) {
    console.log('calling validation future');

    return true;
});

jQuery.validator.unobtrusive.adapters.add("future", ["param"], function(options) {
    options.messages["future"] = options.message;
});

