using System;
using MuonLab.Web.Xhtml.Components;
using MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications;
using NSubstitute;

namespace MuonLab.Web.Xhtml.Tests.Components.TextBoxSpecifications
{
	public class WithExplicitPlaceholderSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime>>
    {
        protected override void Given()
        {
            base.Given();

            this.termResolver
                .ResolveTerm("place holder", this.culture)
                .Returns("holder of places");
        }

        protected override void When()
        {
            component
                .ShowDefaultAsEmpty()
                .WithPlaceholder()
                .WithExplicitPlaceholder("place holder");
        }

        protected override string expectedRendering => "<input type=\"text\" placeholder=\"place holder\" />";
    }
}