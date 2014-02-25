using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADCL
{
    class singletonTargetManager
    {

        private static singletonTargetManager instance;
        public static singletonTargetManager getInstance()
        {
            if(instance==null)
            {
                instance = new singletonTargetManager();
            }
            return instance;
        }
      
        
        private List<target> statusList = new List<target>();

        public List<target> getList()
        {
            return statusList;
        }

        private singletonTargetManager()
        {

        }
    }
}
