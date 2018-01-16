using System;
using System.Globalization;
using MuonLab.Web.Xhtml.Configuration;

namespace MuonLab.Web.Xhtml.Components
{
    public abstract class FormattableComponent<TViewModel, TProperty> :
        VisibleComponent<TViewModel, TProperty>,
        IFormattableComponent<TProperty>,
        IFormattableComponentInternal<TProperty>
    {
        public Func<TProperty, string> FormatFunc { get; set; }
        
        protected FormattableComponent(ITermResolver termResolver, CultureInfo culture) : base(termResolver, culture)
        {
            this.FormatFunc = s => ReferenceEquals(s, null) ? null : $"{s}";
        }

        protected string FormatValue(TProperty value)
        {
            return this.FormatFunc.Invoke(this.Value);
        }
    }
}