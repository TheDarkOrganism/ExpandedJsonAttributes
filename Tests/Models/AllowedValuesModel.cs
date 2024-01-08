namespace Tests.Models
{
	public sealed class AllowedValuesModel
	{
		[AllowedValues("Red", "Green", "Blue")]
		[JsonPropertyName("color")]
		public required string Color { get; init; }
	}
}
