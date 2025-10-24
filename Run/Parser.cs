using System.Xml;
using Microsoft.OData.Edm;
using Microsoft.OData.Edm.Csdl;

namespace Run;

static class Parser
{
    private static readonly CsdlReaderSettings Settings = new() { IgnoreUnexpectedAttributesAndElements = true };

    public static IEdmModel Parse(string content)
    {
        using var stringReader = new StringReader(content);
        using var xmlReader = XmlReader.Create(stringReader);
        var success = CsdlReader.TryParse(xmlReader, [], Settings, out var edmModel, out var errors);
        if (!success)
            throw new Exception(string.Join(Environment.NewLine, errors.Select(err => err.ErrorMessage).ToArray()));

        return edmModel;
    }
}