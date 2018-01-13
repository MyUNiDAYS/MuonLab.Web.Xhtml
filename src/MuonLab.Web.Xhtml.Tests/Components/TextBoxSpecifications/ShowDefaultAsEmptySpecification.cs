using System;
using MuonLab.Web.Xhtml.Components;
using MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications;

namespace MuonLab.Web.Xhtml.Tests.Components.TextBoxSpecifications
{
	public class ShowDefaultAsEmptySpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime>>
    {
        protected override void When()
        {
			component.ShowDefaultAsEmpty().WithValue(default(DateTime));
        }

        protected override string expectedRendering => "<input type=\"text\" />";
    }
}