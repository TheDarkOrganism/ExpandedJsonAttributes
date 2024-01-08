namespace Tests.Models
{
	public sealed class MaxLengthModel
	{
		[JsonPropertyName("value")]
		[MaxLength(3)]
		public required int[] Value { get; init; }
	}
}
