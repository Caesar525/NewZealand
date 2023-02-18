using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace NEWZEALAND.Localization
{
    public static class NEWZEALANDLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(NEWZEALANDConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(NEWZEALANDLocalizationConfigurer).GetAssembly(),
                        "NEWZEALAND.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
