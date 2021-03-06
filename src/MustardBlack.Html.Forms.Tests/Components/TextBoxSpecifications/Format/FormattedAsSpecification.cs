using System;
using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.FormattableComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.TextBoxSpecifications.Format
{
    public class FormattedAsSpecification : FormattedAsStringSpecification<TextBoxComponent<TestEntity, DateTime>, DateTime>
    {
        protected override DateTime value => new DateTime(2009, 12, 12);

	    protected override string formatString => "dd/MM/yyyy";

	    protected override string expectedRendering => "<input type=\"text\" value=\"12/12/2009\" />";
    }
}