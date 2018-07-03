using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpen.Core.Language.Model {
	public sealed class LanguageEntityTable<T> where T: LanguageEntity
	{
		private readonly List<T> _entities;

		public LanguageEntityTable()
		{
			_entities = new List<T>();
		}

		public void Add(T var) {
			if(!_entities.Contains(var)) {
				_entities.Add(var);
			}
		}

		public void AddRange(IEnumerable<T> entities)
		{
			if (entities != null)
			{
				_entities.AddRange(entities);
			}
		}
		
		public bool Contains(string variableName) {
			return _entities.Any(v => v.Name == variableName);
		}

		public T this[string name]
		{
			get {
				var ret = _entities.FirstOrDefault(e => e.Name == name);
				if (ret == null)
				{
					throw new KeyNotFoundException($"Entity '{name}' not found");
				}
				return ret;
			}
		}
	}
}
