using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Configuration;
using NSubstitute;

namespace MustardBlack.Html.Forms.Tests.Configuration.FormConfigurationSpecifications.Initialize
{
    public class when_initializing_IVisibleComponent : Specification
    {
        TestFormConfiguration configuration;
        IVisibleComponent component;

        protected override void Given()
        {
            configuration = new TestFormConfiguration();
            component = Stub<IVisibleComponent>();
        }

        protected override void When()
        {
            configuration.Initialize(component);
        }

        [Then]
        public void the_component_should_have_the_ivisiblecomponent_config_ran_on_it()
        {
            component.Received().WithName("test");
        }

        [Then]
        public void the_component_should_have_the_icomponent_config_ran_on_it()
        {
            component.Received().WithId("test");
        }

        [Then]
        public void the_component_should_not_have_the_itextboxcomponent_config_ran_on_it()
        {
            component.DidNotReceive().WithName("fish");
        }

        private class TestFormConfiguration : FormConfiguration
        {
            public TestFormConfiguration()
            {
                Configure<IComponent>(c => c.WithId("test"));
                Configure<IVisibleComponent>(c => c.WithName("test"));
                Configure<ITextBoxComponent>(c => c.WithName("fish"));
            }
        }
    }
}