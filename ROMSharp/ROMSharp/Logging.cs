[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace ROMSharp
{
    public static class Logging
    {
        public static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}