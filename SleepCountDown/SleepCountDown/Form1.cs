using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SleepCountDown
{
    public partial class Form1 : Form
    {
        SleepCountDownModel model;

        public Form1()
        {
            InitializeComponent();
            //setup drag and drop
            AllowDrop = true;
            DragEnter += new DragEventHandler(Form1_DragEnter);
            DragDrop += new DragEventHandler(Form1_DragDrop);
            //setup the model layer
            model = new SleepCountDownModel();
            model.Enabled = false;
            model.NotifyChange += Model_NotifyChange;
            //make sure all of our controls have the same state at the start of the app
            dateTimePicker.Enabled = true;
            sleepRadioButton.Enabled = true;
            hibernateRadioButton.Enabled = true;
            //load the custom start/stop button image
            LoadStartStopButtonImage();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Model_NotifyChange(this, model);
        }

        private void Model_NotifyChange(object sender, SleepCountDownModel model)
        {
            if(model.SuspendSuccess)
            {
                Application.Exit();
            }
            Invoke((MethodInvoker)delegate
            {
                setControlsEnabled(!model.Enabled);
                dateTimePicker.Value = new DateTime(1753, 1, 1, model.Time.Hours, model.Time.Minutes, model.Time.Seconds);
                sleepRadioButton.Checked = model.SuspendMode == SuspendMode.Sleep;
                hibernateRadioButton.Checked = model.SuspendMode == SuspendMode.Hibernate;
            });
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            var button = sender as RadioButton;
            if(button.Enabled)
            {
                model.SuspendMode = SuspendMode.Sleep;
            }
        }

        private void hibernateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var button = sender as RadioButton;
            if (button.Enabled)
            {
                model.SuspendMode = SuspendMode.Hibernate;
            }
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            model.Time = dateTimePicker.Value.TimeOfDay;
            model.Enabled = !model.Enabled;
        }

        private void setControlsEnabled(bool enabled)
        {
            if (dateTimePicker.Enabled != enabled)
            {
                dateTimePicker.Enabled = enabled;
                hibernateRadioButton.Enabled = enabled;
                sleepRadioButton.Enabled = enabled;
            }
        }

        private void LoadStartStopButtonImage()
        {
            Image image = SleepCountDownPersistence.getStartStopButtonImage();
            if (image != null) //there was an image to load
            {
                startStopButton.BackgroundImage = image;
            }
            else //there was no image or there was an error
            {
                //so we now load the default Haruna back
                startStopButton.BackgroundImage = Properties.Resources.Haruna;
            }
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if(files.Length > 0)
            {
                SleepCountDownPersistence.setStartStopButtonImagePath(files[0]);
            }
            LoadStartStopButtonImage();
        }
    }
}
