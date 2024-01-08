namespace Tests.Models.DataType
{
	public sealed class EmailAddressModel
	{
		[EmailAddress]
		[JsonPropertyName("email")]
		public required string Email { get; init; }
	}
}
