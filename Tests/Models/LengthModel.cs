namespace Tests.Models
{
	public sealed class LengthModel
	{
		[Length(1, int.MaxValue)]
		[JsonPropertyName("name")]
		public required string Name { get; init; }
	}
}
