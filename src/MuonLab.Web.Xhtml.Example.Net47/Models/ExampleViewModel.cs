namespace MuonLab.Web.Xhtml.Example.Net47.Models
{
	public class ExampleViewModel
	{
		public string Name { get; set; }
		public string Password { get; set; }

		public Gender? Sex { get; set; }

		public int Age { get; set; }

		public enum Gender
		{
			Male = 0,
			Female = 1
		}
	}
}