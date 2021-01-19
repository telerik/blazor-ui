namespace BlazingCoffee.Server.IO
{
    public static class MimeTypes
    {
		public static string Doc
		{
			get { return "application/msword"; }
		}

		public static string Docx
		{
			get { return "application/vnd.openxmlformats-officedocument.wordprocessingml.document"; }
		}

		public static string Pdf
		{
			get { return System.Net.Mime.MediaTypeNames.Application.Pdf; }
		}
	}
}
