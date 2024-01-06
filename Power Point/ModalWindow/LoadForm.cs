using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Power_Point
{
    public partial class LoadForm : System.Windows.Forms.Form
    {
        public event EventHandler _downloadEndEvent;
        const string CONTENT_TYPE = "application/json";
        const string FILE_NAME = "data.json";
        private GoogleDriveService _service;

        public LoadForm()
        {
            InitializeComponent();
            const string APPLICATION_NAME = "DrawAnywhere";
            const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";

            _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
        }

        // Click load button
        private void ClickLoadButton(object sender, EventArgs e)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            List<Google.Apis.Drive.v2.Data.File> fileList = _service.ListRootFileAndFolder();
            Google.Apis.Drive.v2.Data.File foundFile = fileList.Find(item => item.Title == FILE_NAME);
            List<List<Shape>> fileData = null;
            if (foundFile != null)
            {
                string fileText = _service.GetGoogleFileText(foundFile, currentDirectory);
                fileData = TransformFileInfo(JsonConvert.DeserializeObject<List<List<Dictionary<string, object>>>>(fileText));
            }
            if (_downloadEndEvent != null)
            {
                FileDataEventArguments arguments = new FileDataEventArguments(fileData);
                _downloadEndEvent.Invoke(sender, arguments);
            }
            Close();
        }

        // Transfoem file data
        private List<List<Shape>> TransformFileInfo(List<List<Dictionary<string, object>>> fileInfo)
        {
            List<List<Shape>> fileData = new List<List<Shape>>();
            for (int i = 0; i < fileInfo.Count; i++)
            {
                fileData.Add(new List<Shape>());
                for (int j = 0; j < fileInfo[i].Count; j++)
                {
                    Dictionary<string, object> shapeInfo = fileInfo[i][j];
                    Factory factory = new Factory(shapeInfo["ShapeName"] as string);
                    Shape shape = factory.CreateShape(Convert.ToInt32(shapeInfo["PointX1"]), Convert.ToInt32(shapeInfo["PointY1"]), Convert.ToInt32(shapeInfo["PointX2"]), Convert.ToInt32(shapeInfo["PointY2"]));
                    fileData[i].Add(shape);
                }
            }
            return fileData;
        }

        // Click form close
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _downloadEndEvent.Invoke(null, null);
            base.OnFormClosing(e);
        }

    }
}
