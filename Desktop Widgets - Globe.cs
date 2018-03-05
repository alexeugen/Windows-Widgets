using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        bool move;
        int i = 3;
     
        bool right_icons = true;
        int count = 1;
        string html;
        int yt;


        Point[] positions = new Point[20];
        PictureBox[] icons = new PictureBox[20];
        String[] exe = new string[20];

        public Form1()
        {
            InitializeComponent();
            this.TransparencyKey = BackColor;
            this.FormBorderStyle = FormBorderStyle.None;
            
            search_pb.Visible = false;
            listBox1.Visible = false;
            add_btn.Visible = false;

            positions[1] =new Point(629, 86);
            positions[2] = new Point(647, 136);
            positions[3] = new Point(695, 155);
            positions[4] = new Point(571, 99);
            positions[5] = new Point(590, 155);
            positions[6] = new Point(629, 192);
            positions[7] = new Point(677, 221);
            positions[8] = new Point(523, 132);
            positions[9] = new Point(542, 190);
            positions[10] = new Point(581, 235);

            icons[1] = photoshop_open;
            icons[2] = illustrator_open;
            icons[3] = cb_open;
            icons[4] = word_open;
            icons[5] = ppt_open;
            icons[6] = excel_open;
            icons[7] = paint_open;
            icons[8] = notepad_open;
            icons[9] = skype_open;
            icons[10] = vs_open;

        }
      
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
                this.SetDesktopLocation(MousePosition.X -765, MousePosition.Y-20);
        }

   

        private void checked_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (checked_btn.Checked==true)
                this.TopMost = true;
            else
                this.TopMost = false;
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if (search_textbox.Width<130)
            {
                search_textbox.Width += 130;
                search_textbox.Left -= 130;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (search_textbox.Width > 130)
            {
                search_textbox.Width -= 130;
                search_textbox.Left += 130;
                
            }
            search_timer.Enabled = true;
            search_pb.BringToFront();
            search_pb.Visible = true;
            Process.Start("http://google.com/search?q=" + search_textbox.Text);
            search_textbox.Clear();

        }



    

        private void button7_Click(object sender, EventArgs e)
        {
            if (webBrowser1.Visible == false)
            {
                webBrowser1.Visible = true;
               // yt_timer.Enabled = true;
                button1.Visible = true;
                button2.Visible = true;

            }
            else
            {
                webBrowser1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
            }
               
            
        }

        private void yt_timer_Tick(object sender, EventArgs e)
        {
           // webBrowser1.Document.GetElementById("watch7-container").InnerText = "";
           // webBrowser1.Document.GetElementById("footer-container").InnerText = "";
          
        }

        private void search_timer_Tick(object sender, EventArgs e)
        {
            search_pb.Visible = false;
            search_timer.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            move_timer.Enabled = true;
        }

        private void move_timer_Tick(object sender, EventArgs e)
        {
            if (i >=-8)
            {
                pictureBox2.Top += (i*i - 12);
                pictureBox2.Left +=i*5;
            }

            i--;
        }

        private void search_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (search_textbox.Width > 130)
                {
                    search_textbox.Width -= 130;
                    search_textbox.Left += 130;

                }
                search_timer.Enabled = true;
                search_pb.BringToFront();
                search_pb.Visible = true;
                Process.Start("http://google.com/search?q=" + search_textbox.Text);
                search_textbox.Clear();
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

     

 
     

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(right_icons==false)
            {
             
      
                yt_btn.Visible = true;
                
                right_icons = true;
            }
            else
            {
       
           
                yt_btn.Visible = false;
              
                right_icons = false;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            if(listBox1.Visible==false)
            {
                listBox1.Visible = true;
                add_btn.Visible = true;
            }
            else
            {
                listBox1.Visible = false;
                add_btn.Visible = false;
            }
            
        }

      

       
       

        private void add_btn_Click(object sender, EventArgs e)
        {
            int j = listBox1.Items.Count-1;

            for (int i = j; i >= 0; i--)
                if (listBox1.GetSelected(i))
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "Executable Files|*.exe";
                    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        exe[i + 1] = ofd.FileName;
                        icons[i + 1].Location = positions[count];
                        icons[i + 1].Visible = true;
                        count++;
                    }
                        
                }
                    

        }
#region icons_click
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Process.Start(exe[1]);
        }

        private void illustrator_open_Click(object sender, EventArgs e)
        {
            Process.Start(exe[2]);
        }

        private void cb_open_Click(object sender, EventArgs e)
        {
            Process.Start(exe[3]);
        }

        private void word_open_Click(object sender, EventArgs e)
        {
            Process.Start(exe[4]);
        }

        private void ppt_open_Click(object sender, EventArgs e)
        {
            Process.Start(exe[5]);
        }

        private void excel_open_Click(object sender, EventArgs e)
        {
            Process.Start(exe[6]);
        }

        private void paint_open_Click(object sender, EventArgs e)
        {
            Process.Start(exe[7]);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Process.Start(exe[8]);
        }

        private void skype_open_Click(object sender, EventArgs e)
        {
            Process.Start(exe[9]);
        }
       
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Process.Start(exe[10]);
        }


        #endregion

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.ScrollBarsEnabled = false;
            html = webBrowser1.Document.GetElementById("masthead-positioner").InnerHtml;
            webBrowser1.Document.GetElementById("masthead-positioner").InnerHtml = "";
            webBrowser1.Document.GetElementById("masthead-positioner-height-offset").InnerHtml = "";
           

            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            webBrowser1.ScrollBarsEnabled = true;
            webBrowser1.Document.GetElementById("masthead-positioner").InnerHtml = html;
        }

        private void mail_btn_Click(object sender, EventArgs e)
        {
           // Form form2 = new YahooMail();
           // form2.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void youtube_left_timer_Tick(object sender, EventArgs e)
        {
         /*   webBrowser1.ScrollBarsEnabled = false;
            html = webBrowser1.Document.GetElementById("masthead-positioner").InnerHtml;
            webBrowser1.Document.GetElementById("masthead-positioner").InnerHtml = "";
            webBrowser1.Document.GetElementById("masthead-positioner-height-offset").InnerHtml = "";

            yt++;
            if (yt == 2)
                youtube_left_timer.Enabled = false;
                */
        }

        private void youtebe_l1fting_Tick(object sender, EventArgs e)
        {

        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
          //  youtube_left_timer.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
