namespace Tests.Models
{
	public sealed class CustomValidationModel
	{
		[CustomValidation(typeof(CustomValidationModel), nameof(ValidateEven))]
		[JsonPropertyName("number")]
		public int Number { get; init; }

		public static ValidationResult? ValidateEven(int number)
		{
			return number % 2 == 0 ? ValidationResult.Success : new("The value must be even");
		}
	}
}
