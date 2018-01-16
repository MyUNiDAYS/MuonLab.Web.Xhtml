namespace MuonLab.Web.Xhtml.Components
{
	public static class ComponentExtensions
	{
	    /// <summary>
	    /// Sets the value for this component
	    /// </summary>
	    /// <param name="value"></param>
	    /// <returns></returns>
        public static TComponent WithValue<TComponent, TProperty>(this TComponent component, TProperty value)
            where TComponent : IComponent<TProperty>
	    {
	        (component as IComponentInternal<TProperty>).Value = value;
	        return component;
	    }

		/// <summary>
		/// Sets an attribute-value on the component if a condition is met
		/// </summary>
		/// <param name="condition"></param>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static TComponent WithAttrIf<TComponent>(this TComponent component, bool condition, string name, object value)
			where TComponent : IComponent
		{
			if (condition)
				component.WithAttr(name, value);

			return component;
		}

		/// <summary>
		/// Sets the components HTML id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static TComponent WithId<TComponent>(this TComponent component, string id)
			where TComponent : IComponent
		{
			component.WithAttr("id", id);

			return component;
		}

		/// <summary>
		/// Sets the components HTML name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static TComponent WithName<TComponent>(this TComponent component, string name)
			where TComponent : IComponent
		{
			component.WithAttr("name", name);

			return component;
		}


		/// <summary>
		/// Set the field as disabled
		/// </summary>
		/// <returns></returns>
		public static TComponent Disabled<TComponent>(this TComponent component)
			where TComponent : IComponent
		{
			component.WithAttr("disabled", "disabled");
			return component;
		}

		/// <summary>
		/// Fluent CssClass setter
		/// </summary>
		/// <param name="className"></param>
		/// <returns></returns>
		public static TComponent WithClass<TComponent>(this TComponent component, string className)
			where TComponent : IComponent
		{
			component.WithAttr("class", className);
			return component;
		}

		/// <summary>
		/// Fluent CssClass setter
		/// </summary>
		/// <param name="className"></param>
		/// <returns></returns>
		public static TComponent AddClass<TComponent>(this TComponent component, string className) 
			where TComponent : IComponent
		{
			var componentInternal = component as IComponentInternal;
			if (!string.IsNullOrEmpty(componentInternal.GetAttr("class")))
				component.WithAttr("class", componentInternal.GetAttr("class") + ' ' + className);
			else
				component.WithAttr("class", className);

			return component;
		}
	}
}