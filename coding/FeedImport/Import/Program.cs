using CommandLine;
using Import.Core;
using Import.Core.Capterra;
using Import.Core.Contracts;
using Import.Core.Database;
using Import.Core.SoftwareAdvice;

namespace Import
{
	internal class Program
    {
        static void Main(string[] args)
        {
            var options = Parser.Default.ParseArguments<CapterraOptions, SoftwareAdviceOptions>(args);
            RunImport(options);
        } 
        
        static void RunImport(ParserResult<object> options)
        {
            IProductStore productStore = new SQLProductStore();
            IProvider provider = null;

            options.WithParsed<CapterraOptions>(options =>
            {
                provider = new CapterraFeed(options.Path);
            })
            .WithParsed<SoftwareAdviceOptions>(options =>
            {
                provider = new SoftwareAdviceFeed(options.Path);
            });

            if (provider is not null)
            {
                ImportProcessor processor = new ImportProcessor(provider, productStore);
                processor.Import();
            }
        }
    }
}
