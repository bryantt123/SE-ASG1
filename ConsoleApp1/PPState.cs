using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface PPState
    {       
        void park();
        void exit();
        void applyPass();
        void renewPass();
        void transferPass();
        void terminatePass();
    }
}
