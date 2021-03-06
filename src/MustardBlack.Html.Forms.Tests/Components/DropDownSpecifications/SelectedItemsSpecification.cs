using System;
using System.Collections.Generic;

namespace MustardBlack.Html.Forms.Tests.Components.DropDownSpecifications
{
	public class SelectedItemsSpecification : DropDownBoxComponentSpecification
	{
		Guid item1;

		protected override void Given()
		{
			this.item1 = Guid.Parse("2008BC01-C2AE-43CD-AA91-FDA8592E5B1A");

			base.Given();
		}
		protected override void When()
		{
			this.component.WithValue(this.item1);
		}

		protected override IEnumerable<TestClass> Items => new [] { new TestClass { Guid = this.item1 }, new TestClass {Guid = Guid.Parse("1A3521DF-8B2B-4AC5-A624-9D819A1F3CBD")}};
		protected override string ExpectedRendering => "<select>" +
		                                               "<option selected value=\"2008bc01-c2ae-43cd-aa91-fda8592e5b1a\">2008bc01-c2ae-43cd-aa91-fda8592e5b1a</option>" +
		                                               "<option value=\"1a3521df-8b2b-4ac5-a624-9d819a1f3cbd\">1a3521df-8b2b-4ac5-a624-9d819a1f3cbd</option>" +
		                                               "</select>";
	}
}