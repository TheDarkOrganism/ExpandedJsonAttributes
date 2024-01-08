namespace Tests.Tests
{
	public sealed class TestConfig<TAttribute> : TestMinBase
		where TAttribute : notnull, ValidationAttribute
	{
		internal string Name { get; }

		internal JsonSerializerOptions GenericOptions { get; }

		internal JsonSerializerOptions GenericPropertyOptions { get; }

		public TestConfig()
		{
			Name = typeof(TAttribute).Name.Replace(nameof(Attribute), string.Empty);

			GenericOptions = GetSerializerOptions(typeInfo => JsonModifiers.ValidateGeneric<TAttribute>(typeInfo));

			GenericPropertyOptions = GetSerializerOptions((typeInfo, resolvePropertyNames) => JsonModifiers.ValidateGeneric<TAttribute>(typeInfo, resolvePropertyNames));
		}
	}
}
