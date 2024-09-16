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

				// Her bir parametreyi boşluklardan temizleyerek ayırıyoruz
				var paramParts = param.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
				var propertyFromQueryName = paramParts[0]; // Property ismini alıyoruz

				var objectProperty = propertyInfos
			   .FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

				if (objectProperty is null)
					continue;

				// Eğer "desc" varsa, descending, yoksa ascending yapıyoruz
				var direction = (paramParts.Length > 1 && paramParts[1].Equals("desc", StringComparison.InvariantCultureIgnoreCase))
					? "descending"
					: "ascending";

				orderQueryBuilder.Append($"{objectProperty.Name} {direction},");
			}

			// Sondaki virgülü temizliyoruz
			var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
			return orderQuery;
		}
	}
}
