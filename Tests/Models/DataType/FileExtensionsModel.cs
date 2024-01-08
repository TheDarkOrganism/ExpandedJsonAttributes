namespace Tests.Models.DataType
{
	public sealed class FileExtensionsModel
	{
		[FileExtensions(Extensions = "exe")]
		[JsonPropertyName("extension")]
		public required string Extension { get; init; }
	}
}
