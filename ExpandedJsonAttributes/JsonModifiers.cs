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

		public static void ValidateRange(JsonTypeInfo typeInfo, bool resolvePropertyNames)
		{
			ValidateGeneric<RangeAttribute>(typeInfo, resolvePropertyNames);
		}

		public static void ValidateRange(JsonTypeInfo typeInfo)
		{
			ValidateGeneric<RangeAttribute>(typeInfo);
		}

		public static void ValidateCustomValidation(JsonTypeInfo typeInfo, bool resolvePropertyNames)
		{
			ValidateGeneric<CustomValidationAttribute>(typeInfo, resolvePropertyNames);
		}

		public static void ValidateCustomValidation(JsonTypeInfo typeInfo)
		{
			ValidateGeneric<CustomValidationAttribute>(typeInfo);
		}

		public static void ValidateDataType(JsonTypeInfo typeInfo, bool resolvePropertyNames)
		{
			ValidateGeneric<DataTypeAttribute>(typeInfo, resolvePropertyNames);
		}

		public static void ValidateDataType(JsonTypeInfo typeInfo)
		{
			ValidateGeneric<DataTypeAttribute>(typeInfo);
		}

		public static void ValidateCreditCard(JsonTypeInfo typeInfo, bool resolvePropertyNames)
		{
			ValidateGeneric<CreditCardAttribute>(typeInfo, resolvePropertyNames);
		}

		public static void ValidateCreditCard(JsonTypeInfo typeInfo)
		{
			ValidateGeneric<CreditCardAttribute>(typeInfo);
		}

		public static void ValidateEmail(JsonTypeInfo typeInfo, bool resolvePropertyNames)
		{
			ValidateGeneric<EmailAddressAttribute>(typeInfo, resolvePropertyNames);
		}

		public static void ValidateEmail(JsonTypeInfo typeInfo)
		{
			ValidateGeneric<EmailAddressAttribute>(typeInfo);
		}

		public static void ValidateEnumDataType(JsonTypeInfo typeInfo, bool resolvePropertyNames)
		{
			ValidateGeneric<EnumDataTypeAttribute>(typeInfo, resolvePropertyNames);
		}

		public static void ValidateEnumDataType(JsonTypeInfo typeInfo)
		{
			ValidateGeneric<EnumDataTypeAttribute>(typeInfo);
		}

		public static void ValidateFileExtensions(JsonTypeInfo typeInfo, bool resolvePropertyNames)
		{
			ValidateGeneric<FileExtensionsAttribute>(typeInfo, resolvePropertyNames);
		}

		public static void ValidateFileExtensions(JsonTypeInfo typeInfo)
		{
			ValidateGeneric<FileExtensionsAttribute>(typeInfo);
		}

		public static void ValidatePhone(JsonTypeInfo typeInfo, bool resolvePropertyNames)
		{
			ValidateGeneric<PhoneAttribute>(typeInfo, resolvePropertyNames);
		}

		public static void ValidatePhone(JsonTypeInfo typeInfo)
		{
			ValidateGeneric<PhoneAttribute>(typeInfo);
		}

		public static void ValidateRegularExpression(JsonTypeInfo typeInfo, bool resolvePropertyNames)
		{
			ValidateGeneric<RegularExpressionAttribute>(typeInfo, resolvePropertyNames);
		}

		public static void ValidateRegularExpression(JsonTypeInfo typeInfo)
		{
			ValidateGeneric<RegularExpressionAttribute>(typeInfo);
		}

		public static void ValidateStringLength(JsonTypeInfo typeInfo, bool resolvePropertyNames)
		{
			ValidateGeneric<StringLengthAttribute>(typeInfo, resolvePropertyNames);
		}

		public static void ValidateStringLength(JsonTypeInfo typeInfo)
		{
			ValidateGeneric<StringLengthAttribute>(typeInfo);
		}

		public static void ValidateMaxLength(JsonTypeInfo typeInfo, bool resolvePropertyNames)
		{
			ValidateGeneric<MaxLengthAttribute>(typeInfo, resolvePropertyNames);
		}

		public static void ValidateMaxLength(JsonTypeInfo typeInfo)
		{
			ValidateGeneric<MaxLengthAttribute>(typeInfo);
		}

		public static void ValidateMinLength(JsonTypeInfo typeInfo, bool resolvePropertyNames)
		{
			ValidateGeneric<MinLengthAttribute>(typeInfo, resolvePropertyNames);
		}

		public static void ValidateMinLength(JsonTypeInfo typeInfo)
		{
			ValidateGeneric<MinLengthAttribute>(typeInfo);
		}

		public static void ValidateUrl(JsonTypeInfo typeInfo, bool resolvePropertyNames)
		{
			ValidateGeneric<UrlAttribute>(typeInfo, resolvePropertyNames);
		}

		public static void ValidateUrl(JsonTypeInfo typeInfo)
		{
			ValidateGeneric<UrlAttribute>(typeInfo);
		}

#if NET8_0_OR_GREATER

		public static void ValidateLength(JsonTypeInfo typeInfo, bool resolvePropertyNames)
		{
			ValidateGeneric<LengthAttribute>(typeInfo, resolvePropertyNames);
		}

		public static void ValidateLength(JsonTypeInfo typeInfo)
		{
			ValidateGeneric<LengthAttribute>(typeInfo);
		}

		public static void ValidateAllowedValues(JsonTypeInfo typeInfo, bool resolvePropertyNames)
		{
			ValidateGeneric<AllowedValuesAttribute>(typeInfo, resolvePropertyNames);
		}

		public static void ValidateAllowedValues(JsonTypeInfo typeInfo)
		{
			ValidateGeneric<AllowedValuesAttribute>(typeInfo);
		}

		public static void ValidateBase64String(JsonTypeInfo typeInfo, bool resolvePropertyNames)
		{
			ValidateGeneric<Base64StringAttribute>(typeInfo, resolvePropertyNames);
		}

		public static void ValidateBase64String(JsonTypeInfo typeInfo)
		{
			ValidateGeneric<Base64StringAttribute>(typeInfo);
		}

#endif
	}
}
