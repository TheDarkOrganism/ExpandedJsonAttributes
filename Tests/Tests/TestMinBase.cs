namespace Tests.Tests
{
	public abstract class TestMinBase
	{
		protected internal static JsonSerializerOptions GetSerializerOptions(Action<JsonTypeInfo> modifier)
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

		protected internal static JsonSerializerOptions GetSerializerOptions(Action<JsonTypeInfo, bool> modifier)
		{
			return GetSerializerOptions(typeInfo => modifier(typeInfo, true));
		}
	}
}
