using MuonLab.Web.Xhtml.Components;

namespace MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications
{
	public class TestComponent<TEntity, TProperty> : Component<TEntity, TProperty> where TEntity : class
	{
		public override string ControlPrefix => "ctrl";

		protected override string RenderComponent()
		{
			this.htmlAttributes["name"] = this.Name;
			var builder = new TagBuilder("test", this.htmlAttributes);
			return builder.ToString();
		}
	}
}