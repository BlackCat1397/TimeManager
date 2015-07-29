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
    public partial class Form2 : Form
    {
        public Task task;
        Form1 form;


        public Form2(Form1 form1)
        {
            InitializeComponent();
            form = form1;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            task = new Task(textBox1.Text, form);
            form.newTask(task, form.id);
            form.id++;
            Close();
        }
    }
}
