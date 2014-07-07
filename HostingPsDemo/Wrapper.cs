using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingPsDemo
{
    public interface IWrapper
    {
        string Status { set; }
        string Output { set; }

        void FirstButton();
        void SecondButton();
    }
}
