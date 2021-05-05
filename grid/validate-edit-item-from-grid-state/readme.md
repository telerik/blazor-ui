# Validate Edited Model in Grid State with Your Own Code

In this example, we show how the grid gets locked when a data annotation event is fired on a grid cell in in-cell edit mode (see more in the <a href="https://docs.telerik.com/blazor-ui/components/grid/editing/incell#notes" target="_blank">InCell editing notes section</a>).

The `WeatherForecast` Model has a `Required` and `StringLength` data annotation for the `Summary` property.

When you run the application

1. Click on one of the Summary column cells and delete the contents.
    * The cell border will turn red and a tooltip of the data annotation message ("Your forecast requires a summary") will appear. 
    
        At this point, the entire grid is locked and will not fire any events until you enter something into the summary cells that satisfies the data annotations. This can be a problem for your users when they try to do something with the grid at that point like discard the row or try to "Add Forecast" (external buttons to the grid). 
        
1. If you try to click on "Add Forecast", the `ValidateGridState` method is called and it runs the validation for the current row being editing. It then shows the data annotation message in the text box. 
    * This information then gives the user some guidance on what they need to do in order to proceed. You can show it with other approaches like an <a href="https://demos.telerik.com/blazor-ui/dialog/predefined-dialogs" target="_blank">alert dialog</a> or a <a href="https://demos.telerik.com/blazor-ui/notification/overview" target="_blank">notification</a>.

1. Also, try to click the "Discard..." button at the top of the screen when you have an annotation error. The currently edited row will be deleted.
    * The trick here is that we are calling `ValidateGridState` on this event before deleting. If we do not do that, the row will be deleted and the grid will remain in a locked state which is not good.

You can take a similar approach to validate the models before loading the grid state in the `OnStateInit` event to ensure a workable state of the grid for your users. For example, if there is an edited item that does not satisfy validation you can show a message, alter the model (e.g., based on the original edit item), or discard the item being edited altogether. You can choose what to do based on the UX you are looking for.

### Attribution

This sample project and code were contributed by Marc of XLerant.