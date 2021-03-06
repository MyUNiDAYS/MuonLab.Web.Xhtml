using System.Collections.Generic;

namespace MustardBlack.Html.Forms.Components
{
	public interface IVisibleComponent<in TProperty> : IComponent<TProperty>, IVisibleComponent
	{
	}

	public interface IVisibleComponent : IComponent
    {
        IVisibleComponent WithRenderingOrder(params ComponentPart[] renderingOrder);

        string Label { get; }

	    /// <summary>
	    /// Adds an HTML Label tag to the markup with text automatically determined from the property represented by the component
	    /// </summary>
	    /// <returns></returns>
	    IVisibleComponent WithAria(bool label = true, bool describedBy = true);

		/// <summary>
		/// Adds an HTML Label tag to the markup with text automatically determined from the property represented by the component
		/// </summary>
		/// <returns></returns>
		IVisibleComponent WithLabel();

		/// <summary>
		/// Adds an HTML Label tag to the markup with the given text.
		/// </summary>
		/// <param name="label">The label text</param>
		/// <param name="contentType">The content type of the label</param>
		/// <returns></returns>
		IVisibleComponent WithLabel(string label, ContentType contentType = ContentType.Term);

		/// <summary>
		/// Sets the html attributes that will be applied to the components label
		/// </summary>
		/// <param name="attributes"></param>
		/// <returns></returns>
		IVisibleComponent WithLabelAttributes(object attributes);

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
        /// Sets the html attributes that will be applied to the components help-text
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        IVisibleComponent WithHelpTextAttributes(object attributes);

		/// <summary>
		/// Set the field as readonly
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

		/// <summary>
		/// Places the provided html before the rendered components
		/// </summary>
		/// <param name="html"></param>
		/// <returns></returns>
	    IVisibleComponent WithWrapperStartHtml(string html);

		/// <summary>
		/// Places the provided html after the rendered components
		/// </summary>
		/// <param name="html"></param>
		/// <returns></returns>
	    IVisibleComponent WithWrapperEndHtml(string html);

		IVisibleComponent WithState(ComponentState state, IEnumerable<string> validationErrors);
		IVisibleComponent WithValidationMessageRenderer(IValidationMessageRenderer messageRenderer);
    }
}