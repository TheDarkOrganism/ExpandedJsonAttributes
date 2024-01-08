namespace Tests.Tests
{
	public sealed class StringLengthTests(TestConfig<StringLengthAttribute> config) : TestBase<StringLengthAttribute, StringLengthModel>(config)
	{
		protected internal override Action<JsonTypeInfo> GetModifier()
		{
			return JsonModifiers.ValidateStringLength;
		}

		protected internal override Action<JsonTypeInfo, bool> GetPropertyModifier()
		{
			return JsonModifiers.ValidateStringLength;
		}
	}
}
