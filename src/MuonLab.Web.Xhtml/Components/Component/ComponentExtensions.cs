namespace MuonLab.Web.Xhtml.Components
{
	public static class ComponentExtensions
	{

		/// <summary>
		/// Sets an attribute-value on the component if a condition is met
		/// </summary>
		/// <param name="condition"></param>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static TComponent WithAttrIf<TComponent>(this TComponent component, bool condition, string name, object value)
			where TComponent : IComponent
		{
			if (condition)
				component.WithAttr(name, value);

			return component;
		}
	}
}