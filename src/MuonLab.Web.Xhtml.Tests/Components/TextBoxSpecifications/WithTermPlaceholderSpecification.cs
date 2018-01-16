using System;
using MuonLab.Web.Xhtml.Components;
using MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications;
using NSubstitute;

namespace MuonLab.Web.Xhtml.Tests.Components.TextBoxSpecifications
{
	public class WithTermPlaceholderSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime>>
    {
        protected override void Given()
        {
            base.Given();

            this.termResolver
                .ResolveTerm("holder of places", this.culture)
                .Returns("held place");
        }

        protected override void When()
        {
            component.ShowDefaultAsEmpty().WithPlaceholder("holder of places");
        }

        protected override string expectedRendering => "<input type=\"text\" placeholder=\"held place\" />";
    }
}