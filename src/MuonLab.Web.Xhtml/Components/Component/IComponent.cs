using System;
using MuonLab.Web.Xhtml.Configuration;

namespace MuonLab.Web.Xhtml.Components
{
    public interface IComponent
#if NET46
	    : System.Web.IHtmlString
#endif
	{
        string Name { get; }
		
        /// <summary>
        /// Sets an attribute-value on the component
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IComponent WithAttr(string name, object value);
        
        /// <summary>
        /// Removes an attribute if set
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IComponent WithoutAttr(string name);
		
        /// <summary>
        /// Sets the raw string attempted value. This should not be used outside of the ComponentFactory
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IComponent WithAttemptedValue(string value);
    }

    public interface IComponent<in TProperty> : IComponent
    {

    }
}