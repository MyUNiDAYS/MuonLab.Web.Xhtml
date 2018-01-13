using System;
using MuonLab.Web.Xhtml.Components;
using MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications;

namespace MuonLab.Web.Xhtml.Tests.Components.TextBoxSpecifications
{
	public class WithMaxLengthSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime>>
    {
        protected override void When()
        {
			component.WithMaxLength(10);
        }

        protected override string expectedRendering => "<input type=\"text\" maxlength=\"10\" />";
    }
}