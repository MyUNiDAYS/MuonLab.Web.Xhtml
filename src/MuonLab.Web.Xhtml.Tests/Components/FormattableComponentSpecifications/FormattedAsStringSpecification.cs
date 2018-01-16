using System;
using MuonLab.Testing;
using MuonLab.Web.Xhtml.Components;

namespace MuonLab.Web.Xhtml.Tests.Components.FormattableComponentSpecifications
{
    public abstract class FormattedAsStringSpecification<TComponent, TProperty> : FormattableComponentSpecification<TComponent> where TComponent : IFormattableComponent
    {
        protected override void When()
        {
            var x = new TextBoxComponent<TestEntity, DateTime>(null, null);
            x.FormattedAs<TextBoxComponent<TestEntity, DateTime>, DateTime>("");//.WithValue(null);

            component = component.FormattedAs(formatString).WithValue(value) as IFormattableComponent;
        }

        protected abstract TProperty value { get; }
        protected abstract string formatString { get; }

        [Then]
        public void TheValueShouldBeFormattedCorrectly()
        {
            component.ToString().ShouldEqual(expectedRendering);
        }
    }
}