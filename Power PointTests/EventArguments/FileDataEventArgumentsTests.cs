using Microsoft.VisualStudio.TestTools.UnitTesting;
using Power_Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point.Tests
{
    [TestClass()]
    public class FileDataEventArgumentsTests
    {
        [TestMethod()]
        public void FileDataEventArgumentsTest()
        {
            FileDataEventArguments arguments = new FileDataEventArguments(null);

            Assert.IsNull(arguments.FileData);
        }
    }
}