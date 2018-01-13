using System;

namespace MuonLab.Web.Xhtml
{
	public static class HtmlEncoder
	{
		public static Func<object, string> HtmlEncodeFunc = s => System.Net.WebUtility.HtmlEncode(s.ToString());
		public static Func<object, string> HtmlAttributeEncodeFunc = s => System.Net.WebUtility.HtmlEncode(s.ToString());
		public static string HtmlEncode(object input) => HtmlEncodeFunc(input);
		public static string HtmlAttributeEncode(object input) => HtmlAttributeEncodeFunc(input);
	}
}