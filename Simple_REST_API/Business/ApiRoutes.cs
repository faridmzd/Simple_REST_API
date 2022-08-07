namespace Simple_REST_API.Business
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;
        
        public static class Note
        {
            public const string GetAll = Base + "/note";
            public const string Get = Base + "/note/{id:Guid}";
            public const string Add = Base + "/note";
            public const string Update = Base + "/note";
            public const string Delete = Base + "/note/{id:Guid}";
        }
    }
}
