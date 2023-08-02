namespace SaamAppLib.SharedKernel
{
    public static class MessagingConstants
    {
        public static class Credentials
        {
            public const string DEFAULT_USERNAME = "guest";
            public const string DEFAULT_PASSWORD = "guest";
        }

        public static class Exchanges
        {
            public const string SAAMAPP_BUSINESSMANAGEMENT_EXCHANGE = "saamapp-queueservice-2-mq";

            public const string SAAMAPP_RABBITMQMONGOWATCHER_EXCHANGE =
                "saamapp-rabbitmqmongowatcher";
        }

        public static class NetworkConfig
        {
            public const int DEFAULT_PORT = 5672;
            public const string DEFAULT_VIRTUAL_HOST = "/";
        }

        public static class Queues
        {
            public const string FDCM_BUSINESSMANAGEMENT_IN = "fdcm-businessmanagement-in";
            public const string FDCM_SAAMAPP_IN = "fdcm-saamapp-in";
            public const string FDVCP_SAAMAPP_IN = "fdvcp-saamapp-in";
            public const string FDVCP_RABBITMQMONGOWATCHER_IN = "fdvcp-rabbitmqmongowatcher-in";
        }
    }
}