using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepCountDown
{
    static class SleepCountDownPersistence
    {
        public static void setStartStopButtonImagePath(string path)
        {
            Properties.Settings.Default.ButtonImagePath = path;
            Properties.Settings.Default.Save();
        }

        public static Image getStartStopButtonImage()
        {
            string path = Properties.Settings.Default.ButtonImagePath;
            if(path == "")
            {
                return null; //there's no picture to load
            }
            else
            {
                Image image;
                try
                {
                    image = Image.FromFile(path);
                }
                catch(Exception e) // this will run if the file can't be converted to an image
                {
                    image = null;
                    setStartStopButtonImagePath(""); //we clear the path. This is to be able get the 
                                                     //default Haruna back
                }
                return image;
            }
        }
    }
}
