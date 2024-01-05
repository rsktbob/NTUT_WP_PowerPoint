using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Power_Point
{
    public class FileDataEventArguments : EventArgs
    {
        public List<List<Shape>> FileData
        {
            get;
        }

        public FileDataEventArguments(List<List<Shape>> fileData)
        {
            FileData = fileData;
        }
    }
}
