using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MuonLab.Web.Xhtml.Components
{
	[DebuggerDisplay("Name: {Name}")]
    public abstract class Component<TViewModel, TProperty> : 
		IComponent<TProperty>,
		IComponentInternal,
        IComponentInternal<TProperty>
	{
	    protected readonly IDictionary<string, object> htmlAttributes;
	    public abstract string ControlPrefix { get; }
	    public TProperty Value { get; set; }
	    protected string attemptedValue;

	    public string Name => (this as IComponentInternal).GetAttr("name");


	    protected Component()
        {
            this.htmlAttributes = new Dictionary<string, object>();
        }

	    /// <summary>
        /// Sets an attribute-value on the component
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public IComponent WithAttr(string name, object value)
        {
            this.htmlAttributes[name] = value;
            return this;
        }

	    /// <summary>
        /// Removes an attribute if it exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IComponent WithoutAttr(string name)
        {
            if (this.htmlAttributes.ContainsKey(name))
                this.htmlAttributes.Remove(name);
            return this;
        }
        
	    public IComponent WithAttemptedValue(string value)
        {
            this.attemptedValue = value;
            return this;
        }

	    /// <inheritdoc />
        string IComponentInternal.GetAttr(string name)
		{
			return this.GetAttr(name);
		}

	    protected internal string GetAttr(string name)
	    {
		    return this.htmlAttributes.ContainsKey(name) ? this.htmlAttributes[name].ToString() : null;
		}

	    protected abstract string RenderComponent();


	    public override string ToString()
        {
            return this.RenderComponent();
        }

	    public string ToHtmlString()
    	{
    		return this.ToString();
    	}
	}
}