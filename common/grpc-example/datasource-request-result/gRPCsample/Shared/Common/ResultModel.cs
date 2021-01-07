using System;
using System.Collections.Generic;
using System.Text;

namespace gRPCsample.Shared
{
    /// <summary>
    /// Extension of the ResultModel to return the Valid status
    /// </summary>
    public partial class ResultModel
    {
        public bool IsValid
        {
            get
            {
                return string.IsNullOrEmpty(ErrorMessage);
            }
        }
    }
}
