namespace Tests.Tests.DataType
{
	public sealed class CreditCardTests(TestConfig<CreditCardAttribute> config) : DataTypeTestBase<CreditCardAttribute, CreditCardModel>(config)
	{
		protected internal override Action<JsonTypeInfo> GetModifier()
		{
			return JsonModifiers.ValidateCreditCard;
		}

		protected internal override Action<JsonTypeInfo, bool> GetPropertyModifier()
		{
			return JsonModifiers.ValidateCreditCard;
		}
	}
}
