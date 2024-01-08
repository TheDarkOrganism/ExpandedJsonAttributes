namespace Tests.Tests.DataType
{
	public abstract class DataTypeTestBase<TAttribute, TModel> : TestBase<TAttribute, TModel>
		where TAttribute : notnull, DataTypeAttribute
		where TModel : notnull
	{
		protected internal sealed override string SampleFolderPath => Path.Combine(base.SampleFolderPath, "DataType");

		private static readonly JsonSerializerOptions _simpleOptions = GetSerializerOptions(typeInfo => JsonModifiers.ValidateDataType(typeInfo));

		private static readonly JsonSerializerOptions _complexOptions = GetSerializerOptions((typeInfo, resolvePropertyNames) => JsonModifiers.ValidateDataType(typeInfo, resolvePropertyNames));

		protected internal DataTypeTestBase(TestConfig<TAttribute> config) : base(config) { }

		[Fact]
		public async Task BadDataType()
		{
			await HandleBadAsync(_simpleOptions);
		}

		[Fact]
		public async Task GoodDataType()
		{
			await HandleGoodAsync(_simpleOptions);
		}

		[Fact]
		public async Task BadDataTypeProperties()
		{
			await HandleBadAsync(_complexOptions);
		}

		[Fact]
		public async Task GoodDataTypeProperties()
		{
			await HandleGoodAsync(_complexOptions);
		}
	}
}
