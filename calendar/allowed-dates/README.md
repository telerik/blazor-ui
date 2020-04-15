# Telerik Calendar - Allowed Dates

This project demonstrates how you can implement an allowed dates parameter to disable dates
that are not included in your `AllowedDates` list.

## Description

Assume you have a calendar in which you want to disable only a small list of dates, you can achieve that using the clendars `DisabledDates` parameter, you can read more about it [here][TelerikCalendarSelection].

However, what if what you are trying to achieve is the opposite, you have a small list of allowed dates and you wish to disable the dates that are not included in your list.

## Implementation

As shown in [Index.razor][SourceCode] you have to call `DisableDates(DateTime)` function and pass it a date that is currently visible in your calendar.
This will detect what month(s) are currently displayed by your calendar and add the  displayed days to the `DisabledDates` list iff they are not available in your `AllowedDates` list.

What happens if the user changes the current view?
- Using the `DateChangedHandler` we call the `DisableDates(DateTime)` function to clear the old `DisabledDates` list and create a new list that contains the disabled days to the navigated view.

The project contains the following methods: 
- `protected override void OnInitialized()`: Initializes the current view
- `void DateChangedHandler(DateTime)`: Is called when the user changes the current view
- `void DisableDates(DateTime)`: Is called to refresh `DisabledDates` list accordingly.
- `IEnumerable<DateTime> GetDisabledDates(DateTime)`: Gets the date range that are currently displayed by the view excep the dates already available in the `AllowedDates` list.

### Thanks
This contribution was made by [Hüssam Elvani][Contributor].

   [TelerikCalendarSelection]: <https://docs.telerik.com/blazor-ui/components/calendar/selection>
   [SourceCode]: <https://github.com/telerik/blazor-ui/blob/master/calendar/allowed-dates/Pages/Index.razor>
   [Contributor]: <http://github.com/hussamelvani>
