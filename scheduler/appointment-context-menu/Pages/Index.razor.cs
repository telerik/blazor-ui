using appointment_context_menu.Models;
using appointment_context_menu.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Blazor;
using Telerik.Blazor.Components;

namespace appointment_context_menu.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        AppointmentService ApptService { get; set; }
        public DateTime StartDate { get; set; }
        public SchedulerView CurrView { get; set; } = SchedulerView.Week;
        public DateTime DayStart { get; set; }
        List<SchedulerAppointment> Appointments { get; set; }
        SchedulerAppointment LastClickedAppointment { get; set; }
        TelerikContextMenu<ContextMenuItem> TheContextMenu { get; set; }
        List<ContextMenuItem> MenuItems = new List<ContextMenuItem>()
        {
            new ContextMenuItem
            {
                Text = "Delete",
                CommandName = "delete",
                Icon = "delete"
            },
            new ContextMenuItem
            {
                Text = "Toggle Important",
                CommandName = "toggleimportant",
                Icon = "warning"
            }
        };

        async Task ShowContextMenu(MouseEventArgs e, SchedulerAppointment appt)
        {
            LastClickedAppointment = appt;
            PrepareMenuItems(LastClickedAppointment);
            await TheContextMenu.ShowAsync(e.ClientX, e.ClientY);
        }

        void PrepareMenuItems(SchedulerAppointment appt)
        {
            // disable one item, you can make bigger changes here too
            MenuItems[0].Disabled = appt.IsImportant;
        }

        async Task MenuClickHandler(ContextMenuItem clickedItem)
        {
            // handle the command from the context menu by using the stored metadata
            if (!string.IsNullOrEmpty(clickedItem.CommandName) && LastClickedAppointment != null)
            {
                switch (clickedItem.CommandName.ToLowerInvariant())
                {
                    case "delete":
                        await DeleteAppt(LastClickedAppointment);
                        break;
                    case "toggleimportant":
                        await ToggleAppointmentImportant(LastClickedAppointment);
                        break;
                    default:
                        break;
                }
            }
            LastClickedAppointment = null;
        }

        protected override async Task OnInitializedAsync()
        {
            DateTime start = ApptService.GetStartTime();
            StartDate = start;
            DayStart = start;
            await GetAppointments();
        }

        async Task DeleteAppt(SchedulerAppointment appt)
        {
            if (appt.IsImportant)
            {
                return;
            }
            await ApptService.DeleteAsync(appt);
            await GetAppointments();
        }

        async Task ToggleAppointmentImportant(SchedulerAppointment appt)
        {
            appt.IsImportant = !appt.IsImportant;
            await ApptService.UpdateAsync(appt);
            await GetAppointments();
        }

        async Task GetAppointments()
        {
            Appointments = new List<SchedulerAppointment>(await ApptService.GetAppointmentsAsync());
        }
    }
}
