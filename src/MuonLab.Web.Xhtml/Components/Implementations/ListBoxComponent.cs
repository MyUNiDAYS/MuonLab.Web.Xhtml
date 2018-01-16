using System;
using System.Collections.Generic;
using System.Globalization;
using MuonLab.Web.Xhtml.Configuration;

namespace MuonLab.Web.Xhtml.Components.Implementations
{
	public class ListBoxComponent<TViewModel, TProperty, TData> :
		VisibleComponent<TViewModel, TProperty>,
		IListBoxComponent<TProperty>
	{
		readonly IEnumerable<TData> items;
		readonly Func<TProperty, string> propertyValueFunc;
		readonly Func<TData, string> itemValueFunc;
		readonly Func<TData, string> itemTextFunc;
		readonly Func<TData, object> itemHtmlAttributes;

		public ListBoxComponent(ITermResolver termResolver, CultureInfo culture, IEnumerable<TData> items, Func<TProperty, string> propertyValueFunc, Func<TData, string> itemValueFunc, Func<TData, string> itemTextFunc, Func<TData, object> itemHtmlAttributes)
			: base(termResolver, culture)
		{
			if (items == null)
				throw new ArgumentNullException(nameof(items), "DropDown's data items enumerable cannot be null");

			this.items = items;
			this.propertyValueFunc = propertyValueFunc;
			this.itemValueFunc = itemValueFunc;
			this.itemTextFunc = itemTextFunc;
			this.itemHtmlAttributes = itemHtmlAttributes;
			this.WithSize(5);
		}

		public override string ControlPrefix => "lst";

		/// <summary>
		/// Sets the size of the list box (in rows)
		/// </summary>
		/// <returns></returns>
		public virtual IListBoxComponent WithSize(int size)
		{
			this.WithAttr("size", size);
			return this;
		}
		
		protected override string RenderComponent()
		{
			var builder = new TagBuilder("select", this.htmlAttributes);

			if (this.ariaLabel)
				this.htmlAttributes.Add("aria-label", this.termResolver.ResolveTerm(this.Label, this.culture));

			this.AddAriaDescribedBy();
			
			foreach (var item in items)
			{
				var optionAttributes = this.itemHtmlAttributes?.Invoke(item);

				var optionBuilder = new TagBuilder("option", optionAttributes);

				optionBuilder.HtmlAttributes.Add("value", this.itemValueFunc.Invoke(item));

				if (!ReferenceEquals(this.Value, null) && Equals(propertyValueFunc(this.Value), itemValueFunc(item)))
					optionBuilder.HtmlAttributes.Add("selected", "selected");

				optionBuilder.SetInnerText(this.itemTextFunc.Invoke(item));

				builder.InnerHtml += optionBuilder.ToString();
			}

			return builder.ToString();
		}
	}
}