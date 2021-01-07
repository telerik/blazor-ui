using System;
using System.Collections.Generic;
using System.Text;

namespace gRPCsample.Shared
{
    public class TestGridJSONModel
    {
        public long Id { get; set; }
        public int ColumInt32 { get; set; }
        public double ColumnDouble { get; set; }
        public float ColumnFloat { get; set; }
        public bool ColumnBool { get; set; }
        public string ColumnString { get; set; }
        public byte[] ColumnBytes { get; set; }
        public TestObjectJSONModel ColumnTestObject { get; set; }
        public DateTime Modified { get; set; }
        public DateTimeOffset Created { get; set; }

        public string ColumnBytesString { get { return BitConverter.ToString(ColumnBytes); } }
    }
}
