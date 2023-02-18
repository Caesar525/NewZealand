using NEWZEALAND.Debugging;

namespace NEWZEALAND
{
    public class NEWZEALANDConsts
    {
        public const string LocalizationSourceName = "NEWZEALAND";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "e5e2ad4389054e55879f40046d175c57";
    }
}
