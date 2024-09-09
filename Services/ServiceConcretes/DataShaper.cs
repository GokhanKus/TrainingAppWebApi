﻿using Services.ServiceContracts;
using System.Dynamic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace Services.ServiceConcretes
{
	public class DataShaper<T> : IDataShaper<T> where T : class
	{
		public PropertyInfo[] Properties { get; set; }
		public DataShaper()
		{
			Properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
		}
		public IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, string? fieldsString)
		{
			var requiredFields = GetRequiredFiels(fieldsString);
			return FetchDataForEntity(entities, requiredFields);
		}
		public ExpandoObject ShapeData(T entity, string? fieldsString)
		{
			var requiredParameters = GetRequiredFiels(fieldsString);
			return FetchDataForEntity(entity, requiredParameters);
		}
		private IEnumerable<ExpandoObject> FetchDataForEntity(IEnumerable<T> entities, IEnumerable<PropertyInfo> requiredProperties)
		{
			var shapedData = new List<ExpandoObject>();
			foreach (var entity in entities)
			{
				var shapedObject = FetchDataForEntity(entity, requiredProperties);
				shapedData.Add(shapedObject);
			}
			return shapedData;
		}
		private ExpandoObject FetchDataForEntity(T entity, IEnumerable<PropertyInfo> requiredProperties)
		{
			var shapedObject = new ExpandoObject();
			foreach (var property in requiredProperties)
			{
				var objectPropertyValue = property.GetValue(entity);
				shapedObject.TryAdd(property.Name, objectPropertyValue);
			}
			return shapedObject;
		}
		private IEnumerable<PropertyInfo> GetRequiredFiels(string fieldsString)
		{
			var requiredFields = new List<PropertyInfo>();

			if (!string.IsNullOrEmpty(fieldsString))
			{
				var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);
				foreach (var field in fields)
				{
					PropertyInfo? propertyInfo = Properties.FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));
					if (propertyInfo is null) continue;
					requiredFields.Add(propertyInfo);
				}
			}
			else
			{
				requiredFields = Properties.ToList();//eger client hicbir field sorgusu yazmadiysa butun alanlarin getirilmesini istiyor demektir o yuzden hepsini aldik.
			}
			return requiredFields;
		}
	}
}
