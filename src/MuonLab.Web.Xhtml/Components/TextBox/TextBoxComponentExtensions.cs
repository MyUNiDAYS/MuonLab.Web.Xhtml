// ReSharper disable once CheckNamespace
namespace MuonLab.Web.Xhtml.Components
{
	public static class TextBoxComponentExtensions
	{
		/// <summary>
		/// Sets the rendering order for the parts of the component
		/// </summary>
		/// <param name="component"></param>
		/// <param name="maxLength"></param>
		/// <returns></returns>
		public static TComponent WithMaxLength<TComponent>(this TComponent component, int maxLength) where TComponent : ITextBoxComponent
		{
			component.WithAttr("maxlength", maxLength.ToString());
			return component;
		}


		public static TComponent PreventAutoComplete<TComponent>(this TComponent component) where TComponent : ITextBoxComponent
		{
			component.WithAttr("autocomplete", "off");
			return component;
		}

		public static TComponent AllowAutoComplete<TComponent>(this TComponent component) where TComponent : ITextBoxComponent
		{
			component.WithoutAttr("autocomplete");
			return component;
		}
	}
}