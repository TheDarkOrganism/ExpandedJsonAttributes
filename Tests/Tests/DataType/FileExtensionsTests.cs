namespace Tests.Tests.DataType
{
	public sealed class FileExtensionsTests(TestConfig<FileExtensionsAttribute> config) : DataTypeTestBase<FileExtensionsAttribute, FileExtensionsModel>(config)
	{
		protected internal override Action<JsonTypeInfo> GetModifier()
		{
			return JsonModifiers.ValidateFileExtensions;
		}

		protected internal override Action<JsonTypeInfo, bool> GetPropertyModifier()
		{
			return JsonModifiers.ValidateFileExtensions;
		}
	}
}
