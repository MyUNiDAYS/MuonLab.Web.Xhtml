using System;

namespace MuonLab.Web.Xhtml.Components
{
    internal interface IFormattableComponentInternal<TProperty> : IComponentInternal<TProperty>
    {
        Func<TProperty, string> FormatFunc { set; }
    }
}