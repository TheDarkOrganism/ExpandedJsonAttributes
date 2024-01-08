namespace Tests.Tests
{
	public sealed class RangeTests(TestConfig<RangeAttribute> config) : TestBase<RangeAttribute, RangeModel>(config)
	{
		protected internal override Action<JsonTypeInfo> GetModifier()
		{
			return JsonModifiers.ValidateRange;
		}

		protected internal override Action<JsonTypeInfo, bool> GetPropertyModifier()
		{
			return JsonModifiers.ValidateRange;
		}
	}
}
