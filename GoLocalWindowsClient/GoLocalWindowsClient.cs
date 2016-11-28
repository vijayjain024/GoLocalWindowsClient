using System;
using System.Windows.Forms;
using Windows.Devices.Geolocation;
using System.Device.Location;
using System.Drawing;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public partial class GoLocalWindowsClient : Form
    {
        List<Control> controllist = new List<Control>(); //control list for news feed page
        List<Control> postlist = new List<Control>();//control list for post news page

        int maxlength = 1000;

        public GoLocalWindowsClient()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // GetLocation();
            label2.Hide();

        }

        private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            //MessageBox.Show(String.Format("Lat: {0}, Long: {1}", e.Position.Location.Latitude, e.Position.Location.Longitude));
        }

        private void login_Click(object sender, EventArgs e)
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += watcher_PositionChanged;
            watcher.Start();
            userlabel.Hide();
            userinput.Hide();
            desclbl.Hide();
            homepagelogo.Hide();
            login.Hide();
            applogo.Show();
            post.Show();
            int feedcount = 3;
            //add logic to update feedcount fro the web service
            showNewsFeed(feedcount);
            label1.Hide();
        }

        public void showNewsFeed(int feedcount)
        {
            //textbox coordinates
            int startx = 153;
            int starty = 82;
            int width = 369;
            int height = 153;
            //button coordinates
            int btnstartx = 362;
            int btnwidth = 70;
            int btnheight = 27;
            
            for (int i = 1; i <= feedcount; i++)
            {
                //create a textbox
                TextBox txtNumber = new TextBox();
                txtNumber.Name = "txtNumber_"+i;
                txtNumber.Text = i + "";

                //set properties of the textbox
                txtNumber.Multiline = true;
                txtNumber.ReadOnly = true;
                txtNumber.WordWrap = true;
                txtNumber.DoubleClick += txtNumber_click;
                txtNumber.ScrollBars = ScrollBars.Vertical;
                
                //set the location of the textbox
                txtNumber.Location = new Point(startx, starty);

                //set the size of the textbox               
                txtNumber.Size = new Size(width, height);

                // This adds a new TextBox
                this.Controls.Add(txtNumber);
                // add the textbox to the list
                controllist.Add(txtNumber);
                //adjust the height for the buttons
                starty += 5 + height;

                //create labels for upvote and downvote
                Button upvote = new Button();
                Button downvote = new Button();
                upvote.Name = "btnup" + 20 + i;
                upvote.Text = "Upvote";
                downvote.Name = "btndown" + 20 + i;
                downvote.Text = "Downvote";

                //set location and size for buttons
                upvote.Location = new Point(btnstartx, starty);
                upvote.Size = new Size(btnwidth, btnheight);
                downvote.Location = new Point(btnstartx + btnwidth + 10, starty);
                downvote.Size = new Size(btnwidth, btnheight);
                this.Controls.Add(upvote);
                this.Controls.Add(downvote);
                controllist.Add(upvote);
                controllist.Add(downvote);

                starty += btnheight + 10;
                //TextBox commentNumber = new TextBox();
                //commentNumber.Name = "txtNumber" + 20 + i;
                //commentNumber.Text = "Enter a comment here";
                // Create Variables to Define "X" and "Y" Locations
                //var txtLocX = txtNumber.Location.X;
                //var txtLocY = txtNumber.Location.Y;

                //Set your TextBox Location Here
                //txtLocX = 153;
                //txtLocY = 82;
                //commentNumber.Location = new Point(startx, starty);


                //set the size of the textbox
                //commentNumber.Multiline = true;
                //commentNumber.ReadOnly = true;
                //commentNumber.WordWrap = true;
                //commentNumber.ScrollBars = ScrollBars.Vertical;
                //commentNumber.Size = new Size(width, height);

                // This adds a new TextBox
                //this.Controls.Add(commentNumber);

                //starty += 30;



            }
            label2.Location = new Point(startx, starty + 15);
            label2.Show();
        }

        private void txtNumber_click(object sender, EventArgs e)
        {
            string name  = (sender as TextBox).Name;
            int index = name.IndexOf("_");
            int id = int.Parse((name.Substring(index + 1)));

        }

        private void label2_Click(object sender, EventArgs e)
        {



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                    }

        private void userlabel_Click(object sender, EventArgs e)
        {

        }

        private void post_Click(object sender, EventArgs e)
        {
            // need to implement code to post a story to the app here
            // hide all elements and show only a textbox (+ image, if possible)
            // add a button to post the new story

            //hide the post news button
            post.Hide();

            for (int i = 0; i < controllist.Count; i++)
            {
                controllist[i].Hide();
            }
            //create a textbox
            TextBox txtNumber = new TextBox();
            txtNumber.Name = "txtNumber" + 10;
            txtNumber.Text = "Post your news here";

            //set properties of the textbox
            txtNumber.Multiline = true;
            txtNumber.WordWrap = true;
            txtNumber.MaxLength = maxlength;
            txtNumber.ScrollBars = ScrollBars.Vertical;

            //set the location of the textbox
            txtNumber.Location = new Point(153, 82);

            //set the size of the textbox               
            txtNumber.Size = new Size(369, 153);

            // This adds a new TextBox
            this.Controls.Add(txtNumber);
            postlist.Add(txtNumber);

            //add post and back button
            Button postnews = new Button();
            Button back = new Button();
            postnews.Name = "btnpost" + 20;
            postnews.Text = "Post";
            back.Name = "btnback" + 20;
            back.Text = "Back";
            postnews.Location = new Point(362, 245);
            postnews.Size = new Size(70, 27);
            back.Location = new Point(442, 245);
            back.Size = new Size(70, 27);
            this.Controls.Add(postnews);
            this.Controls.Add(back);
            postlist.Add(postnews);
            postlist.Add(back);
            back.Click += Back_Click;
        }

        private void Back_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < postlist.Count; i++)
            {
                postlist[i].Hide();
            }
            post.Show();
            for (int i = 0; i < controllist.Count; i++)
            {
                controllist[i].Show();
            }
        }
    }
}
