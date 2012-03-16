using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MuonLab.Web.Xhtml
{
	public static class Enumerator
	{
		public static IEnumerable<TEnum> GetAll<TEnum>()
		{
			if(!typeof(TEnum).IsEnum)
				throw new ArgumentException("`" + typeof(TEnum) + "` is not an Enum");

			return Enum.GetNames(typeof(TEnum)).Select(n => (TEnum)Enum.Parse(typeof(TEnum), n));
		}

		public static IEnumerable GetAll(Type enumType)
		{
			if (!enumType.IsEnum)
				throw new ArgumentException("`" + enumType + "` is not an Enum", "enumType");

			return Enum.GetNames(enumType).Select(n => Enum.Parse(enumType, n));
		}
	}
}