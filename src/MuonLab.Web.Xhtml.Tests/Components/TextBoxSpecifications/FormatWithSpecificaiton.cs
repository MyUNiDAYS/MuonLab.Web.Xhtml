using System;
using MuonLab.Web.Xhtml.Components;
using MuonLab.Web.Xhtml.Tests.Components.FormattableComponentSpecifications;

namespace MuonLab.Web.Xhtml.Tests.Components.TextBoxSpecifications
{
    public class FormatWithSpecificaiton : FormatWithSpecification<TextBoxComponent<TestEntity, DateTime>, DateTime>
    {
        protected override DateTime value => new DateTime(2009, 12, 12);

	    protected override Func<DateTime, string> formatFunc => x => string.Format("{0:dd/MM/yyyy}", x);

	    protected override string expectedRendering => "<input type=\"text\" value=\"12/12/2009\" />";
    }
}