function focusElement(selector, shouldSelect) {
    var elem = selector.querySelector("input");
    if (elem && elem.focus) {
        setTimeout(function () {
            elem.focus();
            if (shouldSelect) {
                elem.select();
            }
        }, 30);
    }
}