using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flag
{
    public partial class Form2 : Form
    {
        static OpenFileDialog dialog = new OpenFileDialog();
        public static int val = 18;
        static string fn = "";
        public static Image prev;
        string[] countryname =new string[254]{"afghanistan","aland_islands","albania","algeria","american_samoa","andorra","angola","anguilla","antarctica","antigua_and_barbuda","argentina",
"armenia","aruba","australia","austria","azerbaijan","bahamas","bahrain","bangladesh","barbados","belarus","belgium","belize",
"benin","bermuda","bhutan","bolivia","bonaire","bosnia_and_herzegovina","botswana","bouvet_island","brazil","british_indian_ocean_territory","brunei","bulgaria",
"burkina_faso","burundi","cambodia","cameroon","canada","cape_verde","cayman_islands","central_african_republic","chad","chile","china","christmas_island",
"cocos_islands","colombia","comoros","cook_islands","costa_rica","cote_d_Ivoire","croatia","cuba","curacao","cyprus","czech_republic","democratic_republic_of_the_congo",
"denmark","djibouti","dominica","dominican_republic","east_timor","ecuador","egypt","el_salvador","england","equatorial_guinea","eritrea","estonia",
"ethiopia","european_union","falkland_islands","faroe_islands","fiji","finland","france","french_guiana","french_polynesia","french_southern_territories","gabon","gambia",
"georgia","germany","ghana","gibraltar","greece","greenland","grenada","guadeloupe","guam","guatemala","guernsey","guinea",
"guinea_bissau","guyana","haiti","heard_island_and_mcdonald_islands","honduras","hong_kong","hungary","iceland","india","indonesia","iran","iraq",
"ireland","isle_of_man","israel","italy","jamaica","japan","jersey","jordan","kazakhstan","kenya","kiribati","korea_north",
"korea_south","kosovo","kuwait","kyrgyzstan","laos","latvia","lebanon","lesotho","liberia","libya","liechtenstein","lithuania",
"luxembourg","macao","macedonia","madagascar","malawi","malaysia","maldives","mali","malta","marshall_islands","martinique","mauritania",
"mauritius","mayotte","mexico","micronesia","moldova","monaco","mongolia","montenegro","montserrat","morocco","mozambique","myanmar",
"namibia","nauru","nepal","netherlands","new_caledonia","new_zealand","nicaragua","niger","nigeria","niue","norfolk_island","northern_mariana_islands",
"norway","oman","pakistan","palau","palestinian_territory","panama","papua_new_guinea","paraguay","peru","philippines","pitcairn_islands","poland",
"portugal","puerto_rico","qatar","republic_of_china","republic_of_the_congo","reunion","romania","russia","rwanda","saint_barthelemy","saint_helena","saint_kitts_and_nevis",
"saint_lucia","saint_martin","saint_pierre_and_miquelon","saint_vincent_and_the_grenadines","samoa","san_marino","sao_tome_and_principe","saudi_arabia","scotland","senegal","serbia","seychelles",
"sierra_leone","singapore","sint_maarten","slovakia","slovenia","solomon_islands","somalia","south_africa","south_georgia_and_the_south_sandwich_islands","south_sudan","spain","sri_lanka",
"sudan","suriname","svalbard_and_jan_mayen","swaziland","sweden","switzerland","syria","tajikistan","tanzania","thailand","togo","tokelau",
"tonga","trinidad_and_tobago","tunisia","turkey","turkmenistan","turks_and_caicos_islands","tuvalu","uganda","ukraine","united_arab_emirates","united_kingdom","united_states_of_america",
"uruguay","ussr","uzbekistan","vanuatu","vatican_city","venezuela","vietnam","virgin_islands_british","virgin_islands_us","wales","wallis_and_futuna","western_sahara",
"yemen","zambia","zimbabwe"};
     
        
        public Form2()
        {
            InitializeComponent();
        }
        public static string[] imgname = new string[300];
        private void Form2_Load(object sender, EventArgs e)
        {
            string path=Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DirectoryInfo dir = new DirectoryInfo(path+"\\flags");
            //label1.Text = path;
            string[] str = new string[300];
            int x = 0;
            char[] ar=new char[100];
            foreach (FileInfo file in dir.GetFiles())
            {
                try
                {
                    //  file.MoveTo()
                    this.imageList1.Images.Add(Image.FromFile(file.FullName));
                    imgname[x] = file.FullName;
                    string s = file.Name;
                    x++;
                    //   if (s == "afeqwrwqrfghanistan.gif")
                    {

                        int i = 0;
                        for ( i = 0; i < s.Length; i++)
                        {
                           // if (s[i] == '.') break;
                            ar[i] = s[i];
                        }
                        ar[i] ='\0';
                        s = "";
                        ar[0] = char.ToUpper(ar[0]);
                        for (i = 0; i < ar.Length; i++)
                        {
                            s += ar[i];
                        }
                         //   MessageBox.Show(s);

                //        file.CopyTo(path +"\\"+ s);
               
                        //   file.MoveTo(path + "\\" + "asd");
                    }
                  //  if (x < 1)
                    {
                      // MessageBox.Show(file.Name);   
               
                //   Image images = Image.FromFile(imgname[x]);
                     //  images = ScaleImage(images, 100, 100);
                       //images.Save(Application.StartupPath + "\\" + file.FullName);
                       //Thread.Sleep(5);
                    }

                    //    Image image = ScaleImage(Image.FromFile(imgname[x]), 100, 100);
                

                }
                catch
                {
                    Console.WriteLine("This is not an image file");
                }
            }
            this.listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(25, 25);
            this.listView1.LargeImageList = this.imageList1;
            //or
            //this.listView1.View = View.SmallIcon;
            //this.listView1.SmallImageList = this.imageList1;

            for (int j = 0; j < this.imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                if(j==18)
                item.Selected = true;
                this.listView1.Items.Add(item);
           
                // countryname[j]=countryname[j].ToUpper();
                string s=char.ToUpper(countryname[j][0]) + countryname[j].Substring(1);
                s=s.Replace('_', ' ');
                item.Text = s;
               
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            val = listView1.SelectedIndices[0];
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DirectoryInfo dir = new DirectoryInfo(path + "\\all_flags");
            path = path + "\\all_flags";
            Image backImg= Image.FromFile(path+"\\"+"bangladesh.gif");
            try {
                backImg = Image.FromFile(textBox1.Text.ToString());
            }
            catch
            {
                if(textBox1.Text=="")
                {
                MessageBox.Show("You have not selected any profile picture");
                   // Application.Restart();
                }
                else
                {
                    MessageBox.Show("Profile Picture Format Error");
                  //  Application.Restart();
                }
              //  Application.Restart();
            }
            Image ghostImg = Image.FromFile(imgname[val]);
            //using 
            int x = backImg.Width;
            int y = backImg.Height;
            backImg = ScaleImage(backImg, x, y);
            ghostImg = ScaleImage(ghostImg, x, y);

          //  using (var image = Image.FromFile(dialog.FileName.ToString()))
           // using (var newImage = ScaleImage(image, w, h))
           
                string temp = dialog.FileName.ToString();
                string newtemp = "";
                string ghostname = "";
                for (int j = temp.Length - 1; j >= 0; j--)
                {
                    if (temp[j] == '\\') break;
                    newtemp += temp[j];
                }
                char[] array = newtemp.ToCharArray();
                Array.Reverse(array);
                fn = new string(array);
           temp = imgname[val];
            newtemp = "";
            ghostname = "";
            for (int j = temp.Length - 1; j >= 0; j--)
            {
                if (temp[j] == '\\') break;
                newtemp += temp[j];
            }
            char[] arrays = newtemp.ToCharArray();
            Array.Reverse(arrays);
            ghostname = new string(arrays);
            // ghostImg.MakeTransparent();
            Graphics g = Graphics.FromImage(backImg);
            Bitmap transparentGhost = new Bitmap(ghostImg.Width, ghostImg.Height);
            Graphics transGraphics = Graphics.FromImage(transparentGhost);
            ColorMatrix tranMatrix = new ColorMatrix();
            float f = trackBar1.Value;
            f = f / 100;
            tranMatrix.Matrix33 = f; //this is the transparency value, tweak this to fine tuned results.
            ImageAttributes transparentAtt = new ImageAttributes();
            transparentAtt.SetColorMatrix(tranMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            transGraphics.DrawImage(ghostImg, new Rectangle(0, 0, transparentGhost.Width, transparentGhost.Height), 0, 0, transparentGhost.Width, transparentGhost.Height, GraphicsUnit.Pixel, transparentAtt);
            transGraphics.Dispose();
            g.DrawImage(transparentGhost, 0, 0);
          
            string s="";
            for(int i=0;i<ghostname.Length;i++)
            {
                if (ghostname[i] == '.') break;
                s+= ghostname[i];
            }

            {
             backImg.Save(Application.StartupPath + "\\" + s+ "_" + fn);
            //    ghostImg = ScaleImage(ghostImg, 300, 250);
              //  ghostImg.Save(Application.StartupPath + "\\"+ghostname);
          MessageBox.Show("Photo Converted Successfully");
            }
            /*
            Graphics transGraphics = Graphics.FromImage(transparentGhost);
            ColorMatrix tranMatrix = new ColorMatrix();
            tranMatrix.Matrix33 = 0.25F; ghostImg, new Rectangle(0, 0, transparentGhost.Width, transparentGhost.Height), 0, 0, transparentGhost.Width, transparentGhost.Height, GraphicsUnit.Pixel, transparentAttthis is the transparency value, tweak this to fine tuned results.

            ImageAttributes transparentAtt = new ImageAttributes();
            transparentAtt.SetColorMatrix(tranMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            transGraphics.DrawImage(ghostImg, new Rectangle(0, 0, transparentGhost.Width, transparentGhost.Height), 0, 0, transparentGhost.Width, transparentGhost.Height, GraphicsUnit.Pixel, transparentAtt);
            transGraphics.Dispose();
          
            smallBmp.MakeTransparent();
            int margin = 5;
            int x = largeBmp.Width - smallBmp.Width - margin;
            int y = largeBmp.Height - smallBmp.Height - margin;
            g.DrawImage(smallBmp, new Point(x, y));
            pictureBox1.Image = largeBmp;
              */
            //pnl_draw.Invalidate();
            // pictureBox1.Image = backImg;
            //  return backImg;

        }
        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(maxWidth, maxHeight);//new

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, maxWidth, maxHeight);//new

            return newImage;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dialog.Filter = "All files (*.*)|*.*|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            dialog.InitialDirectory = @"C:\Pictures\";
            dialog.Title = "Please select an image file to encrypt.";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //    Test();
                textBox1.Text = dialog.FileName;
                //Encrypt the selected file. I'll do this later. :)
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            val = listView1.SelectedIndices[0];
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DirectoryInfo dir = new DirectoryInfo(path + "\\all_flags");
            path = path + "\\all_flags";
            Image backImg = Image.FromFile(path + "\\" + "bangladesh.gif");
            try
            {
                backImg = Image.FromFile(textBox1.Text.ToString());
            }
            catch
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("You have not selected any profile picture");
                    // Application.Restart();
                }
                else
                {
                    MessageBox.Show("Profile Picture Format Error");
                    //  Application.Restart();
                }
                //  Application.Restart();
            }
            Image ghostImg = Image.FromFile(imgname[val]);
            //using 
            int x = backImg.Width;
            int y = backImg.Height;
            backImg = ScaleImage(backImg, x, y);
            ghostImg = ScaleImage(ghostImg, x, y);

            //  using (var image = Image.FromFile(dialog.FileName.ToString()))
            // using (var newImage = ScaleImage(image, w, h))

            string temp = dialog.FileName.ToString();
            string newtemp = "";
            string ghostname = "";
            for (int j = temp.Length - 1; j >= 0; j--)
            {
                if (temp[j] == '\\') break;
                newtemp += temp[j];
            }
            char[] array = newtemp.ToCharArray();
            Array.Reverse(array);
            fn = new string(array);
            temp = imgname[val];
            newtemp = "";
            ghostname = "";
            for (int j = temp.Length - 1; j >= 0; j--)
            {
                if (temp[j] == '\\') break;
                newtemp += temp[j];
            }
            char[] arrays = newtemp.ToCharArray();
            Array.Reverse(arrays);
            ghostname = new string(arrays);
            // ghostImg.MakeTransparent();
            Graphics g = Graphics.FromImage(backImg);
            Bitmap transparentGhost = new Bitmap(ghostImg.Width, ghostImg.Height);
            Graphics transGraphics = Graphics.FromImage(transparentGhost);
            ColorMatrix tranMatrix = new ColorMatrix();
            float f = trackBar1.Value;
            f = f / 100;
            tranMatrix.Matrix33 = f; //this is the transparency value, tweak this to fine tuned results.
            ImageAttributes transparentAtt = new ImageAttributes();
            transparentAtt.SetColorMatrix(tranMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            transGraphics.DrawImage(ghostImg, new Rectangle(0, 0, transparentGhost.Width, transparentGhost.Height), 0, 0, transparentGhost.Width, transparentGhost.Height, GraphicsUnit.Pixel, transparentAtt);
            transGraphics.Dispose();
            g.DrawImage(transparentGhost, 0, 0);

            string s = "";
            for (int i = 0; i < ghostname.Length; i++)
            {
                if (ghostname[i] == '.') break;
                s += ghostname[i];
            }
            prev =ScaleImage(backImg, 400, 250);
            Preview ob = new Preview();
            ob.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            for (int j = 0; j < this.imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
               
                if (j == 18)
                    item.Selected = true;
                this.listView1.Items.Add(item);

                // countryname[j]=countryname[j].ToUpper();
                string s = char.ToUpper(countryname[j][0]) + countryname[j].Substring(1);
                s = s.Replace('_', ' ');
                item.Text = s;
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            /*
            val = listView1.SelectedIndices[0];
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DirectoryInfo dir = new DirectoryInfo(path + "\\all_flags");
            path = path + "\\all_flags";
            Image backImg = Image.FromFile(path + "\\" + "bangladesh.gif");
            try
            {
                backImg = Image.FromFile(textBox1.Text.ToString());
            }
            catch
            {
                if (textBox1.Text == "")
                {
                    //      MessageBox.Show("You have not selected any profile picture");
                    // Application.Restart();
                }
                else
                {
                    MessageBox.Show("Profile Picture Format Error");
                    //  Application.Restart();
                }
                //  Application.Restart();
            }
            Image ghostImg = Image.FromFile(imgname[val]);
            //using 
            int x = backImg.Width;
            int y = backImg.Height;
            backImg = ScaleImage(backImg, x, y);
            ghostImg = ScaleImage(ghostImg, x, y);

            //  using (var image = Image.FromFile(dialog.FileName.ToString()))
            // using (var newImage = ScaleImage(image, w, h))

            string temp = dialog.FileName.ToString();
            string newtemp = "";
            string ghostname = "";
            for (int j = temp.Length - 1; j >= 0; j--)
            {
                if (temp[j] == '\\') break;
                newtemp += temp[j];
            }
            char[] array = newtemp.ToCharArray();
            Array.Reverse(array);
            fn = new string(array);
            temp = imgname[val];
            newtemp = "";
            ghostname = "";
            for (int j = temp.Length - 1; j >= 0; j--)
            {
                if (temp[j] == '\\') break;
                newtemp += temp[j];
            }
            char[] arrays = newtemp.ToCharArray();
            Array.Reverse(arrays);
            ghostname = new string(arrays);
            // ghostImg.MakeTransparent();
            Graphics g = Graphics.FromImage(backImg);
            Bitmap transparentGhost = new Bitmap(ghostImg.Width, ghostImg.Height);
            Graphics transGraphics = Graphics.FromImage(transparentGhost);
            ColorMatrix tranMatrix = new ColorMatrix();
            float f = trackBar1.Value;
            f = f / 100;
            tranMatrix.Matrix33 = f; //this is the transparency value, tweak this to fine tuned results.
            ImageAttributes transparentAtt = new ImageAttributes();
            transparentAtt.SetColorMatrix(tranMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            transGraphics.DrawImage(ghostImg, new Rectangle(0, 0, transparentGhost.Width, transparentGhost.Height), 0, 0, transparentGhost.Width, transparentGhost.Height, GraphicsUnit.Pixel, transparentAtt);
            transGraphics.Dispose();
            g.DrawImage(transparentGhost, 0, 0);

            string s = "";
            for (int i = 0; i < ghostname.Length; i++)
            {
                if (ghostname[i] == '.') break;
                s += ghostname[i];
            }

            {
                //  backImg.Save(Application.StartupPath + "\\" + s + "_" + fn);
                ghostImg = ScaleImage(ghostImg, 300, 250);
                ghostImg.Save(Application.StartupPath + "\\" + ghostname);
                //MessageBox.Show("Photo Converted Successfully");
            }
            */
        }
    }
}
