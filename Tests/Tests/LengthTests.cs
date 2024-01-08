namespace Tests.Tests
{
	public sealed class LengthTests(TestConfig<LengthAttribute> config) : TestBase<LengthAttribute, LengthModel>(config)
	{
		protected internal override Action<JsonTypeInfo> GetModifier()
		{
			return JsonModifiers.ValidateLength;
		}

		protected internal override Action<JsonTypeInfo, bool> GetPropertyModifier()
		{
			return JsonModifiers.ValidateLength;
		}
	}
}
