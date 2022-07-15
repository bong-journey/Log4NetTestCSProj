using log4net;
using log4net.Config;

namespace Log4netTest{
    class Log4netTest{

        # region variables
        private static ILog _logger = null;
        private static string _logPath = @"C:\Log";
        private static string _log4ConfigPath = string.Format(@"{0}\Log4netConfig.xml", AppDomain.CurrentDomain.BaseDirectory);
        # endregion

        # region Functions
        static void StartLogging()
        {
            InitLogger();
        }
        private static void InitLogger()
        {
            if(!Directory.Exists(_logPath))
                Directory.CreateDirectory(_logPath);
            
            XmlConfigurator.Configure(new FileInfo(_log4ConfigPath));

            _logger = log4net.LogManager.GetLogger("RollingFile");
        }

        public static void LogOnDebugMode(string log)
        {
            _logger.Debug(log);
        }

        public static void LogOnInfoMode(string log)
        {
            _logger.Info(log);
        }

        public static void LogOnErrorMode(string log)
        {
            _logger.Error(log);
        }

        public static void LogOnErrorMode(string log, Exception exception)
        {
            _logger.Error(log, exception);
        }

        #endregion

        static void Main()
        {
            StartLogging();
            
            LogOnInfoMode("Logging info ...");
            LogOnDebugMode("Logging Debug info ...");
            LogOnErrorMode("Logging Error ...");
            LogOnErrorMode("Logging Error ... => ", new FormatException());
        }
    }
}