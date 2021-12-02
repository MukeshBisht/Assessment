using CommandLine;

namespace Import
{
    class FilePathOption
    {
        [Value(index: 1, MetaName ="path", Required = true, HelpText = "File Path to import.")]
        public string Path { get; set; }
    }

    [Verb("capterra", HelpText = "import products from capterra.")]
    class CapterraOptions : FilePathOption
    { 
    }

    [Verb("softwareadvice", HelpText = "import products from softwareadvice.")]
    class SoftwareAdviceOptions : FilePathOption
    { 
    }
}
