namespace Tests.Tests
{
	public sealed class CustomValidationTests(TestConfig<CustomValidationAttribute> config) : TestBase<CustomValidationAttribute, CustomValidationModel>(config)
	{
		protected internal override Action<JsonTypeInfo> GetModifier()
		{
			return JsonModifiers.ValidateCustomValidation;
		}

		protected internal override Action<JsonTypeInfo, bool> GetPropertyModifier()
		{
			return JsonModifiers.ValidateCustomValidation;
		}
	}
}
