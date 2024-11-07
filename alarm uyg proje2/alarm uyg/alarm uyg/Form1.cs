using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Data.OleDb;


namespace alarm_uyg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text=DateTime.Now.ToShortTimeString();



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            button2.Enabled =false;
        }
        SoundPlayer player=new SoundPlayer();

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            button1.Enabled = false;
            if(numericUpDown1.Value==DateTime.Now.Hour&&numericUpDown2.Value==DateTime.Now.Minute)
            {
                timer1.Stop();
                SoundPlayer muzik = new SoundPlayer();
                string ses = Application.StartupPath + "\\alarm.wav";
                muzik.SoundLocation = ses;
                muzik.Play();
               
            }
            button2.Enabled=true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            player.Stop();
        }
        public void database()
        {
            OleDbConnection b = new OleDbConnection("provider=microsoft.ace.oledb.12.0; data source=alarm.accdb;persist security info=false;");
            b.Open();

            OleDbCommand saat = new OleDbCommand("insert into saat(saat,dakika) values(" + numericUpDown1.Value + "," + numericUpDown2.Value + ")" , b);
            saat.ExecuteNonQuery();
            b.Close();

        
        }
    }
}
