using System.Collections.Generic;
using System.Linq;

namespace MustardBlack.Html.Forms
{
	public class ValidationMessageRenderer : IValidationMessageRenderer
	{
		readonly string messageClass;
		readonly string validMessageClass;
		readonly string invalidMessageClass;

		public string ComponentValidCssClass { get; }
        public string ComponentInvalidCssClass { get; }

		public ValidationMessageRenderer(string messageClass = "field-validation-message", string validMessageClass = "field-validation-ok", string invalidMessageClass = "field-validation-error", string componentValidCssClass = "input-validation-ok", string componentInvalidCssClass = "input-validation-error")
		{
			this.messageClass = messageClass;
			this.validMessageClass = validMessageClass;
			this.invalidMessageClass = invalidMessageClass;
            this.ComponentValidCssClass = componentValidCssClass;
            this.ComponentInvalidCssClass = componentInvalidCssClass;
        }

		/// <summary>
		/// Returns a new ValidationMessageRenderer configured to be compatible with Bootstrap css classes
		/// </summary>
		/// <returns></returns>
        public static ValidationMessageRenderer BootstrapCompatibleValidationMessageRenderer()
        {
			return new ValidationMessageRenderer("feedback", "valid-feedback", "invalid-feedback", "is-valid", "is-invalid");
		}

		public virtual string Render(ComponentState state, ValidationMarkerMode showValidationMessageMode, IEnumerable<string> validationErrors, string id)
		{
			if (state == ComponentState.Unvalidated && showValidationMessageMode != ValidationMarkerMode.Always)
				return "";

			var builder = new TagBuilder("span");
			if (id != null)
				builder.HtmlAttributes["id"] = id;

			if (state == ComponentState.Invalid)
			{
				var firstError = validationErrors.FirstOrDefault();
				if (firstError != null)
				{
					builder.SetInnerText(firstError);
					builder.HtmlAttributes["class"] = this.messageClass + ' ' + this.invalidMessageClass;
				}
			}
			else if (state == ComponentState.Valid)
				builder.HtmlAttributes["class"] = this.messageClass + ' ' + this.validMessageClass;
			else
				builder.HtmlAttributes["class"] = this.messageClass;

			return builder.ToString();
		}
    }
}