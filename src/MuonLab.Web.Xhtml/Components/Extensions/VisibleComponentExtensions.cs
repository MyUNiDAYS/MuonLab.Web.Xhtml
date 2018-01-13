using MuonLab.Web.Xhtml.Components;

// ReSharper disable once CheckNamespace
namespace MuonLab.Web.Xhtml
{
	public static class VisibleComponentExtensions
	{
		/// <summary>
		/// Sets the rendering order for the parts of the component
		/// </summary>
		/// <param name="component"></param>
		/// <param name="renderingOrder"></param>
		/// <returns></returns>
		public static TComponent WithRenderingOrder<TComponent>(this TComponent component, params ComponentPart[] renderingOrder) where TComponent : IVisibleComponent
		{
			(component as IVisibleComponentInternal).WithRenderingOrder(renderingOrder);
			return component;
		}
	}
}