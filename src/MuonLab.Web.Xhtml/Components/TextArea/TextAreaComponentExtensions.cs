namespace MuonLab.Web.Xhtml.Components
{
	public static class TextAreaComponentExtensions
	{
		public static TComponent WithRows<TComponent>(this TComponent component, int rows)
			where TComponent : ITextAreaComponent
		{
			component.WithAttr("rows", rows);
			return component;
		}

		public static TComponent WithCols<TComponent>(this TComponent component, int cols)
			where TComponent : ITextAreaComponent
		{
			component.WithAttr("cols", cols);
			return component;
		}
	}
}