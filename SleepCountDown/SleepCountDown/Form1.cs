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
            model = new SleepCountDownModel();
            model.Enabled = false;
            model.NotifyChange += Model_NotifyChange;

            dateTimePicker.Enabled = true;
            sleepRadioButton.Enabled = true;
            hibernateRadioButton.Enabled = true;
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
    }
}
