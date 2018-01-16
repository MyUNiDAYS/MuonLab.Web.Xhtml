using System;

namespace MuonLab.Web.Xhtml.Components.Implementations
{
    public class HiddenFieldComponent<TViewModel, TProperty> : 
		Component<TViewModel, TProperty>, 
		IHiddenFieldComponent<TProperty>
    {
        readonly Func<TProperty, string> toStringFunc;

        public override string ControlPrefix => "hid";

	    public HiddenFieldComponent() : this(x => x.ToString())
        {
        }

        public HiddenFieldComponent(Func<TProperty, string> toStringFunc)
        {
            this.toStringFunc = toStringFunc;
        }

        protected override string RenderComponent()
        {
            var builder = new TagBuilder("input", this.htmlAttributes);
            builder.HtmlAttributes.Add("type", "hidden");

            if(!ReferenceEquals(this.Value, null))
                builder.HtmlAttributes.Add("value", toStringFunc(this.Value));

            return builder.ToString();
        }
    }
}