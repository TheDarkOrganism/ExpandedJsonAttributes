namespace Tests.Tests.DataType
{
	public sealed class EnumDataTypeTests(TestConfig<EnumDataTypeAttribute> config) : DataTypeTestBase<EnumDataTypeAttribute, EnumDataTypeModel>(config)
	{
		protected internal override Action<JsonTypeInfo> GetModifier()
		{
			return JsonModifiers.ValidateEnumDataType;
		}

		protected internal override Action<JsonTypeInfo, bool> GetPropertyModifier()
		{
			return JsonModifiers.ValidateEnumDataType;
		}
	}
}
