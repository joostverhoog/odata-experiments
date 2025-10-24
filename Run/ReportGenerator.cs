using Microsoft.OData.Edm;
using Microsoft.OData.Edm.Vocabularies;

namespace Run;

class ReportGenerator(IEdmModel model)
{
    const string OptionalParameter = "Org.OData.Core.V1.OptionalParameter";

    public IEnumerable<string> Generate()
    {
        foreach (var line in model.EntityContainer.Elements.OfType<IEdmActionImport>().SelectMany(Generate))
            yield return line;
    }

    IEnumerable<string> Generate(IEdmActionImport actionImport)
    {
        var action = actionImport.Action;
        yield return $"## Action {action.Name}";
        
        foreach (var line in action.Parameters.SelectMany(Generate))
            yield return line;
    }
    
    IEnumerable<string> Generate(IEdmOperationParameter parameter)
    {
        yield return $"### Parameter {parameter.Name}";

        var isOptional = model.FindVocabularyAnnotations<IEdmVocabularyAnnotation>(parameter, OptionalParameter).Any();
        yield return isOptional ? "Optional" : "Non-optional";
    }
}