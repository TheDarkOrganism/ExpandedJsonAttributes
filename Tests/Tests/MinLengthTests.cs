namespace Tests.Tests
{
	public sealed class MinLengthTests(TestConfig<MinLengthAttribute> config) : TestBase<MinLengthAttribute, MinLengthModel>(config)
	{
		protected internal override Action<JsonTypeInfo> GetModifier()
		{
			return JsonModifiers.ValidateMinLength;
		}

		protected internal override Action<JsonTypeInfo, bool> GetPropertyModifier()
		{
			return JsonModifiers.ValidateMinLength;
		}
	}
}
