using System.Collections.Generic;
using MuonLab.Web.Xhtml.Properties;

namespace MuonLab.Web.Xhtml.Components
{
	public interface IVisibleComponent : IComponent
    {

        string Label { get; }

        /// <summary>
        /// Adds an HTML Label tag to the markup with text automatically determined from the property represented by the component
        /// </summary>
        /// <returns></returns>
        IVisibleComponent WithLabel(bool aria = true);

		/// <summary>
		/// Adds an HTML Label tag to the markup with the given text.
		/// </summary>
		/// <param name="label">The label text</param>
		/// <param name="contentType">The content type of the label</param>
		/// <returns></returns>
		IVisibleComponent WithLabel(string label, ContentType contentType = ContentType.Term, bool aria = true);

        /// <summary>
        /// Prevents an HTML label from being rendered
        /// </summary>
        /// <returns></returns>
        IVisibleComponent WithoutLabel();

        /// <summary>
        /// Adds a validation message to the markup when the field is invalid
        /// </summary>
        /// <returns></returns>
		IVisibleComponent WithValidationMessage(ValidationMarkerMode mode);

        /// <summary>
        /// Prevents a validation message from being displayed
        /// </summary>
        /// <returns></returns>
        IVisibleComponent WithoutValidationMessage();

        /// <summary>
        /// Sets the help text for the component
        /// </summary>
        /// <returns></returns>
        IVisibleComponent WithHelpText(string helpText, ContentType contentType = ContentType.Term);

        /// <summary>
        /// set teh field as readonly
        /// </summary>
        /// <returns></returns>
        IVisibleComponent ReadOnly();

        /// <summary>
        /// Wraps all rendered tags in an outer tag with the given name
        /// </summary>
        /// <param name="tagName">the tag name, e.g. "div". Pass null for no wrapper</param>
        /// <returns></returns>
        IVisibleComponent WithWrapper(string tagName);

        /// <summary>
        /// Wraps all rendered tags in an outer tag with the given name
        /// </summary>
        /// <param name="tagName">the tag name, e.g. "div". Pass null for no wrapper</param>
        /// <param name="htmlAttributes">The html attributes to apply to the wrapper</param>
        /// <returns></returns>
        IVisibleComponent WithWrapper(string tagName, object htmlAttributes);

		IVisibleComponent WithState(ComponentState state, IEnumerable<string> validationErrors);
		IVisibleComponent WithValidationMessageRenderer(IValidationMessageRenderer messageRenderer);
    }
}