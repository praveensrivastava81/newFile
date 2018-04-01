﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace BuyNowTracker
{
    public class ScreenCapture
    {
        public static MemoryStream SaveScreen()
        {

            Bitmap memoryImage;

            try
            {

                memoryImage = new Bitmap(1000, 900);

                Size s = new Size(memoryImage.Width, memoryImage.Height);

                Graphics memoryGraphics = Graphics.FromImage(memoryImage);

                memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);

                //That's it! Save the image in the directory and this will work like charm.

                string flname = Guid.NewGuid().ToString();

                string folderPath = AppDomain.CurrentDomain.BaseDirectory + "/ScreenShot";

                if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                // string str = string.Format(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Screenshot" + flname + ".png");

                //memoryImage.Save(folderPath + @"\" + flname + ".png");


                MemoryStream memoryStream = new MemoryStream();
                memoryImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);

                memoryImage.Dispose();

                return memoryStream;

            }
            catch (Exception ex)
            {

                throw (ex);

            }
        }

    }

}
