using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gRPCsample.Server.Data
{
    public class DataModel
    {
        public long Id { get; set; }
        public int ColumnInt32 { get; set; }
        public double ColumnDouble { get; set; }
        public float ColumnFloat { get; set; }
        public bool ColumnBool { get; set; }
        public string ColumnString { get; set; }
        public byte[] ColumnBytes { get; set; }
        public long ObjectId { get; set; }
        public string ObjectDescription { get; set; }
        public DateTime Modified { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
