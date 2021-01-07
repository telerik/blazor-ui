using System;
using System.Collections.Generic;
using System.Text;

namespace gRPCsample.Shared.Helpers
{
    /// <summary>
    ///  A helper to get the message out of the Exception
    /// </summary>
    public class ExHelper
    {
        public static string GetExceptionText(Exception ex)
        {
            return GetExceptionText(string.Empty, ex);
        }

        public static string GetExceptionText(string prefix, Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            if (ex != null)
            {
                if (!string.IsNullOrEmpty(prefix))
                    sb.Append($"{prefix} ");

                sb.Append($"{ex.Message} ");
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    sb.Append($"{innerException.Message} ");
                    innerException = innerException.InnerException;
                }
            }

            return sb.ToString();
        }
    }
}
