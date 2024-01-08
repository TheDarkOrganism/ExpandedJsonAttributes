using System.Reflection;
using System.Text.Json.Serialization.Metadata;

namespace ExpandedJsonAttributes
{
	public static class JsonModifiers
	{
		public static void ValidateType(Type type, JsonTypeInfo typeInfo, bool resolvePropertyNames)
		{
			ArgumentNullException.ThrowIfNull(type, nameof(type));
			ArgumentNullException.ThrowIfNull(typeInfo, nameof(typeInfo));
			ArgumentNullException.ThrowIfNull(resolvePropertyNames, nameof(resolvePropertyNames));

			if (!type.IsAssignableTo(typeof(ValidationAttribute)))
			{
				throw new ArgumentException($"{nameof(type)} is not instance of {nameof(ValidationAttribute)}", nameof(type));
			}

			foreach (JsonPropertyInfo propertyInfo in typeInfo.Properties)
			{
				Action<object, object?>? setProperty = propertyInfo.Set;

				if (setProperty is not null)
				{
					IEnumerable<ValidationAttribute>? attributes = propertyInfo.AttributeProvider?.GetCustomAttributes(type, true).OfType<ValidationAttribute>();

					if (attributes is not null)
					{
						propertyInfo.Set = (obj, value) =>
						{
							string name = propertyInfo.Name;

							foreach (ValidationAttribute attribute in attributes)
							{
								if (attribute is not CompareAttribute && !attribute.IsValid(value))
								{
									throw new ExpandedAttributeException(resolvePropertyNames ? typeInfo.Type.GetProperty(propertyInfo.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)?.Name ?? name : name, attribute, resolvePropertyNames);
								}
							}

							setProperty(obj, value);
						};
					}
				}
			}
		}

		public static void ValidateType(Type type, JsonTypeInfo typeInfo)
		{
			ValidateType(type, typeInfo, default);
		}

		public static void ValidateGeneric<TAttribute>(JsonTypeInfo typeInfo, bool resolvePropertyNames)
			where TAttribute : notnull, ValidationAttribute
		{
			ValidateType(typeof(TAttribute), typeInfo, resolvePropertyNames);
		}

		public static void ValidateGeneric<TAttribute>(JsonTypeInfo typeInfo)
			where TAttribute : notnull, ValidationAttribute
		{
			ValidateType(typeof(TAttribute), typeInfo);
		}
	}
}
