namespace Tests.Models.DataType
{
	public sealed class CreditCardModel
	{
		[CreditCard]
		[JsonPropertyName("cardNumber")]
		public required string CardNumber { get; init; }
	}
}
