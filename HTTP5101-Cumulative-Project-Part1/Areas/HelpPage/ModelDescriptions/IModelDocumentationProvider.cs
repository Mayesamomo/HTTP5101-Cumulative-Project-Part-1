using System;
using System.Reflection;

namespace HTTP5101_Cumulative_Project_Part1.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}