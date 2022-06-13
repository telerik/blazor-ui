

# Telerik UI for Blazor Components and Sample Apps

Telerik UI for Blazor enables you to develop new Blazor applications and modernize legacy web projects in half the time with a high-performing Blazor Data Grid and 95+ truly native, easy-to-customize UI components to cover any requirement.

[![Try Telerik Blazor UI](images/830x230-Blazor-Banner.png)](https://www.telerik.com/blazor-ui/?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme)

This repository contains examples related to [Telerik UI for Blazor components](https://www.telerik.com/blazor-ui?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme) that can be used in addition to the existing documentation or demos. They provide scenarios and answers to common how-to questions related to:
* [Blazor Data Grid](https://www.telerik.com/blazor-ui/grid?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme)
* [Blazor Chart](https://www.telerik.com/blazor-ui/chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme)
* [Blazor Editor](https://www.telerik.com/blazor-ui/editor?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme)
* [Blazor Drawer](https://www.telerik.com/blazor-ui/drawer?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme)
* [Blazor Scheduler](https://www.telerik.com/blazor-ui/scheduler?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme) and more.

The included code examples are applicable for both Blazor WebAssembly and Blazor Server projects. For most of them, a component and some classes are provided to illustrate a specific use case can be achieved. 

> **NOTE**: This repository does not contain the actual source code of the components, or the demos application available at the official [UI for Blazor demos](https://demos.telerik.com/blazor-ui?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme). The demos application is available as an offline project from your Telerik UI for Blazor installation.
***
## Table of Contents

* [Common Support Questions](#common-support-questions)
  * [Where can I find help?](#where-can-i-find-help)
  * [When do you plan to release feature X?](#when-do-you-plan-to-release-feature-x)
  * [Where do I make suggestions?](#where-do-i-make-suggestions)
* [Blazor UI Components](#blazor-ui-components)
* [Design to development](#design-to-development-support)
* [Sample Applications](#sample-applications)
  * [Task Tracker Dashboard](#blazor-dashboard-application)
  * [Financial Portfolio](#blazor-stocks-application)
  * [Coffee Warehouse Dashboard](#blazor-coffee-warehouse-application)
* [Package References](#package-references)
* [Contribution](#contribution)
* [Licensing](#licensing)
* [Useful Links](#useful-links)
* 
***

## Common Support Questions

### Where can I find help?

1. For community support, we recommend asking questions on Stack Overflow using the [telerik-blazor tag](http://stackoverflow.com/questions/tagged/telerik-blazor).
2. If you have an active trial or license, you can use the official [support channel](https://www.telerik.com/account/support-tickets?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme) for questions, technical assistance, bug reports or problem resolutions. 

  
### When do you plan to release feature X
Check the [Telerik UI for Blazor Roadmap](https://www.telerik.com/support/whats-new/blazor-ui/roadmap) to see a list of components, features and tooling we have planned.

### Where do I make suggestions?

If your feature isn’t listed in the product roadmap, check our dedicated [feedback portal](https://feedback.telerik.com/blazor?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme). You can upvote existing requested items or If you don’t see your feature on our portal, you can request the feature there.

## Blazor UI Components

### Blazor Data Management
<table><tbody>
<tr>
  <td><b>Blazor DataGrid Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/grid?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Gird Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/grid/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Data Grid Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/grid/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Data Grid Demos</td>
</tr>
 <tr>
  <td><b>Blazor ListView Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/listview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">List View Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/listview/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ListView Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/listview/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ListView Demos</td>
</tr> 
 <tr>
  <td><b>Blazor TreeList Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/treelist">Tree List Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/treelist/overview">TreeList Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/treelist/overview">TreeList Demos</td>
</tr> 
 <tr>
  <td><b>Blazor Filter Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/filter?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Filter Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/filter/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Filter Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/filter/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Filter Demos</td>
</tr> 
<tr>
  <td><b>Blazor Pager Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/pager?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Pager Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/pager/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Pager Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/pager/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Pager Demos</td>
</tr> 
</tbody></table>

### Blazor File Management
<table><tbody>
<tr>
  <td><b>Blazor File Manager</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/file-manager?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">FileManager Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/filemanager/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">FileManager Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/filemanager/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">FileManager Demos</td>
</tr>
<tr>
  <td><b>Blazor FileUpload Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/upload?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">File Upload Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/upload/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">FileUpload Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/upload/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">FileUpload Demos</td>
</tr>
<tr>
  <td><b>Blazor FileSelect Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/fileselect?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">File Select Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/fileselect/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">FileSelect Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/fileselect/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">FileSelect Demos</td>
</tr>
</tbody></table>

### Blazor Geo Visualization
<table><tbody>
<tr>
  <td><b>Blazor Map Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/map?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Map Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/map/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Map Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/map/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Map Demos</td>
</tr>   
</tbody></table>

### Blazor Scheduling Components
<table><tbody>
<tr>
  <td><b>Blazor Calendar Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/calendar?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Calendar Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/calendar/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Calendar Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/calendar/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Calendar Demos</td>
</tr>
<tr>
  <td><b>Blazor Gantt Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/gantt?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Gantt Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/gantt/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Gantt Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/gantt/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Gantt Demos</td>
</tr> 
<tr>
  <td><b>Blazor Scheduler Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/scheduler?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Scheduler Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/scheduler/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Scheduler Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/scheduler/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Scheduler Demos</td>
</tr> 
</tbody></table>

### Blazor Editor Components
<table><tbody>
<tr>
  <td><b>Blazor AutoComplete Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/autocomplete?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">AutoComplete Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/autocomplete/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">AutoComplete Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/autocomplete/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">AutoComplete Demos</td>
</tr>
<tr>
  <td><b>Blazor Checkbox Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/checkbox?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Checkbox Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/checkbox/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Checkbox Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/checkbox/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Checkbox Demos</td>
</tr>
<tr>
  <td><b>Blazor ColorGradient Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/colorgradient?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Color Gradient Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/colorgradient/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Color Gradient Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/colorgradient/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Color Gradient Demos</td>
</tr>
<tr>
  <td><b>Blazor ColorPalette Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/colorpalette?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Color Palette Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/colorpalette/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ColorPalette Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/colorpalette/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ColorPalette Demos</td>
</tr>
<tr>
  <td><b>Blazor ColorPicker Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/colorpicker?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Color Picker Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/colorpicker/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ColorPicker Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/colorpicker/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ColorPicker Demos</td>
</tr>
<tr>
  <td><b>Blazor FlatColorPicker Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/flatcolorpicker?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Flat Color Picker Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/flatcolorpicker/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">FlatColorPicker Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/flatcolorpicker/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">FlatColorPicker Demos</td>
</tr>
<tr>
  <td><b>Blazor ComboBox Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/combobox?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ComboBox Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/combobox/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ComboBox Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/combobox/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ComboBox Demos</td>
</tr>
<tr>
  <td><b>Blazor DateInput Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/dateinput?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Date Input Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/dateinput/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">DateInput Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/dateinput/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">DateInput Demos</td>
</tr>
<tr>
  <td><b>Blazor DatePicker Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/datepicker?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Date Picker Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/datepicker/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">DatePicker Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/datepicker/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">DatePicker Demos</td>
</tr>
<tr>
  <td><b>Blazor DateRangePicker Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/daterangepicker?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">DateRangePicker Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/daterangepicker/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">DateRangePicker Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/daterangepicker/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">DateRangePicker Demos</td>
</tr>
 <tr>
  <td><b>Blazor DateTimePicker Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/datetimepicker?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">DateTimePicker Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/datetimepicker/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">DateTimePicker Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/datetimepicker/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">DateTimePicker Demos</td>
</tr>
 <tr>
  <td><b>Blazor TimePicker Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/timepicker?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Time Picker Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/timepicker/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">TimePicker Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/timepicker/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">TimePicker Demos</td>
</tr>
 <tr>
  <td><b>Blazor DropDownList Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/dropdownlist?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">DropDownList Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/dropdownlist/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">DropDownList Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/dropdownlist/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">DropDownList Demos</td>
</tr>
<tr>
  <td><b>Blazor MaskedTextBox Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/maskedtextbox?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">MaskedTextBox Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/maskedtextbox/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">MaskedTextBox Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/maskedtextbox/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">MaskedTextBox Demos</td>
</tr>
<tr>
  <td><b>Blazor MultiSelect Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/multiselect?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Multi Select Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/multiselect/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">MultiSelect Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/fileselect/multiselect?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">MultiSelect Demos</td>
</tr>
<tr>
  <td><b>Blazor NumericTextBox Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/numeric-textbox?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Numeric TextBox Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/numerictextbox/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">NumericTextBox Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/numerictextbox/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">NumericTextBox Demos</td>
</tr>
<tr>
  <td><b>Blazor RadioGroup Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/radiogroup?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Radio Group Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/radiogroup/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">RadioGroup Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/radiogroup/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">RadioGroup Demos</td>
</tr>
<tr>
  <td><b>Blazor Editor Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/editor?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Editor Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/editor/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme"> Editor Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/editor/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Editor Demos</td>
</tr>
<tr>
  <td><b>Blazor TextArea Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/textarea?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Text Area Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/textarea/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">TextArea Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/textarea/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">TextArea Demos</td>
</tr>
<tr>
  <td><b>Blazor TextBox Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/textbox?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">TextBox Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/textbox/overview">TextBox Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/textbox/overview">TextBox Demos</td>
</tr>
<tr>
  <td><b>Blazor Slider Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/slider?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Slider Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/slider/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Slider Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/slider/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Slider Demos</td>
</tr>
<tr>
  <td><b>Blazor RangeSlider Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/rangeslider?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">RangeSlider Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/rangeslider/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">RangeSlider Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/rangeslider/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">RangeSlider Demos</td>
</tr>
<tr>
  <td><b>Blazor Switch Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/switch?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Switch Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/switch/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Switch Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/switch/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Switch Demos</td>
</tr>
<tr>
  <td><b>Blazor ValidationMessage Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/validation-message?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ValidationMessage Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/validation/message?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ValidationMessage Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/validation/validation-message/template?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ValidationMessage Demos</td>
</tr>
<tr>
  <td><b>Blazor ValidationSummary Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/validationsummary?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ValidationSummary Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/validation/summary?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ValidationSummary Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/validation/validation-summary/template?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ValidationSummary Demos</td>
</tr>
<tr>
  <td><b>Blazor ValidationTooltip Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/validationtooltip?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ValidationTooltip Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/validation/tooltip?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ValidationTooltip Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/validation/validation-tooltip/template?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ValidationTooltip Demos</td>
</tr>
</tbody></table>

### Blazor Data Visualization Components
<table><tbody>
<tr>
  <td><b>Blazor Chart Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Chart Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/chart/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Chart Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/chart/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Chart Demos</td>
</tr>
<tr>
  <td><b>Blazor Area Chart Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/area-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Area Chart Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/chart/types/area?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">AreaChart Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/chart/area-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">AreaChart Demos</td>
</tr>
<tr>
  <td><b>Blazor Bar Chart Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/bar-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Bar Chart Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/chart/types/bar?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">BarChart Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/chart/bar-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">BarChart Demos</td>
</tr>
<tr>
  <td><b>Blazor Bubble Chart Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/bubble-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Bubble Chart Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/chart/types/bubble?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">BubbleChart Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/chart/bubble-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">BubbleChart Demos</td>
</tr>
<tr>
  <td><b>Blazor Column Chart Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/column-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Column Chart Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/chart/types/column?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ColumnChart Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/chart/column-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ColumnChart Demos</td>
</tr>
<tr>
  <td><b>Blazor Line Chart Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/line-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Line Chart Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/chart/types/line?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">LineChart Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/chart/line-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">LineChart Demos</td>
</tr> 
<tr>
  <td><b>Blazor Donut Chart Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/donut-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Donut Chart Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/chart/types/donut?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">DonutChart Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/chart/donut-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">DonutChart Demos</td>
</tr>
<tr>
  <td><b>Blazor Pie Chart Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/pie-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Pie Chart Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/chart/types/pie?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">PieChart Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/chart/pie-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">PieChart Demos</td>
</tr> 
<tr>
  <td><b>Blazor Stock Chart Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/stock-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Stock Chart Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/stockchart/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Blazor StockChart Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/stockchart/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Blazor StockChart Demos</td>
</tr> 
  <tr>
  <td><b>Blazor Candlestick Chart Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/candlestick-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Candlestick Chart Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/chart/types/candlestick?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Candlestick Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/chart/candlestick-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Candlestick Demos</td>
</tr>
<tr>
  <td><b>Blazor OHLC Chart Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/ohlc-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">OHLC Chart Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/chart/types/ohlc?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">OHLC Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/chart/ohlc-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">OHLC Demos</td>
</tr>
<tr>
  <td><b>Blazor Heatmap Chart Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/heatmap?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Heatmap Chart Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/chart/types/heatmap?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Blazor HeatmapChart Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/chart/heatmap-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Blazor HeatmapChart Demos</td>
</tr>
<tr>
  <td><b>Blazor Radar Area Chart Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/radar-area-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">RadarArea Chart Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/chart/types/radar-area?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">RadarAreaChart Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/chart/radar-area-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">RadarAreaChart Demos</td>
</tr>
<tr>
  <td><b>Blazor Radar Column Chart Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/radar-column-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">RadarColumn Chart Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/chart/types/radar-column?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Blazor RadarColumn Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/chart/radar-column-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Blazor RadarColumn Demos</td>
</tr>
<tr>
  <td><b>Blazor Radar Line Chart Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/radar-line-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">RadarLine Chart Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/chart/types/radar-line?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">RadarLine Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/chart/radar-line-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">RadarLine Demos</td>
</tr>
<tr>
  <td><b>Blazor Scatter Chart Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/scatter-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Scatter Chart Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/chart/types/scatter?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ScatterChart Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/chart/scatter-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ScatterChart Demos</td>
</tr>
<tr>
   <td><b>Blazor Scatter Line Chart Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/scatter-line-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ScatterLine Chart Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/chart/types/scatter-line?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ScatterLineChart Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/chart/scatter-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ScatterLineChart Demos</td>
</tr>
</tbody></table>

### Blazor Barcode Components
<table><tbody>
<tr>
   <td><b>Blazor Barcode Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/barcode?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Barcode Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/barcodes/barcode/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Barcode Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/barcode/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Barcode Demos</td>
</tr>
<tr>
   <td><b>Blazor QR Code Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/qr-code?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">QR Code Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/barcodes/qrcode/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">QRCode Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/qrcode/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">QRCode Demos</td>
</tr>  
</tbody></table>

### Blazor Gauges Components
<table><tbody>
<tr>
   <td><b>Blazor ArcGauge Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/arc-gauge?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ArcGauge Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/arcgaugee/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ArcGauge Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/arcgauge/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ArcGauge Demos</td>
</tr>
<tr>
  <td><b>Blazor CircularGauge Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/circular-gauge?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">CircularGauge Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/circulargauge/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">CircularGauge Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/circulargauge/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">CircularGauge Demos</td>
</tr>
<tr>
  <td><b>Blazor LinearGauge Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/linear-gauge?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">LinearGauge Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/lineargauge/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">LinearGauge Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/lineargauge/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">LinearGauge Demos</td>
</tr>
<tr>
  <td><b>Blazor RadialGauge Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/radial-gauge?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">RadialGauge Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/radialgauge/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">RadialGauge Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/radialgauge/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">RadialGauge Demos</td>
</tr>
</tbody></table>

### Interactivity & UX 
<table><tbody>
<tr>
   <td><b>Blazor ProgressBar Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/progressbar?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ProgressBar Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/progressbar/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ProgressBar Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/progressbar/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ProgressBar Demos</td>
</tr>
<tr>
   <td><b>Blazor ChunkProgressBar Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/chunkprogressbar?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ChunkProgressBar Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/chunkprogressbar/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ChunkProgressBar Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/chunkprogressbar/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ChunkProgressBar Demos</td>
</tr>
<tr>
  <td><b>Blazor Loader Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/loader?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Loader Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/loader/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Loader Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/loader/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Loader Demos</td>
</tr>
<tr>
  <td><b>Blazor LoaderContainer Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/loader-container?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">LoaderContainer Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/loadercontainer/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">LoaderContainer Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/loadercontainer/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">LoaderContainer Demos</td>
</tr>
<tr>
  <td><b>Blazor Notification Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/notification?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Notification Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/notification/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Notification Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/notification/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Notification Demos</td>
</tr>
<tr>
  <td><b>Blazor Tooltip Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/tooltip?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Tooltip Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/tooltip/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Tooltip Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/tooltip/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Tooltip Demos</td>
</tr>
</tbody></table>

### Blazor Layout Components
<table><tbody>
<tr>
  <td><b>Blazor Carousel Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/carousel?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Carousel Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/carousel/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Carousel Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/carousel/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Carousel Demos</td>
</tr>
  <tr>
  <td><b>Blazor Card Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/card?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Card Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/card/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Card Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/card/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Card Demos</td>
</tr>
<tr>
  <td><b>Blazor Animation Container</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/animation-container?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Animation Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/animationcontainer/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Animation Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/animationcontainer/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Animation Demos</td>
</tr>
  <tr>
  <td><b>Blazor Dialog Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/dialog?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Dialog Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/dialog/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Dialog Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/dialog/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Dialog Demos</td>
</tr>
<tr>
  <td><b>Blazor Form Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/form?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Form Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/form/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Form Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/form/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Form Demos</td>
</tr>
<tr>
  <td><b>Blazor GridLayout Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/gridlayout?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">GridLayout Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/gridlayout/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">GridLayout Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/gridlayout/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">GridLayout Demos</td>
</tr>
<tr>
  <td><b>Blazor StackLayout Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/stacklayout">StackLayout Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/stacklayout/overview">StackLayout Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/stacklayout/overview">StackLayout Demos</td>
</tr>
<tr>
  <td><b>Blazor MediaQuery Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/mediaquery?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">MediaQuery Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/mediaquery/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">MediaQuery Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/mediaquery/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">MediaQuery Demos</td>
</tr>
<tr>
  <td><b>Blazor Splitter Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/splitter?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Splitter Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/splitter/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Splitter Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/splitter/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Splitter Demos</td>
</tr>
<tr>
  <td><b>Blazor TileLayout Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/tilelayout?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">TileLayout Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/tilelayout/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">TileLayout Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/tilelayout/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">TileLayout Demos</td>
</tr>
<tr>
  <td><b>Blazor Window Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/window?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Window Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/window/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Window Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/window/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Window Demos</td>
</tr>
</tbody></table>

### Blazor Label Components
<table><tbody>
<tr>
  <td><b>Blazor FloatingLabel Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/floatinglabel?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">FloatingLabel Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/floatinglabel/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">FloatingLabel Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/panelbar/floatinglabel?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">FloatingLabel Demos</td>
</tr>
</tbody></table>  

### Blazor Navigation Components
<table><tbody>
<tr>
  <td><b>Blazor Breadcrumb Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/breadcrumb?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Breadcrumb Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/breadcrumb/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Breadcrumb Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/breadcrumb/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Breadcrumb Demos</td>
</tr>
<tr>
  <td><b>Blazor Button Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/button?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Button Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/button/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Button Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/button/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Button Demos</td>
</tr>
<tr>
  <td><b>Blazor ButtonGroup Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/buttongroup?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ButtonGroup Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/buttongroup/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ButtonGroup Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/buttongroup/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ButtonGroup Demos</td>
</tr>
<tr>
  <td><b>Blazor SplitButton Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/split-button?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">SplitButton Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/splitbutton/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">SplitButton Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/splitbutton/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">SplitButton Demos</td>
</tr>
<tr>
  <td><b>Blazor ToggleButton Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/togglebutton?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ToggleButton Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/togglebutton/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ToggleButton Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/togglebutton/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ToggleButton Demos</td>
</tr>
<tr>
  <td><b>Blazor ContextMenu Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/context-menu?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ContextMenu Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/contextmenu/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ContextMenu Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/contextmenu/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">ContextMenu Demos</td>
</tr>
<tr>
  <td><b>Blazor Menu Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/menu?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Menu Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/menu/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Menu Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/menu/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Menu Demos</td>
</tr>
<tr>
  <td><b>Blazor Drawer Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/drawer?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Drawer Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/drawer/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Drawer Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/drawer/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Drawer Demos</td>
</tr>
<tr>
  <td><b>Blazor PanelBar Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/panelbar?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">PanelBar Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/panelbar/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">PanelBar Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/panelbar/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">PanelBar Demos</td>
</tr>
<tr>
  <td><b>Blazor TabStrip Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/tabstrip?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">TabStrip Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/tabstrip/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">TabStrip Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/tabstrip/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">TabStrip Demos</td>
</tr>
<tr>
  <td><b>Blazor Toolbar Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/toolbar?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Toolbar Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/toolbar/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Toolbar Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/toolbar/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Toolbar Demos</td>
</tr>
<tr>
  <td><b>Blazor TreeView Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/treeview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">TreeView Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/treeview/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">TreeView Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/treeview/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">TreeView Demos</td>
</tr>
<tr>
  <td><b>Blazor Stepper Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/stepper?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Stepper Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/stepper/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Stepper Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/stepper/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Stepper Demos</td>
</tr>
<tr>
  <td><b>Blazor Wizard Component</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/wizard?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Wizard Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/wizard/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Wizard Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/wizard/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Wizard Demos</td>
</tr>
</tbody></table>  

### Document Processing Libraries
As part of your Telerik UI for Blazor trial or licensed copy you get access to several document processing libraries that allow you to convert, manage and export data to different file formats.

<table><tbody>
<tr>
  <td><b>Blazor PDF Processing Library</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/pdfprocessing?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">PDF Processing Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/document-processing/pdf?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">PDF Processing Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/pdfprocessing/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">PDF Processing Demos</td>
</tr>
<tr>
  <td><b>Blazor Spread Processing Library</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/spreadprocessing?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Spread Processing Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/document-processing/spreadsheet?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Spread Processing Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/spreadprocessing/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Spread Processing Demos</td>
</tr>
<tr>
  <td><b>Blazor SpreadStream Processing Library</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/spreadstreamprocessing?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">SpreadStream Processing Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/document-processing/spreadstream?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">SpreadStream Processing Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/spreadstreamprocessing/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">SpreadStream Processing Demos</td>
</tr>
<tr>
  <td><b>Blazor Words Processing Library</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/wordprocessing?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Words Processing Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/document-processing/words?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Words Processing Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/wordsprocessing/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Words Processing Demos</td>
</tr>
<tr>
  <td><b>Blazor Zip Library</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/ziplibrary?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Zip Library Features</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/components/document-processing/zip?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Zip Library Documentation</td>
  <td><a href="https://demos.telerik.com/blazor-ui/ziplibrary/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Zip Library Demos</td>
</tr>
</tbody></table>

## Design-to-Development Support

### 3 Design Themes

<table><tbody>
<tr>
  <td><b>Default Theme</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/components/styling/theme-default?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Blazor Default Theme</a></td>
</tr>
<tr>
  <td><b> Material Theme</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/components/styling/theme-material?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Blazor Material Theme</a></td>
</tr>
<tr>
  <td><b>Bootstrap Theme</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/components/styling/theme-bootstrap?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Blazor Bootstrap Theme</a></td>
</tr>
</tbody></table>

### Design Kits for Figma

<table><tbody>
<tr>
  <td><b>3 Telerik UI Design Kits for Figma</b></td>
   <td><a href="https://www.telerik.com/blazor-ui/3-telerik-ui-kits-for-figma?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Telerik UI Figma Design Kits</a></td>
  <td><a href="https://docs.telerik.com/blazor-ui/styling-and-themes/figma-ui-kits?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Documentation</td>
</tr>
</tbody></table>

### Customize the Telerik UI for Blazor Themes to Match Your Brand

<table><tbody>
<tr>
  <td><b>Blazor ThemeBuilder</b></td>
  <td><a href="https://www.telerik.com/blazor-ui/themebuilder-brand-colors/?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Apply Your Brand Colors</a></td>
  <td><a href="https://themebuilder.telerik.com/blazor-ui/?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme">Telerik UI for Blazor ThemeBuilder App</a></td>
</tr>
</tbody></table>

## Sample Applications

### Blazor Dashboard Application

We created the [Blazor Dashboard Application](https://demos.telerik.com/blazor-dashboard-app/?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme) following the best practices of building UI with Telerik UI for Blazor components, which makes it a fantastic learning resource. You can see a complete task tracking application and how easy it is to set up complex components such as the Data Grid (Table), Charts, or Forms.

* [Live demo](https://demos.telerik.com/blazor-dashboard-app/dashboard?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme)
* [Source code](https://github.com/telerik/blazor-ui/tree/master/sample-applications/blazor-dashboard?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme)

![Blazor Dashboard sample](sample-applications/blazor-dashboard-sample.png)

### Blazor Stocks Application

The [Blazor Financial Portfolio Application](https://demos.telerik.com/blazor-financial-portfolio/?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme) is a progressive web app (PWA) which shows how to create fast, beautiful and dynamic financial dashboards. It takes full advantage of Blazor's fast rendering and shows dynamic data updates in real time which allows monitoring data with no visible delay.

* [Live demo](https://demos.telerik.com/blazor-financial-portfolio/?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme)
* [Source code](https://github.com/telerik/blazor-ui/tree/master/sample-applications/blazor-stocks)

![Financial portfolio sample](sample-applications/blazor-stocks-sample.png)

### Blazor Coffee Warehouse Application

The [Blazor Coffee Warehouse Application](https://demos.telerik.com/blazor-coffee/?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme) is a coffee warehouse management application that shows CRUD operations over various data grids and other components, visualizations with Charts and everything else you would need for a warehouse.

* [Live demo](https://demos.telerik.com/blazor-coffee/?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme)
* [Source code](https://github.com/telerik/blazor-ui/tree/master/sample-applications/blazing-coffee)

![Blazor Coffee App](sample-applications/blazor-coffee-sample.png)


## Package References

The projects usually reference a commercial version of UI for Blazor components. If you only have a trial license, replace the reference to the NuGet package and to the JS Interop file and/or Theme [accordingly](https://docs.telerik.com/blazor-ui/getting-started/what-you-need?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme).

The references (both to Telerik UI for Blazor, and the .NET framework) are usually up-to-date for the time of creation. You may need to update to their latest versions and make any necessary changes. The Blazor framework is evolving rapidly and these examples may not get their references updated all the time. Nevertheless, the general approaches should remain valid, barring breaking changes in the framework.

## Contribution

**Issues and Pull Requests are welcome.** 

To submit a pull request, you should **first [fork](https://docs.github.com/en/free-pro-team@latest/github/getting-started-with-github/fork-a-repo) the repo**.

## Licensing
Telerik UI for Blazor is a commercial UI library. To use the components, you need to either register for a free trial or purchase a license.

The 30-day free trial can be obtained from [Telerik UI for Blazor product page](https://www.telerik.com/blazor-ui?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme) and gives you access to all Telerik UI for Blazor components and their full functionality. For more infromation regarding the available license and budnle options you can review the [product pricing page](https://www.telerik.com/purchase/blazor-ui?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme).

For both active trialist and license holders you get access to our legendary technical support provided directly by the UI for Blazor dev team!


## Useful Links

* Browse all [UI for Blazor component demos live](https://demos.telerik.com/blazor-ui?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme)
* Browse [the Telerik UI for Blazor documentation](https://docs.telerik.com/blazor-ui/introduction?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme)
* Follow this link to [report bugs and add feature requests](https://feedback.telerik.com/blazor?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme)
* Browse or contribute to [localization texts](https://github.com/telerik/blazor-ui-messages) used in the samples
* Create, runm, share and test Blazor code snippets directly in the browser in our [Blazor REPL code runner](https://blazorrepl.telerik.com/?utm_medium=referral&utm_source=github&utm_campaign=blazor-ui-trial-gh-public-readme)
