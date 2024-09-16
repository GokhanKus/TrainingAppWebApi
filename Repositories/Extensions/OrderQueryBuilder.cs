using System.Reflection;
using System.Text;

namespace Repositories.Extensions
{
	public static class OrderQueryBuilder
	{
		//farklı entityler icin sıralama yapmak isteyebiliriz hepsi bunu kullansin hepsi icin ayri ayri yazilmasin
		public static string CreateOrderQuery<T>(string orderByQueryString)
		{
			var orderParams = orderByQueryString.Trim().Split(','); //queryString uzerinden var olan queryleri aldik

			var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);//class uzerinden prop bilgilerini aldik

			var orderQueryBuilder = new StringBuilder();

			foreach (var param in orderParams)
			{
				if (string.IsNullOrEmpty(param))
					continue;

				var propertyFromQueryName = param.Split(' ')[0];

				var objectProperty = propertyInfos
					.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

				if (objectProperty is null)
					continue;

				var direction = param.EndsWith(" desc") ? "descending" : "ascending";
				orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
			}
			var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
			return orderQuery;
		}
	}
}
