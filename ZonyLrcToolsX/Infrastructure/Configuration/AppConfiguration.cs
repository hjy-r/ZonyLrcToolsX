namespace ZonyLrcToolsX.Infrastructure.Configuration
{
    public class AppConfiguration
    {
        private readonly object _locker = new object();
        private AppConfiguration _instance;

        private AppConfiguration()
        {
            
        }

        public AppConfiguration Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if(_instance == null) _instance = new AppConfiguration();
                    }
                }

                return _instance;
            }
        }

        public void Initialize()
        {
            
        }
    }
}