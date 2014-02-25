using SADCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADCL
{
    public enum MissileLauncherType
    {
        mockLauncher,
        realLauncher
    }

    class missileFactory
    {
        public ImissileCommand create(MissileLauncherType type) // we took out static from public static 
        {
            if (type == MissileLauncherType.mockLauncher)               
                return new mockLauncher();
            else if (type == MissileLauncherType.realLauncher)
                return new realLauncher();
            return null;
        }
        
    }

}
