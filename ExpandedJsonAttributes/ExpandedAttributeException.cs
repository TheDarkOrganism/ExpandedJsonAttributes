namespace ExpandedJsonAttributes
{
	public sealed class ExpandedAttributeException : ValidationException
	{
		public string Name { get; }

		public bool IsPropertyName { get; }

		public ValidationAttribute Attribute { get; }

		internal ExpandedAttributeException(string name, ValidationAttribute attribute, bool isPropertyName) : base(attribute.FormatErrorMessage(name))
		{
			Name = name;
			IsPropertyName = isPropertyName;
			Attribute = attribute;
		}
	}
}
