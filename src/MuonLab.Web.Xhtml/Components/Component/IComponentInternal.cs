namespace MuonLab.Web.Xhtml.Components
{
	internal interface IComponentInternal
	{
		/// <summary>
		/// Gets an attribute by its name
		/// </summary>
		/// <param name="name">The name of the attribute to get</param>
		/// <returns>The attribute value or null</returns>
		string GetAttr(string name);
	}
}