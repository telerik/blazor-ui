using ReadOnlySlots.Models;

namespace ReadOnlySlots.Data
{
    public class AppointmentService
    {
        private static List<SchedulerAppointment> _data { get; set; } = new List<SchedulerAppointment>()
        {
            new SchedulerAppointment
            {
                Title = "Board meeting",
                Description = "Q4 is coming to a close, review the details.",
                Start = new DateTime(2019, 12, 5, 10, 00, 0),
                End = new DateTime(2019, 12, 5, 11, 30, 0)
            },

            new SchedulerAppointment
            {
                Title = "Vet visit",
                Description = "The cat needs vaccinations and her teeth checked.",
                Start = new DateTime(2019, 12, 2, 11, 30, 0),
                End = new DateTime(2019, 12, 2, 12, 0, 0)
            },

            new SchedulerAppointment
            {
                Title = "Planning meeting",
                Description = "Kick off the new project.",
                Start = new DateTime(2019, 12, 6, 9, 30, 0),
                End = new DateTime(2019, 12, 6, 12, 0, 0)
            },

            new SchedulerAppointment
            {
                Title = "Trip to Hawaii",
                Description = "An unforgettable holiday!",
                IsAllDay = true,
                Start = new DateTime(2019, 11, 27),
                End = new DateTime(2019, 12, 05)
            },

            new SchedulerAppointment
            {
                Title = "Morning run",
                Description = "Some time to clear the head and exercise.",
                Start = new DateTime(2019, 11, 27, 9, 0, 0),
                End = new DateTime(2019, 11, 27, 9, 30, 0),
                RecurrenceRule = "FREQ=WEEKLY;BYDAY=MO,TU,WE,TH,FR"
            }
        };

        public static async Task Create(SchedulerAppointment itemToInsert)
        {
            itemToInsert.Id = Guid.NewGuid();
            _data.Insert(0, itemToInsert);
        }

        public static async Task<List<SchedulerAppointment>> Read()
        {
            return await Task.FromResult(_data);
        }

        public static async Task Update(SchedulerAppointment itemToUpdate)
        {
            var index = _data.FindIndex(i => i.Id == itemToUpdate.Id);
            if (index != -1)
            {
                _data[index] = itemToUpdate;
            }
        }

        public static async Task Delete(SchedulerAppointment itemToDelete)
        {
            if (itemToDelete.RecurrenceId != null)
            {
                // a recurrence exception was deleted, you may want to update
                // the rest of the data source - find an item where theItem.Id == itemToDelete.RecurrenceId
                // and remove the current exception date from the list of its RecurrenceExceptions
            }

            if (!string.IsNullOrEmpty(itemToDelete.RecurrenceRule) && itemToDelete.RecurrenceExceptions?.Count > 0)
            {
                // a recurring appointment was deleted that had exceptions, you may want to
                // delete or update any exceptions from the data source - look for
                // items where theItem.RecurrenceId == itemToDelete.Id
            }

            _data.Remove(itemToDelete);
        }
    }
}
