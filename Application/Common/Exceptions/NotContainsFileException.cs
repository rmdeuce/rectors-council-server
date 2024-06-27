using System.Xml.Linq;

namespace Application.Common.Exceptions
{
    public class NotContainsFileException : Exception
    {
        public NotContainsFileException(string filePath, string name)
            : base($"File path \"{filePath}\" not found for entity {name}") { }
    }
}
