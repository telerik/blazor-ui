using System.ComponentModel;

namespace export_to_xlsx_hierarchy.Models
{
    public static class FileFormats
    {
        public enum Formats
        {
            [Description("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
            XLSX,
            [Description("text/csv")]
            CSV
        };
    }
}