# Sync Selected Drawer Item on Load and Navigation

If you use the built-in drawer items for navigation, the selected (highlighted) one will update automatically.

If you navigate through other means such as directly land on a page from and external link, or use internal Blazor navigation (such as `<NavLink>` or `<a>` elements), the selected (highlighted) item in the drawer will become out of sync with the currently active page.

This happens because the drawer cannot know that the navigation happened in order to update itself. Moreover, even if it were to handle such events from the `NavigationManager`, updating the selected item means raising the `SelectedItemChanged` event, which can cause non-deterministic behavior. Generally, the event is a result of a user action (like clicking on a drawer item) and lets the app react to that. If it starts firing without a user action, it can cause infinite loops and the execution of business logic when it is not intended.

Thus, the solution to ensure external navigation keeps the correct item selected is to select it with application code when the desired events occur.

This sample project shows the two most common scenarios:

* Internal navigation from elements outside the drawer. This is handled through the `LocationChanged` event of the `NavigationManager`.

* Selecting an item on load, regardless of which page the user lands on. This is done through the `OnInitialized` lifecycle method.

Both examples are in the `~/Shared/MainLayout.razor` file, and code commends provide more information. They both rely on a couple of helper methods that are also in the same file.
