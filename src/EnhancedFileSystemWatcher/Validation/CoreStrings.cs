using JetBrains.Annotations;

// copied from https://github.com/aspnet/EntityFramework/blob/dev/src/Microsoft.EntityFrameworkCore/Properties/CoreStrings.resx
namespace System.IO.Validation
{
    internal static class CoreStrings
    {
        /// <summary>
        /// The string argument '{argumentName}' cannot be empty.
        /// </summary>
        public static string ArgumentIsEmpty([CanBeNull] string argumentName)
        {
            return $"The string argument '{argumentName}' cannot be empty.";
        }
    }
}