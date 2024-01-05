﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleDriveUploader.GoogleDrive;
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
            const string CLIEBT_SECRET_FILE_NAME = "clientSecret.json";

            _service = new GoogleDriveService(APPLICATION_NAME, CLIEBT_SECRET_FILE_NAME);
        }

        // Click load button
        private void CliclLoadButton(object sender, EventArgs e)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            List<Google.Apis.Drive.v2.Data.File> fileList = _service.ListRootFileAndFolder();
            Google.Apis.Drive.v2.Data.File foundFile = fileList.Find(item => { return item.Title == FILE_NAME; });
            if (foundFile != null)
            {
                _service.DownloadFile(foundFile, currentDirectory);
            }
            InvokeDowbloadEndEvent(sender, e);
            Close();
        }

        // Invoke download end event
        private void InvokeDowbloadEndEvent(object sender, EventArgs e)
        {
            if (_downloadEndEvent != null)
            {
                _downloadEndEvent.Invoke(sender, e);
            }
        }
    }
}