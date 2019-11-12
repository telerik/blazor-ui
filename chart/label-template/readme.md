# Chart Templates - Complex Logic

This project showcases a few examples in how you can create complex logic in your chart label templates. Make sure you are familiar with the [Chart Label Template and Format](https://docs.telerik.com/blazor-ui/components/chart/labels-template-and-format) article first.

This project is an extended example of what the [How to format the percent in a label for a pie or donut chart](https://docs.telerik.com/blazor-ui/knowledge-base/chart-format-percent) KB article.

Key concepts:

* The chart renders on the client to improve server performance. This means that the labels also render on the client and you would need to use JavaScript.
* If simple logic and rendering as described in the article above do not suffice, you need to create and call the required JS functions from the template string. In this example, they are in a file called `chart-template-functions.js` which is referenced in the index file (`~/Pages/_Host.cshml`)