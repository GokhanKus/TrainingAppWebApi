using System.Dynamic;

namespace Services.ServiceContracts
{
	public interface IDataShaper<T> where T : class
	{
		//ExpandoObject: memberlari runtimeda dinamik olarak eklenebilen ve kaldirilabilen bir obje saglar
		IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, string? fieldsString);
		ExpandoObject ShapeData(T entity, string? fieldsString);
	}
}
#region Reflection
/*
Reflection(Yansıma), bir programın kendi yapısını çalışma zamanında inceleme, analiz etme ve hatta değiştirme yeteneğidir. 
Bu, bir programın derleme zamanında bilinen türleri, özellikleri ve metotları hakkında bilgi almanıza, 
bu türlerin özelliklerine ve metotlarına erişmenize, hatta bunları çalışma zamanında oluşturmanıza ve kullanmanıza olanak tanır.
C# ve .NET gibi modern programlama dilleri ve çerçeveler, Reflection özelliğini desteklerler.
Reflection, genellikle dinamik olarak türleri, özellikleri ve metotları kullanmanın gerektiği durumlarda kullanılır.
Örneğin, veritabanı sorgularını oluşturmak, XML veya JSON verilerini serileştirmek/deserileştirmek, 
dinamik olarak türler oluşturmak veya mevcut türlerin özelliklerini sorgulamak gibi durumlarda Reflection kullanılabilir.
Reflection, System.Reflection adlı .NET kütüphanesinde yer alan sınıflar ve yöntemler tarafından sağlanır. 
Bu sınıflar ve yöntemler, türleri ve bunların üyelerini (örneğin, alanlar, özellikler, metotlar) analiz etmenize ve 
çalışma zamanında bu türlerle etkileşimde bulunmanıza olanak tanır.
Birkaç yaygın Reflection kullanımı şunlardır:
Bir türün adını kullanarak bir türü dinamik olarak yükleme ve kullanma.
Bir türün özelliklerine ve metotlarına dinamik olarak erişme ve onları çağırma.
Bir türün alanlarını ve özelliklerini sorgulama ve değerlerini okuma/yazma.
Mevcut türlerin üyeleri hakkında bilgi alma ve bu bilgileri kullanma.
Ancak, Reflection güçlü bir araç olmasına rağmen, aşırı kullanımı performansı etkileyebilir ve kodunuzu karmaşık hale getirebilir. 
Bu nedenle, Reflection'u yalnızca gerektiğinde ve uygun bir şekilde kullanmak önemlidir.
*/
#endregion
#region Data Shaping
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
#endregion
