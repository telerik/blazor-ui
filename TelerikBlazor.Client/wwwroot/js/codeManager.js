window.codeManager = {
    renderCode: function (url) {

        var xhr = new XMLHttpRequest();
        xhr.open('GET', '/source/index?path=/Pages/' + url.replace(/-/g, '_') + '.cshtml');
        xhr.onload = function () {
            if (xhr.status === 200) {
                var snippetContainer = document.getElementById("codecontainer");
                snippetContainer.innerHTML = xhr.responseText;
                prettyPrint();
            }
            else {
                alert('Request failed.  Returned status of ' + xhr.status);
            }
        };
        xhr.send();
    }
}