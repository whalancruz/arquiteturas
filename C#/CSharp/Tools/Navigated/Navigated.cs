using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CSharp.Tools.Navigated
{
    public class Navigated : RoutePrefixAttribute
    {
        public Navigated() : base("api") { }

        public Navigated(string prefix) : base("api/" + prefix) { }
    }
}