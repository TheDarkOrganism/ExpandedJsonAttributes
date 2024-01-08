namespace Tests.Models
{
	public sealed class MinLengthModel
	{
		[JsonPropertyName("value")]
		[MinLength(1)]
		public required int[] Value { get; init; }
	}
}
