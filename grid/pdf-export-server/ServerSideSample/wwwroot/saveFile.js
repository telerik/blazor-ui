(function () {

    window.saveFile = function (bytesBase64, mimeType, fileName) {
        var fileUrl = "data:" + mimeType + ";base64," + bytesBase64;
        fetch(fileUrl)
            .then(response => response.blob())
            .then(blob => {
                var link = window.document.createElement("a");
                link.href = window.URL.createObjectURL(blob, { type: mimeType });
                link.download = fileName;
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);
            });
    }

})();
