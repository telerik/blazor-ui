using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace gRPCsample.Shared
{
    /// <summary>
    /// The extension for the Grid data
    /// We can add Data Annotations for entry validation as per the example below
    /// It requires an additional Property
    /// Use the Property name (e.g. ColumnStringValidated) with the Data Annotaion in the grid
    /// Note: Couldn't get MetaData to work
    /// </summary>
    public partial class TestDataModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The ColumnString is required")]
        [MaxLength(25, ErrorMessage = "The ColumnString has to be between 1 and 25 characters")]
        public string ColumnStringValidated { get { return ColumnString; } set { ColumnString = value; } }

        /// <summary>
        /// Convert Date Time
        /// </summary>
        public DateTime Modified
        {
            get { return ModifiedTs.ToDateTime().ToLocalTime(); }

            set { ModifiedTs = value.ToUniversalTime().ToTimestamp(); }
        }

        /// <summary>
        /// Convert Date Time Offset
        /// May need more work to get the correct time on the client
        /// </summary>
        public DateTimeOffset Created
        {
            get { return CreatedTs.ToDateTimeOffset().ToLocalTime(); }

            set { CreatedTs = value.ToUniversalTime().ToTimestamp(); }
        }

        /// <summary>
        /// Convert byte array
        /// </summary>
        public string ColumnBytesString
        {
            get { return BitConverter.ToString(ColumnBytes.ToByteArray()); }
        }
    }
}
