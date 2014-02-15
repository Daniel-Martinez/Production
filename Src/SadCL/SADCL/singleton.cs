using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADCL
{
    class singleton
    {

        private static singleton instance;
        public static singleton getInstance()
        {
            if(instance==null)
            {
                instance = new singleton();
            }
            return instance;
        }
      
        
        private List<target> statusList = new List<target>();

        public List<target> getList()
        {
            return statusList;
        }
    }
}
