namespace Entities.RequestFeatures
{
	public class BodyMeasurementParameters : RequestParameters
	{
		public uint MinWeight { get; set; }
		public uint MaxWeight { get; set; } = 1000;
		public bool IsValid => MaxWeight >= MinWeight;
	}
}
