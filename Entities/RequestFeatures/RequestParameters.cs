namespace Entities.RequestFeatures
{
	public abstract class RequestParameters
	{
		const int DefaultPageSize = 10; // Sabit değer 10 olarak ayarlanacak
		const int maxPageSize = 50; //istemciye max 50 kaynak verilsin
		public int PageNumber { get; set; }
		//full-property
		private int _pageSize = DefaultPageSize;
        public int PageSize
		{
			get { return _pageSize; }
			set { _pageSize = value > maxPageSize ? maxPageSize : value; }
			//value 50den buyukse(istemci 50'den fazla kaynak isterse max 50, 50'den kucukse istenilen deger gelsin)
		}
		public string? Fields { get; set; }
	}
}
