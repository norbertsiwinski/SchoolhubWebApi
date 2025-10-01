namespace Schoolhub.Domain.Students
{
    public record StudentIdentifier
    {
        public string Value { get; }

        private StudentIdentifier(string value) => Value = value;

        public static StudentIdentifier Create(string identifier) 
        {
            if (string.IsNullOrWhiteSpace(identifier))
                throw new ArgumentException("Student identifier is required.");

            return new StudentIdentifier(identifier);
        }
    }
}
