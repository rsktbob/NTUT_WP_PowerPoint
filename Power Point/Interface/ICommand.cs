using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public interface ICommand
    {
        // Execute function
        void Execute();

        // Unexecute function
        void ReverseExecute();
    }
}
