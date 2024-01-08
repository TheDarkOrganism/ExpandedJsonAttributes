namespace Tests.Models.DataType
{
	public sealed class UrlModel
	{
		[JsonPropertyName("url")]
		[Url]
		public required string Url { get; init; }
	}
}
