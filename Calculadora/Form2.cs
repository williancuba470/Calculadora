using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.TeamFoundation.Common;


namespace Calculadora
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label9.Text = Environment.UserName;
            label10.Text = '\u00AE'.ToString();
            string version = Environment.OSVersion.Version.Major.ToString() + "." + Environment.OSVersion.Version.Minor.ToString();
            string compilacion = Environment.OSVersion.Version.Build.ToString();
            string servicepack = Environment.OSVersion.ServicePack.ToString();            
            if (Environment.OSVersion.Platform.ToString().Equals("Win32NT"))
            {
                label2.Text = "Versión " + version + " (compilación " + compilacion;
                label2.Text = (servicepack.Length != 0) ? label2.Text + ": " + servicepack + ")" : label2.Text + ")";
                label1.Text = "Microsoft Windows";                 
                string versionwindow = OSDetails.Version.ToString(), edicion = OSDetails.Edition.ToString();
                label14.Text = (OSDetails.IsHomeEdition) ? "Home" : edicion;                
                if (OSDetails.IsServer)
                {                     
                    if(versionwindow.Equals("Server2003"))
                    {
                        label11.Text = "Windows Server";
                        label12.Text = "2003";
                        label3.Text = "Copyright © 2003 Microsoft Corporation." + label3.Text;
                        label11.Font = new Font(label11.Font.FontFamily, label11.Font.Size - 7);
                        label12.Font = new Font(label12.Font.FontFamily, label11.Font.Size);
                        label14.Font = new Font(label14.Font.FontFamily, label11.Font.Size);
                        pictureBox1.Left = panel1.Left;
                        label11.Left = pictureBox1.Left + pictureBox1.Size.Width;
                        label10.Left = label11.Left + label11.Size.Width - 7;
                        label12.Left = label10.Left + label10.Size.Width - 4;
                        label14.Left = label12.Left + label12.Size.Width - 5;
                        label11.Top += 8;
                        label12.Top = label11.Top;
                        label14.Top = label11.Top;
                        label4.Text = "El sistema operativo " + label11.Text + " " + label12.Text + " " + label14.Text + " y la interfaz de usuario";
                        label5.Text = " están protegidos por las leyes de marca comercial y otros derechos de";
                        label6.Text = "propiedad intelectual actuales y pendientes en los Estados Unidos y";
                        label13.Text = "otros países.";
                    }
                    else if(versionwindow.Equals("Server2008"))
                    {
                        label11.Text = "Windows Server";
                        label12.Text = "2008";
                        label3.Text = "Copyright © 2008 Microsoft Corporation." + label3.Text;
                        label11.Font = new Font(label11.Font.FontFamily, label11.Font.Size - 7);
                        label12.Font = new Font(label12.Font.FontFamily, label11.Font.Size);
                        label14.Font = new Font(label14.Font.FontFamily, label11.Font.Size);
                        pictureBox1.Left = panel1.Left;
                        label11.Left = pictureBox1.Left + pictureBox1.Size.Width;
                        label10.Left = label11.Left + label11.Size.Width - 7;
                        label12.Left = label10.Left + label10.Size.Width - 4;
                        label14.Left = label12.Left + label12.Size.Width - 5;
                        label11.Top += 8;
                        label12.Top = label11.Top;
                        label14.Top = label11.Top;
                        label4.Text = "El sistema operativo " + label11.Text + " " + label12.Text + " " + label14.Text + " y la interfaz de usuario";
                        label5.Text = " están protegidos por las leyes de marca comercial y otros derechos de";
                        label6.Text = "propiedad intelectual actuales y pendientes en los Estados Unidos y";
                        label13.Text = "otros países.";
                    }
                    else if (versionwindow.Equals("Server2008R2"))
                    {
                        label11.Text = "Windows Server";
                        label12.Text = "2008 R2";
                        label3.Text = "Copyright © 2008 Microsoft Corporation." + label3.Text;
                        label11.Font = new Font(label11.Font.FontFamily, label11.Font.Size - 10);
                        label12.Font = new Font(label12.Font.FontFamily, label11.Font.Size);
                        label14.Font = new Font(label14.Font.FontFamily, label11.Font.Size);
                        pictureBox1.Left = panel1.Left;
                        label11.Left = pictureBox1.Left + pictureBox1.Size.Width;
                        label10.Left = label11.Left + label11.Size.Width - 7;
                        label12.Left = label10.Left + label10.Size.Width - 4;
                        label14.Left = label12.Left + label12.Size.Width - 5;
                        label11.Top += 8;
                        label12.Top = label11.Top;
                        label14.Top = label11.Top;
                        label4.Text = "El sistema operativo " + label11.Text + " " + label12.Text + " " + label14.Text + " y la interfaz de";
                        label5.Text = " usuario están protegidos por las leyes de marca comercial y otros derechos";
                        label6.Text = "de propiedad intelectual actuales y pendientes en los Estados Unidos y";
                        label13.Text = "otros países.";
                    }
                    else
                    {
                        label11.Text = versionwindow;
                        label10.Left = label11.Left + label11.Size.Width - 4;
                        label3.Text = "Copyright © Microsoft Corporation." + label3.Text;
                        label4.Text = "El sistema operativo " + label11.Text + " " + label12.Text + " " + label14.Text + label4.Text;
                    }
                }
                else if (OSDetails.IsClient) 
                {
                    if (versionwindow.Equals("Vista"))
                    {
                        label11.Text = "Windows " + versionwindow;
                        label3.Text = "Copyright © 2007 Microsoft Corporation." + label3.Text;
                        label11.Font = new Font(label11.Font.FontFamily, label11.Font.Size - 2);
                        label12.Font = new Font(label12.Font.FontFamily, label11.Font.Size);
                        label14.Font = new Font(label14.Font.FontFamily, label11.Font.Size);
                        pictureBox1.Left = panel1.Left;
                        label11.Left = pictureBox1.Left + pictureBox1.Size.Width;
                        label10.Left = label11.Left + label11.Size.Width - 7;
                        label12.Left = label10.Left + label10.Size.Width - 4;
                        label14.Left = label12.Left + label12.Size.Width - 3;
                        label11.Top = pictureBox1.Top + 7;
                        label12.Top = label11.Top;
                        label14.Top = label11.Top;
                        label4.Text = "El sistema operativo " + label11.Text + " " + label12.Text + " " + label14.Text + " y la interfaz de usuario";
                        label5.Text = " están protegidos por las leyes de marca comercial y otros derechos de";
                        label6.Text = "propiedad intelectual actuales y pendientes en los Estados Unidos y otros";
                        label13.Text = "países.";
                    }
                    else if (versionwindow.Equals("XP")) 
                    {
                        label11.Text = "Windows " + versionwindow;
                        label3.Text = "Copyright © 2001 Microsoft Corporation." + label3.Text;
                        label11.Font = new Font(label11.Font.FontFamily, label11.Font.Size - 1);
                        label12.Font = new Font(label12.Font.FontFamily, label11.Font.Size);
                        label14.Font = new Font(label14.Font.FontFamily, label11.Font.Size);
                        pictureBox1.Left = panel1.Left;
                        label11.Left = pictureBox1.Left + pictureBox1.Size.Width;
                        label10.Left = label11.Left + label11.Size.Width - 5;
                        label14.Left = label10.Left + label10.Size.Width - 4;
                        label11.Top = pictureBox1.Top + 7;
                        label12.Top = label11.Top;
                        label14.Top = label11.Top;
                        label4.Text = "El sistema operativo " + label11.Text + " " + label12.Text + " " + label14.Text + " y la interfaz de usuario están";
                        label5.Text = " protegidos por las leyes de marca comercial y otros derechos de propiedad";
                        label6.Text = "intelectual actuales y pendientes en los Estados Unidos y otros países.";
                        label13.Text = "";
                    }
                    else if (versionwindow.Equals("Windows8Client"))
                    {
                        if (version.Equals("6.3") && compilacion.Equals("9600"))
                        {
                            label11.Text = "Windows";
                            label12.Text = "8.1";
                            label3.Text = "Copyright © 2012 Microsoft Corporation." + label3.Text;
                            pictureBox1.Left = panel1.Left + 15;
                            label11.Left = pictureBox1.Left + pictureBox1.Size.Width;
                            label10.Left = label11.Left + label11.Size.Width - 12;
                            label12.Left = label10.Left + label10.Size.Width - 4;
                            label14.Left = label12.Left + label12.Size.Width - 10;
                            label4.Text = "El sistema operativo " + label11.Text + " " + label12.Text + " " + label14.Text + label4.Text;
                        }
                        else if (version.Equals("6.2") && compilacion.Equals("9200"))
                        {
                            label11.Text = "Windows";
                            label12.Text = "8";
                            label3.Text = "Copyright © 2012 Microsoft Corporation." + label3.Text;
                            pictureBox1.Left = panel1.Left + 15;
                            label11.Left = pictureBox1.Left + pictureBox1.Size.Width;
                            label10.Left = label11.Left + label11.Size.Width - 12;
                            label12.Left = label10.Left + label10.Size.Width - 4;
                            label14.Left = label12.Left + label12.Size.Width - 8;
                            label4.Text = "El sistema operativo " + label11.Text + " " + label12.Text + " " + label14.Text + label4.Text;
                        }
                    }
                    else if (versionwindow.Equals("Windows7"))
                    {
                        label11.Text = "Windows";
                        label12.Text = "7";
                        label3.Text = "Copyright © 2009 Microsoft Corporation." + label3.Text;
                        pictureBox1.Left = panel1.Left + 15;
                        label11.Left = pictureBox1.Left + pictureBox1.Size.Width;
                        label10.Left = label11.Left + label11.Size.Width - 12;
                        label12.Left = label10.Left + label10.Size.Width - 4;
                        label14.Left = label12.Left + label12.Size.Width - 8;
                        label4.Text = "El sistema operativo " + label11.Text + " " + label12.Text + " " + label14.Text + label4.Text;
                    }
                    else if (version.Equals("10.0"))
                    {
                        label11.Text = "Windows";
                        label12.Text = "10";
                        label3.Text = "Copyright © 2015 Microsoft Corporation." + label3.Text;
                        pictureBox1.Left = panel1.Left + 15;
                        label11.Left = pictureBox1.Left + pictureBox1.Size.Width;
                        label10.Left = label11.Left + label11.Size.Width - 12;
                        label12.Left = label10.Left + label10.Size.Width - 4;
                        label14.Left = label12.Left + label12.Size.Width - 8;
                        label4.Text = "El sistema operativo " + label11.Text + " " + label12.Text + " " + label14.Text + label4.Text;
                    }
                    else
                    {
                        label11.Text = versionwindow;
                        label3.Text = "Copyright © Microsoft Corporation." + label3.Text;
                        pictureBox1.Left = panel1.Left + 15;
                        label11.Left = pictureBox1.Left + pictureBox1.Size.Width;
                        label10.Left = label11.Left + label11.Size.Width - 12;
                        label12.Left = label10.Left + label10.Size.Width - 4;
                        label14.Left = label12.Left + label12.Size.Width - 8;
                        label4.Text = "El sistema operativo " + label11.Text + " " + label12.Text + " " + label14.Text + label4.Text;
                    }
                }
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
