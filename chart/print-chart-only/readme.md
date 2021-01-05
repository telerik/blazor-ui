# Printing Charts

This example shows how to print separate Chart components.

By using the browser printing engine and some custom CSS you can hide everything else on the page so only the chart will show up.

Key points of interest:
* Add the custom CSS for the print mode in a separate file and include `media` parameter in the stylesheet link.
* Wrap the Chart component in a container to which you can define a class and style it where needed (for example, if you have multiple charts on the page you can hide some of them and print only a specific one)
* We use JS Interop to call the browser `print` method that does the actual printing. What we do is to add the desired CSS to the project so it prints what we want.
    * Make sure that the browser will print background graphics (this is a checkbox on the browser Print dialog) so that you can get the proper colors on the chart.
	
<strong>Note:</strong> A `Class` parameter for the Chart will be available in 2.21.0. 
