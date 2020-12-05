var dotNetComponent;
var containerElem;
var pasteTextArea;

function initializeExcelPasting(elem, dotnetObject) {
    if (elem && dotnetObject) {
        containerElem = elem;
        dotNetComponent = dotnetObject;
        // when focus moves to the grid, we will start listening for pasted content
        // getting the pasted data generally requires a content editable element or an input
        // using a content editable element is not an option because it would let
        // people alter and break the components and content inside
        // so we have to hack an input in only when needed
        elem.addEventListener("focusin", createTextArea);
    }
}

function cleanUpExcelPasting(elem) {
    if (elem) {
        elem.removeEventListener();
        dotNetComponent = null;
        containerElem = null;
        destroyTextArea();
    }
}

function pasteHandler(e) {
    dotNetComponent.invokeMethodAsync("PasteHandler", e.clipboardData.getData("Text"));
    // after pasting, we could remove the textarea to let the user interact with the grid fully
    // consider tweaking when and how and where this textarea is depending on your
    // preferences, UX requirements and needs, and user feedback
    //destroyTextArea();
    // now we will only clean its value to prevent it from getting far too long in case of performance issues
    pasteTextArea.value = "";
}

function createTextArea() {
    if (pasteTextArea) return;
    // the goal is to position an invisible (transparent) textarea above the grid
    // either entirely, or somewhere out of sight
    // so we can capture its paste event and push it to the Blazor code
    pasteTextArea = document.createElement("textarea");
    pasteTextArea.style.position = "absolute";
    pasteTextArea.style.opacity = 0;
    pasteTextArea.style.border = "none";
    pasteTextArea.style.height = 0;
    pasteTextArea.style.width = 0;
    pasteTextArea.style.top = 0;
    containerElem.appendChild(pasteTextArea);

    pasteTextArea.addEventListener("paste", pasteHandler);
    pasteTextArea.addEventListener("focusout", destroyTextArea);

    // focus the new textarea so we can receive pasting. Note that this will interfere with inputs inside the grid
    // they will lose focus as soon as they get focus because we need to use that focus to get the pasted content
    // otherwise we can't get pasting - the only other option is a contenteditable element which is not viable
    setTimeout(function () {
        pasteTextArea.focus();
    });
}

function destroyTextArea() {
    if (pasteTextArea) {
        pasteTextArea.removeEventListener("paste", pasteHandler);
        containerElem.removeChild(pasteTextArea);
        pasteTextArea = null;
    }
}