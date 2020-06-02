using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using ICS_Data_Convertion.Models;

namespace ICS_Data_Convertion.Services
{
    public class ConvertICSToModel
    {
        public string line;
        //Replace this path with your actual path
        public static string path = @"C:\work\ics-data-convertion\ICS_Data_Convertion\ICS_Data_Convertion\Calendar\myevents.ics";

        public StreamReader file = new StreamReader(path);
        
        public void GetAppointment()
        {
            while((line = file.ReadLine()) != null)
            {
                if (line.Contains("BEGIN:VEVENT"))
                {
                    CalendarAppointments appointment = new CalendarAppointments();
                    //appointment.DTStart
                }
            }
        }
    }
}
