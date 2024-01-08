namespace Tests.Tests
{
	public abstract class TestBase<TAttribute, TModel> : IClassFixture<TestConfig<TAttribute>>
		where TAttribute : notnull, ValidationAttribute
		where TModel : notnull
	{
		private readonly TestConfig<TAttribute> _config;

		private readonly JsonSerializerOptions _simpleOptions;

		private readonly JsonSerializerOptions _complexOptions;

		protected internal virtual string SampleFolderPath { get; } = "Samples";

		protected internal TestBase(TestConfig<TAttribute> config)
		{
			_config = config;

			_simpleOptions = TestConfig<TAttribute>.GetSerializerOptions(GetModifier());

			_complexOptions = TestConfig<TAttribute>.GetSerializerOptions(GetPropertyModifier());
		}

		protected internal abstract Action<JsonTypeInfo> GetModifier();

		protected internal abstract Action<JsonTypeInfo, bool> GetPropertyModifier();

		private async Task<TModel?> GetModel(string name, JsonSerializerOptions options)
		{
			return JsonSerializer.Deserialize<TModel>(await File.ReadAllTextAsync(Path.Combine(SampleFolderPath, _config.Name, $"{name}.json")), options);
		}

		protected internal async Task HandleBadAsync(JsonSerializerOptions options)
		{
			_ = await Assert.ThrowsAsync<ExpandedAttributeException>(async () => Assert.NotNull(await GetModel("Bad", options)));
		}

		protected internal async Task HandleGoodAsync(JsonSerializerOptions options)
		{
			Assert.NotNull(await GetModel("Good", options));
		}

		[Fact]
		public async Task Bad()
		{
			await HandleBadAsync(_simpleOptions);
		}

		[Fact]
		public async Task BadGeneric()
		{
			await HandleBadAsync(_config.GenericOptions);
		}

		[Fact]
		public async Task Good()
		{
			await HandleGoodAsync(_simpleOptions);
		}

		[Fact]
		public async Task GoodGeneric()
		{
			await HandleGoodAsync(_config.GenericOptions);
		}

		[Fact]
		public async Task BadProperties()
		{
			await HandleBadAsync(_complexOptions);
		}

		[Fact]
		public async Task BadGenericProperties()
		{
			await HandleBadAsync(_config.GenericPropertyOptions);
		}

		[Fact]
		public async Task GoodProperties()
		{
			await HandleGoodAsync(_complexOptions);
		}

		[Fact]
		public async Task GoodGenericProperties()
		{
			await HandleGoodAsync(_config.GenericPropertyOptions);
		}
	}
}
