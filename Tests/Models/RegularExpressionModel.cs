namespace Tests.Models
{
	public sealed class RegularExpressionModel
	{
		[JsonPropertyName("text")]
		[RegularExpression("\"\\s\\w{5}\\s\\w{5}\\s\"")]
		public required string Text { get; init; }
	}
}
