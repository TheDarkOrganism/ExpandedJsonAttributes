namespace Tests.Models
{
	public sealed class RangeModel
	{
		[Range(1, 18)]
		[JsonPropertyName("age")]
		public int Age { get; init; }
	}
}
