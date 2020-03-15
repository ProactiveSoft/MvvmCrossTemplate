using MvvmCross;

namespace $safeprojectname$
{
    // This class is never actually executed, but when Xamarin linking is enabled, it ensures types and properties
    // are preserved in the deployed app
    [Preserve(AllMembers = true)]
    public class LinkerPleaseInclude
    {
        // Initialize MvvmCross plugins
        //public void Include(MvvmCross.Plugin.Json.Plugin plugin) => plugin.Load();

        //public void Include(MvvmCross.Plugin.Messenger.Plugin plugin) => plugin.Load();
    }
}