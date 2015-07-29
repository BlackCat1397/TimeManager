using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeManager
{
    public class Task
    {
        Timer timer;
        DateTime date;
        DateTime stopWatch = new DateTime();
        bool run = false;
        bool active = true;


        // Constructor:
        public Task(string name, Form1 tform)
        {
            this.form = tform;
            this.Name = name;
            this.initTim();
        }
        
        public Task(string name, int id)
        {
            this.Name = name;
            this.ID = id;
            this.initTim();
        }

        public void Start()
        {
            if (run)
            {
                timer.Stop();
                run = false;
            }
            else
            {
                date = DateTime.Now;
                timer.Start();
                run = true;
            }
        }

        public void Reset()
        {
            timer.Stop();
            run = false;
            stopWatch = new DateTime();
            StopWatch = stopWatch;
            form.updateTime(stopWatch);
        }

        // Timer init:
        private void initTim()
        {
            this.timer = new Timer();
            this.timer.Interval = 10;
            this.timer.Tick += new EventHandler(tickTimer);
            this.timer.Stop();
        }

        public void Activate()
        {
            active = true;
        }

        public void Deactivate()
        {
            active = false;
        }

        private void tickTimer(object sender, EventArgs e)
        {
            StopWatch = stopWatch;
            long ticks = DateTime.Now.Ticks - date.Ticks;
            stopWatch = stopWatch.AddTicks(ticks);
            if (active)
                form.updateTime(stopWatch);
            date = DateTime.Now;
        }

        public string Name
        {
            get; set;
        }

        public int ID
        {
            get; set;
        }

        public Form1 form
        {
            get; set;
        }

        public DateTime StopWatch
        {
            get;
            set;
        }
    }
}
