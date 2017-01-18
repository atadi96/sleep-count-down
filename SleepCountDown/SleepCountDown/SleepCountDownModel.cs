using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SleepCountDown
{
    public enum SuspendMode
    {
        Sleep,
        Hibernate
    }

    public class SleepCountDownModel
    {
        private Timer timer;
        private int seconds;

        public SleepCountDownModel()
        {
            timer = new Timer(1000);
            timer.Enabled = false;
            timer.Elapsed += TimerElapsedEvent;
            seconds = 0;
            SuspendMode = SuspendMode.Sleep;
            SuspendSuccess = false;
        }

        public TimeSpan Time
        {
            get
            {
                int hours = this.seconds / 3600;
                int minutes = (this.seconds % 3600) / 60;
                int seconds = this.seconds % 60;
                return new TimeSpan(hours, minutes, seconds);
            }
            set
            {
                seconds = value.Hours;
                seconds = seconds * 60 + value.Minutes;
                seconds = seconds * 60 + value.Seconds;
                NotifyChange?.Invoke(this, this);
            }
        }

        public SuspendMode SuspendMode;

        public bool Enabled
        {
            set
            {
                timer.Enabled = value;
                NotifyChange?.Invoke(this, this);
            }
            get
            {
                return timer.Enabled;
            }
        }

        public bool SuspendSuccess
        {
            get;
            private set;
        }

        public event EventHandler<SleepCountDownModel> NotifyChange;

        private void TimerElapsedEvent(object sender, ElapsedEventArgs e)
        {
            --seconds;
            if(seconds <= 0)
            {
                switch (SuspendMode)
                {
                    case SuspendMode.Sleep:
                        SuspendSuccess = System.Windows.Forms.Application.SetSuspendState(
                            System.Windows.Forms.PowerState.Suspend,
                            true,
                            true
                        );
                        timer.Enabled = false;
                        break;
                    case SuspendMode.Hibernate:
                        SuspendSuccess = System.Windows.Forms.Application.SetSuspendState(
                            System.Windows.Forms.PowerState.Hibernate,
                            true, 
                            true
                        );
                        timer.Enabled = false;
                        break;
                    default:
                        break;
                }
            }
            NotifyChange?.Invoke(this, this);
        }


    }
}
