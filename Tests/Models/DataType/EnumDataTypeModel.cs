namespace Tests.Models.DataType
{
	public sealed class EnumDataTypeModel
	{
		[EnumDataType(typeof(DayOfWeek))]
		[JsonPropertyName("day")]
		public required string Day { get; init; }
	}
}
