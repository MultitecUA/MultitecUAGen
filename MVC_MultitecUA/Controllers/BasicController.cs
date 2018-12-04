using MultitecUAGenNHibernate.CAD.MultitecUA;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MultitecUA.Controllers
{
    public class BasicController : Controller
    {
        protected ISession session;

        protected BasicController()
        {
        }

        protected void SessionInitialize()
        {
            if (session == null)
            {
                session = NHibernateHelper.OpenSession();
            }
        }


        protected void SessionClose()
        {
            if (session != null && session.IsOpen)
            {
                session.Close();
                session.Dispose();
                session = null;
            }
        }
    }
}
