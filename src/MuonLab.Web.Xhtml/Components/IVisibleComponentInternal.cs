namespace MuonLab.Web.Xhtml.Components
{
	internal interface IVisibleComponentInternal
	{
		void WithRenderingOrder(params ComponentPart[] renderingOrder);
	}
}