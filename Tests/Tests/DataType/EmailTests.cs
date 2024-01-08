namespace Tests.Tests.DataType
{
	public sealed class EmailTests(TestConfig<EmailAddressAttribute> config) : DataTypeTestBase<EmailAddressAttribute, EmailAddressModel>(config)
	{
		protected internal override Action<JsonTypeInfo> GetModifier()
		{
			return JsonModifiers.ValidateEmail;
		}

		protected internal override Action<JsonTypeInfo, bool> GetPropertyModifier()
		{
			return JsonModifiers.ValidateEmail;
		}
	}
}
