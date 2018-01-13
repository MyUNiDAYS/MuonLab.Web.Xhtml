using System.Globalization;
using MuonLab.Web.Xhtml.Configuration;

namespace MuonLab.Web.Xhtml.Components.Implementations
{
    public class TextBoxComponent<TViewModel, TProperty> : 
		FormattableComponent<TViewModel, TProperty>, 
		ITextBoxComponent<TProperty>,
		ITextBoxComponentInternal
    {
	    protected bool useLabelForPlaceholder;
	    protected string placeholder;
	    protected bool explicitPlaceholder;

	    public TextBoxComponent(ITermResolver termResolver, CultureInfo culture) : base(termResolver, culture)
	    {
	    }

	    public override string ControlPrefix => "txt";

	    protected bool asDefaultEmpty;

        public virtual ITextBoxComponent ShowDefaultAsEmpty()
        {
            this.asDefaultEmpty = true;
            return this;
        }

	    public ITextBoxComponent WithPlaceholder()
	    {
			this.useLabelForPlaceholder = true;
			this.explicitPlaceholder = false;
		    return this;
	    }

	    public ITextBoxComponent WithPlaceholder(string text)
	    {
			this.useLabelForPlaceholder = false;
			this.explicitPlaceholder = false;
		    this.placeholder = text;
			return this;
	    }

	    public ITextBoxComponent WithExplicitPlaceholder(string text)
		{
			this.useLabelForPlaceholder = false;
			this.explicitPlaceholder = true;
			this.placeholder = text;
			return this;
	    }

	    public virtual ITextBoxComponent PreventAutoComplete()
        {
            WithAttr("autocomplete", "off");
            return this;
        }

        public ITextBoxComponent AllowAutoComplete()
        {
            WithoutAttr("autocomplete");
            return this;
        }

	    void ITextBoxComponentInternal.WithMaxLength(int length)
	    {
		    this.WithAttr("maxlength", length.ToString());
	    }

		protected override string RenderComponent()
        {
            string fieldValue;

            if (this.asDefaultEmpty && Equals(this.value, default(TProperty)))
                fieldValue = null;
            else
                fieldValue = this.FormatValue(this.value);

            if (this.attemptedValue != null)
                fieldValue = this.attemptedValue;

		    if (this.explicitPlaceholder)
			    this.htmlAttributes.Add("placeholder", this.placeholder);
			else if(this.useLabelForPlaceholder)
				this.htmlAttributes.Add("placeholder", this.termResolver.ResolveTerm(this.Label, this.culture));
			else if(!string.IsNullOrEmpty(this.placeholder))
				this.htmlAttributes.Add("placeholder", this.termResolver.ResolveTerm(this.placeholder, this.culture));

	        if (this.ariaLabel)
				this.htmlAttributes.Add("aria-label", this.termResolver.ResolveTerm(string.IsNullOrEmpty(this.Label) ? this.placeholder : this.Label, this.culture));

			this.AddAriaDescribedBy();

			this.htmlAttributes.Add("type", "text");
            this.htmlAttributes.Add("value", fieldValue);
            var builder = new TagBuilder("input", this.htmlAttributes);
            return builder.ToString();
        }

    }
}