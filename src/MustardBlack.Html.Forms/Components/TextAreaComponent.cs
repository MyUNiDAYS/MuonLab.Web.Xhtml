using System.Globalization;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms.Components
{
    public class TextAreaComponent<TViewModel, TProperty> : 
		FormattableComponent<TViewModel, TProperty>, 
		ITextAreaComponent<TProperty>
    {
		protected bool useLabelForPlaceholder;
	    protected string placeholder;

	    public TextAreaComponent(ITermResolver termResolver, IValidationMessageRenderer validationMessageRenderer, CultureInfo culture) : base(termResolver, validationMessageRenderer, culture)
	    {
	    }

	    public override string ControlPrefix => "txt";

	    public ITextAreaComponent WithRows(int rows)
        {
            WithAttr("rows", rows);
            return this;
        }

        public ITextAreaComponent WithCols(int cols)
        {
            WithAttr("cols", cols);
            return this;
        }


		public ITextAreaComponent WithPlaceholder()
		{
			this.useLabelForPlaceholder = true;
			return this;
		}

		public ITextAreaComponent WithPlaceholder(string text)
		{
			this.useLabelForPlaceholder = false;
			this.placeholder = text;
			return this;
		}

		protected override string RenderComponent()
        {
			if (this.useLabelForPlaceholder)
				this.htmlAttributes.Add("placeholder", this.termResolver.ResolveTerm(this.Label, this.culture));
			else if (!string.IsNullOrEmpty(this.placeholder))
				this.htmlAttributes.Add("placeholder", this.termResolver.ResolveTerm(this.placeholder, this.culture));

	        if (this.ariaLabel)
				this.htmlAttributes.Add("aria-label", this.termResolver.ResolveTerm(string.IsNullOrEmpty(this.Label) ? this.placeholder : this.Label, this.culture));

			this.AddAriaDescribedBy();

            var builder = new TagBuilder("textarea", this.htmlAttributes);
            builder.SetInnerText(this.FormatValue(this.value));
            return builder.ToString();
        }
    }
}