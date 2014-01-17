using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace UtahPlanners2
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var config = GlobalConfiguration.Configuration;
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}", // For some reason this is smart enough to hit the Application/ folder to look for the controller
                defaults: new { id = RouteParameter.Optional }
            );

            // JSON format by default with XML as an optional format based on header request
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            // Serializes enums to text
            var jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            var enumConverter = new Newtonsoft.Json.Converters.StringEnumConverter();
            jsonFormatter.SerializerSettings.Converters.Add(enumConverter);
        }

        #region Unused hooks

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        #endregion
    }
}