using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Ex3.Controllers
{
    public static class MessageBox
    {
        public static void Show(this Page Page, String message)
        {
            Page.ClientScript.RegisterStartupScript(
                Page.GetType(),
                "MessageBox",
                "<script language='javascript'>alert('" + message + "');</script>"
            );
        }
    }
}