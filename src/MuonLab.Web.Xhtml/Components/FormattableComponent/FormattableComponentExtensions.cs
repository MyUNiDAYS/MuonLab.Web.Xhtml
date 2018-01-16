using System;

namespace MuonLab.Web.Xhtml.Components
{
    public static class FormattableComponentExtensions
    {
        public static TComponent FormattedAs<TComponent, TProperty>(this TComponent component, string formatString)
            where TComponent : IFormattableComponent<TProperty>, IComponent<TProperty>
        {
            (component as IFormattableComponentInternal<TProperty>).FormatFunc = s => ReferenceEquals(s, null) ? null : string.Format("{0:" + formatString + "}", s);
            return component;
        }

        public static TComponent FormatWith<TComponent, TProperty>(this TComponent component, Func<TProperty, string> formatFunc)
            where TComponent : IFormattableComponent<TProperty>, IComponent<TProperty>
        {
            (component as IFormattableComponentInternal<TProperty>).FormatFunc = formatFunc;
            return component;
        }

    }
}