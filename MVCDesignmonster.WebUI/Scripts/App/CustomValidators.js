/// <reference path="jquery.validate.js" />
/// <reference path="jquery.validate.unobtrusive.js" />

// Tror man måste använda .addMinMax istället för addSingleVal:
//$.validator.unobtrusive.adapters.addMinMax("wordcount", "minwords", "maxwords",
//                                      "minmaxwords", [minAttribute, [maxAttribute]]);

$.validator.unobtrusive.adapters.addSingleVal("wordcount", "maxwords");
$.validator.addMethod("wordcount", function (value, element, maxwords) {
    if (value) {
        if (value.split(' ').length > maxwords) {
            return false;
        }
    }
    return true;
});

$.validator.unobtrusive.adapters.addSingleVal("wordcount", "minwords");
$.validator.addMethod("wordcount", function (value, element, minwords) {
    if (value) {
        if (value.split(' ').length < minwords) {
            return false;
        }
    }
    return true;
});


// backup med fungerande addSingleVal ENDAST för maxwords.
//$.validator.unobtrusive.adapters.addSingleVal("wordcount", "maxwords");
//$.validator.addMethod("wordcount", function (value, element, maxwords) {
//    if (value) {
//        if (value.split(' ').length > maxwords) {
//            return false;
//        }
//    }
//    return true;
//});
