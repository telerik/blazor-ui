function round(value, decimals) {
    // taken from https://www.jacklmoore.com/notes/rounding-in-javascript/
    return Number(Math.round(value + 'e' + decimals) + 'e-' + decimals);
    // just an example of working with input and modifying it
}

function conditionalRendering(dataItem) {
    if (dataItem.ExtraData) {
        return dataItem.ExtraData;
    }
    return "";
    // if you don't want anything rendered, return an empty string
    // if you don't return anything you will get "undefined" rendered
}

function forLoop(categoryText) {
    var result = "";
    for (var i = 0; i < categoryText.length; i++) {
        result += categoryText[i] + "\n"; // new line just to showcase the concept
    }
    return result;
}