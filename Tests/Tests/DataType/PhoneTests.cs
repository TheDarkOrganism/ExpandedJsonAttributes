namespace Tests.Tests.DataType
{
	public sealed class PhoneTests(TestConfig<PhoneAttribute> config) : DataTypeTestBase<PhoneAttribute, PhoneModel>(config)
	{
		protected internal override Action<JsonTypeInfo> GetModifier()
		{
			return JsonModifiers.ValidatePhone;
		}

		protected internal override Action<JsonTypeInfo, bool> GetPropertyModifier()
		{
			return JsonModifiers.ValidatePhone;
		}
	}
}
