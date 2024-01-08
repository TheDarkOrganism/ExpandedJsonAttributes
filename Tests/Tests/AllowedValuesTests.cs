namespace Tests.Tests
{
	public sealed class AllowedValuesTests(TestConfig<AllowedValuesAttribute> config) : TestBase<AllowedValuesAttribute, AllowedValuesModel>(config)
	{
		protected internal override Action<JsonTypeInfo> GetModifier()
		{
			return JsonModifiers.ValidateAllowedValues;
		}

		protected internal override Action<JsonTypeInfo, bool> GetPropertyModifier()
		{
			return JsonModifiers.ValidateAllowedValues;
		}
	}
}
