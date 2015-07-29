using System;
using System.IO;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TimeManager
{
    public partial class Form1 : Form
    {
        List<Task> array = new List<Task>();
        public int id = 0;
        int t = 0;
        bool f = false;
       

        
        void refreshCombobox ()
        {
            f = true;
            comboBox1.DataSource = null;
            comboBox1.DataSource = array;
            comboBox1.DisplayMember = "Name";
        }

        public Form1()
        {
            InitializeComponent();
            this.SizeChanged += new EventHandler(form1_sizeeventhandler);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (array.Count != 0)
            {
                t = comboBox1.SelectedIndex;
                array[t].Start();
            }
            //else
                //error!
        }

        public void updateTime(DateTime SW)
        {
            label1.Text = String.Format("{00:HH:mm:ss:ff}", SW);
            notifyIcon1.Text = String.Format("{00:HH:mm:ss:ff}", SW);
        }

        //Reset button
        private void button2_Click(object sender, EventArgs e)
        {
            if (array.Count != 0)
            {
                array[t].Reset();
            }
        }
 
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void form1_sizeeventhandler(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }


        //New Task button^^
        private void button3_Click(object sender, EventArgs e)
        {
            if (array.Count != 0)
                array[t].Deactivate();
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        //^^
        public void newTask(Task task, int id)
        {
            array.Insert(0, task);
            refreshCombobox();
            comboBox1.SelectedIndex = 0;
            updateTime(array[0].StopWatch);
        }

        //Delete Task button
        private void button4_Click(object sender, EventArgs e)
        {
            if (array.Count != 0)
            {
                f = true;
                int t = comboBox1.SelectedIndex;
                Task task = array[t];
                array[t].Deactivate();
                array.Remove(task);

                if (t != 0)
                    comboBox1.SelectedIndex = t - 1;
                else
                    comboBox1.SelectedIndex = 0;
                t = comboBox1.SelectedIndex;
                if (array.Count != 0)
                    array[t].Activate();
                refreshCombobox();
            }
            //else
                //error
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!f)
            {
                array[t].Deactivate();

                t = comboBox1.SelectedIndex;
                array[t].Activate();
                updateTime(array[t].StopWatch);
            }
            f = false;
        }


        //report
        private void button5_Click(object sender, EventArgs e)
        {
            string fileName = "test.txt";  // a sample file name 
            string text = "";


            // Delete the file if it exists. 
            if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }

             foreach (Task task in array)
            {
                 text += task.Name;
                 text += "-";
                 text += String.Format("{00:HH:mm:ss}", task.StopWatch);
                 text += Environment.NewLine;
            }
             
            
            byte[] info = new System.Text.UTF8Encoding(true).GetBytes(text);
            
           

            // Create the file. 
            using (System.IO.FileStream fs = System.IO.File.Create(fileName, 1024))
            {
                // Add some information to the file. 
                fs.Write(info, 0, info.Length);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (Task task in array)
            {
                task.Reset();
            }
        }
    }
}
