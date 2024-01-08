namespace Tests.Tests
{
	public sealed class Base64StringTests(TestConfig<Base64StringAttribute> config) : TestBase<Base64StringAttribute, Base64StringModel>(config)
	{
		protected internal override Action<JsonTypeInfo> GetModifier()
		{
			return JsonModifiers.ValidateBase64String;
		}

		protected internal override Action<JsonTypeInfo, bool> GetPropertyModifier()
		{
			return JsonModifiers.ValidateBase64String;
		}
	}
}
