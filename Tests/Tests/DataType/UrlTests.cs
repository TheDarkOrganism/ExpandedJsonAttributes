namespace Tests.Tests.DataType
{
	public sealed class UrlTests(TestConfig<UrlAttribute> config) : DataTypeTestBase<UrlAttribute, UrlModel>(config)
	{
		protected internal override Action<JsonTypeInfo> GetModifier()
		{
			return JsonModifiers.ValidateUrl;
		}

		protected internal override Action<JsonTypeInfo, bool> GetPropertyModifier()
		{
			return JsonModifiers.ValidateUrl;
		}
	}
}
