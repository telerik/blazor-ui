# Breadcrumb - Automatically Generate Items Based on URL

This sample project shows one way to use the [Telerik Breadcrumb](https://demos.telerik.com/blazor-ui/breadcrumb/overview) to subscribe to the [NavigationManager](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.navigationmanager?view=aspnetcore-5.0)'s [LocationChanged](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.navigationmanager.locationchanged?view=aspnetcore-5.0) so individual items are automatically populated instead of defining them on every page.

## Getting Started
* All the code related to the breadcrumb is in the `~Shared/BreadcrumbWrapper.razor` file, which is used inside the `~Shared/Mainlayout.razor` file.
* Code comments in the file provide details.

## Building The Project
Open the .sln file, build the project and run it. You can navigate between the various pages using the NavMenu. The breadcrumb items will appear on the top left of the page and change, addressing the current route.

## Steps
- introduce a `NavigationManager` property by injecting it in the file you would like to build the breadcrumbs:
```cs
    [Inject] private NavigationManager NavigationManager { get; set; }
```
- create an event handler with the following signature:
```cs
    private void OnLocationChanged(object sender, LocationChangedEventArgs e) {}
```
- override the `OnInitialized{Async}` lifecycle method and subscribe the event handler you just introduced to the `LocationChanged` event. This way your event handler will be called every time the `LocationChanged` event is triggered, which is anytime the navigation location has changed:
```cs
    protected override void OnInitialized()
    {
        NavigationManager.LocationChanged += OnLocationChanged;
    }
```
- The `NavigationManager` also provides several properties which could help you exctract the needed data. For example, if you would like to get the current relative path, you can use the following:
```cs
    var relativePath = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);
```
- For example, if you navigate to `https://localhost:44369/products/computer-peripherals`, the above line will yield the `products/computer-peripherals` string. We can now easily `Split('/')` the result, and create an item for each subpath from this result.

## Notes 
You do not have to follow the structure within this project. You can simply take this as a base and build upon. For example, you can enchance the data before setting the new items, like capitalizing the first letter of each item, mapping a subpath to a completely different string to display, adding icons for specific items or other styling based on specific subpaths. For example, introduce such a method which returns an item based on given criteria:
```cs
    public BreadcrumbItem GetItem(string path) =>
    path switch
    {
        "products" => new BreadcrumbItem { Text = "Products", Icon = "barcode", Title = "Products", Url = "/products" },
        "computer-peripherals" => new BreadcrumbItem { Text = "Computer Peripherals", Icon = "camera", Title = "Products", Url = "/products/computer-peripherals" },
        "keyboards" => new BreadcrumbItem { Text = "Keyboards", Title = "Keyboards", ImageUrl = "images/keyboard.png", Url = "/products/computer-peripherals/keyboards" },
        _ => null,
    };
```