// ReSharper disable once CheckNamespace
namespace MuonLab.Web.Xhtml.Components
{
    public interface ITextBoxComponent : IFormattableComponent
    {
        ITextBoxComponent ShowDefaultAsEmpty();
        ITextBoxComponent WithPlaceholder();
        ITextBoxComponent WithPlaceholder(string placeholder);
	    ITextBoxComponent WithExplicitPlaceholder(string placeholder);
    }
}