
/// <reference path="jquery.validate.js" />
/// <reference path="jquery.validate.unobtrusive.js" />
$.validator.unobtrusive.adapters.addSingleVal("maxwords", "wordcount");
$.validator.addMethod("maxwords", function (value, element, maxwords) {
    if (value) {
        if (value.split(' ').length > maxwords) {
            return false;
        }
    }
    return true;
});


$.validator.unobtrusive.adapters.addSingleVal("minwords", "wordcount");
$.validator.addMethod("minwords", function (value, element, minwords) {
    if (value) {
        if (value.split(' ').length < minwords) {
            return false;
        }
    }
    return true;
});