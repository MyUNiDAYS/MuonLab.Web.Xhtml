using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MuonLab.Web.Xhtml.Properties;

namespace MuonLab.Web.Xhtml.Example.Net47
{
	internal sealed class ModelStateDictionaryErrorProvider : IErrorProvider
	{
		readonly ModelStateDictionary modelState;

		public ModelStateDictionaryErrorProvider(ModelStateDictionary modelState)
		{
			this.modelState = modelState;
		}

		public IDictionary<string, IList<string>> AllErrors
		{
			get { throw new NotImplementedException(); }
		}

		public IEnumerable<string> GetErrorsFor(string componentName)
		{
			if (modelState[componentName] == null)
				return new string[0];

			return modelState[componentName].Errors.Select(e => e.ErrorMessage);
		}

		public ComponentState GetStateFor(string componentName)
		{
			if (modelState[componentName] == null)
				return ComponentState.Unvalidated;

			return modelState[componentName].Errors.Any() ? ComponentState.Invalid : ComponentState.Valid;
		}

		public string GetAttemptedValueFor(string componentName)
		{
			throw new NotImplementedException();
		}
	}
}