using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    public class Connection
    {
        private static Entities Context;
        public static Entities GetContext() 
        {
            if (Context == null)
            {
                Context = new Entities();
            }
            return Context;
        }
        public static void SaveContext(Entities Context)
        {
            Context.SaveChanges();
        }
    }
}
