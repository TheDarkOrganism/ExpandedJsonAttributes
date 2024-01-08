namespace Tests.Models.DataType
{
	public sealed class PhoneModel
	{
		[Phone]
		[JsonPropertyName("phoneNumber")]
		public required string PhoneNumber { get; init; }
	}
}
