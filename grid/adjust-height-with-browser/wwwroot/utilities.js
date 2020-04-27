// Used to select Telerik Grid Row
function scrollToSelectedRow(gridSelector) {
    var gridWrapper = document.querySelector(gridSelector);
    if (gridWrapper) {
        var selectedRow = gridWrapper.querySelector("tr.k-state-selected");
        if (selectedRow) {
            selectedRow.scrollIntoView();
        }
    }
}