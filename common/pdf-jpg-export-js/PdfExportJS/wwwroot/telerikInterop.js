window.telerikClientExporter = {
    // A simple adaptor pattern can surface Kendo APIs to Blazor
    saveAs: KendoFileSaver.saveAs,
    exportImage: function (elementRef, options) {
        return KendoDrawing.drawDOM(elementRef, options)
            .then((g) => KendoDrawing.exportImage(g));
    },
    exportPDF: function (elementRef, options) {
        return KendoDrawing.drawDOM(elementRef, options)
            .then((g) => KendoDrawing.exportPDF(g));
    }
}
