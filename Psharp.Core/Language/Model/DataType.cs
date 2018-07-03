using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpen.Core.Language.Model {
	public enum DataType {
		Unknown = 0,
		Int,
		Double,
		String,
		Plain,
		Bool
	}

	public static class DataTypeParser
	{
		public static DataType Parse(string dataTypeString)
		{
			DataType ret;
			Enum.TryParse(dataTypeString,true,out ret);
			return ret;
		}

		public static string EmitTypeKeyword(DataType type)
		{
			switch (type)
			{
				case DataType.Unknown:
					return "dynamic";
				case DataType.Plain:
				case DataType.String:
					return "string";
				default:
					return type.ToString().ToLower();
			}
		}
	}
}
