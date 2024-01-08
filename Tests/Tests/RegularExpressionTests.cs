namespace Tests.Tests
{
	public sealed class RegularExpressionTests(TestConfig<RegularExpressionAttribute> config) : TestBase<RegularExpressionAttribute, RegularExpressionModel>(config)
	{
		protected internal override Action<JsonTypeInfo> GetModifier()
		{
			return JsonModifiers.ValidateRegularExpression;
		}

		protected internal override Action<JsonTypeInfo, bool> GetPropertyModifier()
		{
			return JsonModifiers.ValidateRegularExpression;
		}
	}
}
