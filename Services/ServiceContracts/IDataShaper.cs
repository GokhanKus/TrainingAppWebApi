using System.Dynamic;

namespace Services.ServiceContracts
{
	public interface IDataShaper<T> where T : class
	{
		//ExpandoObject: memberlari runtimeda dinamik olarak eklenebilen ve kaldirilabilen bir obje saglar
		IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, string fieldsString);
		ExpandoObject ShapeData(T entity, string fieldsString);
	}
}
/*
Data Shaping: 
API tuketicisinin, sorgu dizesi araciligiyla talep ettigi nesnenin alanlarini secerek sonuc setini sekillendirmesini saglar
her api'nin ihtiyaci olmayabilir karmasık ve yogun trafik var ise api'mizde o zaman kullanilabilir ve boyle bir implementasyon yapilacaksa;
runtime'da -calisma zamaninda- kod yaziyoruz ve runtime'da nesne uretmek ilgili nesnenin alanlarini secmek ve buna ait donusleri istemciye yapmak maliyetli istir
ornek queryler;
workouts?fields = id,totalcaloriesburned
exercises?fields = id, name, description
bodymeasurements?fields = id, weight
*/
