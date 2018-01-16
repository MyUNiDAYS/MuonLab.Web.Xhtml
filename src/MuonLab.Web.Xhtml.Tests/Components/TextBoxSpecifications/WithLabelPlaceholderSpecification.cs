using System;
using MuonLab.Web.Xhtml.Components;
using MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications;
using NSubstitute;

namespace MuonLab.Web.Xhtml.Tests.Components.TextBoxSpecifications
{
	public class WithLabelPlaceholderSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime>>
    {
        protected override void Given()
        {
            base.Given();

            this.termResolver
                .ResolveTerm("a label", this.culture)
                .Returns("labellous");
        }

        protected override void When()
        {
            component
                .ShowDefaultAsEmpty()
                .WithPlaceholder()
                .WithLabel("a label", aria: false);
        }

        protected override string expectedRendering => "<input type=\"text\" placeholder=\"labellous\" />";
    }
}