using System.Globalization;
using MuonLab.Web.Xhtml.Configuration;

namespace MuonLab.Web.Xhtml.Components
{
    public class EmailBoxComponent<TViewModel, TProperty> : 
		TextBoxComponent<TViewModel, TProperty>, 
		IEmailBoxComponent<TProperty> 
    {
	    public EmailBoxComponent(ITermResolver termResolver, CultureInfo culture) : base(termResolver, culture)
	    {
	    }

	    public override string ControlPrefix => "txt";

	    protected override string RenderComponent()
        {
            string fieldValue;

            if (this.asDefaultEmpty && Equals(this.Value, default(TProperty)))
                fieldValue = null;
            else
                fieldValue = this.FormatValue(this.Value);

            if (this.attemptedValue != null)
                fieldValue = this.attemptedValue;

			if (this.useLabelForPlaceholder)
				this.htmlAttributes.Add("placeholder", this.termResolver.ResolveTerm(this.Label, this.culture));
			else if (!string.IsNullOrEmpty(this.placeholder))
				this.htmlAttributes.Add("placeholder", this.termResolver.ResolveTerm(this.placeholder, this.culture));

	        if (this.ariaLabel)
				this.htmlAttributes.Add("aria-label", this.termResolver.ResolveTerm(string.IsNullOrEmpty(this.Label) ? this.placeholder : this.Label, this.culture));

			this.AddAriaDescribedBy();

            this.htmlAttributes.Add("type", "email");
            this.htmlAttributes.Add("value", fieldValue);
            var builder = new TagBuilder("input", this.htmlAttributes);
            return builder.ToString();
        }

    }
}