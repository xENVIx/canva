using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canva.Classes
{
    internal class CvTimer
    {
        public event EventHandler<System.Timers.ElapsedEventArgs>? Elapsed;

        public void Start()
        {
            if (_running)
            {
                timer.Stop();
            }

            timer.Start();
            _running = true;

        }

        public void Stop()
        {
            if (_running) _running = false;
            timer.Stop();
        }
        
        
        public bool Enabled { get { return timer.Enabled; } set { timer.Enabled = value; } }

        /// <summary>
        /// interval in ms
        /// </summary>
        public double Interval { get { return timer.Interval; } set { timer.Interval = value; } }


        public bool AutoReset { get { return timer.AutoReset; } set { timer.AutoReset = value; } }



        internal CvTimer() : base()
        {
            timer.Elapsed += Timer_Elapsed; 
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            _running = false;
            Elapsed?.Invoke(this, e);
        }

        private System.Timers.Timer timer = new System.Timers.Timer();

        private bool _running = false;
    }
}
