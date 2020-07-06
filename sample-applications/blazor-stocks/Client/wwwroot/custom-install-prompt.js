function showAddToHomeScreen() {
    // These assembly and method names must match the app name and the method in the MainLayout.razor
    const blazorAssembly = 'BlazorFinancePortfolio.Client';
    const blazorInstallMethod = 'InstallPwaPrompt';
    DotNet.invokeMethodAsync(blazorAssembly, blazorInstallMethod)
        .then(function () { }, function (er) { setTimeout(showAddToHomeScreen, 1000); });
}
function OnPwaInstallClick() {
    if (window.PWADeferredPrompt) {
        // Fires the browser prompt. Invoked from the custom instalation UI through JS Interop
        window.PWADeferredPrompt.prompt();
        window.PWADeferredPrompt.userChoice
            .then(function (choiceResult) {
                window.PWADeferredPrompt = null;
            });
    }
}
window.addEventListener('beforeinstallprompt', function (e) {
    // Prevent Chrome 67 and earlier from automatically showing the prompt
    e.preventDefault();
    // Stash the event so it can be triggered later.
    window.PWADeferredPrompt = e;
    // Show custom installation prompt (which will trigger the built-in one, of course, when confirmed by the user)
    showAddToHomeScreen();
});

// Prompt when the PWA has been installed but a new version is available
// Code based on the Blazor.PWA.MSBuild package by SQL-MisterMagoo
// Read more at https://github.com/SQL-MisterMagoo/Blazor.PWA.MSBuild/blob/master/LICENSE.txt
window.updateAvailable = new Promise(function (resolve, reject) {
    if ('serviceWorker' in navigator) {
        navigator.serviceWorker.register('service-worker.js')
            .then(function (registration) {
                console.info('Registration successful, scope is:', registration.scope);
                registration.onupdatefound = () => {
                    const installingWorker = registration.installing;
                    installingWorker.onstatechange = () => {
                        switch (installingWorker.state) {
                            case 'installed':
                                if (navigator.serviceWorker.controller) {
                                    resolve(true);
                                } else {
                                    resolve(false);
                                }
                                break;
                            default:
                        }
                    };
                };
            })
            .catch(error =>
                console.info('Service worker registration failed, error:', error));
    }
});
window['updateAvailable']
    .then(isAvailable => {
        if (isAvailable) {
            // TODO: Consider adding your own app UI for this as well in a fashion similar to the showAddToHomeScreen() method
            alert('Update available. Reload the page when convenient.');
        }
    });