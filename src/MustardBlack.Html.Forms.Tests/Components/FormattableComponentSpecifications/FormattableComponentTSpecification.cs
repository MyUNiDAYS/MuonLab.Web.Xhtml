using System;
using System.Globalization;
using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms.Tests.Components.FormattableComponentSpecifications
{
    public abstract class FormattableComponentTSpecification<TComponent, TProperty> : Specification where TComponent : IFormattableComponent<TProperty>
    {
        protected IFormattableComponent<TProperty> component;

        protected override void Given()
        {
			this.component = (TComponent)Activator.CreateInstance(typeof(TComponent), Dependency<ITermResolver>(), new ValidationMessageRenderer(), new CultureInfo("en-GB"));
			if(this.component is IVisibleComponent)
				((IVisibleComponent)component).WithRenderingOrder(ComponentPart.Component);
        }

        protected abstract string expectedRendering { get; }
    }
}