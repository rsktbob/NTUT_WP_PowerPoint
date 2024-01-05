using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class FileDataEventArguments : EventArgs
    {
        public List<List<List<object>>> FileData
        {
            get;
        }

        public FileDataEventArguments(List<List<List<object>>> fileData)
        {
            FileData = fileData;
        }
    }
}
