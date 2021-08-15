# Load Scheduler Appointments on Demand

In some scenarios, fetching all appointments for the scheduler at once can be a slow operation (for example, because there is a huge amount of entries overall, or the database is slow). You may want to optimize the queries for appointments so that you do not fetch all possible appointments at once, but only when the user should see them (for example, when the current view they are on includes these appointments).

You can load data on demand for next views or dates as the user navigates the scheduler with the help of the events it exposes - <a href="https://docs.telerik.com/blazor-ui/components/scheduler/events#datechanged" target="_blank">DateChanged</a> and <a href="https://docs.telerik.com/blazor-ui/components/scheduler/events#viewchanged" target="_blank">ViewChanged</a>.

This example demonstrates one basic way to do that. The key points in this implementation:

* The service "translates" the UI information (current date, which might not be the exact start of the period; and current view) into a range of dates to filter by.
    * You may want to pass additional data such as current user, their rights/roles, specific calendars and so on that will help you optimize the request.
* The scheduler events are used to fetch that data on demand and populate it to its `Data` parameter.
* In this example, a real database and real optimization is not implemented, the method just filters a hardcoded set of appointments in-memory. You need to implement the desired optimizations according to your particular situation, data, data source connection, business logic.
    * The Blazor app data service can send and receive the data in any way required by your app - direct database connection in a server-side app, serialize to an API endpoint, serialize for an OData endpoint, use local cache (e.g., browser local storage or in-memory on server), and so on.
