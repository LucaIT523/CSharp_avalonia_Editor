using System.Runtime.InteropServices;

namespace MockerProject;

public static class Utilities
{
    public static bool IsBrowser()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER"));
    }
}
