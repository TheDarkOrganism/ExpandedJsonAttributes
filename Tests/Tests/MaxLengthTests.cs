namespace Tests.Tests
{
	public sealed class MaxLengthTests(TestConfig<MaxLengthAttribute> config) : TestBase<MaxLengthAttribute, MaxLengthModel>(config)
	{
		protected internal override Action<JsonTypeInfo> GetModifier()
		{
			return JsonModifiers.ValidateMaxLength;
		}

		protected internal override Action<JsonTypeInfo, bool> GetPropertyModifier()
		{
			return JsonModifiers.ValidateMaxLength;
		}
	}
}
