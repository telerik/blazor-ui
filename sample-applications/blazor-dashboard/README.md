# Blazor Dashboard App

This sample application showcases how easy it is to plug the Telerik Blazor components in your layout, data and models. It is insipred by other similar dashboard apps for [Vue.js](https://github.com/telerik/vue-dashboard) and [Angular](https://github.com/telerik/ng2-dashboard).

## What's Inside

* `Bootstrap` for the layouts
* the [Telerik Blazor components](https://www.telerik.com/blazor-ui) for the UI elements
* customized SASS variables for Bootstrap
* the Telerik Bootstrap SASS theme to also utilize those variables
* `Gulp` to fetch the SASS dependencies, build them and minify the output
* dummy data, because, at the time of writing, the [Octokit.NET](https://github.com/octokit/octokit.net) package does not work under Blazor due to [issues with async requests](https://github.com/aspnet/AspNetCore/issues/9125)

## How to Run Locally

To run this app locally, you need:

* Node.js
* to be able to run the latest Telerik UI for Blazor version (more details [here](https://docs.telerik.com/blazor-ui/getting-started/what-you-need))

If you don't have a commercial license for UI for Blazor, [start a trial](https://www.telerik.com/download-trial-file/v2-b/ui-for-blazor) and replace the package reference with `Telerik.UI.for.Blazor.Trial`.

### One-time Installation

While the compiled CSS is committed in the repo and the app can run as-is, if you want to run the tasks yourself, you need to perform the procedure below. Alternatively, remove `gulpfile.js` and `package.json` from the project.

To build the dependencies, ensure you can build the SASS modules by:

1. open `PowerShell` as `Administrator`
1. execute `npm install --global --production windows-build-tools`
1. execute `npm install -g node-gyp`
1. from the command inside the project folder (where the `packages.json` file is), execute `npm install`

### Usual Run

1. open the `sln` file with VS 2019
1. press `F5`

### Update Telerik Theme

When you update the Telerik components, you may want to fetch the latest theme as well. To do that, execute the following in the shell:

1. `npm install` - fetches the latest Theme from the Telerik package
1. `npm run build:production` - runs the `gulp` task (see the `gulpfile.js`) that builds the Telerik Theme with the custom variables in the project, builds the rest of the styles of the app, and minifies them.


