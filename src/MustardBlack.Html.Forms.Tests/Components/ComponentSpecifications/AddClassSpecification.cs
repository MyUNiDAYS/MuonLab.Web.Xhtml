using MustardBlack.Html.Forms.Components;

namespace MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications
{
	public class AddClassSpecification : Specification
	{
		private IComponent component;

		protected override void Given()
		{
			this.component = new TestComponent<TestEntity, string>();
		}

		protected override void When()
        {
            component = component.AddClass("myclass");
        }

        [Then]
        public void TheClassShouldBeSetCorrectly()
        {
			component.ToString().ShouldEqual("<test class=\"myclass\"></test>");
        }
	}
}