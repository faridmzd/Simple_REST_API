namespace Simple_REST_API.Business
{
    public static class ApiRoutes
    {
        private const string Root = "api";
        private const string Version = "v1";
        private const string Base = Root + "/" + Version;
        
        public static class Note
        {
            public const string GetAll = Base + "/note";
            public const string Get = Base + "/note/{Id:length(24)}";
            public const string Add = Base + "/note";
            public const string Update = Base + "/note/{Id:length(24)}";
            public const string Delete = Base + "/note/{Id:length(24)}";
        }
    }
}
