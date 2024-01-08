namespace Tests.Tests
{
	public sealed class TestConfig<TAttribute>
		where TAttribute : notnull, ValidationAttribute
	{
		internal string Name { get; }

		internal JsonSerializerOptions GenericOptions { get; }

		internal JsonSerializerOptions GenericPropertyOptions { get; }

		internal static JsonSerializerOptions GetSerializerOptions(Action<JsonTypeInfo> modifier)
		{
			return new()
			{
				TypeInfoResolver = new DefaultJsonTypeInfoResolver()
				{
					Modifiers =
					{
						modifier
					}
				}
			};
		}

		internal static JsonSerializerOptions GetSerializerOptions(Action<JsonTypeInfo, bool> modifier)
		{
			return GetSerializerOptions(typeInfo => modifier(typeInfo, true));
		}

		public TestConfig()
		{
			Name = typeof(TAttribute).Name.Replace(nameof(Attribute), string.Empty);

			GenericOptions = GetSerializerOptions(typeInfo => JsonModifiers.ValidateGeneric<TAttribute>(typeInfo));

			GenericPropertyOptions = GetSerializerOptions((typeInfo, resolvePropertyNames) => JsonModifiers.ValidateGeneric<TAttribute>(typeInfo, resolvePropertyNames));
		}
	}
}
