namespace Tests.Models
{
	public sealed class Base64StringModel
	{
		[Base64String]
		[JsonPropertyName("value")]
		public required string Value { get; init; }
	}
}
