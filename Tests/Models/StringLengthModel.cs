namespace Tests.Models
{
	public sealed class StringLengthModel
	{
		[JsonPropertyName("text")]
		[StringLength(5)]
		public required string Text { get; init; }
	}
}
