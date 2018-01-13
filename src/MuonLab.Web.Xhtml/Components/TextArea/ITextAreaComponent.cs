namespace MuonLab.Web.Xhtml.Components
{
	public interface ITextAreaComponent : IFormattableComponent
    {
		ITextAreaComponent WithPlaceholder();
		ITextAreaComponent WithPlaceholder(string placeholder);
    }

	public interface ITextAreaComponent<TProperty> : IFormattableComponent<TProperty>, ITextAreaComponent
    {

    }
}