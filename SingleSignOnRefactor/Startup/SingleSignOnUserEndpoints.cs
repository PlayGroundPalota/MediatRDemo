using System;
using SingleSignOnRefactor.Models;

namespace SingleSignOnRefactor.Startup
{
    public static class SingleSignOnUserEndpoints
    {
        public static WebApplication UserEndPointsConfiguration(this WebApplication app)
        {
            // register all end points here
            app.MapGet("/Test", () => "Hello");

            return app;
        }


    }
}

