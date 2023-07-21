// this function takes a selector that describes the desired grid
// and then finds the first selected row, then scrolls to it
// via standard browser methods - effectively, the grid does not
// interact or implement this. Suitable for regular paging mode only, not for virtual scrolling
function scrollToSelectedRow(gridSelector) {
    var gridWrapper = document.querySelector(gridSelector);
    if (gridWrapper) {
        var selectedRow = gridWrapper.querySelector("tr.k-state-selected");
        if (selectedRow) {
            // scrollIntoView can behave in a few different ways. See
            // https://developer.mozilla.org/en-US/docs/Web/API/Element/scrollIntoView
            selectedRow.scrollIntoView({
                behavior: "smooth",
                block: "nearest",
                inline: "nearest"
            });
        }
    }
}
