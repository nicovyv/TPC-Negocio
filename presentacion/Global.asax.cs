using negocio;
using System;
using System.Web;

namespace presentacion
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }
        void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            Session.Add("error", Security.ManejoError(exc));
            Response.Redirect("Error.aspx");
        }
    }
}