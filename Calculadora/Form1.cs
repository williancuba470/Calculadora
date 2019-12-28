using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace Calculadora
{
    
    

    public partial class Form1 : Form
    {
        System.Media.SoundPlayer Ding = new System.Media.SoundPlayer("../../Resources/Ding.wav");
        bool v, SePuede = true, mr1 = false, mr2 = false, mr3 = false, Handled = false, raiz = false;
        int pos;
        string op;
        decimal aa = 0, bb = 0;
        decimal M = 0;
        decimal? M2 = null;
        Control controlFocus, controlFocusOld;
        string[] arreglo1 = {"Escribir valor","Escribir valor","Escribir valor","Escribir valor",""};
        string[] arreglo2 = {"Escribir valor","Escribir valor","Escribir valor","Escribir valor","Escribir valor",""};
        string[] arreglo3 = {"Escribir valor","Escribir valor",""};
        string[] arreglo4 = {"Escribir valor","Escribir valor",""};
        
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        public Form1()
        {
            InitializeComponent();
            textBox22.GotFocus += TextBox22_GotFocus;
            textBox23.GotFocus += TextBox23_GotFocus;
        }

        private void TextBox22_GotFocus(object sender, EventArgs e)
        {
           HideCaret(textBox22.Handle);
        }

        private void TextBox23_GotFocus(object sender, EventArgs e)
        {
            HideCaret(textBox23.Handle);
        }

        private void hacercaDeCalculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)//ya
        {
            this.comboBox1.Text = this.comboBox1.Items[0].ToString();
            this.comboBox2.Text = this.comboBox2.Items[0].ToString();
            this.comboBox3.Text = this.comboBox3.Items[0].ToString();
            this.comboBox4.Text = this.comboBox4.Items[0].ToString();
            this.comboBox5.Text = this.comboBox5.Items[0].ToString();
            this.comboBox6.Text = this.comboBox6.Items[0].ToString();
            this.comboBox7.Text = this.comboBox7.Items[0].ToString();
            this.comboBox8.Text = this.comboBox8.Items[0].ToString();
            this.dateTimePicker1.Value = System.DateTime.Now;
            this.dateTimePicker2.Value = System.DateTime.Now;
            controlFocus = textBox22;
            controlFocusOld = radioButton5;            
        }

        private void OnHistorialPanel2()//ya
        {
            if (this.estándarToolStripMenuItem.Checked || this.estadísticasToolStripMenuItem.Checked)
            {
                this.panel2.Width = 190;
                this.panel3.Width = 179;
                this.panel4.Width = 179;
                this.button1.Location = new Point(169, 4);
                this.button2.Location = new Point(149, 4);
                if (this.estándarToolStripMenuItem.Checked)
                {
                    this.label1.Visible = false;
                    this.listBox1.Visible = true;
                    this.listBox2.Visible = false;
                    this.listBox3.Visible = false;
                }
                else if (this.estadísticasToolStripMenuItem.Checked)
                {
                    this.label1.Visible = true;
                    this.listBox1.Visible = false;
                    this.listBox2.Visible = false;
                    this.listBox3.Visible = true;
                }

            }
            else if (this.científicaToolStripMenuItem.Checked)
            {
                this.panel2.Width = 383;
                this.panel3.Width = 370;
                this.panel4.Width = 370;
                this.button1.Location = new Point(358, 4);
                this.button2.Location = new Point(338, 4);
                this.label1.Visible = false;
                this.listBox1.Visible = false;
                this.listBox2.Visible = true;
                this.listBox3.Visible = false;
            }
            this.panel2.Height = 150;
            this.button1.Visible = true;
            this.button2.Visible = true;
            this.panel3.Visible = true;
            this.panel4.Visible = true;
        }

        private void OffHistorialPanel2()//ya
        {
            if (this.estándarToolStripMenuItem.Checked)
            {
                this.panel2.Width = 190;
            }
            else if (this.científicaToolStripMenuItem.Checked || this.programadorToolStripMenuItem.Checked)
            {
                this.panel2.Width = 383;
            }
            this.panel2.Height = 50;
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.panel3.Visible = false;
            this.panel4.Visible = false;
            this.listBox1.Visible = false;
            this.listBox2.Visible = false;
            this.listBox3.Visible = false;
            this.label1.Visible = false;
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)//ya
        {
            this.historialToolStripMenuItem.Checked = !this.historialToolStripMenuItem.Checked;
            this.ModificarTamannoForm1();
            this.panel2.Focus();
            this.textBox22.Focus();
            //this.textBox22.Select(textBox22.TextLength, 0);
        }
        
        private void estándarToolStripMenuItem_Click(object sender, EventArgs e)//ya
        {
            if (!(this.estándarToolStripMenuItem.Checked))
            {
                this.estándarToolStripMenuItem.Checked = true;
                this.científicaToolStripMenuItem.Checked = false;
                this.programadorToolStripMenuItem.Checked = false;
                this.estadísticasToolStripMenuItem.Checked = false;
                if (!this.historialToolStripMenuItem.Enabled)
                    this.historialToolStripMenuItem.Enabled = true;
                this.ModificarTamannoForm1();
                this.Modificar7();
                this.panel12.Visible = false;
                this.button24.Enabled = true;                
                this.textBox22.Text = "0";
                this.textBox23.Text = "";
                this.textBox23.Visible = true;
                this.panel2.Focus();
                textBox22.Font = new Font(this.textBox22.Font.FontFamily, 16);
                this.textBox22.Focus();
                this.textBox22.Select(textBox22.TextLength, 0);
            }
        }

        private void científicaToolStripMenuItem_Click(object sender, EventArgs e)//ya
        {
            if (!(this.científicaToolStripMenuItem.Checked))
            {
                this.estándarToolStripMenuItem.Checked = false;
                this.científicaToolStripMenuItem.Checked = true;
                this.programadorToolStripMenuItem.Checked = false;
                this.estadísticasToolStripMenuItem.Checked = false;
                if (!this.historialToolStripMenuItem.Enabled)
                    this.historialToolStripMenuItem.Enabled = true;
                this.ModificarTamannoForm1();
                this.Modificar7();
                this.panel12.Visible = true;
                this.button24.Enabled = false;
                this.CambiarInv(true);
                this.textBox22.Text = "0";
                this.textBox23.Text = "";
                this.textBox23.Visible = true;
                this.panel2.Focus();
                textBox22.Font = new Font(this.textBox22.Font.FontFamily, 16);
                this.textBox22.Focus();
                this.textBox22.Select(textBox22.TextLength, 0);
            }
        }

        private void programadorToolStripMenuItem_Click(object sender, EventArgs e)//ya
        {
            if (!(this.programadorToolStripMenuItem.Checked))
            {
                this.estándarToolStripMenuItem.Checked = false;
                this.científicaToolStripMenuItem.Checked = false;
                this.programadorToolStripMenuItem.Checked = true;
                this.estadísticasToolStripMenuItem.Checked = false;
                this.historialToolStripMenuItem.Enabled = false;
                this.panel15.Visible = true;
                this.panel16.Visible = true;
                this.panel11.Visible = true;
                this.panel12.Visible = false;
                this.panel11.Location = new Point(206, 127);
                this.button24.Enabled = false;
                this.button9.Enabled = false;
                this.ChequearRadioButtons();
                this.button21.Location = new Point(116, 32);
                this.Modificar4(false);
                this.Modificar5(false);
                this.Modificar6(true);
                if (this.básicasToolStripMenuItem.Checked)
                    this.Width = 423;
                else
                {
                    this.Width = 800;
                    this.MoverPanel(new Point(410, 3));
                    this.ModificarTamannoPanel(312);
                }
                this.OffHistorialPanel2();
                this.Height = 390;
                this.textBox22.Text = "0";
                this.textBox23.Text = "";
                this.textBox23.Visible = false;
                this.panel2.Focus();
                textBox22.Font = new Font(this.textBox22.Font.FontFamily, 16);
                Modificar8("");
                this.textBox22.Focus();
                this.textBox22.Select(textBox22.TextLength, 0);
            }
        }

        private void estadísticasToolStripMenuItem_Click(object sender, EventArgs e)//ya
        {
            if (!(this.estadísticasToolStripMenuItem.Checked))
            {
                this.estándarToolStripMenuItem.Checked = false;
                this.científicaToolStripMenuItem.Checked = false;
                this.programadorToolStripMenuItem.Checked = false;
                this.estadísticasToolStripMenuItem.Checked = true;
                this.historialToolStripMenuItem.Enabled = false;
                this.panel15.Visible = false;
                this.panel16.Visible = false;
                this.panel12.Visible = false;
                this.panel11.Visible = true;
                this.button9.Enabled = true;
                this.panel11.Location = new Point(12, 158);
                this.button21.Location = new Point(116, 160);
                this.Modificar1(true);
                this.Modificar2(true);
                this.Modificar5(true);
                this.Modificar6(false);
                if (this.básicasToolStripMenuItem.Checked)
                    this.Width = 229;
                else
                {
                    this.Width = 606;
                    this.MoverPanel(new Point(216, 3));
                    this.ModificarTamannoPanel(343);
                }
                this.OnHistorialPanel2();
                this.Height = 421;
                this.textBox22.Text = "0";
                this.textBox23.Text = "";
                this.textBox23.Visible = false;
                this.panel2.Focus();
                textBox22.Font = new Font(this.textBox22.Font.FontFamily, 16);
                this.textBox22.Focus();
                this.textBox22.Select(textBox22.TextLength, 0);
            }
        }

        private void ModificarTamannoForm1()//ya
        {
            if (this.historialToolStripMenuItem.Checked)
            {
                if (this.estándarToolStripMenuItem.Checked)
                {
                    this.panel11.Location = new Point(12, 158);
                    if (this.básicasToolStripMenuItem.Checked)
                        this.Width = 229;
                    else
                    {
                        this.Width = 606;
                        this.MoverPanel(new Point(216, 3));
                        this.ModificarTamannoPanel(343);
                    }
                }
                else if (this.científicaToolStripMenuItem.Checked)
                {
                    this.panel11.Location = new Point(206, 158);
                    this.panel12.Location = new Point(12, 158);
                    if (this.básicasToolStripMenuItem.Checked)
                        this.Width = 423;
                    else
                    {
                        this.Width = 800;
                        this.MoverPanel(new Point(410, 3));
                        this.ModificarTamannoPanel(343);
                    }
                }
                this.OnHistorialPanel2();
                this.Height = 421;
            }
            else
            {
                if (this.estándarToolStripMenuItem.Checked)
                {
                    this.panel11.Location = new Point(12, 59);
                    if (this.básicasToolStripMenuItem.Checked)
                        this.Width = 229;
                    else
                    {
                        this.Width = 606;
                        this.MoverPanel(new Point(216, 3));
                        this.ModificarTamannoPanel(244);
                    }
                }
                else if (this.científicaToolStripMenuItem.Checked)
                {
                    this.panel11.Location = new Point(206, 59);
                    this.panel12.Location = new Point(12, 59);
                    if (this.básicasToolStripMenuItem.Checked)
                        this.Width = 423;
                    else
                    {
                        this.Width = 800;
                        this.MoverPanel(new Point(410, 3));
                        this.ModificarTamannoPanel(244);
                    }
                }
                this.OffHistorialPanel2();
                this.Height = 323;
            }
        }

        private void básicasToolStripMenuItem_Click(object sender, EventArgs e)//ya
        {
            if (!this.básicasToolStripMenuItem.Checked)
            {
                this.Width = this.Width - 377;
                this.básicasToolStripMenuItem.Checked = true;
                this.conversiónDeUnidadesToolStripMenuItem.Checked = false;
                this.cálculoDeFechaToolStripMenuItem.Checked = false;
                this.hipotecaToolStripMenuItem.Checked = false;
                this.alquilerDeVehículosToolStripMenuItem.Checked = false;
                this.consumoDeCombustibleToolStripMenuItem.Checked = false;
                this.consumoDeCombustibleI100KmToolStripMenuItem.Checked = false;
                this.PanelVisible(false);
                this.panel2.Focus();
                this.textBox22.Focus();
                //this.textBox22.Select(textBox22.TextLength, 0);
                if (programadorToolStripMenuItem.Checked && radioButton4.Checked)
                   Modificar3(true);                
            }
        }

        private void conversiónDeUnidadesToolStripMenuItem_Click(object sender, EventArgs e)//ya
        {
            if (!this.conversiónDeUnidadesToolStripMenuItem.Checked)
            {
                if (this.básicasToolStripMenuItem.Checked)
                {
                    this.Width = this.Width + 377;
                    this.Verificar();
                }
                this.básicasToolStripMenuItem.Checked = false;
                this.conversiónDeUnidadesToolStripMenuItem.Checked = true;
                this.cálculoDeFechaToolStripMenuItem.Checked = false;
                this.hipotecaToolStripMenuItem.Checked = false;
                this.alquilerDeVehículosToolStripMenuItem.Checked = false;
                this.consumoDeCombustibleToolStripMenuItem.Checked = false;
                this.consumoDeCombustibleI100KmToolStripMenuItem.Checked = false;
                this.panel10.Visible = true;
                this.panel5.Visible = false;
                this.panel6.Visible = false;
                this.panel7.Visible = false;
                this.panel8.Visible = false;
                this.panel9.Visible = false;
                this.comboBox1.Focus();
                if (programadorToolStripMenuItem.Checked && radioButton4.Checked)
                    Modificar3(false);
            }
        }

        private void cálculoDeFechaToolStripMenuItem_Click(object sender, EventArgs e)//ya
        {
            if (!this.cálculoDeFechaToolStripMenuItem.Checked)
            {
                if (this.básicasToolStripMenuItem.Checked)
                {
                    this.Width = this.Width + 377;
                    this.Verificar();
                }
                this.básicasToolStripMenuItem.Checked = false;
                this.conversiónDeUnidadesToolStripMenuItem.Checked = false;
                this.cálculoDeFechaToolStripMenuItem.Checked = true;
                this.hipotecaToolStripMenuItem.Checked = false;
                this.alquilerDeVehículosToolStripMenuItem.Checked = false;
                this.consumoDeCombustibleToolStripMenuItem.Checked = false;
                this.consumoDeCombustibleI100KmToolStripMenuItem.Checked = false;
                this.panel5.Visible = true;
                this.panel6.Visible = false;
                this.panel7.Visible = false;
                this.panel8.Visible = false;
                this.panel9.Visible = false;
                this.panel10.Visible = false;
                comboBox4.Focus();
                if (programadorToolStripMenuItem.Checked && radioButton4.Checked)
                    Modificar3(false);
            }
        }

        private void hipotecaToolStripMenuItem_Click(object sender, EventArgs e)//ya
        {
            if (!this.hipotecaToolStripMenuItem.Checked)
            {
                if (this.básicasToolStripMenuItem.Checked)
                {
                    this.Width = this.Width + 377;
                    this.Verificar();
                }
                this.básicasToolStripMenuItem.Checked = false;
                this.conversiónDeUnidadesToolStripMenuItem.Checked = false;
                this.cálculoDeFechaToolStripMenuItem.Checked = false;
                this.hipotecaToolStripMenuItem.Checked = true;
                this.alquilerDeVehículosToolStripMenuItem.Checked = false;
                this.consumoDeCombustibleToolStripMenuItem.Checked = false;
                this.consumoDeCombustibleI100KmToolStripMenuItem.Checked = false;
                this.panel6.Visible = true;
                this.panel5.Visible = false;
                this.panel7.Visible = false;
                this.panel8.Visible = false;
                this.panel9.Visible = false;
                this.panel10.Visible = false;
                comboBox5.Focus();
                if (programadorToolStripMenuItem.Checked && radioButton4.Checked)
                    Modificar3(false);
            }
        }

        private void alquilerDeVehículosToolStripMenuItem_Click(object sender, EventArgs e)//ya
        {
            if (!this.alquilerDeVehículosToolStripMenuItem.Checked)
            {
                if (this.básicasToolStripMenuItem.Checked)
                {
                    this.Width = this.Width + 377;
                    this.Verificar();
                }
                this.básicasToolStripMenuItem.Checked = false;
                this.conversiónDeUnidadesToolStripMenuItem.Checked = false;
                this.cálculoDeFechaToolStripMenuItem.Checked = false;
                this.hipotecaToolStripMenuItem.Checked = false;
                this.alquilerDeVehículosToolStripMenuItem.Checked = true;
                this.consumoDeCombustibleToolStripMenuItem.Checked = false;
                this.consumoDeCombustibleI100KmToolStripMenuItem.Checked = false;
                this.panel7.Visible = true;
                this.panel5.Visible = false;
                this.panel6.Visible = false;
                this.panel8.Visible = false;
                this.panel9.Visible = false;
                this.panel10.Visible = false;
                comboBox6.Focus();
                if (programadorToolStripMenuItem.Checked && radioButton4.Checked)
                    Modificar3(false);
            }
        }

        private void consumoDeCombustibleToolStripMenuItem_Click(object sender, EventArgs e)//ya
        {
            if (!this.consumoDeCombustibleToolStripMenuItem.Checked)
            {
                if (this.básicasToolStripMenuItem.Checked)
                {
                    this.Width = this.Width + 377;
                    this.Verificar();
                }
                this.básicasToolStripMenuItem.Checked = false;
                this.conversiónDeUnidadesToolStripMenuItem.Checked = false;
                this.cálculoDeFechaToolStripMenuItem.Checked = false;
                this.hipotecaToolStripMenuItem.Checked = false;
                this.alquilerDeVehículosToolStripMenuItem.Checked = false;
                this.consumoDeCombustibleToolStripMenuItem.Checked = true;
                this.consumoDeCombustibleI100KmToolStripMenuItem.Checked = false;
                this.panel8.Visible = true;
                this.panel5.Visible = false;
                this.panel6.Visible = false;
                this.panel7.Visible = false;
                this.panel9.Visible = false;
                this.panel10.Visible = false;
                comboBox7.Focus();
                if (programadorToolStripMenuItem.Checked && radioButton4.Checked)
                    Modificar3(false);
            }
        }

        private void consumoDeCombustibleI100KmToolStripMenuItem_Click(object sender, EventArgs e)//ya
        {
            if (!this.consumoDeCombustibleI100KmToolStripMenuItem.Checked)
            {
                if (this.básicasToolStripMenuItem.Checked)
                {
                    this.Width = this.Width + 377;
                    this.Verificar();
                }
                this.básicasToolStripMenuItem.Checked = false;
                this.conversiónDeUnidadesToolStripMenuItem.Checked = false;
                this.cálculoDeFechaToolStripMenuItem.Checked = false;
                this.hipotecaToolStripMenuItem.Checked = false;
                this.alquilerDeVehículosToolStripMenuItem.Checked = false;
                this.consumoDeCombustibleToolStripMenuItem.Checked = false;
                this.consumoDeCombustibleI100KmToolStripMenuItem.Checked = true;
                this.panel9.Visible = true;
                this.panel5.Visible = false;
                this.panel6.Visible = false;
                this.panel7.Visible = false;
                this.panel8.Visible = false;
                this.panel10.Visible = false;
                comboBox8.Focus();
                if (programadorToolStripMenuItem.Checked && radioButton4.Checked)
                    Modificar3(false);
            }
        }

        private void ModificarTamannoPanel(int Height)
        {
            this.panel5.Height = Height;
            this.panel6.Height = Height;
            this.panel7.Height = Height;
            this.panel8.Height = Height;
            this.panel9.Height = Height;
            this.panel10.Height = Height;
        }

        private void MoverPanel(Point Location)
        {
            this.panel5.Location = Location;
            this.panel6.Location = Location;
            this.panel7.Location = Location;
            this.panel8.Location = Location;
            this.panel9.Location = Location;
            this.panel10.Location = Location;
        }

        private void PanelVisible(bool valor)
        {
            this.panel5.Visible = valor;
            this.panel6.Visible = valor;
            this.panel7.Visible = valor;
            this.panel8.Visible = valor;
            this.panel9.Visible = valor;
            this.panel10.Visible = valor;
        }

        private void Verificar()
        {
            if (this.programadorToolStripMenuItem.Checked)
            {
                this.MoverPanel(new Point(410, 3));
                this.ModificarTamannoPanel(312);
            }
            else if (this.estadísticasToolStripMenuItem.Checked)
            {
                this.MoverPanel(new Point(216, 3));
                this.ModificarTamannoPanel(343);
            }
            else
            {
                if (this.historialToolStripMenuItem.Checked)
                {
                    if (this.estándarToolStripMenuItem.Checked)
                    {
                        this.MoverPanel(new Point(216, 3));
                        this.ModificarTamannoPanel(343);
                    }
                    else if (this.científicaToolStripMenuItem.Checked)
                    {
                        this.MoverPanel(new Point(410, 3));
                        this.ModificarTamannoPanel(343);
                    }
                }
                else
                {
                    if (this.estándarToolStripMenuItem.Checked)
                    {
                        this.MoverPanel(new Point(216, 3));
                        this.ModificarTamannoPanel(244);
                    }
                    else if (this.científicaToolStripMenuItem.Checked)
                    {
                        this.MoverPanel(new Point(410, 3));
                        this.ModificarTamannoPanel(244);
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //,
            bool valor = false;
            TextBox tb = textBox22;
            int SelectionStart = 0, SelectionLength = 0;
            if (controlFocus.GetType().Name.Contains("TextBox") || controlFocus.GetType().Name.Contains("DateTimePicker") || controlFocus.GetType().Name.Contains("NumericUpDown"))
            {
                if (controlFocus.GetType().Name.Contains("DateTimePicker") || controlFocus.GetType().Name.Contains("NumericUpDown") || controlFocus.Name.Equals("textBox16") || controlFocus.Name.Equals("textBox9") || controlFocus.Name.Equals("textBox2") || controlFocus.Name.Equals("textBox3") || controlFocus.Name.Equals("textBox4") || controlFocus.Name.Equals("textBox24") || controlFocus.Name.Equals("textBox10") || controlFocus.Name.Equals("textBox17"))
                    valor = true;
                else
                    tb = (TextBox)controlFocus;
            }
            if (!valor)
            {
                if (!SePuede && tb.Equals(textBox22))
                {
                    textBox22.Text = "0";
                    SePuede = true;
                }
                if (tb.Equals(textBox22) && mr3)
                {
                    textBox22.Text = "0"; 
                }                
                SelectionStart = tb.SelectionStart;
                SelectionLength = tb.SelectionLength;
                tb.Focus();
                tb.SelectionStart = SelectionStart;
                tb.SelectionLength = SelectionLength;                
                if (!TieneCerosIzquierda(tb, ','))
                {
                    string s;                    
                    s = tb.Text.Remove(SelectionStart, SelectionLength).Insert(tb.SelectionStart, ",");
                    if (!tb.Equals(textBox22) || (tb.Equals(textBox22) && PuedeImprimir(',')))
                    {
                        if (tb.Equals(textBox22) && mr3)
                           mr3 = false;
                        tb.Text = s;
                        tb.Select(SelectionStart + 1, 0);
                    }
                    else
                        Ding.Play();
                }
                else if (tb.Equals(textBox22))
                {
                    errorProvider1.SetError(tb, "");
                    Ding.Play();
                }
                else
                {
                    ModificarTextBox(tb, true);
                    Ding.Play();
                }
            }
            else
            {
                if (controlFocus.GetType().Name.Equals("TextBox"))
                {
                    SelectionStart = ((TextBox)controlFocus).SelectionStart;
                    SelectionLength = ((TextBox)controlFocus).SelectionLength;
                }
                else if (controlFocus.GetType().Name.Equals("NumericUpDown"))
                {
                    SelectionStart = ((((NumericUpDown)controlFocus).Controls[1]) as TextBox).SelectionStart;
                    SelectionLength = ((((NumericUpDown)controlFocus).Controls[1]) as TextBox).SelectionLength;
                }
                controlFocus.Focus();
                if (controlFocus.GetType().Name.Equals("TextBox"))
                {
                    ((TextBox)controlFocus).SelectionStart = SelectionStart;
                    ((TextBox)controlFocus).SelectionLength = SelectionLength;
                }
                else if (controlFocus.GetType().Name.Equals("NumericUpDown"))
                {
                    ((((NumericUpDown)controlFocus).Controls[1]) as TextBox).SelectionStart = SelectionStart;
                    ((((NumericUpDown)controlFocus).Controls[1]) as TextBox).SelectionLength = SelectionLength;
                }
                Ding.Play();
            }                         
        }

        private void ChequearRadioButtons()//ya
        {
            if (this.radioButton6.Checked)
            {
                this.Modificar1(false);
                this.Modificar2(false);
                this.Modificar3(false);
            }
            else if (this.radioButton7.Checked)
            {
                this.Modificar1(true);
                this.Modificar2(false);
                this.Modificar3(false);
            }
            else if (this.radioButton5.Checked)
            {
                this.Modificar1(true);
                this.Modificar2(true);
                this.Modificar3(false);
            }
            else if (this.radioButton4.Checked)
            {
                this.Modificar1(true);
                this.Modificar2(true);
                this.Modificar3(true);
            }
        }

        private void ChequearRadioButtons1()
        {
            Label[] arreglo = {
                               label28,label31,label47,label48,label49,label50,label51,label52,
                               label43,label44,label45,label46,label41,label42,label40,label39
                              };
            if (radioButton8.Checked)
            {
                for (int i = arreglo.Length - 1; i >= 0; i--)
                    if (i > arreglo.Length - 3)
                        (arreglo[i] as Label).Visible = true;
                    else
                        (arreglo[i] as Label).Visible = false;
                label35.Visible = true;
                label34.Visible = label30.Visible = label33.Visible = label32.Visible = label29.Visible = false;
            }
            else if (radioButton9.Checked)
            {
                for (int i = arreglo.Length - 1; i >= 0; i--)
                    if (i > arreglo.Length - 5)
                        (arreglo[i] as Label).Visible = true;
                    else
                        (arreglo[i] as Label).Visible = false;
                label35.Visible = label34.Visible = true;
                label30.Visible = label33.Visible = label32.Visible = label29.Visible = false;
            }
            else if (radioButton10.Checked)
            {
                for (int i = arreglo.Length - 1; i >= 0; i--)
                    if (i > arreglo.Length - 9)
                        (arreglo[i] as Label).Visible = true;
                    else
                        (arreglo[i] as Label).Visible = false;
                label35.Visible = label34.Visible = label30.Visible = true;
                label33.Visible = label32.Visible = label29.Visible = false;
            }
            else if (radioButton11.Checked)
            {
                for (int i = arreglo.Length - 1; i >= 0; i--)
                    (arreglo[i] as Label).Visible = true;
                label35.Visible = label34.Visible = label30.Visible = label33.Visible = label32.Visible = label29.Visible = true;                
            }
        }

        private void button37_Click(object sender, EventArgs e)//ya
        {
            bool cambio = this.button58.Visible;
            if (cambio)
            {
                this.CambiarInv(false);
            }
            else
            {
                this.CambiarInv(true);
            }
        }

        private void CambiarInv(bool cambio)//ya
        {
            this.button58.Visible = cambio;
            this.button57.Visible = cambio;
            this.button62.Visible = cambio;
            this.button60.Visible = cambio;
            this.button36.Visible = cambio;
            this.button38.Visible = cambio;
            this.button39.Visible = cambio;
            this.button42.Visible = cambio;
            this.button43.Visible = cambio;
            this.button40.Visible = cambio;
            this.button87.Visible = !cambio;
            this.button88.Visible = !cambio;
            this.button89.Visible = !cambio;
            this.button90.Visible = !cambio;
            this.button91.Visible = !cambio;
            this.button92.Visible = !cambio;
            this.button93.Visible = !cambio;
            this.button94.Visible = !cambio;
            this.button95.Visible = !cambio;
            this.button96.Visible = !cambio;
        }

        private void Modificar1(bool cambio)//ya
        {
            this.button31.Enabled = cambio;
            this.button12.Enabled = cambio;
            this.button10.Enabled = cambio;
            this.button30.Enabled = cambio;
            this.button35.Enabled = cambio;
            this.button32.Enabled = cambio;
        }

        private void Modificar2(bool cambio)//ya
        {
            this.button28.Enabled = cambio;
            this.button15.Enabled = cambio;
        }

        private void Modificar3(bool cambio)//ya
        {
            this.button72.Enabled = cambio;
            this.button80.Enabled = cambio;
            this.button71.Enabled = cambio;
            this.button73.Enabled = cambio;
            this.button59.Enabled = cambio;
            this.button61.Enabled = cambio;
        }

        private void Modificar4(bool cambio)//ya
        {
            this.button25.Enabled = cambio;
            this.button27.Enabled = cambio;
        }

        private void Modificar5(bool cambio)//ya
        {
            this.button41.Visible = cambio;
            this.button56.Visible = cambio;
            this.button64.Visible = cambio;
            this.button65.Visible = cambio;
            this.button66.Visible = cambio;
            this.button67.Visible = cambio;
            this.button69.Visible = cambio;
            this.button68.Visible = cambio;
            this.button70.Visible = cambio;
            this.button86.Visible = cambio;
        }

        private void Modificar6(bool cambio)//ya
        {
            this.button29.Visible = cambio;
            this.button18.Visible = cambio;
            this.button19.Visible = cambio;
            this.button23.Visible = cambio;
            this.button20.Visible = cambio;
            this.button25.Visible = cambio;
            this.button24.Visible = cambio;
            this.button27.Visible = cambio;
            this.button11.Visible = cambio;
        }

        private void Modificar7()//ya
        {
            this.button9.Enabled = true;
            this.panel11.Visible = true;
            this.panel15.Visible = false;
            this.panel16.Visible = false;
            this.Modificar1(true);
            this.Modificar2(true);
            this.Modificar4(true);
            this.Modificar5(false);
            this.Modificar6(true);
            this.button21.Location = new Point(116, 32);
        }

        private void Modificar8(string s)
        {
            Label[] arreglo = {
                               label28,label31,label47,label48,label49,label50,label51,label52,
                               label43,label44,label45,label46,label41,label42,label40,label39
                              };
            for (int i = arreglo.Length - 1, j = s.Length; i >= 0; i--)
            {
                if (j >= 4)
                {
                    (arreglo[i] as Label).Text = s.Substring(j - 4);
                    s = s.Remove(j - 4);
                    j = s.Length;
                }
                else
                {
                    (arreglo[i] as Label).Text = s.PadLeft(4,'0');
                    s = "";
                    j = 0;
                }
            }              
        }

        private void f(object[] destino)//ya
        {
            this.comboBox2.Items.Clear();
            this.comboBox3.Items.Clear();
            this.comboBox2.Items.AddRange(destino);
            this.comboBox3.Items.AddRange(destino);
            this.comboBox2.Text = this.comboBox2.Items[0].ToString();
            this.comboBox3.Text = this.comboBox3.Items[0].ToString();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)//ya
        {
            switch (this.comboBox1.SelectedIndex)
            {
                case 0:
                    object[] d0 = { "Gradián", "Grado", "Radián" };
                    this.f(d0);                    
                    break;
                case 1:
                    object[] d1 = { "Acres", "Centímetro cuadrado", "Hectáreas", "Kilómetro cuadrado", "Metros cuadrados", "Milímetro cuadrado", "Milla cuadrada", "Pies cuadrados", "Pulgada cuadrada", "Yarda cuadrada" };
                    this.f(d1);
                    break;
                case 2:
                    object[] d2 = { "Caloría", "Electronvoltio", "Julio", "Kilocaloría", "Kilojulio", "Pie-libra", "Unidad térmica británica" };
                    this.f(d2);
                    break;
                case 3:
                    object[] d3 = { "Día", "Hora", "Microsegundo", "Milisegundo", "Minuto", "Segundo", "Semana" };
                    this.f(d3);
                    break;
                case 4:
                    object[] d4 = { "Angstrom", "Braza", "Cadena", "Centímetros", "Extensión", "Kilómetros", "Mano", "Metros", "Micrones", "Milímetros", "Milla", "Millas náuticas", "Nanómetro", "Pica", "Pies", "Pulgada", "Rods", "Vínculo", "Yarda" };
                    this.f(d4);
                    break;
                case 5:
                    object[] d5 = { "Centigramo", "Decagramo", "Decigramo", "Gramo", "Hectogramo", "Kilogramo", "Libra", "Miligramo", "Onza", "Quilate", "Stone", "Tonelada corta", "Tonelada larga", "Tonelada métrica" };
                    this.f(d5);
                    break;
                case 6:
                    object[] d6 = { "BTU/minuto", "Caballo", "Kilovatio", "Pie-libra/minuto", "Vatio" };
                    this.f(d6);
                    break;
                case 7:
                    object[] d7 = { "Atmósfera", "Bar", "Kilopascal", "Libra por pulgada cuadrada (PSI)", "Milímetro de mercurio", "Pascal" };
                    this.f(d7);
                    break;
                case 8:
                    object[] d8 = { "Grados Celsius", "Grados Fahrenheit", "Kelvin" };
                    this.f(d8);
                    break;
                case 9:
                    object[] d9 = { "Centímetro por segundo", "Kilómetro por hora", "Mach (a atm estándar)", "Metro por segundo", "Millas por hora", "Nudos", "Pies por segundo" };
                    this.f(d9);
                    break;
                case 10:
                    object[] d10 = { "Centímetro cúbico", "Cuarto de galón (EE.UU.)", "Cuarto de galón (R.U.)", "Galón (EE.UU.)", "Galón (R.U.)", "Litro", "Métro cúbico", "Onza líquida (EE.UU.)", "Onza líquida (R.U.)", "Pies cúbicos", "Pinta (EE.UU.)", "Pinta (R.U.)", "Pulgada cúbica", "Yarda cúbica" };
                    this.f(d10);
                    break;
            }
            this.textBox1.Text = "Escribir valor";
            this.textBox1.ForeColor = SystemColors.InactiveCaptionText;
            this.textBox1.Font = new Font(this.textBox1.Font, FontStyle.Italic);
            this.textBox2.Text = "";
            if (textBox1.Width != 345)
            {
                errorProvider1.SetError(textBox1, "");
                ModificarTextBox(textBox1,false);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBox4.SelectedIndex)
            {
                case 0:
                    label9.Visible = true;
                    label6.Visible = true;
                    dateTimePicker2.Visible = true;
                    label10.Visible = true;
                    textBox4.Visible = true;
                    textBox3.Visible = true;
                    label36.Visible = false;
                    label37.Visible = false;
                    label38.Visible = false;
                    numericUpDown1.Visible = false;
                    numericUpDown2.Visible = false;
                    numericUpDown3.Visible = false;
                    radioButton12.Visible = false;
                    radioButton13.Visible = false;
                    label2.Visible = false;
                    textBox24.Visible = false;
                    break;
                case 1:
                    label36.Visible = true;
                    label37.Visible = true;
                    label38.Visible = true;
                    numericUpDown1.Visible = true;
                    numericUpDown2.Visible = true;
                    numericUpDown3.Visible = true;
                    radioButton12.Visible = true;
                    radioButton13.Visible = true;
                    label9.Visible = false;
                    label6.Visible = false;
                    dateTimePicker2.Visible = false;
                    label10.Visible = false;
                    textBox4.Visible = false;
                    textBox3.Visible = false;
                    label2.Visible = true;
                    textBox24.Visible = true;
                    break;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)//ya
        {
            if (this.textBox1.Text == "")
            {
                this.textBox1.Text = "Escribir valor";
                this.textBox1.ForeColor = SystemColors.InactiveCaptionText;
                this.textBox1.Font = new Font(this.textBox1.Font, FontStyle.Italic);
            }
            if (textBox1.Width != 345)
            {
                errorProvider1.SetError(textBox1, "");
                ModificarTextBox(textBox1, false);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)//ya
        {
            if (this.textBox1.Text == "Escribir valor")
                this.textBox1.Text = "";
            this.textBox1.ResetFont();
            this.textBox1.ResetForeColor();
            this.textBox1.SelectAll();
            controlFocus = textBox1;
        }       

        private void panel2_Enter(object sender, EventArgs e)
        {
            CambiarColor(true);
            if (programadorToolStripMenuItem.Checked)
            {
                this.ChequearRadioButtons();
                this.button9.Enabled = false;
            }
        }

        private void CambiarColor(bool valor)
        {
            if (valor)
            {
                this.panel2.BackColor = SystemColors.ButtonHighlight;
                listBox1.BackColor = SystemColors.ButtonHighlight;
                listBox2.BackColor = SystemColors.ButtonHighlight;
                listBox3.BackColor = SystemColors.ButtonHighlight;
                textBox22.BackColor = SystemColors.ButtonHighlight;
                textBox23.BackColor = SystemColors.ButtonHighlight;
                textBox22.SelectionStart = textBox22.TextLength;
            }
            else
            {
                this.panel2.BackColor = SystemColors.Control;
                listBox1.BackColor = SystemColors.Control;
                listBox2.BackColor = SystemColors.Control;
                listBox3.BackColor = SystemColors.Control;
                textBox22.BackColor = SystemColors.Control;
                textBox23.BackColor = SystemColors.Control;
            }
        }
        
        private void panel2_Leave(object sender, EventArgs e)
        {
            if (panel10.ContainsFocus || panel5.ContainsFocus || panel6.ContainsFocus || panel7.ContainsFocus || panel8.ContainsFocus || panel9.ContainsFocus)
                CambiarColor(false);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)//ya
        {
            if ((e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '-')
            {
                errorProvider1.SetError(textBox1, "ERROR\n'" + e.KeyChar.ToString() + "' no es un caracter permitido");
                ModificarTextBox(textBox1,true);
                e.KeyChar = (char)Keys.Escape;
            }
            else if ((e.KeyChar == (char)Keys.Back || (e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == ',' || e.KeyChar == '-') && (TieneCerosIzquierda(textBox1, e.KeyChar)))
            {
                ModificarTextBox(textBox1, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
                ModificarTextBox(textBox1, false);
            }
        }
                
        private void textBox1_TextChanged(object sender, EventArgs e)//ya
        {
            this.Validar();
        }

        private void Accion1(double valor)//ya
        {
             if (comboBox2.SelectedIndex == comboBox3.SelectedIndex)
                 textBox2.Text = Convert.ToString(valor);
             else
             {
                 switch (comboBox1.SelectedIndex)
                 {
                     //Ángulo
                     case 0:
                         this.Angulo(valor);
                         break;
                     //Área
                     case 1:
                         this.Area(valor);
                         break;
                     //Energía
                     case 2:
                         this.Energia(valor);
                         break;
                     //Hora
                     case 3:
                         this.Hora(valor);
                         break;
                     //Longitud
                     case 4:
                         this.Longitud(valor);
                         break;
                     //Peso/Masa
                     case 5:
                         this.PesoMasa(valor);
                         break;
                     //Potencia
                     case 6:
                         this.Potencia(valor);
                         break;
                     //Presión
                     case 7:
                         this.Presion(valor);
                         break;
                     //Temperatura
                     case 8:
                         this.Temperatura(valor);
                         break;
                     //Velocidad
                     case 9:
                         this.Velocidad(valor);
                         break;
                     //Volumen
                     case 10:
                         this.Volumen(valor);
                         break;
                 }
             }            
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)//ya
        {
            this.Validar();
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)//ya
        {
            this.Validar();
        }

        private void Angulo(double valor)//ya
        {
            switch (comboBox2.SelectedIndex)
            {
                //Gradián
                case 0:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Gradián a Grado
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.9);
                            break;
                        //Gradián a Radián
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.015707963267949);
                            break;
                    }
                    break;
                //Grado
                case 1:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Grado a Gradián
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 1.111111111111111);
                            break;
                        //Grado a Radián
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.0174532925199433);
                            break;
                    }
                    break;
                //Radián
                case 2:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Radián a Gradián
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 63.66197723675814);
                            break;
                        //Radián a Grado
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 57.29577951308233);
                            break;
                    }
                    break;
            }
        }

        private void Area(double valor)//ya
        {
            switch (comboBox2.SelectedIndex)
            {
                //Acres
                case 0:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 40468564.224);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.40468564224);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.0040468564224);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 4046.8564224);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 4046856422.4);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.0015625);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 43560);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 6272640);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 4840);
                            break;
                    }
                    break;
                //Centímetro cuadrado
                case 1:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 2.471053814671653e-8);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.00000001);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.0000000001);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.0001);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 100);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 3.861021585424458e-11);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 0.001076391041671);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 0.15500031000062);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 1.19599004630108e-4);
                            break;
                    }
                    break;
                //Hectáreas
                case 2:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 2.471053814671653);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 100000000);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.01);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 10000);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 10000000000);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.0038610215854245);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 107639.1041670972);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 15500031.000062);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 11959.9004630108);
                            break;
                    }
                    break;
                //Kilómetro cuadrado
                case 3:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 247.1053814671653);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 10000000000);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 100);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 1000000);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 1000000000000);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.3861021585424458);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 10763910.41670972);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 1550003100.0062);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 1195990.04630108);
                            break;
                    }
                    break;
                //Metros cuadrados
                case 4:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 2.471053814671653e-4);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 10000);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.0001);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.000001);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 1000000);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 3.861021585424458e-7);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 10.76391041670972);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 1550.0031000062);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 1.19599004630108);
                            break;
                    }
                    break;
                //Milímetro cuadrado
                case 5:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 2.471053814671653e-10);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.01);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.0000000001);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.000000000001);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.000001);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 3.861021585424458e-13);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 1.076391041670972e-5);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 0.0015500031000062);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 1.19599004630108e-6);
                            break;
                    }
                    break;
                //Milla cuadrada
                case 6:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 640);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 25899881103.36);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 258.9988110336);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 2.589988110336);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 2589988.110336);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 2589988110336);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 27878400);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 4014489600);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 3097600);
                            break;
                    }
                    break;
                //Pies cuadrados
                case 7:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 2.295684113865932e-5);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 929.0304);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.000009290304);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.00000009290304);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.09290304);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 92903.04);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 3.587006427915519e-8);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 144);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 0.1111111111111111);
                            break;
                    }
                    break;
                //Pulgada cuadrada
                case 8:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 1.594225079073564e-7);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 6.4516);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.000000064516);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.00000000064516);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.00064516);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 645.16);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 2.490976686052444e-10);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 0.0069444444444444);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 7.716049382716049e-4);
                            break;
                    }
                    break;
                //Yarda cuadrada
                case 9:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 2.066115702479339e-4);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 8361.2736);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.000083612736);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.00000083612736);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.83612736);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 836127.36);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 3.228305785123967e-7);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 9);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 1296);
                            break;
                    }
                    break;

            }
        }

        private void Energia(double valor)//ya
        {
            switch (comboBox2.SelectedIndex)
            {
                //
                case 0:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 2.61319518892216e+19);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 4.1868);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.001);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.0041868);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 3.088025206594056);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.003968320164996);
                            break;
                    }
                    break;
                //
                case 1:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 3.826732898633801e-20);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 1.60217653e-19);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 3.826732898633801e-23);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 1.60217653e-22);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 1.181704764988391e-19);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 1.518570132770204e-22);
                            break;
                    }
                    break;
                //
                case 2:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 0.2388458966274959);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 6.241509479607718e+18);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 2.388458966274959e-4);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.001);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.7375621492772656);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 9.478169879134378e-4);
                            break;
                    }
                    break;
                //
                case 3:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 1000);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 2.61319518892216e+22);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 4186.8);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 4.1868);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 3088.025206594056);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 3.968320164995981);
                            break;
                    }
                    break;
                //
                case 4:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 238.8458966274959);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 6.241509479607718e+21);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 1000);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.2388458966274959);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 737.5621492772656);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.9478169879134378);
                            break;
                    }
                    break;
                //
                case 5:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 0.3238315535328652);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 8.462350577132721e+18);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 1.3558179483314);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 3.238315535328652e-4);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.0013558179483314);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.0012850672839464);
                            break;
                    }
                    break;
                //
                case 6:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 251.9957963122194);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 6.585142025517001e+21);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 1055.056);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.2519957963122194);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 1.055056);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 778.1693709678747);
                            break;
                    }
                    break;
            }
        }

        private void Hora(double valor)//ya
        {
            switch (comboBox2.SelectedIndex)
            {
                //Día
                case 0:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 24);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 86400000000);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 86400000);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 1440);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 86400);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.1428571428571429);
                            break;
                    }
                    break;
                //Hora
                case 1:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 0.0416666666666667);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 3600000000);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 3600000);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 60);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 3600);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.005952380952381);
                            break;
                    }
                    break;
                //Microsegundo
                case 2:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 1.157407407407407e-11);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 2.777777777777778e-10);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.001);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 1.666666666666667e-8);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.000001);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 1.653439153439153e-12);
                            break;
                    }
                    break;
                //Milisegundo
                case 3:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 1.157407407407407e-8);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 2.777777777777778e-7);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 1000);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 1.666666666666667e-5);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.001);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 1.653439153439153e-9);
                            break;
                    }
                    break;
                //Minuto
                case 4:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 6.944444444444444e-4);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.0166666666666667);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 60000000);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 60000);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 60);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 9.920634920634921e-5);
                            break;
                    }
                    break;
                //Segundo
                case 5:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 1.157407407407407e-5);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 2.777777777777778e-4);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 1000000);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 1000);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.0166666666666667);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 1.653439153439153e-6);
                            break;
                    }
                    break;
                //Semana
                case 6:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 7);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 168);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 604800000000);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 604800000);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 10080);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 604800);
                            break;
                    }
                    break;
            }
        }

        private void Longitud(double valor)//ya
        {
           switch (comboBox2.SelectedIndex)
            {
                //Angstrom
                case 0:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Braza
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 5.468066491688539e-11);
                            break;
                        //Cadena
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 4.970969537898672e-12);
                            break;
                        //Centímetros
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.00000001);
                            break;
                        //Extensión
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 4.374453193350831e-10);
                            break;
                        //Kilómetros
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.0000000000001);
                            break;
                        //Mano
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 9.84251968503937e-10);
                            break;
                        //Metro
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 0.0000000001);
                            break;
                        //Micrones
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 0.0001);
                            break;
                        //Milímetros
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 0.0000001);
                            break;
                        //Milla
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 6.21371192237334e-14);
                            break;
                        //Millas náuticas
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 5.399568034557235e-14);
                            break;
                        //Nanómetro
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 0.1);
                            break;
                        //Pica
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 2.371063015836614e-8);
                            break;
                        //Pies
                        case 14:
                            textBox2.Text = Convert.ToString(valor * 3.280839895013123e-10);
                            break;
                        //Pulgada
                        case 15:
                            textBox2.Text = Convert.ToString(valor * 3.937007874015748e-9);
                            break;
                        //Rods
                        case 16:
                            textBox2.Text = Convert.ToString(valor * 1.988387815159469e-11);
                            break;
                        //Vínculo
                        case 17:
                            textBox2.Text = Convert.ToString(valor * 4.970969537898672e-10);
                            break;
                        //Yarda
                        case 18:
                            textBox2.Text = Convert.ToString(valor * 1.093613298337708e-10);
                            break;
                    }
                    break;
                //Braza
                case 1:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Angstrom
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 18288000000);
                            break;
                        //Cadena
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.0909090909090909);
                            break;
                        //Centímetros
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 182.88);
                            break;
                        //Extensión
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 8);
                            break;
                        //Kilómetros
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.0018288);
                            break;
                        //Mano
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 18);
                            break;
                        //Metro
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 1.8288);
                            break;
                        //Micrones
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 1828800);
                            break;
                        //Milímetros
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 1828.8);
                            break;
                        //Milla
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 0.0011363636363636);
                            break;
                        //Millas náuticas
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 9.874730021598272e-4);
                            break;
                        //Nanómetro
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 1828800000);
                            break;
                        //Pica
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 433.6200043362);
                            break;
                        //Pies
                        case 14:
                            textBox2.Text = Convert.ToString(valor * 6);
                            break;
                        //Pulgada
                        case 15:
                            textBox2.Text = Convert.ToString(valor * 72);
                            break;
                        //Rods
                        case 16:
                            textBox2.Text = Convert.ToString(valor * 0.3636363636363636);
                            break;
                        //Vínculo
                        case 17:
                            textBox2.Text = Convert.ToString(valor * 9.090909090909091);
                            break;
                        //Yarda
                        case 18:
                            textBox2.Text = Convert.ToString(valor * 2);
                            break;
                    }
                    break;
                //Cadena
                case 2:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Angstrom
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 201168000000);
                            break;
                        //Braza
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 11);
                            break;
                        //Centímetros
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 2011.68);
                            break;
                        //Extensión
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 88);
                            break;
                        //Kilómetros
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.0201168);
                            break;
                        //Mano
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 198);
                            break;
                        //Metro
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 20.1168);
                            break;
                        //Micrones
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 20116800);
                            break;
                        //Milímetros
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 20116.8);
                            break;
                        //Milla
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 0.0125);
                            break;
                        //Millas náuticas
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 0.0108622030237581);
                            break;
                        //Nanómetro
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 20116800000);
                            break;
                        //Pica
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 4769.8200476982);
                            break;
                        //Pies
                        case 14:
                            textBox2.Text = Convert.ToString(valor * 66);
                            break;
                        //Pulgada
                        case 15:
                            textBox2.Text = Convert.ToString(valor * 792);
                            break;
                        //Rods
                        case 16:
                            textBox2.Text = Convert.ToString(valor * 4);
                            break;
                        //Vínculo
                        case 17:
                            textBox2.Text = Convert.ToString(valor * 100);
                            break;
                        //Yarda
                        case 18:
                            textBox2.Text = Convert.ToString(valor * 22);
                            break;
                    }
                    break;
                //Centímetros
                case 3:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Angstrom
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 100000000);
                            break;
                        //Braza
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.0054680664916885);
                            break;
                        //Cadena
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 4.970969537898672e-4);
                            break;
                        //Extensión
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.0437445319335083);
                            break;
                        //Kilómetros
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.00001);
                            break;
                        //Mano
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.0984251968503937);
                            break;
                        //Metro
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 0.01);
                            break;
                        //Micrones
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 10000);
                            break;
                        //Milímetro
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 10);
                            break;
                        //Milla
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 6.21371192237334e-6);
                            break;
                        //Millas náuticas
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 5.399568034557235e-6);
                            break;
                        //Nanómetro
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 10000000);
                            break;
                        //Pica
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 2.371063015836614);
                            break;
                        //Pies
                        case 14:
                            textBox2.Text = Convert.ToString(valor * 0.0328083989501312);
                            break;
                        //Pulgada
                        case 15:
                            textBox2.Text = Convert.ToString(valor * 0.3937007874015748);
                            break;
                        //Rods
                        case 16:
                            textBox2.Text = Convert.ToString(valor * 0.0019883878151595);
                            break;
                        //Vínculo
                        case 17:
                            textBox2.Text = Convert.ToString(valor * 0.0497096953789867);
                            break;
                        //Yarda
                        case 18:
                            textBox2.Text = Convert.ToString(valor * 0.0109361329833771);
                            break;
                    }
                    break;
                //Extensión
                case 4:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Angstrom
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 2286000000);
                            break;
                        //Braza
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.125);
                            break;
                        //Cadena
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.0113636363636364);
                            break;
                        //Centímetros
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 22.86);
                            break;
                        //Kilómetros
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.0002286);
                            break;
                        //Mano
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 2.25);
                            break;
                        //Metro
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 0.2286);
                            break;
                        //Micrones
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 228600);
                            break;
                        //Milímetros
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 228.6);
                            break;
                        //Milla
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 1.420454545454545e-4);
                            break;
                        //Millas náuticas
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 1.234341252699784e-4);
                            break;
                        //Nanómetro
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 228600000);
                            break;
                        //Pica
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 54.20250054202501);
                            break;
                        //Pies
                        case 14:
                            textBox2.Text = Convert.ToString(valor * 0.75);
                            break;
                        //Pulgada
                        case 15:
                            textBox2.Text = Convert.ToString(valor * 9);
                            break;
                        //Rods
                        case 16:
                            textBox2.Text = Convert.ToString(valor * 0.0454545454545455);
                            break;
                        //Vínculo
                        case 17:
                            textBox2.Text = Convert.ToString(valor * 1.136363636363636);
                            break;
                        //Yarda
                        case 18:
                            textBox2.Text = Convert.ToString(valor * 0.25);
                            break;
                    }
                    break;
                //Kilómetros
                case 5:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Angstrom
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 10000000000000);
                            break;
                        //Braza
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 546.8066491688539);
                            break;
                        //Cadena
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 49.70969537898672);
                            break;
                        //Centímetro
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 100000);
                            break;
                        //Extensión
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 4374.453193350831);
                            break;
                        //Mano
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 9842.51968503937);
                            break;
                        //Metro
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 1000);
                            break;
                        //Micrones
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 1000000000);
                            break;
                        //Milímetros
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 1000000);
                            break;
                        //Milla
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 0.621371192237334);
                            break;
                        //Millas náuticas
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 0.5399568034557235);
                            break;
                        //Nanómetro
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 1000000000000);
                            break;
                        //Pica
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 237106.3015836614);
                            break;
                        //Pies
                        case 14:
                            textBox2.Text = Convert.ToString(valor * 3280.839895013123);
                            break;
                        //Pulgada
                        case 15:
                            textBox2.Text = Convert.ToString(valor * 39370.07874015748);
                            break;
                        //Rods
                        case 16:
                            textBox2.Text = Convert.ToString(valor * 198.8387815159469);
                            break;
                        //Vínculo
                        case 17:
                            textBox2.Text = Convert.ToString(valor * 4970.969537898672);
                            break;
                        //Yarda
                        case 18:
                            textBox2.Text = Convert.ToString(valor * 1093.613298337708);
                            break;
                    }
                    break;
                //Mano
                case 6:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Angstrom
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 1016000000);
                            break;
                        //Braza
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.0555555555555556);
                            break;
                        //Cadena
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.0050505050505051);
                            break;
                        //Centímetro
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 10.16);
                            break;
                        //Extensión
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.4444444444444444);
                            break;
                        //Kilómetro
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.0001016);
                            break;
                        //Metro
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 0.1016);
                            break;
                        //Micrones
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 101600);
                            break;
                        //Milímetro
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 101.6);
                            break;
                        //Milla
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 6.313131313131313e-5);
                            break;
                        //Millas náuticas
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 5.485961123110151e-5);
                            break;
                        //Nanómetro
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 101600000);
                            break;
                        //Pica
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 24.0900002409);
                            break;
                        //Pies
                        case 14:
                            textBox2.Text = Convert.ToString(valor * 0.3333333333333333);
                            break;
                        //Pulgada
                        case 15:
                            textBox2.Text = Convert.ToString(valor * 4);
                            break;
                        //Rods
                        case 16:
                            textBox2.Text = Convert.ToString(valor * 0.0202020202020202);
                            break;
                        //Vínculo
                        case 17:
                            textBox2.Text = Convert.ToString(valor * 0.5050505050505051);
                            break;
                        //Yarda
                        case 18:
                            textBox2.Text = Convert.ToString(valor * 0.1111111111111111);
                            break;
                    }
                    break;
                //Metro
                case 7:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Angstrom
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 10000000000);
                            break;
                        //Braza
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.5468066491688539);
                            break;
                        //Cadena
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.0497096953789867);
                            break;
                        //Centímetro
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 100);
                            break;
                        //Extensión
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 4.374453193350831);
                            break;
                        //Kilómetro
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.001);
                            break;
                        //Mano
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 9.84251968503937);
                            break;
                        //Micrones
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 1000000);
                            break;
                        //Milímetro
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 1000);
                            break;
                        //Milla
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 6.21371192237334e-4);
                            break;
                        //Millas náuticas
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 5.399568034557235e-4);
                            break;
                        //Nanómetro
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 1000000000);
                            break;
                        //Pica
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 237.1063015836614);
                            break;
                        //Pies
                        case 14:
                            textBox2.Text = Convert.ToString(valor * 3.280839895013123);
                            break;
                        //Pulgada
                        case 15:
                            textBox2.Text = Convert.ToString(valor * 39.37007874015748);
                            break;
                        //Rods
                        case 16:
                            textBox2.Text = Convert.ToString(valor * 0.1988387815159469);
                            break;
                        //Vínculo
                        case 17:
                            textBox2.Text = Convert.ToString(valor * 4.970969537898672);
                            break;
                        //Yarda
                        case 18:
                            textBox2.Text = Convert.ToString(valor * 1.093613298337708);
                            break;
                    }
                    break;
                //Micrones
                case 8:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Angstrom
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 10000);
                            break;
                        //Braza
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 5.468066491688539e-7);
                            break;
                        //Cadena
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 4.970969537898672e-8);
                            break;
                        //Centímetro
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.0001);
                            break;
                        //Extensión
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 4.374453193350831e-6);
                            break;
                        //Kilómetro
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.000000001);
                            break;
                        //Mano
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 9.84251968503937e-6);
                            break;
                        //Metro
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 0.000001);
                            break;
                        //Milímetro
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 0.001);
                            break;
                        //Milla
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 6.21371192237334e-10);
                            break;
                        //Millas náuticas
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 5.399568034557235e-10);
                            break;
                        //Nanómetro
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 1000);
                            break;
                        //Pica
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 2.371063015836614e-4);
                            break;
                        //Pies
                        case 14:
                            textBox2.Text = Convert.ToString(valor * 3.280839895013123e-6);
                            break;
                        //Pulgada
                        case 15:
                            textBox2.Text = Convert.ToString(valor * 3.937007874015748e-5);
                            break;
                        //Rods
                        case 16:
                            textBox2.Text = Convert.ToString(valor * 1.988387815159469e-7);
                            break;
                        //Vínculo
                        case 17:
                            textBox2.Text = Convert.ToString(valor * 4.970969537898672e-6);
                            break;
                        //Yarda
                        case 18:
                            textBox2.Text = Convert.ToString(valor * 1.093613298337708e-6);
                            break;
                    }
                    break;
                //Milímetros
                case 9:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Angstrom
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 10000000);
                            break;
                        //Braza
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 5.468066491688539e-4);
                            break;
                        //Cadena
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 4.970969537898672e-5);
                            break;
                        //Centímetros
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.1);
                            break;
                        //Extensión
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.0043744531933508);
                            break;
                        //Kilómetro
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.000001);
                            break;
                        //Mano
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.0098425196850394);
                            break;
                        //Metro
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 0.001);
                            break;
                        //Micrones
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 1000);
                            break;
                        //Milla
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 6.21371192237334e-7);
                            break;
                        //Millas náuticas
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 5.399568034557235e-7);
                            break;
                        //Nanómetro
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 1000000);
                            break;
                        //Pica
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.2371063015836614);
                            break;
                        //Pies
                        case 14:
                            textBox2.Text = Convert.ToString(valor * 0.0032808398950131);
                            break;
                        //Pulgada
                        case 15:
                            textBox2.Text = Convert.ToString(valor * 0.0393700787401575);
                            break;
                        //Rods
                        case 16:
                            textBox2.Text = Convert.ToString(valor * 1.988387815159469e-4);
                            break;
                        //Vínculo
                        case 17:
                            textBox2.Text = Convert.ToString(valor * 0.0049709695378987);
                            break;
                        //Yarda
                        case 18:
                            textBox2.Text = Convert.ToString(valor * 0.0010936132983377);
                            break;
                    }
                    break;
                //Milla
                case 10:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Angstrom
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 16093440000000);
                            break;
                        //Braza
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 880);
                            break;
                        //Cadena
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 80);
                            break;
                        //Centímetros
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 160934.4);
                            break;
                        //Extensión
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 7040);
                            break;
                        //Kilómetro
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 1.609344);
                            break;
                        //Mano
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 15840);
                            break;
                        //Metro
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 1609.344);
                            break;
                        //Micrones
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 1609344000);
                            break;
                        //Milímetro
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 1609344);
                            break;
                        //Millas náuticas
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 0.8689762419006479);
                            break;
                        //Nanómetro
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 1609344000000);
                            break;
                        //Pica
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 381585.603815856);
                            break;
                        //Pies
                        case 14:
                            textBox2.Text = Convert.ToString(valor * 5280);
                            break;
                        //Pulgada
                        case 15:
                            textBox2.Text = Convert.ToString(valor * 63360);
                            break;
                        //Rods
                        case 16:
                            textBox2.Text = Convert.ToString(valor * 320);
                            break;
                        //Vínculo
                        case 17:
                            textBox2.Text = Convert.ToString(valor * 8000);
                            break;
                        //Yarda
                        case 18:
                            textBox2.Text = Convert.ToString(valor * 1760);
                            break;
                    }
                    break;
                //Millas náuticas
                case 11:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Angstrom
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 18520000000000);
                            break;
                        //Braza
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 1012.685914260717);
                            break;
                        //Cadena
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 92.0623558418834);
                            break;
                        //Centímetro
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 185200);
                            break;
                        //Extensión
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 8101.487314085739);
                            break;
                        //Kilómetros
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 1.852);
                            break;
                        //Mano
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 18228.34645669291);
                            break;
                        //Metro
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 1852);
                            break;
                        //Micrones
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 1852000000);
                            break;
                        //Milímetros
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 1852000);
                            break;
                        //Milla
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 1.150779448023543);
                            break;
                        //Nanómetro
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 1852000000000);
                            break;
                        //Pica
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 439120.870532941);
                            break;
                        //Pies
                        case 14:
                            textBox2.Text = Convert.ToString(valor * 6076.115485564304);
                            break;
                        //Pulgada
                        case 15:
                            textBox2.Text = Convert.ToString(valor * 72913.38582677165);
                            break;
                        //Rods
                        case 16:
                            textBox2.Text = Convert.ToString(valor * 368.2494233675336);
                            break;
                        //Vínculo
                        case 17:
                            textBox2.Text = Convert.ToString(valor * 9206.23558418834);
                            break;
                        //Yarda
                        case 18:
                            textBox2.Text = Convert.ToString(valor * 2025.371828521435);
                            break;
                    }
                    break;
                //Nanómetro
                case 12:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Angstrom
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 10);
                            break;
                        //Braza
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 5.468066491688539e-10);
                            break;
                        //Cadena
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 4.970969537898672e-11);
                            break;
                        //Centímetro
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.0000001);
                            break;
                        //Extensión
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 4.374453193350831e-9);
                            break;
                        //Kilómetros
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.000000000001);
                            break;
                        //Mano
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 9.84251968503937e-9);
                            break;
                        //Metro     
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 0.000000001);
                            break;
                        //Micrones
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 0.001);
                            break;
                        //Milímetros
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 0.000001);
                            break;
                        //Milla
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 6.21371192237334e-13);
                            break;
                        //Millas náuticas
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 5.399568034557235e-13);
                            break;
                        //Pica
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 2.371063015836614e-7);
                            break;
                        //Pies
                        case 14:
                            textBox2.Text = Convert.ToString(valor * 3.280839895013123e-9);
                            break;
                        //Pulgada
                        case 15:
                            textBox2.Text = Convert.ToString(valor * 3.937007874015748e-8);
                            break;
                        //Rods
                        case 16:
                            textBox2.Text = Convert.ToString(valor * 1.988387815159469e-10);
                            break;
                        //Vínculo
                        case 17:
                            textBox2.Text = Convert.ToString(valor * 4.970969537898672e-9);
                            break;
                        //Yarda
                        case 18:
                            textBox2.Text = Convert.ToString(valor * 1.093613298337708e-9);
                            break;
                    }
                    break;
                //Pica
                case 13:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Angstrom
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 42175176);
                            break;
                        //Braza
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.0023061666666667);
                            break;
                        //Cadena
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 2.096515151515152e-4);
                            break;
                        //Centímetros
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.42175176);
                            break;
                        //Extensión
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.0184493333333333);
                            break;
                        //Kilómetro
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.0000042175176);
                            break;
                        //Mano
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.041511);
                            break;
                        //Metro
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 0.0042175176);
                            break;
                        //Micrones
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 4217.5176);
                            break;
                        //Milímetros
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 4.2175176);
                            break;
                        //Milla
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 2.620643939393939e-6);
                            break;
                        //Millas náuticas
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 2.277277321814255e-6);
                            break;
                        //Nanómetro
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 4217517.6);
                            break;
                        //Pies
                        case 14:
                            textBox2.Text = Convert.ToString(valor * 0.013837);
                            break;
                        //Pulgada
                        case 15:
                            textBox2.Text = Convert.ToString(valor * 0.166044);
                            break;
                        //Rods
                        case 16:
                            textBox2.Text = Convert.ToString(valor * 8.386060606060606e-4);
                            break;
                        //Vínculo
                        case 17:
                            textBox2.Text = Convert.ToString(valor * 0.0209651515151515);
                            break;
                        //Yarda
                        case 18:
                            textBox2.Text = Convert.ToString(valor * 0.0046123333333333);
                            break;
                    }
                    break;
                //Pies
                case 14:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Angstrom
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 3048000000);
                            break;
                        //Braza
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.1666666666666667);
                            break;
                        //Cadena
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.0151515151515152);
                            break;
                        //Centímetros
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 30.48);
                            break;
                        //Extensión
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 1.333333333333333);
                            break;
                        //Kilómetros
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.0003048);
                            break;
                        //Mano
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 3);
                            break;
                        //Metro
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 0.3048);
                            break;
                        //Micrones
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 304800);
                            break;
                        //Milímetros
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 304.8);
                            break;
                        //Milla
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 1.893939393939394e-4);
                            break;
                        //Millas náuticas
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 1.645788336933045e-4);
                            break;
                        //Nanómetro
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 304800000);
                            break;
                        //Pica
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 72.27000072270001);
                            break;
                        //Pulgada
                        case 15:
                            textBox2.Text = Convert.ToString(valor * 12);
                            break;
                        //Rods
                        case 16:
                            textBox2.Text = Convert.ToString(valor * 0.0606060606060606);
                            break;
                        //Vínculo
                        case 17:
                            textBox2.Text = Convert.ToString(valor * 1.515151515151515);
                            break;
                        //Yarda
                        case 18:
                            textBox2.Text = Convert.ToString(valor * 0.3333333333333333);
                            break;
                    }
                    break;
                //Pulgada
                case 15:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Angstrom
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 254000000);
                            break;
                        //Braza
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.0138888888888889);
                            break;
                        //Cadena
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.0012626262626263);
                            break;
                        //Centímetros
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 2.54);
                            break;
                        //Extensión
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.1111111111111111);
                            break;
                        //Kilómetros
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.0000254);
                            break;
                        //Mano
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.25);
                            break;
                        //Metro
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 0.0254);
                            break;
                        //Micrones
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 25400);
                            break;
                        //Milímetros
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 25.4);
                            break;
                        //Milla
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 1.578282828282828e-5);
                            break;
                        //Millas náuticas
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 1.371490280777538e-5);
                            break;
                        //Nanómetro
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 25400000);
                            break;
                        //Pica
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 6.022500060225001);
                            break;
                        //Pies
                        case 14:
                            textBox2.Text = Convert.ToString(valor * 0.0833333333333333);
                            break;
                        //Rods
                        case 16:
                            textBox2.Text = Convert.ToString(valor * 0.0050505050505051);
                            break;
                        //Vínculo
                        case 17:
                            textBox2.Text = Convert.ToString(valor * 0.1262626262626263);
                            break;
                        //Yarda
                        case 18:
                            textBox2.Text = Convert.ToString(valor * 0.0277777777777778);
                            break;
                    }
                    break;
                //Rods
                case 16:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Angstrom
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 50292000000);
                            break;
                        //Braza
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 2.75);
                            break;
                        //Cadena
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.25);
                            break;
                        //Centímetro
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 502.92);
                            break;
                        //Extensión
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 22);
                            break;
                        //Kilómetros
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.0050292);
                            break;
                        //Mano
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 49.5);
                            break;
                        //Metro
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 5.0292);
                            break;
                        //Micrones
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 5029200);
                            break;
                        //Milímetros
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 5029.2);
                            break;
                        //Milla
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 0.003125);
                            break;
                        //Millas náuticas
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 0.0027155507559395);
                            break;
                        //Nanómetro
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 5029200000);
                            break;
                        //Pica
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 1192.45501192455);
                            break;
                        //Pies
                        case 14:
                            textBox2.Text = Convert.ToString(valor * 16.5);
                            break;
                        //Pulgada
                        case 15:
                            textBox2.Text = Convert.ToString(valor * 198);
                            break;
                        //Vínculo
                        case 17:
                            textBox2.Text = Convert.ToString(valor * 25);
                            break;
                        //Yarda
                        case 18:
                            textBox2.Text = Convert.ToString(valor * 5.5);
                            break;
                    }
                    break;
                //Vínculo
                case 17:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Angstrom
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 2011680000);
                            break;
                        //Braza
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.11);
                            break;
                        //Cadena
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.01);
                            break;
                        //Centímetros
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 20.1168);
                            break;
                        //Extensión
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.88);
                            break;
                        //Kilómetros
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.000201168);
                            break;
                        //Mano
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 1.98);
                            break;
                        //Metro
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 0.201168);
                            break;
                        //Micrones
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 201168);
                            break;
                        //Milímetros
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 201.168);
                            break;
                        //Milla
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 0.000125);
                            break;
                        //Millas náuticas
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 1.08622030237581e-4);
                            break;
                        //Nanómetro
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 201168000);
                            break;
                        //Pica
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 47.698200476982);
                            break;
                        //Pies
                        case 14:
                            textBox2.Text = Convert.ToString(valor * 0.66);
                            break;
                        //Pulgada
                        case 15:
                            textBox2.Text = Convert.ToString(valor * 7.92);
                            break;
                        //Rods
                        case 16:
                            textBox2.Text = Convert.ToString(valor * 0.04);
                            break;
                        //Yarda
                        case 18:
                            textBox2.Text = Convert.ToString(valor * 0.22);
                            break;
                    }
                    break;
                //Yarda
                case 18:
                    switch (comboBox3.SelectedIndex)
                    {
                        //Angstrom
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 9144000000);
                            break;
                        //Braza
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.5);
                            break;
                        //Cadena
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.0454545454545455);
                            break;
                        //Centímetros
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 91.44);
                            break;
                        //Extensión
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 4);
                            break;
                        //Kilómetros
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.0009144);
                            break;
                        //Mano
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 9);
                            break;
                        //Metro
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 0.9144);
                            break;
                        //Micrones
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 914400);
                            break;
                        //Milímetros
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 914.4);
                            break;
                        //Milla
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 5.681818181818182e-4);
                            break;
                        //Millas náuticas
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 4.937365010799136e-4);
                            break;
                        //Nanómetro
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 914400000);
                            break;
                        //Pica
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 216.8100021681);
                            break;
                        //Pies
                        case 14:
                            textBox2.Text = Convert.ToString(valor * 3);
                            break;
                        //Pulgada
                        case 15:
                            textBox2.Text = Convert.ToString(valor * 36);
                            break;
                        //Rods
                        case 16:
                            textBox2.Text = Convert.ToString(valor * 0.1818181818181818);
                            break;
                        //Vínculo
                        case 17:
                            textBox2.Text = Convert.ToString(valor * 4.545454545454545);
                            break;
                    }
                    break;
           }
        }

        private void PesoMasa(double valor)//ya
        {
            switch (comboBox2.SelectedIndex)
            {
                //Centigramo
                case 0:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.001);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.1);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.01);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.0001);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.00001);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 2.204622621848776e-5);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 10);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 3.527396194958041e-4);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 0.05);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 1.574730444177697e-6);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 1.102311310924388e-8);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 9.842065276110606e-9);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.00000001);
                            break;
                    }
                    break;
                //Decagramo
                case 1:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 1000);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 100);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 10);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.1);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.01);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.0220462262184878);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 10000);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 0.3527396194958041);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 50);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 0.0015747304441777);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 1.102311310924388e-5);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 9.842065276110606e-6);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.00001);
                            break;
                    }
                    break;
                //Decigramo
                case 2:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 10);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.01);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.1);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.001);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.0001);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 2.204622621848776e-4);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 100);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 0.003527396194958);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 0.5);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 1.574730444177697e-5);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 1.102311310924388e-7);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 9.842065276110606e-8);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.0000001);
                            break;
                    }
                    break;
                //Gramo
                case 3:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 100);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.1);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 10);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.01);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.001);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.0022046226218488);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 1000);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 0.0352739619495804);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 5);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 1.574730444177697e-4);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 1.102311310924388e-6);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 9.842065276110606e-7);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.000001);
                            break;
                    }
                    break;
                //Hectogramo
                case 4:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 10000);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 10);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 1000);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 100);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.1);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.2204622621848776);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 100000);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 3.527396194958041);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 500);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 0.015747304441777);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 1.102311310924388e-4);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 9.842065276110606e-5);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.0001);
                            break;
                    }
                    break;
                //Kilogramo
                case 5:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 100000);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 100);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 10000);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 1000);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 10);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 2.204622621848776);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 1000000);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 35.27396194958041);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 5000);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 0.1574730444177697);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 0.0011023113109244);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 9.842065276110606e-4);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.001);
                            break;
                    }
                    break;
                //Libra
                case 6:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 45359.237);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 45.359237);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 4535.9237);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 453.59237);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 4.5359237);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.45359237);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 453592.37);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 16);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 2267.96185);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 0.0714285714285714);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 0.0005);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 4.464285714285714e-4);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.00045359237);
                            break;
                    }
                    break;
                //Miligramo
                case 7:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 0.1);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.0001);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.01);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.001);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.00001);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.000001);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 2.204622621848776e-6);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 3.527396194958041e-5);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 0.005);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 1.574730444177697e-7);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 1.102311310924388e-9);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 9.842065276110606e-10);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.000000001);
                            break;
                    }
                    break;
                //Onza
                case 8:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 2834.9523125);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 2.8349523125);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 283.49523125);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 28.349523125);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.28349523125);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.028349523125);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.0625);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 28349.523125);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 141.747615625);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 0.0044642857142857);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 0.00003125);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 2.790178571428571e-5);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.000028349523125);
                            break;
                    }
                    break;
                //Quilate
                case 9:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 20);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.02);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 2);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.2);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.002);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.0002);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 4.409245243697552e-4);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 200);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 0.0070547923899161);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 3.149460888355394e-5);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 2.204622621848776e-7);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 1.968413055222121e-7);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.0000002);
                            break;
                    }
                    break;
                //Stone
                case 10:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 635029.318);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 635.029318);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 63502.9318);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 6350.29318);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 63.5029318);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 6.35029318);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 14);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 6350293.18);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 224);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 31751.4659);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 0.007);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 0.00625);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.00635029318);
                            break;
                    }
                    break;
                //Tonelada corta
                case 11:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 90718474);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 90718.474);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 9071847.4);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 907184.74);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 9071.8474);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 907.18474);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 2000);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 907184740);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 32000);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 4535923.7);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 142.8571428571429);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 0.8928571428571429);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.90718474);
                            break;
                    }
                    break;
                //Tonelada larga
                case 12:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 101604690.88);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 101604.69088);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 10160469.088);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 1016046.9088);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 10160.469088);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 1016.0469088);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 2240);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 1016046908.8);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 35840);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 5080234.544);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 160);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 1.12);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 1.0160469088);
                            break;
                    }
                    break;
                //Tonelada métrica
                case 13:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 100000000);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 100000);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 10000000);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 1000000);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 10000);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 1000);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 2204.622621848776);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 1000000000);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 35273.96194958041);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 5000000);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 157.4730444177697);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 1.102311310924388);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 0.9842065276110606);
                            break;
                    }
                    break;
            }
        }

        private void Potencia(double valor)//ya
        {
           switch (comboBox2.SelectedIndex)
           {
                //BTU/minuto
                case 0:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.0235808900293295);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.0175842666666667);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 778.1693709678747);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 17.58426666666667);
                            break;
                    }
                    break;
                //Caballo
                case 1:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 42.40722037023268);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.7456998715822702);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 33000.00000000001);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 745.6998715822702);
                            break;
                    }
                    break;
                //Kilovatio
                case 2:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 56.86901927480627);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 1.341022089595028);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 44253.72895663593);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 1000);
                            break;
                    }
                    break;
                //Pie-libra/minuto
                case 3:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 0.0012850672839464);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 3.030303030303029e-5);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 2.259696580552333e-5);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.0225969658055233);
                            break;
                    }
                    break;
                //Vatio
                case 4:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 0.0568690192748063);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.001341022089595);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.001);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 44.25372895663593);
                            break;
                    }
                    break;
           }
        }

        private void Presion(double valor)//ya
        {
            switch (comboBox2.SelectedIndex)
            {
                //Atmósfera
                case 0:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 1.01325);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 101.325);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 14.69594940039221);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 760.1275318829707);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 101325);
                            break;
                    }
                    break;
                //Bar
                case 1:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 0.9869232667160128);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 100);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 14.50377438972831);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 750.1875468867217);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 100000);
                            break;
                    }
                    break;
                //Kilopascal
                case 2:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 0.0098692326671601);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.01);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.1450377438972831);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 7.501875468867217);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 1000);
                            break;
                    }
                    break;
                //Libra por pulgada cuadrada (PSI)
                case 3:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 0.068045961016531);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.06894757);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 6.894757);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 51.72360840210053);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 6894.757);
                            break;
                    }
                    break;
                //Milímetro de mercurio
                case 4:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 0.0013155687145324);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.001333);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.1333);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.0193335312615078);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 133.3);
                            break;
                    }
                    break;
                //Pascal
                case 5:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 9.869232667160128e-6);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.00001);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.001);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 1.450377438972831e-4);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.0075018754688672);
                            break;
                    }
                    break;
            }
        }

        private void Temperatura(double valor)//ya
        {
            switch (comboBox2.SelectedIndex)
            {
                //Grados Celsius
                case 0:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 33.8);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 274.15);
                            break;
                    }
                    break;
                //Grados Fahrenheit
                case 1:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * -17.22222222222222);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 255.9277777777778);
                            break;
                    }
                    break;
                //Kelvin
                case 2:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * -272.15);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * -457.87);
                            break;
                    }
                    break;
            }
        }

        private void Velocidad(double valor)//ya
        {
           switch (comboBox2.SelectedIndex)
           {
              //Centímetro por segundo
              case 0:
                 switch (comboBox3.SelectedIndex)
                 {
                    //Kilómetro por hora
                    case 1:
                       textBox2.Text = Convert.ToString(valor * 0.036);
                       break;
                    //Mach (a atm estándar)
                    case 2:
                       textBox2.Text = Convert.ToString(valor * 2.938641460175678e-5);
                       break;
                    //Metro por segundo
                    case 3:
                       textBox2.Text = Convert.ToString(valor * 0.01);
                       break;
                    //Millas por hora
                    case 4:
                       textBox2.Text = Convert.ToString(valor * 0.022369362920544);
                       break;
                    //Nudos
                    case 5:
                       textBox2.Text = Convert.ToString(valor * 0.019438444924406);
                       break;
                    ////Pies por segundo
                    case 6:
                       textBox2.Text = Convert.ToString(valor * 0.0328083989501312);
                       break;
                 }
                 break;
              //Kilómetro por hora
              case 1:
                 switch (comboBox3.SelectedIndex)
                 {
                    //Centímetro por segundo
                    case 0:
                       textBox2.Text = Convert.ToString(valor * 27.77777777777778);
                       break;
                    //Mach (a atm estándar)
                    case 2:
                       textBox2.Text = Convert.ToString(valor * 8.162892944932439e-4);
                       break;
                    //Metro por segundo
                    case 3:
                       textBox2.Text = Convert.ToString(valor * 0.2777777777777778);
                       break;
                    //Millas por hora
                    case 4:
                       textBox2.Text = Convert.ToString(valor * 0.621371192237334);
                       break;
                    //Nudos
                    case 5:
                       textBox2.Text = Convert.ToString(valor * 0.5399568034557235);
                       break;
                    ////Pies por segundo
                    case 6:
                       textBox2.Text = Convert.ToString(valor * 0.9113444152814232);
                       break;
                 }
                 break;
              //Mach (a atm estándar)
              case 2:
                 switch (comboBox3.SelectedIndex)
                 {
                    //Centímetro por segundo
                    case 0:
                       textBox2.Text = Convert.ToString(valor * 34029.33);
                       break;
                    //Kilómetro por hora
                    case 1:
                       textBox2.Text = Convert.ToString(valor * 1225.05588);
                       break;
                    //Metro por segundo
                    case 3:
                       textBox2.Text = Convert.ToString(valor * 340.2933);
                       break;
                    //Millas por hora
                    case 4:
                       textBox2.Text = Convert.ToString(valor * 761.2144327129563);
                       break;
                    //Nudos
                    case 5:
                       textBox2.Text = Convert.ToString(valor * 661.4772570194384);
                       break;
                    ////Pies por segundo
                    case 6:
                       textBox2.Text = Convert.ToString(valor * 1116.447834645669);
                       break;
                 }
                 break;
            //Metro por segundo
            case 3:
                 switch (comboBox3.SelectedIndex)
                 {
                    //Centímetro por segundo
                    case 0:
                       textBox2.Text = Convert.ToString(valor * 100);
                       break;
                    //Kilómetro por hora
                    case 1:
                       textBox2.Text = Convert.ToString(valor * 3.6);
                       break;
                    //Mach (a atm estándar)
                    case 2:
                       textBox2.Text = Convert.ToString(valor * 0.0029386414601757);
                       break;
                    //Millas por hora
                    case 4:
                       textBox2.Text = Convert.ToString(valor * 2.236936292054402);
                       break;
                    //Nudos
                    case 5:
                       textBox2.Text = Convert.ToString(valor * 1.943844492440605);
                       break;
                    ////Pies por segundo
                    case 6:
                       textBox2.Text = Convert.ToString(valor * 3.280839895013123);
                       break;
                 }
                 break;
            //Millas por hora
            case 4:
                 switch (comboBox3.SelectedIndex)
                 {
                    //Centímetro por segundo
                    case 0:
                       textBox2.Text = Convert.ToString(valor * 44.704);
                       break;
                    //Kilómetro por hora
                    case 1:
                       textBox2.Text = Convert.ToString(valor * 1.609344);
                       break;
                    //Mach (a atm estándar)
                    case 2:
                       textBox2.Text = Convert.ToString(valor * 0.0013136902783569);
                       break;
                    //Metro por segundo
                    case 3:
                       textBox2.Text = Convert.ToString(valor * 0.44704);
                       break;
                    //Nudos
                    case 5:
                       textBox2.Text = Convert.ToString(valor * 0.8689762419006479);
                       break;
                    ////Pies por segundo
                    case 6:
                       textBox2.Text = Convert.ToString(valor * 1.466666666666667);
                       break;
                 }
                 break;
            //Nudos
            case 5:
                 switch (comboBox3.SelectedIndex)
                 {
                    //Centímetro por segundo
                    case 0:
                       textBox2.Text = Convert.ToString(valor * 51.44444444444444);
                       break;
                    //Kilómetro por hora
                    case 1:
                       textBox2.Text = Convert.ToString(valor * 1.852);
                       break;
                    //Mach (a atm estándar)
                    case 2:
                       textBox2.Text = Convert.ToString(valor * 0.0015117677734015);
                       break;
                    //Metro por segundo
                    case 3:
                       textBox2.Text = Convert.ToString(valor * 0.5144444444444444);
                       break;
                    //Millas por hora
                    case 4:
                       textBox2.Text = Convert.ToString(valor * 1.150779448023543);
                       break;
                    ////Pies por segundo
                    case 6:
                       textBox2.Text = Convert.ToString(valor * 1.687809857101196);
                       break;
                 }
                 break;
            //Pies por segundo
            case 6:
                 switch (comboBox3.SelectedIndex)
                 {
                    //Centímetro por segundo
                    case 0:
                       textBox2.Text = Convert.ToString(valor * 30.48);
                       break;
                    //Kilómetro por hora
                    case 1:
                       textBox2.Text = Convert.ToString(valor * 1.09728);
                       break;
                    //Mach (a atm estándar)
                    case 2:
                       textBox2.Text = Convert.ToString(valor * 8.956979170615466e-4);
                       break;
                    //Metro por segundo
                    case 3:
                       textBox2.Text = Convert.ToString(valor * 0.3048);
                       break;
                    //Millas por hora
                    case 4:
                       textBox2.Text = Convert.ToString(valor * 0.6818181818181818);
                       break;
                    //Nudos
                    case 5:
                       textBox2.Text = Convert.ToString(valor * 0.5924838012958963);
                       break;
                 }
                 break;
           }
        }

        private void Volumen(double valor)//ya
        {
            switch (comboBox2.SelectedIndex)
            {
                //Centímetro cúbico
                case 0:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.0010566882094326);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 8.798769931963512e-4);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 2.641720523581484e-4);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 2.199692482990878e-4);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.001);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.000001);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 0.033814022701843);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 0.035195079727854);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 3.531466672148859e-5);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 0.0021133764188652);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 0.0017597539863927);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 0.0610237440947323);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 1.307950619314392e-6);
                            break;
                    }
                    break;
                //Cuarto de galón (EE.UU.)
                case 1:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 946.352946);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.8326741846289889);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.25);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.2081685461572472);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.946352946);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.000946352946);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 32);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 33.30696738515955);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 0.0334201388888889);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 2);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 1.665348369257978);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 57.75);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.0012377829218107);
                            break;
                    }
                    break;
                //Cuarto de galón (R.U.)
                case 2:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 1136.5225);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 1.200949925504855);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.3002374813762137);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.25);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 1.1365225);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.0011365225);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 38.43039761615536);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 40);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 0.040135913308973);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 2.40189985100971);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 2);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 69.35485819790537);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.0014865153077397);
                            break;
                    }
                    break;
                //Galón (EE.UU.)
                case 3:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 3785.411784);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 4);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 3.330696738515955);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.8326741846289889);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 3.785411784);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.003785411784);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 128);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 133.2278695406382);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 0.1336805555555556);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 8);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 6.661393477031911);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 231);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.0049511316872428);
                            break;
                    }
                    break;
                //Galón (R.U.)
                case 4:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 4546.09);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 4.80379970201942);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 4);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 1.200949925504855);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 4.54609);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.00454609);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 153.7215904646214);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 160);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 0.1605436532358921);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 9.607599404038839);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 8);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 277.4194327916215);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.005946061230959);
                            break;
                    }
                    break;
                //Litro
                case 5:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 1000);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 1.056688209432594);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.8798769931963512);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.2641720523581484);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.2199692482990878);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.001);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 33.814022701843);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 35.19507972785405);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 0.0353146667214886);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 2.113376418865187);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 1.759753986392702);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 61.02374409473228);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.0013079506193144);
                            break;
                    }
                    break;
                //Metro cúbico
                case 6:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 1000000);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 1056.688209432594);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 879.8769931963512);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 264.1720523581484);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 219.9692482990878);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 1000);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 33814.022701843);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 35195.07972785405);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 35.31466672148859);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 2113.376418865187);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 1759.753986392702);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 61023.74409473228);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 1.307950619314392);
                            break;
                    }
                    break;
                //Onza líquida (EE.UU.)
                case 7:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 29.5735295625);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.03125);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.0260210682696559);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.0078125);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.006505267067414);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.0295735295625);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.0000295735295625);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 1.040842730786236);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 0.0010443793402778);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 0.0625);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 0.0520421365393118);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 1.8046875);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 3.868071630658436e-5);
                            break;
                    }
                    break;
                //Onza líquida (R.U.)
                case 8:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 28.4130625);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.0300237481376214);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.025);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.0075059370344053);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.00625);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.0284130625);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.0000284130625);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 0.9607599404038839);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 0.0010033978327243);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 0.0600474962752427);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 0.05);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 1.733871454947634);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 3.716288269349353e-5);
                            break;
                    }
                    break;
                //Pies cúbicos
                case 9:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 28316.846592);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 29.92207792207792);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 24.9153418361713);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 7.480519480519481);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 6.228835459042826);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 28.316846592);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.028316846592);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 957.5064935064935);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 996.6136734468521);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 59.84415584415584);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 49.83068367234261);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 1728);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 0.037037037037037);
                            break;
                    }
                    break;
                //Pinta (EE.UU.)
                case 10:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 473.176473);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.5);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.4163370923144944);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.125);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.1040842730786236);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.473176473);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.000473176473);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 16);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 16.65348369257978);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 0.0167100694444444);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 0.8326741846289889);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 28.875);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 6.188914609053498e-4);
                            break;
                    }
                    break;
                //Pinta (R.U.)
                case 11:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 568.26125);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.6004749627524275);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.5);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.1501187406881069);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.125);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.56826125);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.00056826125);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 19.21519880807768);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 20);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 0.0200679566544865);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 1.200949925504855);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 34.67742909895269);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 7.432576538698707e-4);
                            break;
                    }
                    break;
                //Pulgada cúbica
                case 12:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 16.387064);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 0.0173160173160173);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 0.0144186005996362);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 0.0043290043290043);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 0.003604650149909);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 0.016387064);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.000016387064);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 0.5541125541125541);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 0.5767440239854468);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 5.787037037037037e-4);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 0.0346320346320346);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 0.0288372011992723);
                            break;
                        //
                        case 13:
                            textBox2.Text = Convert.ToString(valor * 2.143347050754458e-5);
                            break;
                    }
                    break;
                //Yarda cúbica
                case 13:
                    switch (comboBox3.SelectedIndex)
                    {
                        //
                        case 0:
                            textBox2.Text = Convert.ToString(valor * 764554.857984);
                            break;
                        //
                        case 1:
                            textBox2.Text = Convert.ToString(valor * 807.8961038961039);
                            break;
                        //
                        case 2:
                            textBox2.Text = Convert.ToString(valor * 672.7142295766252);
                            break;
                        //
                        case 3:
                            textBox2.Text = Convert.ToString(valor * 201.974025974026);
                            break;
                        //
                        case 4:
                            textBox2.Text = Convert.ToString(valor * 168.1785573941563);
                            break;
                        //
                        case 5:
                            textBox2.Text = Convert.ToString(valor * 764.554857984);
                            break;
                        //
                        case 6:
                            textBox2.Text = Convert.ToString(valor * 0.764554857984);
                            break;
                        //
                        case 7:
                            textBox2.Text = Convert.ToString(valor * 25852.67532467532);
                            break;
                        //
                        case 8:
                            textBox2.Text = Convert.ToString(valor * 26908.56918306501);
                            break;
                        //
                        case 9:
                            textBox2.Text = Convert.ToString(valor * 27);
                            break;
                        //
                        case 10:
                            textBox2.Text = Convert.ToString(valor * 1615.792207792208);
                            break;
                        //
                        case 11:
                            textBox2.Text = Convert.ToString(valor * 1345.42845915325);
                            break;
                        //
                        case 12:
                            textBox2.Text = Convert.ToString(valor * 46656);
                            break;
                    }
                    break;
            }
        }
        
        private void Validar()//ya
        {
            double valor;
            if (textBox1.Text.Length > 0 && textBox1.Text != "Escribir valor")
            {
                if (double.TryParse(textBox1.Text, out valor))
                   this.Accion1(valor);
                else
                   textBox2.Text = Convert.ToString(valor);                
            }
            else
                textBox2.Text = "";
            if (textBox1.Width != 345)
            {
                errorProvider1.SetError(textBox1, "");
                ModificarTextBox(textBox1,false);
            }
        }

        private bool TieneCerosIzquierda(TextBox control, char caracter)//ya
        {
            string s = control.Text;
            switch (caracter)
            {
                case '-':
                    s = s.Remove(control.SelectionStart, control.SelectionLength).Insert(control.SelectionStart, caracter.ToString());
                    if (s.LastIndexOf('-') != 0)
                    {
                        errorProvider1.SetError(control, "ERROR\nEl caracter '-' ya existe o no se encuentra en la primera posición en la cadena resultante '" + s + "'");
                        return true;
                    }
                    else
                        return Resultado(control, s);                    
                case ',':
                    s = s.Remove(control.SelectionStart, control.SelectionLength).Insert(control.SelectionStart, caracter.ToString());
                    if (s.IndexOf(',') != s.LastIndexOf(',') || (s.IndexOf('-') > 0))
                    {
                        errorProvider1.SetError(control, "ERROR\nEl caracter ',' ya existe o se encuentra justo delante de un caracter '-' en la cadena resultante '" + s + "'");
                        return true;
                    }
                    break;
                case (char)Keys.Delete:
                    if(!(control.SelectionStart == control.TextLength && control.SelectionLength == 0))
                        return Resultado(control, DevolverCadena(control, caracter));                                           
                    break;
                case (char)Keys.Back:
                    if(!(control.SelectionStart == 0 && control.SelectionLength == 0))
                        return Resultado(control, DevolverCadena(control, caracter));                                           
                    break;
                case (char)Keys.D0:
                case (char)Keys.D1:
                case (char)Keys.D2:
                case (char)Keys.D3:
                case (char)Keys.D4:
                case (char)Keys.D5:
                case (char)Keys.D6:
                case (char)Keys.D7:
                case (char)Keys.D8:
                case (char)Keys.D9:
                    return Resultado(control, DevolverCadena(control, caracter));                
            }            
            return false;
        }

        private bool Resultado(TextBox control, string s)//ya
        {
            if (s.Length > 1)
            {
                if (!(s[0] == ',' || s[1] == ',' || ((s[0] > 48 && s[0] < 58) && s[1] != '-') || (s[0] == '-' && (s[1] > 48 && s[1] < 58))))
                    if (s[1] == '-')
                    {
                        errorProvider1.SetError(control, "ERROR\nEl caracter '-' debe encontrarse en la primera posición en la cadena resultante '" + s + "'");
                        return true;
                    }
                    else if (s[0] == '0')
                    {
                        errorProvider1.SetError(control, "ERROR\nNo pueden existir ceros a la izquierda en la cadena resultante '" + s + "'");
                        return true;
                    }
                    else if (s.Length > 2 && (s[0] == '-' && s[1] == '0' && s[2] != ','))
                    {
                        errorProvider1.SetError(control, "ERROR\n No pueden existir ceros a la izquierda en la cadena resultante '" + s + "'");
                        return true;
                    }
            }
            return false;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)//ya
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (TieneCerosIzquierda(textBox1, (char)e.KeyCode))
                {
                    ModificarTextBox(textBox1,true);
                    Ding.Play();
                    e.Handled = true;
                }
                else
                {
                    errorProvider1.SetError(textBox1, "");
                    ModificarTextBox(textBox1,false);
                }              
            }
        }

        private void ModificarTextBox(TextBox control,bool valor)//ya
        {
            if (valor)
            {
                if(control.Name.Equals(textBox1.Name))
                   control.Width = 328;
                else
                   control.Width = 134;
            }
            else
            {
                if (control.Name.Equals(textBox1.Name))
                    control.Width = 345;
                else
                    control.Width = 151;
            }
        }

        private void textBox22_MouseDown(object sender, MouseEventArgs e)
        {
            v = true;
            pos = textBox22.SelectionStart;
        }

        private void textBox22_MouseUp(object sender, MouseEventArgs e)
        {
            v = false;
        }

        private void textBox22_MouseMove(object sender, MouseEventArgs e)
        {
            textBox22.Cursor = Cursors.Arrow;
            if (v)
            {
                textBox22.Select(pos, 0);
                textBox22.SelectionStart = pos;
            }
        }

        private void textBox22_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                Ding.Play();
                Handled = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                textBox22.Text = "0";
                SePuede = true;
                textBox22.SelectionStart = 1;
                mr3 = false;
                Handled = true;
            }
            else if (e.KeyCode == Keys.Return)
            {
                Operacion2();
                Handled = true;
            }
            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Multiply || e.KeyCode == Keys.Divide)
            {
                switch (e.KeyCode)
                { 
                    case Keys.Add:
                        Operacion("+");
                        break;
                    case Keys.Subtract:
                        Operacion("-");
                        break;
                    case Keys.Multiply:
                        Operacion("*");
                        break;
                    case Keys.Divide:
                        Operacion("/");
                        break;
                }                
                SePuede = false;
                Handled = true;
            }
        }

        private void textBox22_DoubleClick(object sender, EventArgs e)
        {
            textBox22.Select(textBox22.TextLength, 0);
            textBox22.Focus();
        }

        private void textBox22_Click(object sender, EventArgs e)
        {
            textBox22.Select(textBox22.TextLength, 0);
            textBox22.Focus();
        }

        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Back 
            //estandar> 0..9 , + - * / % = Delete
            //cientifica> 0..9 , + - * / = Delete
            //programador(bin)> 0..1 + - * / = Delete                 radiobutton6
            //programador(oct)> 0..7 + - * / = Delete                 radiobutton7
            //programador(dec)> 0..9 + - * / = Delete                 radiobutton5
            //programador(hex)> 0..9 + - * / = A..F a..f Delete       radiobutton4
            //estadistica> 0..9 ,
            if (!Handled)
            {
                if ((e.KeyChar != (char)Keys.Back) &&
                   (
                   (estándarToolStripMenuItem.Checked && (e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != ',' && e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '*' && e.KeyChar != '/' && e.KeyChar != '%' && e.KeyChar != '=') ||
                   (científicaToolStripMenuItem.Checked && (e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != ',' && e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '*' && e.KeyChar != '/' && e.KeyChar != '=') ||
                   (programadorToolStripMenuItem.Checked && radioButton6.Checked && (e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D1) && e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '*' && e.KeyChar != '/' && e.KeyChar != '=') ||
                   (programadorToolStripMenuItem.Checked && radioButton7.Checked && (e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D7) && e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '*' && e.KeyChar != '/' && e.KeyChar != '=') ||
                   (programadorToolStripMenuItem.Checked && radioButton5.Checked && (e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '*' && e.KeyChar != '/' && e.KeyChar != '=') ||
                   (programadorToolStripMenuItem.Checked && radioButton4.Checked && (e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '*' && e.KeyChar != '/' && e.KeyChar != '=' && (e.KeyChar < 65 || e.KeyChar > 70) && (e.KeyChar < 97 || e.KeyChar > 102)) ||
                   (estadísticasToolStripMenuItem.Checked && (e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != ',')
                   )
                )
                    e.KeyChar = (char)Keys.Escape;
                else if (e.KeyChar == (char)Keys.Back)
                {
                    if (SePuede)
                    {
                        if (textBox22.TextLength == 1)
                        {
                            if (textBox22.Text != "0")
                            {
                                textBox22.Text = "";
                                e.KeyChar = '0';
                                textBox22.Select(textBox22.TextLength, 0);
                            }
                            else
                                e.KeyChar = (char)Keys.Escape;
                        }
                        else if (textBox22.TextLength == 2 && textBox22.Text[0] == '-')
                        {
                            textBox22.Text = "";
                            e.KeyChar = '0';
                            textBox22.Select(textBox22.TextLength, 0);
                        }
                    }
                    else
                        e.KeyChar = (char)Keys.Escape;
                }
                else if ((e.KeyChar >= 65 && e.KeyChar <= 70) || (e.KeyChar >= 97 && e.KeyChar <= 102))
                {
                    if (!SePuede)
                    {
                        textBox22.Text = "0";
                        SePuede = true;
                    }
                    if (mr3)
                    {
                        textBox22.Text = "0";
                    }
                    if (textBox22.Text == "0")
                        textBox22.Text = "";
                    if (PuedeImprimir(e.KeyChar))
                    {
                        e.KeyChar = System.Convert.ToChar(e.KeyChar.ToString().ToUpper());
                        if (mr3)
                            mr3 = false;
                    }
                    else
                        e.KeyChar = (char)Keys.Escape;
                }
                else if (e.KeyChar >= (char)Keys.D0 && e.KeyChar <= (char)Keys.D9)
                {
                    if (!SePuede)
                    {
                        textBox22.Text = "0";
                        SePuede = true;
                    }
                    if(mr3)
                        textBox22.Text = "0";
                    if (textBox22.Text == "0")
                        textBox22.Text = "";
                    if (!PuedeImprimir(e.KeyChar))
                        e.KeyChar = (char)Keys.Escape;
                    else if(mr3)
                        mr3 = false;
                }
                else if (e.KeyChar == ',')
                {
                    if (!SePuede)
                    {
                        textBox22.Text = "0";
                        SePuede = true;
                    }
                    if (mr3)
                       textBox22.Text = "0";
                    if (TieneCerosIzquierda(textBox22, ',') || !PuedeImprimir(','))
                        e.KeyChar = (char)Keys.Escape;
                    else if(mr3)
                        mr3 = false;
                }
                else if (e.KeyChar == '=')
                {
                    textBox22.Text = textBox22.Text.Insert(textBox22.TextLength, "=");
                    e.KeyChar = (char)Keys.Back;
                    mr3 = true;
                    textBox22.Focus();
                }
            }
            else 
            {
               textBox22.Text = textBox22.Text.Insert(textBox22.TextLength, "+"); 
               e.KeyChar = (char)Keys.Back;
               Handled = false;
               textBox22.Focus();
            }
        }

        private void textBox23_DoubleClick(object sender, EventArgs e)
        {
            textBox22.Focus();
        }

        private void textBox23_Click(object sender, EventArgs e)
        {
            textBox22.Focus();
        }

        private string Traducir1(DayOfWeek dia)
        {
            switch (dia)
            {
                case DayOfWeek.Sunday:
                    return "domingo";
                case DayOfWeek.Monday:
                    return "lunes";
                case DayOfWeek.Tuesday:
                    return "martes";
                case DayOfWeek.Wednesday:
                    return "miércoles";
                case DayOfWeek.Thursday:
                    return "jueves";
                case DayOfWeek.Friday:
                    return "viernes";
                case DayOfWeek.Saturday:
                    return "sábado";
            }
            return "";
        }

        private string Traducir2(int mes)
        {
            switch (mes)
            { 
                case 1:
                    return "enero";
                case 2:
                    return "febrero";
                case 3:
                    return "marzo";
                case 4:
                    return "abril";
                case 5:
                    return "mayo";
                case 6:
                    return "junio";
                case 7:
                    return "julio";
                case 8:
                    return "agosto";
                case 9:
                    return "septiembre";
                case 10:
                    return "octubre";
                case 11:
                    return "noviembre";
                case 12:
                    return "diciembre";
            }
            return "";
        }

        private string Calcular(DateTime newdt, DateTime olddt)
        {
            int anos;
            int meses;
            int dias;
            string str = "";

            anos = (newdt.Year - olddt.Year);
            meses = (newdt.Month - olddt.Month);
            dias = (newdt.Day - olddt.Day);

            if (meses <= 0)
            {
                anos -= 1;
                meses += 12;
            }

            if (dias < 0)
            {
                meses -= 1;
                int DiasAno = newdt.Year;
                int DiasMes = newdt.Month;

                if ((newdt.Month - 1) == 0)
                {
                    DiasAno = DiasAno - 1;
                    DiasMes = 12;
                }
                else
                {
                    DiasMes = DiasMes - 1;
                }

                dias += DateTime.DaysInMonth(DiasAno, DiasMes);
            }

            if (meses == 12)
            {
                anos++;
                meses = 0;
            }

            if (anos < 0)
            {
                return "La fecha inicial es mayor a la fecha final";
            }

            if (anos > 0)
            {
                if (anos == 1)
                    str = str + anos.ToString() + " año; ";
                else
                    str = str + anos.ToString() + " años; ";
            }

            if (meses > 0)
            {
                if (meses == 1)
                    str = str + meses.ToString() + " mes; ";
                else
                    str = str + meses.ToString() + " meses; ";
            }

            if (dias > 0)
            {
                int semanas = dias / 7;
                if (semanas > 0)
                {
                    if (semanas == 1)
                        str = str + semanas.ToString() + " semana; ";
                    else
                        str = str + semanas.ToString() + " semanas; ";
                    dias = dias % 7;                    
                }
                if (dias > 0)
                {
                    if (dias == 1)
                        str = str + dias.ToString() + " día; ";
                    else
                        str = str + dias.ToString() + " días; ";
                }
            }
            str = str.Trim();
            return str.Remove(str.Length-1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (this.comboBox4.SelectedIndex)
            {
                case 0:
                    if (dateTimePicker1.Value.Date.Equals(dateTimePicker2.Value.Date))
                       textBox3.Text = textBox4.Text = "Mismas fechas";     
                    else
                    {
                        //Diferencia (años, meses, semanas, días)
                        textBox4.Text = (dateTimePicker1.Value > dateTimePicker2.Value) ? Calcular(dateTimePicker1.Value, dateTimePicker2.Value) : Calcular(dateTimePicker2.Value, dateTimePicker1.Value);
                        //Diferencia (días)
                        int dias = System.Math.Abs(System.Convert.ToInt32(dateTimePicker1.Value.Subtract(dateTimePicker2.Value).TotalDays));
                        textBox3.Text = (dias == 1) ? "1 día" : dias.ToString() + " días";
                    }
                    textBox4.Focus();
                    textBox4.Select(0,0);
                    break;
                case 1:
                    if(radioButton12.Checked)
                        textBox24.Text = Traducir1(dateTimePicker1.Value.AddDays(Convert.ToDouble(numericUpDown3.Value)).AddMonths(Convert.ToInt32(numericUpDown2.Value)).AddYears(Convert.ToInt32(numericUpDown1.Value)).DayOfWeek) + ", " + dateTimePicker1.Value.AddDays(Convert.ToDouble(numericUpDown3.Value)).Day.ToString() + " de " + Traducir2(dateTimePicker1.Value.AddMonths(Convert.ToInt32(numericUpDown2.Value)).Month) + " de " + dateTimePicker1.Value.AddYears(Convert.ToInt32(numericUpDown1.Value)).Year.ToString();
                    else if(radioButton13.Checked)
                        textBox24.Text = Traducir1(dateTimePicker1.Value.AddDays(Convert.ToDouble(-1 * numericUpDown3.Value)).AddMonths(Convert.ToInt32(-1 * numericUpDown2.Value)).AddYears(Convert.ToInt32(-1 * numericUpDown1.Value)).DayOfWeek) + ", " + dateTimePicker1.Value.AddDays(Convert.ToDouble(-1 * numericUpDown3.Value)).Day.ToString() + " de " + Traducir2(dateTimePicker1.Value.AddMonths(Convert.ToInt32(-1 * numericUpDown2.Value)).Month) + " de " + dateTimePicker1.Value.AddYears(Convert.ToInt32(-1 * numericUpDown1.Value)).Year.ToString();
                    textBox24.Focus();
                    textBox24.Select(0,0);
                    break;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox24.Text = "";
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            textBox24.Text = "";
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            textBox24.Text = "";
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            textBox24.Text = "";
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            textBox24.Text = "";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox4.Text = textBox24.Text = "";
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox4.Text = textBox24.Text = "";
        }

        private void comboBox5_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (comboBox5.SelectedIndex)
            {
                case 0:
                    label14.Text = "Precio de compra";
                    label12.Text = "Plazo (años)";
                    label13.Text = "Tipo de interés (%)";
                    label11.Text = "Pago mensual";
                    textBox5.Text = arreglo1[0];
                    textBox6.Text = arreglo1[1];
                    textBox7.Text = arreglo1[2];
                    textBox8.Text = arreglo1[3];
                    textBox9.Text = arreglo1[4];
                    break;
                case 1:
                    label14.Text = "Precio de compra";
                    label12.Text = "Cuota inicial";
                    label13.Text = "Plazo (años)";
                    label11.Text = "Tipo de interés (%)";
                    textBox5.Text = arreglo1[0];
                    textBox6.Text = arreglo1[4];
                    textBox7.Text = arreglo1[1];
                    textBox8.Text = arreglo1[2];
                    textBox9.Text = arreglo1[3];
                    break;
                case 2:
                    label14.Text = "Precio de compra";
                    label12.Text = "Cuota inicial";
                    label13.Text = "Tipo de interés (%)";
                    label11.Text = "Pago mensual";
                    textBox5.Text = arreglo1[0];
                    textBox6.Text = arreglo1[4];
                    textBox7.Text = arreglo1[2];
                    textBox8.Text = arreglo1[3];
                    textBox9.Text = arreglo1[1];
                    break;
                case 3:
                    label14.Text = "Cuota inicial";
                    label12.Text = "Plazo (años)";
                    label13.Text = "Tipo de interés (%)";
                    label11.Text = "Pago mensual";
                    textBox5.Text = arreglo1[4];
                    textBox6.Text = arreglo1[1];
                    textBox7.Text = arreglo1[2];
                    textBox8.Text = arreglo1[3];
                    textBox9.Text = arreglo1[0];
                    break;
            }
            for (int i = 5; i <= 8; i++)
                Cambiar(i);
        }

        private void Cambiar(int valor)
        { 
            switch(valor)
            {
                case 5:
                    if(textBox5.Text != "Escribir valor")
                    {
                       this.textBox5.ResetFont();
                       this.textBox5.ResetForeColor();
                    }
                    else
                    {
                       this.textBox5.ForeColor = SystemColors.InactiveCaptionText;
                       this.textBox5.Font = new Font(this.textBox5.Font, FontStyle.Italic);                    
                    }
                    break;
                case 6:
                    if(textBox6.Text != "Escribir valor")
                    {
                       this.textBox6.ResetFont();
                       this.textBox6.ResetForeColor();
                    }
                    else
                    {
                       this.textBox6.ForeColor = SystemColors.InactiveCaptionText;
                       this.textBox6.Font = new Font(this.textBox6.Font, FontStyle.Italic);                    
                    }
                    break;
                case 7:
                    if(textBox7.Text != "Escribir valor")
                    {
                       this.textBox7.ResetFont();
                       this.textBox7.ResetForeColor();
                    }
                    else
                    {
                       this.textBox7.ForeColor = SystemColors.InactiveCaptionText;
                       this.textBox7.Font = new Font(this.textBox7.Font, FontStyle.Italic);                    
                    }
                    break;
                case 8:
                    if(textBox8.Text != "Escribir valor")
                    {
                       this.textBox8.ResetFont();
                       this.textBox8.ResetForeColor();
                    }
                    else
                    {
                       this.textBox8.ForeColor = SystemColors.InactiveCaptionText;
                       this.textBox8.Font = new Font(this.textBox8.Font, FontStyle.Italic);                    
                    }
                    break;
                case 18:
                    if (textBox18.Text != "Escribir valor")
                    {
                        this.textBox18.ResetFont();
                        this.textBox18.ResetForeColor();
                    }
                    else
                    {
                        this.textBox18.ForeColor = SystemColors.InactiveCaptionText;
                        this.textBox18.Font = new Font(this.textBox18.Font, FontStyle.Italic);
                    }
                    break;
                case 19:
                    if (textBox19.Text != "Escribir valor")
                    {
                        this.textBox19.ResetFont();
                        this.textBox19.ResetForeColor();
                    }
                    else
                    {
                        this.textBox19.ForeColor = SystemColors.InactiveCaptionText;
                        this.textBox19.Font = new Font(this.textBox19.Font, FontStyle.Italic);
                    }
                    break;
                case 20:
                    if (textBox20.Text != "Escribir valor")
                    {
                        this.textBox20.ResetFont();
                        this.textBox20.ResetForeColor();
                    }
                    else
                    {
                        this.textBox20.ForeColor = SystemColors.InactiveCaptionText;
                        this.textBox20.Font = new Font(this.textBox20.Font, FontStyle.Italic);
                    }
                    break;
                case 21:
                    if (textBox21.Text != "Escribir valor")
                    {
                        this.textBox21.ResetFont();
                        this.textBox21.ResetForeColor();
                    }
                    else
                    {
                        this.textBox21.ForeColor = SystemColors.InactiveCaptionText;
                        this.textBox21.Font = new Font(this.textBox21.Font, FontStyle.Italic);
                    }
                    break;
                case 11:
                    if (textBox11.Text != "Escribir valor")
                    {
                        this.textBox11.ResetFont();
                        this.textBox11.ResetForeColor();
                    }
                    else
                    {
                        this.textBox11.ForeColor = SystemColors.InactiveCaptionText;
                        this.textBox11.Font = new Font(this.textBox11.Font, FontStyle.Italic);
                    }
                    break;
                case 12:
                    if (textBox12.Text != "Escribir valor")
                    {
                        this.textBox12.ResetFont();
                        this.textBox12.ResetForeColor();
                    }
                    else
                    {
                        this.textBox12.ForeColor = SystemColors.InactiveCaptionText;
                        this.textBox12.Font = new Font(this.textBox12.Font, FontStyle.Italic);
                    }
                    break;
                case 13:
                    if (textBox13.Text != "Escribir valor")
                    {
                        this.textBox13.ResetFont();
                        this.textBox13.ResetForeColor();
                    }
                    else
                    {
                        this.textBox13.ForeColor = SystemColors.InactiveCaptionText;
                        this.textBox13.Font = new Font(this.textBox13.Font, FontStyle.Italic);
                    }
                    break;
                case 14:
                    if (textBox14.Text != "Escribir valor")
                    {
                        this.textBox14.ResetFont();
                        this.textBox14.ResetForeColor();
                    }
                    else
                    {
                        this.textBox14.ForeColor = SystemColors.InactiveCaptionText;
                        this.textBox14.Font = new Font(this.textBox14.Font, FontStyle.Italic);
                    }
                    break;
                case 15:
                    if (textBox15.Text != "Escribir valor")
                    {
                        this.textBox15.ResetFont();
                        this.textBox15.ResetForeColor();
                    }
                    else
                    {
                        this.textBox15.ForeColor = SystemColors.InactiveCaptionText;
                        this.textBox15.Font = new Font(this.textBox15.Font, FontStyle.Italic);
                    }
                    break;
            }           
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (this.textBox5.Text == "Escribir valor")
            {
                textBox5.Focus();
                this.textBox5.Text = "";
                Cambiar(5);
            }            
            this.textBox5.SelectAll();
            controlFocus = textBox5;
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (this.textBox6.Text == "Escribir valor")
            {
                textBox6.Focus();
                this.textBox6.Text = "";
                Cambiar(6);
            }            
            this.textBox6.SelectAll();
            controlFocus = textBox6;
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (this.textBox7.Text == "Escribir valor")
            {
                textBox7.Focus();
                this.textBox7.Text = "";
                Cambiar(7);
            }            
            this.textBox7.SelectAll();
            controlFocus = textBox7;
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (this.textBox8.Text == "Escribir valor")
            {
                textBox8.Focus();
                this.textBox8.Text = "";
                Cambiar(8);
            }
            this.textBox8.SelectAll();
            controlFocus = textBox8;
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            double valor;
            if (this.textBox8.Text == "" || !double.TryParse(textBox8.Text, out valor))
            {
                this.textBox8.Text = "Escribir valor";
                Cambiar(8);
            }
            if (textBox8.Width != 151)
            {
                errorProvider1.SetError(textBox8, "");
                ModificarTextBox(textBox8, false);
            }            
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            double valor;
            if (this.textBox7.Text == "" || !double.TryParse(textBox7.Text, out valor))
            {
                this.textBox7.Text = "Escribir valor";
                Cambiar(7);
            }
            if (textBox7.Width != 151)
            {
                errorProvider1.SetError(textBox7, "");
                ModificarTextBox(textBox7, false);
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            double valor;
            if (this.textBox6.Text == "" || !double.TryParse(textBox6.Text, out valor))
            {
                this.textBox6.Text = "Escribir valor";
                Cambiar(6);
            }
            if (textBox6.Width != 151)
            {
                errorProvider1.SetError(textBox6, "");
                ModificarTextBox(textBox6, false);
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            double valor;
            if (this.textBox5.Text == "" || !double.TryParse(textBox5.Text, out valor))
            {
                this.textBox5.Text = "Escribir valor";
                Cambiar(5);
            }
            if (textBox5.Width != 151)
            {
                errorProvider1.SetError(textBox5, "");
                ModificarTextBox(textBox5, false);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox5.Text == "" && !textBox5.Focused)
                textBox5.Text = "Escribir valor";
            switch (comboBox5.SelectedIndex)
            { 
                case 0:
                    arreglo1[0] = textBox5.Text; 
                    break;
                case 1:
                    arreglo1[0] = textBox5.Text;
                    break;
                case 2:
                    arreglo1[0] = textBox5.Text;
                    break;
                case 3:
                    arreglo1[4] = textBox5.Text;
                    break;
            }
            Cambiar(5);
            if (textBox5.Width != 151)
            {
                errorProvider1.SetError(textBox5, "");
                ModificarTextBox(textBox5, false);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox6.Text == "" && !textBox6.Focused)
                textBox6.Text = "Escribir valor";
            switch (comboBox5.SelectedIndex)
            {
                case 0:
                    arreglo1[1] = textBox6.Text;
                    break;
                case 1:
                    arreglo1[4] = textBox6.Text;
                    break;
                case 2:
                    arreglo1[4] = textBox6.Text;
                    break;
                case 3:
                    arreglo1[1] = textBox6.Text;
                    break;
            }
            Cambiar(6);
            if (textBox6.Width != 151)
            {
                errorProvider1.SetError(textBox6, "");
                ModificarTextBox(textBox6, false);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox7.Text == "" && !textBox7.Focused)
                textBox7.Text = "Escribir valor";
            switch (comboBox5.SelectedIndex)
            {
                case 0:
                    arreglo1[2] = textBox7.Text;
                    break;
                case 1:
                    arreglo1[1] = textBox7.Text;
                    break;
                case 2:
                    arreglo1[2] = textBox7.Text;
                    break;
                case 3:
                    arreglo1[2] = textBox7.Text;
                    break;
            }
            Cambiar(7);
            if (textBox7.Width != 151)
            {
                errorProvider1.SetError(textBox7, "");
                ModificarTextBox(textBox7, false);
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox8.Text == "" && !textBox8.Focused)
                textBox8.Text = "Escribir valor";
            switch (comboBox5.SelectedIndex)
            {
                case 0:
                    arreglo1[3] = textBox8.Text;
                    break;
                case 1:
                    arreglo1[2] = textBox8.Text;
                    break;
                case 2:
                    arreglo1[3] = textBox8.Text;
                    break;
                case 3:
                    arreglo1[3] = textBox8.Text;
                    break;
            }
            Cambiar(8);
            if (textBox8.Width != 151)
            {
                errorProvider1.SetError(textBox8, "");
                ModificarTextBox(textBox8, false);
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox9.Text == "Escribir valor")
                textBox9.Text = "";
            switch (comboBox5.SelectedIndex)
            {
                case 0:
                    arreglo1[4] = textBox9.Text;
                    break;
                case 1:
                    arreglo1[3] = textBox9.Text;
                    break;
                case 2:
                    arreglo1[1] = textBox9.Text;
                    break;
                case 3:
                    arreglo1[0] = textBox9.Text;
                    break;
            }
        } 

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "Escribir valor" || textBox5.TextLength == 0)
            {
                if (comboBox5.SelectedIndex == 3)
                    errorProvider1.SetError(textBox5, "La \'" + label14.Text + "\' no puede estar en blanco");
                else
                    errorProvider1.SetError(textBox5, "El \'" + label14.Text + "\' no puede estar en blanco");                 
                ModificarTextBox(textBox5, true);
            }
            else if (System.Convert.ToDouble(textBox5.Text) < 0)
            {
                if (comboBox5.SelectedIndex == 3)
                    errorProvider1.SetError(textBox5, "La \'" + label14.Text + "\' no puede contener un valor negativo");
                else
                    errorProvider1.SetError(textBox5, "El \'" + label14.Text + "\' no puede contener un valor negativo");
                ModificarTextBox(textBox5, true);                
            }
            else if (textBox6.Text == "Escribir valor" || textBox6.TextLength == 0)
            {
                if (comboBox5.SelectedIndex == 1 || comboBox5.SelectedIndex == 2)
                    errorProvider1.SetError(textBox6, "La \'" + label12.Text + "\' no puede estar en blanco");
                else
                    errorProvider1.SetError(textBox6, "El \'" + label12.Text + "\' no puede estar en blanco");
                ModificarTextBox(textBox6, true);
            }
            else if (System.Convert.ToDouble(textBox6.Text) < 0)
            {
                if (comboBox5.SelectedIndex == 1 || comboBox5.SelectedIndex == 2)
                    errorProvider1.SetError(textBox6, "La \'" + label12.Text + "\' no puede contener un valor negativo");
                else
                    errorProvider1.SetError(textBox6, "El \'" + label12.Text + "\' no puede contener un valor negativo");
                ModificarTextBox(textBox6, true);
            }
            else if (textBox7.Text == "Escribir valor" || textBox7.TextLength == 0)
            {
                errorProvider1.SetError(textBox7, "El \'" + label13.Text + "\' no puede estar en blanco");
                ModificarTextBox(textBox7, true);
            }
            else if (System.Convert.ToDouble(textBox7.Text) < 0)
            {
                errorProvider1.SetError(textBox7, "El \'" + label13.Text + "\' no puede contener un valor negativo");
                ModificarTextBox(textBox7, true);
            }
            else if (textBox8.Text == "Escribir valor" || textBox8.TextLength == 0)
            {
                errorProvider1.SetError(textBox8, "El \'" + label11.Text + "\' no puede estar en blanco");
                ModificarTextBox(textBox8, true);
            }
            else if (System.Convert.ToDouble(textBox8.Text) < 0)
            {
                errorProvider1.SetError(textBox8, "El \'" + label11.Text + "\' no puede contener un valor negativo");
                ModificarTextBox(textBox8, true);
            }
            else
                switch (comboBox5.SelectedIndex)
                {
                    case 0:
                        //ok
                        textBox9.Text = ((-(System.Convert.ToDouble(textBox8.Text) * (1 - System.Math.Pow(1 + ((System.Convert.ToDouble(textBox7.Text) / 100) / 12), -(System.Convert.ToDouble(textBox6.Text) * 12)))) + (System.Convert.ToDouble(textBox5.Text) * ((System.Convert.ToDouble(textBox7.Text) / 100) / 12))) / ((System.Convert.ToDouble(textBox7.Text) / 100) / 12)).ToString();
                        break;
                    case 1:
                        //ok
                        textBox9.Text = (((System.Convert.ToDouble(textBox5.Text) - System.Convert.ToDouble(textBox6.Text)) * ((System.Convert.ToDouble(textBox8.Text) / 100) / 12)) / (1 - System.Math.Pow(1 + ((System.Convert.ToDouble(textBox8.Text) / 100) / 12), -(System.Convert.ToDouble(textBox7.Text) * 12)))).ToString();
                        break;
                    case 2:
                        //ok
                        textBox9.Text = ((System.Math.Log((System.Convert.ToDouble(textBox8.Text)) / ((System.Convert.ToDouble(textBox8.Text))-((System.Convert.ToDouble(textBox5.Text) - System.Convert.ToDouble(textBox6.Text))*((System.Convert.ToDouble(textBox7.Text) / 100) / 12))))) / ((System.Math.Log(1+((System.Convert.ToDouble(textBox7.Text) / 100) / 12)))*12)).ToString();
                        break;
                    case 3:
                        //ok
                        textBox9.Text = ((((System.Convert.ToDouble(textBox8.Text)) * (1 - System.Math.Pow(1 + ((System.Convert.ToDouble(textBox7.Text) / 100) / 12), -(System.Convert.ToDouble(textBox6.Text) * 12)))) + ((System.Convert.ToDouble(textBox5.Text)) * ((System.Convert.ToDouble(textBox7.Text) / 100) / 12))) / ((System.Convert.ToDouble(textBox7.Text) / 100) / 12)).ToString();
                        break;
                }
            textBox9.Focus();
            textBox9.Select(0, 0);
        }

        private void comboBox8_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (comboBox8.SelectedIndex)
            {
                case 0:
                    label23.Text = "Distancia (kilómetros)";
                    label22.Text = "Consumo de combustible (I/100 km)";                    
                    textBox18.Text = arreglo4[0];
                    textBox19.Text = arreglo4[1];
                    textBox16.Text = arreglo4[2];                    
                    break;
                case 1:
                    label23.Text = "Distancia (kilómetros)";
                    label22.Text = "Combustible usado (litros)";                    
                    textBox18.Text = arreglo4[0];
                    textBox19.Text = arreglo4[2];
                    textBox16.Text = arreglo4[1];
                    break;
                case 2:
                    label23.Text = "Combustible usado (litros)";
                    label22.Text = "Consumo de combustible (I/100 km)";                    
                    textBox18.Text = arreglo4[2];
                    textBox19.Text = arreglo4[1];
                    textBox16.Text = arreglo4[0];
                    break;                
            }
            Cambiar(18);
            Cambiar(19);
        }

        private void textBox18_Enter(object sender, EventArgs e)
        {
            if (this.textBox18.Text == "Escribir valor")
            {
                textBox18.Focus();
                this.textBox18.Text = "";
                Cambiar(18);
            }
            this.textBox18.SelectAll();
            controlFocus = textBox18;
        }

        private void textBox19_Enter(object sender, EventArgs e)
        {
            if (this.textBox19.Text == "Escribir valor")
            {
                textBox19.Focus();
                this.textBox19.Text = "";
                Cambiar(19);
            }
            this.textBox19.SelectAll();
            controlFocus = textBox19;
        }

        private void textBox18_Leave(object sender, EventArgs e)
        {
            double valor;
            if (this.textBox18.Text == "" || !double.TryParse(textBox18.Text, out valor))
            {
                this.textBox18.Text = "Escribir valor";
                Cambiar(18);
            }
            if (textBox18.Width != 151)
            {
                errorProvider1.SetError(textBox18, "");
                ModificarTextBox(textBox18, false);
            }
        }

        private void textBox19_Leave(object sender, EventArgs e)
        {
            double valor;
            if (this.textBox19.Text == "" || !double.TryParse(textBox19.Text, out valor))
            {
                this.textBox19.Text = "Escribir valor";
                Cambiar(19);
            }
            if (textBox19.Width != 151)
            {
                errorProvider1.SetError(textBox19, "");
                ModificarTextBox(textBox19, false);
            }
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox18.Text == "" && !textBox18.Focused)
                textBox18.Text = "Escribir valor";
            switch (comboBox8.SelectedIndex)
            {
                case 0:
                    arreglo4[0] = textBox18.Text;
                    break;
                case 1:
                    arreglo4[0] = textBox18.Text;
                    break;
                case 2:
                    arreglo4[2] = textBox18.Text;
                    break;
            }
            Cambiar(18);
            if (textBox18.Width != 151)
            {
                errorProvider1.SetError(textBox18, "");
                ModificarTextBox(textBox18, false);
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox19.Text == "" && !textBox19.Focused)
                textBox19.Text = "Escribir valor";
            switch (comboBox8.SelectedIndex)
            {
                case 0:
                    arreglo4[1] = textBox19.Text;
                    break;
                case 1:
                    arreglo4[2] = textBox19.Text;
                    break;
                case 2:
                    arreglo4[1] = textBox19.Text;
                    break;
            }
            Cambiar(19);
            if (textBox19.Width != 151)
            {
                errorProvider1.SetError(textBox19, "");
                ModificarTextBox(textBox19, false);
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox16.Text == "Escribir valor")
                textBox16.Text = "";
            switch (comboBox8.SelectedIndex)
            {
                case 0:
                    arreglo4[2] = textBox16.Text;
                    break;
                case 1:
                    arreglo4[1] = textBox16.Text;
                    break;
                case 2:
                    arreglo4[0] = textBox16.Text;
                    break;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox18.Text == "Escribir valor" || textBox18.TextLength == 0)
            {
                if (comboBox8.SelectedIndex == 0 || comboBox8.SelectedIndex == 1)
                    errorProvider1.SetError(textBox18, "La \'" + label23.Text + "\' no puede estar en blanco");
                else
                    errorProvider1.SetError(textBox18, "El \'" + label23.Text + "\' no puede estar en blanco");
                ModificarTextBox(textBox18, true);
            }
            else if (System.Convert.ToDouble(textBox18.Text) < 0)
            {
                if (comboBox8.SelectedIndex == 0 || comboBox8.SelectedIndex == 1)
                    errorProvider1.SetError(textBox18, "La \'" + label23.Text + "\' no puede contener un valor negativo");
                else
                    errorProvider1.SetError(textBox18, "El \'" + label23.Text + "\' no puede contener un valor negativo");
                ModificarTextBox(textBox18, true);
            }
            else if (textBox19.Text == "Escribir valor" || textBox19.TextLength == 0)
            {
                errorProvider1.SetError(textBox19, "El \'" + label22.Text + "\' no puede estar en blanco");
                ModificarTextBox(textBox19, true);
            }
            else if (System.Convert.ToDouble(textBox19.Text) < 0)
            {
                errorProvider1.SetError(textBox19, "El \'" + label22.Text + "\' no puede contener un valor negativo");
                ModificarTextBox(textBox19, true);
            }            
            else
                switch (comboBox8.SelectedIndex)
                {
                    case 0:
                        //ok
                        textBox16.Text = ((System.Convert.ToDouble(textBox18.Text) * System.Convert.ToDouble(textBox19.Text)) / 100).ToString();
                        break;
                    case 1:
                        //ok
                        textBox16.Text = ((100 * System.Convert.ToDouble(textBox19.Text)) / System.Convert.ToDouble(textBox18.Text)).ToString();
                        break;
                    case 2:
                        //ok
                        textBox16.Text = ((100 * System.Convert.ToDouble(textBox18.Text)) / System.Convert.ToDouble(textBox19.Text)).ToString();
                        break;
                }
                textBox16.Focus();
                textBox16.Select(0, 0);
        }

        private void comboBox7_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (comboBox7.SelectedIndex)
            {
                case 0:
                    label26.Text = "Distancia (millas)";
                    label24.Text = "Consumo de combustible (mpg)";
                    textBox20.Text = arreglo3[0];
                    textBox21.Text = arreglo3[1];
                    textBox17.Text = arreglo3[2];
                    break;
                case 1:
                    label26.Text = "Distancia (millas)";
                    label24.Text = "Combustible (galones)";
                    textBox20.Text = arreglo3[0];
                    textBox21.Text = arreglo3[2];
                    textBox17.Text = arreglo3[1];
                    break;
                case 2:
                    label26.Text = "Combustible (galones)";
                    label24.Text = "Consumo de combustible (mpg)";
                    textBox20.Text = arreglo3[2];
                    textBox21.Text = arreglo3[1];
                    textBox17.Text = arreglo3[0];
                    break;                
            }
            Cambiar(20);
            Cambiar(21);
        }

        private void textBox20_Enter(object sender, EventArgs e)
        {
            if (this.textBox20.Text == "Escribir valor")
            {
                textBox20.Focus();
                this.textBox20.Text = "";
                Cambiar(20);
            }
            this.textBox20.SelectAll();
            controlFocus = textBox20;
        }

        private void textBox21_Enter(object sender, EventArgs e)
        {
            if (this.textBox21.Text == "Escribir valor")
            {
                textBox21.Focus();
                this.textBox21.Text = "";
                Cambiar(21);
            }
            this.textBox21.SelectAll();
            controlFocus = textBox21;
        }

        private void textBox20_Leave(object sender, EventArgs e)
        {
            double valor;
            if (this.textBox20.Text == "" || !double.TryParse(textBox20.Text, out valor))
            {
                this.textBox20.Text = "Escribir valor";
                Cambiar(20);
            }
            if (textBox20.Width != 151)
            {
                errorProvider1.SetError(textBox20, "");
                ModificarTextBox(textBox20, false);
            }
        }

        private void textBox21_Leave(object sender, EventArgs e)
        {
            double valor;
            if (this.textBox21.Text == "" || !double.TryParse(textBox21.Text, out valor))
            {
                this.textBox21.Text = "Escribir valor";
                Cambiar(21);
            }
            if (textBox21.Width != 151)
            {
                errorProvider1.SetError(textBox21, "");
                ModificarTextBox(textBox21, false);
            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox20.Text == "" && !textBox20.Focused)
                textBox20.Text = "Escribir valor";
            switch (comboBox7.SelectedIndex)
            {
                case 0:
                    arreglo3[0] = textBox20.Text;
                    break;
                case 1:
                    arreglo3[0] = textBox20.Text;
                    break;
                case 2:
                    arreglo3[2] = textBox20.Text;
                    break;
            }
            Cambiar(20);
            if (textBox20.Width != 151)
            {
                errorProvider1.SetError(textBox20, "");
                ModificarTextBox(textBox20, false);
            }
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox21.Text == "" && !textBox21.Focused)
                textBox21.Text = "Escribir valor";
            switch (comboBox7.SelectedIndex)
            {
                case 0:
                    arreglo3[1] = textBox21.Text;
                    break;
                case 1:
                    arreglo3[2] = textBox21.Text;
                    break;
                case 2:
                    arreglo3[1] = textBox21.Text;
                    break;
            }
            Cambiar(21);
            if (textBox21.Width != 151)
            {
                errorProvider1.SetError(textBox21, "");
                ModificarTextBox(textBox21, false);
            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox17.Text == "Escribir valor")
                textBox17.Text = "";
            switch (comboBox7.SelectedIndex)
            {
                case 0:
                    arreglo3[2] = textBox17.Text;
                    break;
                case 1:
                    arreglo3[1] = textBox17.Text;
                    break;
                case 2:
                    arreglo3[0] = textBox17.Text;
                    break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox20.Text == "Escribir valor" || textBox20.TextLength == 0)
            {
                if (comboBox7.SelectedIndex == 0 || comboBox7.SelectedIndex == 1)
                    errorProvider1.SetError(textBox20, "La \'" + label26.Text + "\' no puede estar en blanco");
                else
                    errorProvider1.SetError(textBox20, "El \'" + label26.Text + "\' no puede estar en blanco");
                ModificarTextBox(textBox20, true);
            }
            else if (System.Convert.ToDouble(textBox20.Text) < 0)
            {
                if (comboBox7.SelectedIndex == 0 || comboBox7.SelectedIndex == 1)
                    errorProvider1.SetError(textBox20, "La \'" + label26.Text + "\' no puede contener un valor negativo");
                else
                    errorProvider1.SetError(textBox20, "El \'" + label26.Text + "\' no puede contener un valor negativo");
                ModificarTextBox(textBox20, true);
            }
            else if (textBox21.Text == "Escribir valor" || textBox21.TextLength == 0)
            {
                errorProvider1.SetError(textBox21, "El \'" + label24.Text + "\' no puede estar en blanco");
                ModificarTextBox(textBox21, true);
            }
            else if (System.Convert.ToDouble(textBox21.Text) < 0)
            {
                errorProvider1.SetError(textBox21, "El \'" + label24.Text + "\' no puede contener un valor negativo");
                ModificarTextBox(textBox21, true);
            }
            else
                switch (comboBox7.SelectedIndex)
                {
                    case 0:
                    case 1:
                        //ok
                        textBox17.Text = (System.Convert.ToDouble(textBox20.Text) / System.Convert.ToDouble(textBox21.Text)).ToString();
                        break;                    
                    case 2:
                        //ok
                        textBox17.Text = (System.Convert.ToDouble(textBox20.Text) * System.Convert.ToDouble(textBox21.Text)).ToString();
                        break;                    
                }
            textBox17.Focus();
            textBox17.Select(0, 0);
        }

        private void comboBox6_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (comboBox6.SelectedIndex)
            {
                case 0:
                    label19.Text = "Valor de alquiler";
                    label17.Text = "Período de alquiler";
                    label18.Text = "Pagos por año";
                    label16.Text = "Valor residual";
                    label21.Text = "Tipo de interés (%)";
                    textBox13.Text = arreglo2[0];
                    textBox14.Text = arreglo2[1];
                    textBox12.Text = arreglo2[2];
                    textBox11.Text = arreglo2[3];
                    textBox15.Text = arreglo2[4];                    
                    textBox10.Text = arreglo2[5];
                    break;
                case 1:
                    label19.Text = "Valor de alquiler";
                    label17.Text = "Pagos por año";
                    label18.Text = "Valor residual";
                    label16.Text = "Tipo de interés (%)";
                    label21.Text = "Pago periódico";
                    textBox13.Text = arreglo2[0];
                    textBox14.Text = arreglo2[2];
                    textBox12.Text = arreglo2[3];
                    textBox11.Text = arreglo2[4];
                    textBox15.Text = arreglo2[5];                    
                    textBox10.Text = arreglo2[1];
                    break;
                case 2:
                    label19.Text = "Período de alquiler";
                    label17.Text = "Pagos por año";
                    label18.Text = "Valor residual";
                    label16.Text = "Tipo de interés (%)";
                    label21.Text = "Pago periódico";
                    textBox13.Text = arreglo2[1];
                    textBox14.Text = arreglo2[2];
                    textBox12.Text = arreglo2[3];
                    textBox11.Text = arreglo2[4];
                    textBox15.Text = arreglo2[5];                    
                    textBox10.Text = arreglo2[0];
                    break;
                case 3:
                    label19.Text = "Valor de alquiler";
                    label17.Text = "Período de alquiler";
                    label18.Text = "Pagos por año";
                    label16.Text = "Tipo de interés (%)";
                    label21.Text = "Pago periódico";
                    textBox13.Text = arreglo2[0];
                    textBox14.Text = arreglo2[1];
                    textBox12.Text = arreglo2[2];
                    textBox11.Text = arreglo2[4];
                    textBox15.Text = arreglo2[5];                    
                    textBox10.Text = arreglo2[3];
                    break;
            }
            for (int i = 11; i <= 15; i++)
                Cambiar(i);
        }

        private void textBox13_Enter(object sender, EventArgs e)
        {
            if (this.textBox13.Text == "Escribir valor")
            {
                textBox13.Focus();
                this.textBox13.Text = "";
                Cambiar(13);
            }
            this.textBox13.SelectAll();
            controlFocus = textBox13;
        }

        private void textBox14_Enter(object sender, EventArgs e)
        {
            if (this.textBox14.Text == "Escribir valor")
            {
                textBox14.Focus();
                this.textBox14.Text = "";
                Cambiar(14);
            }
            this.textBox14.SelectAll();
            controlFocus = textBox14;
        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            if (this.textBox12.Text == "Escribir valor")
            {
                textBox12.Focus();
                this.textBox12.Text = "";
                Cambiar(12);
            }
            this.textBox12.SelectAll();
            controlFocus = textBox12;
        }

        private void textBox11_Enter(object sender, EventArgs e)
        {
            if (this.textBox11.Text == "Escribir valor")
            {
                textBox11.Focus();
                this.textBox11.Text = "";
                Cambiar(11);
            }
            this.textBox11.SelectAll();
            controlFocus = textBox11;
        }

        private void textBox15_Enter(object sender, EventArgs e)
        {
            if (this.textBox15.Text == "Escribir valor")
            {
                textBox15.Focus();
                this.textBox15.Text = "";
                Cambiar(15);
            }
            this.textBox15.SelectAll();
            controlFocus = textBox15;
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
            double valor;
            if (this.textBox13.Text == "" || !double.TryParse(textBox13.Text, out valor))
            {
                this.textBox13.Text = "Escribir valor";
                Cambiar(13);
            }
            if (textBox13.Width != 151)
            {
                errorProvider1.SetError(textBox13, "");
                ModificarTextBox(textBox13, false);
            }
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            double valor;
            if (this.textBox14.Text == "" || !double.TryParse(textBox14.Text, out valor))
            {
                this.textBox14.Text = "Escribir valor";
                Cambiar(14);
            }
            if (textBox14.Width != 151)
            {
                errorProvider1.SetError(textBox14, "");
                ModificarTextBox(textBox14, false);
            }
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            double valor;
            if (this.textBox12.Text == "" || !double.TryParse(textBox12.Text, out valor))
            {
                this.textBox12.Text = "Escribir valor";
                Cambiar(12);
            }
            if (textBox12.Width != 151)
            {
                errorProvider1.SetError(textBox12, "");
                ModificarTextBox(textBox12, false);
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            double valor;
            if (this.textBox11.Text == "" || !double.TryParse(textBox11.Text, out valor))
            {
                this.textBox11.Text = "Escribir valor";
                Cambiar(11);
            }
            if (textBox11.Width != 151)
            {
                errorProvider1.SetError(textBox11, "");
                ModificarTextBox(textBox11, false);
            }
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            double valor;
            if (this.textBox15.Text == "" || !double.TryParse(textBox15.Text, out valor))
            {
                this.textBox15.Text = "Escribir valor";
                Cambiar(15);
            }
            if (textBox15.Width != 151)
            {
                errorProvider1.SetError(textBox15, "");
                ModificarTextBox(textBox15, false);
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox13.Text == "" && !textBox13.Focused)
                textBox13.Text = "Escribir valor";
            switch (comboBox6.SelectedIndex)
            {
                case 0:
                    arreglo2[0] = textBox13.Text;
                    break;
                case 1:
                    arreglo2[0] = textBox13.Text;
                    break;
                case 2:
                    arreglo2[1] = textBox13.Text;
                    break;
                case 3:
                    arreglo2[0] = textBox13.Text;
                    break;
            }
            Cambiar(13);
            if (textBox13.Width != 151)
            {
                errorProvider1.SetError(textBox13, "");
                ModificarTextBox(textBox13, false);
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox14.Text == "" && !textBox14.Focused)
                textBox14.Text = "Escribir valor";
            switch (comboBox6.SelectedIndex)
            {
                case 0:
                    arreglo2[1] = textBox14.Text;
                    break;
                case 1:
                    arreglo2[2] = textBox14.Text;
                    break;
                case 2:
                    arreglo2[2] = textBox14.Text;
                    break;
                case 3:
                    arreglo2[1] = textBox14.Text;
                    break;
            }
            Cambiar(14);
            if (textBox14.Width != 151)
            {
                errorProvider1.SetError(textBox14, "");
                ModificarTextBox(textBox14, false);
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox12.Text == "" && !textBox12.Focused)
                textBox12.Text = "Escribir valor";
            switch (comboBox6.SelectedIndex)
            {
                case 0:
                    arreglo2[2] = textBox12.Text;
                    break;
                case 1:
                    arreglo2[3] = textBox12.Text;
                    break;
                case 2:
                    arreglo2[3] = textBox12.Text;
                    break;
                case 3:
                    arreglo2[2] = textBox12.Text;
                    break;
            }
            Cambiar(12);
            if (textBox12.Width != 151)
            {
                errorProvider1.SetError(textBox12, "");
                ModificarTextBox(textBox12, false);
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox11.Text == "" && !textBox11.Focused)
                textBox11.Text = "Escribir valor";
            switch (comboBox6.SelectedIndex)
            {
                case 0:
                    arreglo2[3] = textBox11.Text;
                    break;
                case 1:
                    arreglo2[4] = textBox11.Text;
                    break;
                case 2:
                    arreglo2[4] = textBox11.Text;
                    break;
                case 3:
                    arreglo2[4] = textBox11.Text;
                    break;
            }
            Cambiar(11);
            if (textBox11.Width != 151)
            {
                errorProvider1.SetError(textBox11, "");
                ModificarTextBox(textBox11, false);
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox15.Text == "" && !textBox15.Focused)
                textBox15.Text = "Escribir valor";
            switch (comboBox6.SelectedIndex)
            {
                case 0:
                    arreglo2[4] = textBox15.Text;
                    break;
                case 1:
                    arreglo2[5] = textBox15.Text;
                    break;
                case 2:
                    arreglo2[5] = textBox15.Text;
                    break;
                case 3:
                    arreglo2[5] = textBox15.Text;
                    break;
            }
            Cambiar(15);
            if (textBox15.Width != 151)
            {
                errorProvider1.SetError(textBox15, "");
                ModificarTextBox(textBox15, false);
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox10.Text == "Escribir valor")
                textBox10.Text = "";
            switch (comboBox6.SelectedIndex)
            {
                case 0:
                    arreglo2[5] = textBox10.Text;
                    break;
                case 1:
                    arreglo2[1] = textBox10.Text;
                    break;
                case 2:
                    arreglo2[0] = textBox10.Text;
                    break;
                case 3:
                    arreglo2[3] = textBox10.Text;
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "Escribir valor" || textBox13.TextLength == 0)
            {
                errorProvider1.SetError(textBox13, "El \'" + label19.Text + "\' no puede estar en blanco");
                ModificarTextBox(textBox13, true);
            }
            else if (System.Convert.ToDouble(textBox13.Text) < 0)
            {
                errorProvider1.SetError(textBox13, "El \'" + label19.Text + "\' no puede contener un valor negativo");
                ModificarTextBox(textBox13, true);
            }
            else if (textBox14.Text == "Escribir valor" || textBox14.TextLength == 0)
            {
                if (comboBox6.SelectedIndex == 1 || comboBox6.SelectedIndex == 2)
                    errorProvider1.SetError(textBox14, "Los \'" + label17.Text + "\' no pueden estar en blanco");
                else
                    errorProvider1.SetError(textBox14, "El \'" + label17.Text + "\' no puede estar en blanco");
                ModificarTextBox(textBox14, true);
            }
            else if (System.Convert.ToDouble(textBox14.Text) < 0)
            {
                if (comboBox6.SelectedIndex == 1 || comboBox6.SelectedIndex == 2)
                    errorProvider1.SetError(textBox14, "Los \'" + label17.Text + "\' no pueden contener un valor negativo");
                else
                    errorProvider1.SetError(textBox14, "El \'" + label17.Text + "\' no puede contener un valor negativo");
                ModificarTextBox(textBox14, true);
            }
            else if (textBox12.Text == "Escribir valor" || textBox12.TextLength == 0)
            {
                if (comboBox6.SelectedIndex == 0 || comboBox6.SelectedIndex == 3)
                    errorProvider1.SetError(textBox12, "Los \'" + label18.Text + "\' no pueden estar en blanco");
                else
                    errorProvider1.SetError(textBox12, "El \'" + label18.Text + "\' no puede estar en blanco");
                ModificarTextBox(textBox12, true);
            }
            else if (System.Convert.ToDouble(textBox12.Text) < 0)
            {
                if (comboBox6.SelectedIndex == 0 || comboBox6.SelectedIndex == 3)
                    errorProvider1.SetError(textBox12, "Los \'" + label18.Text + "\' no pueden contener un valor negativo");
                else
                    errorProvider1.SetError(textBox12, "El \'" + label18.Text + "\' no puede contener un valor negativo");
                ModificarTextBox(textBox12, true);
            }
            else if (textBox11.Text == "Escribir valor" || textBox11.TextLength == 0)
            {
                errorProvider1.SetError(textBox11, "El \'" + label16.Text + "\' no puede estar en blanco");
                ModificarTextBox(textBox11, true);
            }
            else if (System.Convert.ToDouble(textBox11.Text) < 0)
            {
                errorProvider1.SetError(textBox11, "El \'" + label16.Text + "\' no puede contener un valor negativo");
                ModificarTextBox(textBox11, true);
            }            

            else if (textBox15.Text == "Escribir valor" || textBox15.TextLength == 0)
            {
                errorProvider1.SetError(textBox15, "El \'" + label21.Text + "\' no puede estar en blanco");
                ModificarTextBox(textBox15, true);
            }
            else if (System.Convert.ToDouble(textBox15.Text) < 0)
            {
                errorProvider1.SetError(textBox15, "El \'" + label21.Text + "\' no puede contener un valor negativo");
                ModificarTextBox(textBox15, true);
            }
            else
                switch (comboBox6.SelectedIndex)
                {
                    case 0:
                        //
                        //textBox10.Text = ().ToString();
                        break;
                    case 1:
                        //
                        //textBox10.Text = ().ToString();
                        break;
                    case 2:
                        //
                        //textBox10.Text = ().ToString();
                        break;
                    case 3:
                        //
                        //textBox10.Text = ().ToString();
                        break;
                }
                textBox10.Focus();
                textBox10.Select(0, 0);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '-')
            {
                errorProvider1.SetError(textBox5, "ERROR\n'" + e.KeyChar.ToString() + "' no es un caracter permitido");
                ModificarTextBox(textBox5,true);
                e.KeyChar = (char)Keys.Escape;
            }
            else if ((e.KeyChar == (char)Keys.Back || (e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == ',' || e.KeyChar == '-') && (TieneCerosIzquierda(textBox5, e.KeyChar)))
            {
                ModificarTextBox(textBox5,true);
                e.KeyChar = (char)Keys.Escape;
            }
            else
            {
                errorProvider1.SetError(textBox5, "");
                ModificarTextBox(textBox5,false);
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (TieneCerosIzquierda(textBox5, (char)e.KeyCode))
                {
                    ModificarTextBox(textBox5, true);
                    Ding.Play();
                    e.Handled = true;
                }
                else
                {
                    errorProvider1.SetError(textBox5, "");
                    ModificarTextBox(textBox5, false);
                }
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '-')
            {
                errorProvider1.SetError(textBox6, "ERROR\n'" + e.KeyChar.ToString() + "' no es un caracter permitido");
                ModificarTextBox(textBox6, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else if ((e.KeyChar == (char)Keys.Back || (e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == ',' || e.KeyChar == '-') && (TieneCerosIzquierda(textBox6, e.KeyChar)))
            {
                ModificarTextBox(textBox6, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else
            {
                errorProvider1.SetError(textBox6, "");
                ModificarTextBox(textBox6, false);
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '-')
            {
                errorProvider1.SetError(textBox7, "ERROR\n'" + e.KeyChar.ToString() + "' no es un caracter permitido");
                ModificarTextBox(textBox7, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else if ((e.KeyChar == (char)Keys.Back || (e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == ',' || e.KeyChar == '-') && (TieneCerosIzquierda(textBox7, e.KeyChar)))
            {
                ModificarTextBox(textBox7, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else
            {
                errorProvider1.SetError(textBox7, "");
                ModificarTextBox(textBox7, false);
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '-')
            {
                errorProvider1.SetError(textBox8, "ERROR\n'" + e.KeyChar.ToString() + "' no es un caracter permitido");
                ModificarTextBox(textBox8, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else if ((e.KeyChar == (char)Keys.Back || (e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == ',' || e.KeyChar == '-') && (TieneCerosIzquierda(textBox8, e.KeyChar)))
            {
                ModificarTextBox(textBox8, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else
            {
                errorProvider1.SetError(textBox8, "");
                ModificarTextBox(textBox8, false);
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (TieneCerosIzquierda(textBox6, (char)e.KeyCode))
                {
                    ModificarTextBox(textBox6, true);
                    Ding.Play();
                    e.Handled = true;
                }
                else
                {
                    errorProvider1.SetError(textBox6, "");
                    ModificarTextBox(textBox6, false);
                }
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (TieneCerosIzquierda(textBox7, (char)e.KeyCode))
                {
                    ModificarTextBox(textBox7, true);
                    Ding.Play();
                    e.Handled = true;
                }
                else
                {
                    errorProvider1.SetError(textBox7, "");
                    ModificarTextBox(textBox7, false);
                }
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (TieneCerosIzquierda(textBox8, (char)e.KeyCode))
                {
                    ModificarTextBox(textBox8, true);
                    Ding.Play();
                    e.Handled = true;
                }
                else
                {
                    errorProvider1.SetError(textBox8, "");
                    ModificarTextBox(textBox8, false);
                }
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '-')
            {
                errorProvider1.SetError(textBox13, "ERROR\n'" + e.KeyChar.ToString() + "' no es un caracter permitido");
                ModificarTextBox(textBox13, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else if ((e.KeyChar == (char)Keys.Back || (e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == ',' || e.KeyChar == '-') && (TieneCerosIzquierda(textBox13, e.KeyChar)))
            {
                ModificarTextBox(textBox13, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else
            {
                errorProvider1.SetError(textBox13, "");
                ModificarTextBox(textBox13, false);
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '-')
            {
                errorProvider1.SetError(textBox14, "ERROR\n'" + e.KeyChar.ToString() + "' no es un caracter permitido");
                ModificarTextBox(textBox14, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else if ((e.KeyChar == (char)Keys.Back || (e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == ',' || e.KeyChar == '-') && (TieneCerosIzquierda(textBox14, e.KeyChar)))
            {
                ModificarTextBox(textBox14, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else
            {
                errorProvider1.SetError(textBox14, "");
                ModificarTextBox(textBox14, false);
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '-')
            {
                errorProvider1.SetError(textBox12, "ERROR\n'" + e.KeyChar.ToString() + "' no es un caracter permitido");
                ModificarTextBox(textBox12, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else if ((e.KeyChar == (char)Keys.Back || (e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == ',' || e.KeyChar == '-') && (TieneCerosIzquierda(textBox12, e.KeyChar)))
            {
                ModificarTextBox(textBox12, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else
            {
                errorProvider1.SetError(textBox12, "");
                ModificarTextBox(textBox12, false);
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '-')
            {
                errorProvider1.SetError(textBox11, "ERROR\n'" + e.KeyChar.ToString() + "' no es un caracter permitido");
                ModificarTextBox(textBox11, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else if ((e.KeyChar == (char)Keys.Back || (e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == ',' || e.KeyChar == '-') && (TieneCerosIzquierda(textBox11, e.KeyChar)))
            {
                ModificarTextBox(textBox11, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else
            {
                errorProvider1.SetError(textBox11, "");
                ModificarTextBox(textBox11, false);
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '-')
            {
                errorProvider1.SetError(textBox15, "ERROR\n'" + e.KeyChar.ToString() + "' no es un caracter permitido");
                ModificarTextBox(textBox15, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else if ((e.KeyChar == (char)Keys.Back || (e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == ',' || e.KeyChar == '-') && (TieneCerosIzquierda(textBox15, e.KeyChar)))
            {
                ModificarTextBox(textBox15, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else
            {
                errorProvider1.SetError(textBox15, "");
                ModificarTextBox(textBox15, false);
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (TieneCerosIzquierda(textBox13, (char)e.KeyCode))
                {
                    ModificarTextBox(textBox13, true);
                    Ding.Play();
                    e.Handled = true;
                }
                else
                {
                    errorProvider1.SetError(textBox13, "");
                    ModificarTextBox(textBox13, false);
                }
            }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (TieneCerosIzquierda(textBox14, (char)e.KeyCode))
                {
                    ModificarTextBox(textBox14, true);
                    Ding.Play();
                    e.Handled = true;
                }
                else
                {
                    errorProvider1.SetError(textBox14, "");
                    ModificarTextBox(textBox14, false);
                }
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (TieneCerosIzquierda(textBox12, (char)e.KeyCode))
                {
                    ModificarTextBox(textBox12, true);
                    Ding.Play();
                    e.Handled = true;
                }
                else
                {
                    errorProvider1.SetError(textBox12, "");
                    ModificarTextBox(textBox12, false);
                }
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (TieneCerosIzquierda(textBox11, (char)e.KeyCode))
                {
                    ModificarTextBox(textBox11, true);
                    Ding.Play();
                    e.Handled = true;
                }
                else
                {
                    errorProvider1.SetError(textBox11, "");
                    ModificarTextBox(textBox11, false);
                }
            }
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (TieneCerosIzquierda(textBox15, (char)e.KeyCode))
                {
                    ModificarTextBox(textBox15, true);
                    Ding.Play();
                    e.Handled = true;
                }
                else
                {
                    errorProvider1.SetError(textBox15, "");
                    ModificarTextBox(textBox15, false);
                }
            }
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '-')
            {
                errorProvider1.SetError(textBox20, "ERROR\n'" + e.KeyChar.ToString() + "' no es un caracter permitido");
                ModificarTextBox(textBox20, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else if ((e.KeyChar == (char)Keys.Back || (e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == ',' || e.KeyChar == '-') && (TieneCerosIzquierda(textBox20, e.KeyChar)))
            {
                ModificarTextBox(textBox20, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else
            {
                errorProvider1.SetError(textBox20, "");
                ModificarTextBox(textBox20, false);
            }
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '-')
            {
                errorProvider1.SetError(textBox21, "ERROR\n'" + e.KeyChar.ToString() + "' no es un caracter permitido");
                ModificarTextBox(textBox21, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else if ((e.KeyChar == (char)Keys.Back || (e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == ',' || e.KeyChar == '-') && (TieneCerosIzquierda(textBox21, e.KeyChar)))
            {
                ModificarTextBox(textBox21, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else
            {
                errorProvider1.SetError(textBox21, "");
                ModificarTextBox(textBox21, false);
            }
        }

        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (TieneCerosIzquierda(textBox20, (char)e.KeyCode))
                {
                    ModificarTextBox(textBox20, true);
                    Ding.Play();
                    e.Handled = true;
                }
                else
                {
                    errorProvider1.SetError(textBox20, "");
                    ModificarTextBox(textBox20, false);
                }
            }
        }

        private void textBox21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (TieneCerosIzquierda(textBox21, (char)e.KeyCode))
                {
                    ModificarTextBox(textBox21, true);
                    Ding.Play();
                    e.Handled = true;
                }
                else
                {
                    errorProvider1.SetError(textBox21, "");
                    ModificarTextBox(textBox21, false);
                }
            }
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '-')
            {
                errorProvider1.SetError(textBox18, "ERROR\n'" + e.KeyChar.ToString() + "' no es un caracter permitido");
                ModificarTextBox(textBox18, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else if ((e.KeyChar == (char)Keys.Back || (e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == ',' || e.KeyChar == '-') && (TieneCerosIzquierda(textBox18, e.KeyChar)))
            {
                ModificarTextBox(textBox18, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else
            {
                errorProvider1.SetError(textBox18, "");
                ModificarTextBox(textBox18, false);
            }
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '-')
            {
                errorProvider1.SetError(textBox19, "ERROR\n'" + e.KeyChar.ToString() + "' no es un caracter permitido");
                ModificarTextBox(textBox19, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else if ((e.KeyChar == (char)Keys.Back || (e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == ',' || e.KeyChar == '-') && (TieneCerosIzquierda(textBox19, e.KeyChar)))
            {
                ModificarTextBox(textBox19, true);
                e.KeyChar = (char)Keys.Escape;
            }
            else
            {
                errorProvider1.SetError(textBox19, "");
                ModificarTextBox(textBox19, false);
            }
        }

        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (TieneCerosIzquierda(textBox18, (char)e.KeyCode))
                {
                    ModificarTextBox(textBox18, true);
                    Ding.Play();
                    e.Handled = true;
                }
                else
                {
                    errorProvider1.SetError(textBox18, "");
                    ModificarTextBox(textBox18, false);
                }
            }
        }

        private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (TieneCerosIzquierda(textBox19, (char)e.KeyCode))
                {
                    ModificarTextBox(textBox19, true);
                    Ding.Play();
                    e.Handled = true;
                }
                else
                {
                    errorProvider1.SetError(textBox19, "");
                    ModificarTextBox(textBox19, false);
                }
            }
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            controlFocus = comboBox1;
            CambiarColor(false);
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            controlFocus = comboBox2;
        }

        private void comboBox3_Enter(object sender, EventArgs e)
        {
            controlFocus = comboBox3;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.SelectAll();
            controlFocus = textBox2;
        }

        private void textBox22_Enter(object sender, EventArgs e)
        {
            controlFocus = textBox22;
        }

        private bool PuedeImprimir(char caracter)
        {
            if (estándarToolStripMenuItem.Checked || estadísticasToolStripMenuItem.Checked)
            {
                if ((textBox22.Text.Contains(",") && (textBox22.Text + caracter.ToString()).Length > 17) || (!textBox22.Text.Contains(",") && (textBox22.Text + caracter.ToString()).Length > 16))
                    return false;
            }
            else if (científicaToolStripMenuItem.Checked)
            {
                decimal a;
                if (!System.Decimal.TryParse(textBox22.Text + caracter.ToString(), out a) || (textBox22.Text.Contains(",") && textBox22.TextLength > 29))
                    return false;
            }
            else if (programadorToolStripMenuItem.Checked)
            {
                long a;
                if ((caracter >= 65 && caracter <= 70) || (caracter >= 97 && caracter <= 102))
                {
                    try
                    {
                        if (!System.Int64.TryParse(System.Convert.ToInt64(textBox22.Text + caracter.ToString(), 16).ToString(), out a))
                            return false;
                    }
                    catch (OverflowException)
                    {
                        return false;
                    }
                    catch (ArgumentException)
                    {
                        return false;
                    }
                    catch (FormatException)
                    {
                        return false;
                    }
                }
                else
                {
                    try
                    {
                        if (radioButton4.Checked)
                        {
                            if (!System.Int64.TryParse(System.Convert.ToInt64((textBox22.Text + caracter.ToString()), 16).ToString(), out a))
                                return false;
                        }
                        else if (radioButton5.Checked)
                        {
                            if (!System.Int64.TryParse(System.Convert.ToInt64((textBox22.Text + caracter.ToString()), 10).ToString(), out a))
                                return false;
                        }
                        else if (radioButton6.Checked)
                        {
                            if (!System.Int64.TryParse(System.Convert.ToInt64((textBox22.Text + caracter.ToString()), 2).ToString(), out a))
                                return false;
                        }
                        else if (radioButton7.Checked)
                        {
                            if (!System.Int64.TryParse(System.Convert.ToInt64((textBox22.Text + caracter.ToString()), 8).ToString(), out a))
                                return false;
                        }
                    }
                    catch (OverflowException)
                    {
                        return false;
                    }
                    catch (ArgumentException)
                    {
                        return false;
                    }
                    catch (FormatException)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void ColocarNumero(char numero)
        {
            bool valor = false;
            TextBox tb = textBox22;
            int SelectionStart = 0, SelectionLength = 0;
            if (controlFocus.GetType().Name.Contains("TextBox") || controlFocus.GetType().Name.Contains("DateTimePicker") || controlFocus.GetType().Name.Contains("NumericUpDown"))
            {
                if (controlFocus.GetType().Name.Contains("DateTimePicker") || controlFocus.Name.Equals("textBox16") || controlFocus.Name.Equals("textBox9") || controlFocus.Name.Equals("textBox2") || controlFocus.Name.Equals("textBox3") || controlFocus.Name.Equals("textBox4") || controlFocus.Name.Equals("textBox24") || controlFocus.Name.Equals("textBox10") || controlFocus.Name.Equals("textBox17"))
                    valor = true;
                else
                    tb = (controlFocus.GetType().Name.Contains("NumericUpDown") == true) ? ((NumericUpDown)controlFocus).Controls[1] as TextBox : (TextBox)controlFocus;
            }            
            if (!valor)
            {
                if (!SePuede && tb.Equals(textBox22))
                {
                    textBox22.Text = "0";
                    SePuede = true;
                }
                if (tb.Equals(textBox22) && mr3)
                {
                    textBox22.Text = "0";
                }
                if (tb.Equals(textBox22) && (tb.Text == "0" || raiz))
                {
                    tb.Text = "";
                    if (raiz)
                    {
                        int posicion = textBox23.Text.IndexOf("sqrt", UltimaPosicionOperador(textBox23.Text) + 1);
                        textBox23.Text = textBox23.Text.Remove(posicion, textBox23.TextLength - posicion);
                        raiz = false;
                    }
                }
                SelectionStart = tb.SelectionStart;
                SelectionLength = tb.SelectionLength;
                tb.Focus();
                tb.SelectionStart = SelectionStart;
                tb.SelectionLength = SelectionLength;
                if (!TieneCerosIzquierda(tb, numero))
                {
                    string s = tb.Text.Remove(SelectionStart, SelectionLength).Insert(tb.SelectionStart, numero.ToString());
                    if ((controlFocus.GetType().Name.Equals("TextBox") && (!tb.Equals(textBox22) || (tb.Equals(textBox22) && PuedeImprimir(numero)))) || (controlFocus.GetType().Name.Equals("NumericUpDown") && s.Length <= 3))
                    {
                        if (tb.Equals(textBox22) && mr3)
                            mr3 = false;
                        tb.Text = s;
                        tb.Select(SelectionStart + 1, 0);
                        if (controlFocus.GetType().Name.Equals("NumericUpDown"))
                            ((NumericUpDown)controlFocus).Value = System.Convert.ToDecimal(s);
                    }
                    else
                        Ding.Play();
                }
                else if (tb.Equals(textBox22) || controlFocus.GetType().Name.Contains("NumericUpDown"))
                {
                    errorProvider1.SetError(tb, "");
                    Ding.Play();
                }
                else
                {
                    ModificarTextBox(tb, true);
                    Ding.Play();
                }
            }
            else
            {
                if (controlFocus.GetType().Name.Equals("TextBox"))
                {
                    SelectionStart = ((TextBox)controlFocus).SelectionStart;
                    SelectionLength = ((TextBox)controlFocus).SelectionLength;
                }
                controlFocus.Focus();
                if (controlFocus.GetType().Name.Equals("TextBox"))
                {
                    ((TextBox)controlFocus).SelectionStart = SelectionStart;
                    ((TextBox)controlFocus).SelectionLength = SelectionLength;
                }
                Ding.Play();
            }
        }

        private int UltimaPosicionOperador(string cadena)
        {
            int max = cadena.LastIndexOf("-");
            if (cadena.LastIndexOf("+") > max)
                max = cadena.LastIndexOf("+");
            if (cadena.LastIndexOf("*") > max)
                max = cadena.LastIndexOf("*");
            if (cadena.LastIndexOf("/") > max)
                max = cadena.LastIndexOf("/");
            return max;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //0
            bool valor = false;
            TextBox tb = textBox22;            
            int SelectionStart = 0, SelectionLength = 0;
            if (controlFocus.GetType().Name.Contains("TextBox") || controlFocus.GetType().Name.Contains("DateTimePicker") || controlFocus.GetType().Name.Contains("NumericUpDown"))
            {
                if (controlFocus.GetType().Name.Contains("DateTimePicker") || controlFocus.Name.Equals("textBox16") || controlFocus.Name.Equals("textBox9") || controlFocus.Name.Equals("textBox2") || controlFocus.Name.Equals("textBox3") || controlFocus.Name.Equals("textBox4") || controlFocus.Name.Equals("textBox24") || controlFocus.Name.Equals("textBox10") || controlFocus.Name.Equals("textBox17"))
                    valor = true;
                else
                    tb = (controlFocus.GetType().Name.Contains("NumericUpDown") == true) ? ((NumericUpDown)controlFocus).Controls[1] as TextBox : (TextBox)controlFocus;
            }            
            if (!valor)
            {
                if (!SePuede && tb.Equals(textBox22))
                {
                    textBox22.Text = "";
                    SePuede = true;
                }
                if (tb.Equals(textBox22) && mr3)
                {
                    textBox22.Text = "";
                }
                if (tb.Equals(textBox22) && raiz)
                {
                    if (raiz)
                    {
                        int posicion = textBox23.Text.IndexOf("sqrt", UltimaPosicionOperador(textBox23.Text) + 1);
                        textBox23.Text = textBox23.Text.Remove(posicion, textBox23.TextLength - posicion);
                        raiz = false;
                    }
                }
                SelectionStart = tb.SelectionStart;
                SelectionLength = tb.SelectionLength;
                tb.Focus();
                tb.SelectionStart = SelectionStart;
                tb.SelectionLength = SelectionLength; 
                if (!TieneCerosIzquierda(tb, '0'))
                {
                    string s = tb.Text.Remove(SelectionStart, SelectionLength).Insert(tb.SelectionStart, "0");
                    if ((controlFocus.GetType().Name.Equals("TextBox") && (!tb.Equals(textBox22) || (tb.Equals(textBox22) && PuedeImprimir('0')))) || (controlFocus.GetType().Name.Equals("NumericUpDown") && s.Length <= 3))
                    {
                        if (tb.Equals(textBox22) && mr3)
                            mr3 = false;
                        tb.Text = s;
                        tb.Select(SelectionStart + 1, 0);
                        if (controlFocus.GetType().Name.Equals("NumericUpDown"))
                        {
                            ((NumericUpDown)controlFocus).Value = System.Convert.ToDecimal(1);
                            ((NumericUpDown)controlFocus).Value = System.Convert.ToDecimal(s);
                        }
                    }
                    else
                        Ding.Play();
                }
                else if (tb.Equals(textBox22) || controlFocus.GetType().Name.Contains("NumericUpDown"))
                {
                    errorProvider1.SetError(tb, "");
                    Ding.Play();
                }
                else
                {
                    ModificarTextBox(tb, true);
                    Ding.Play();
                }
            }
            else
            {
                if (controlFocus.GetType().Name.Equals("TextBox"))
                {
                    SelectionStart = ((TextBox)controlFocus).SelectionStart;
                    SelectionLength = ((TextBox)controlFocus).SelectionLength;
                }
                controlFocus.Focus();
                if (controlFocus.GetType().Name.Equals("TextBox"))
                {
                    ((TextBox)controlFocus).SelectionStart = SelectionStart;
                    ((TextBox)controlFocus).SelectionLength = SelectionLength;
                }
                Ding.Play();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //6
            ColocarNumero('6');
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //3
            ColocarNumero('3');
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //9
            ColocarNumero('9');
        }

        private void button28_Click(object sender, EventArgs e)
        {
            //8
            ColocarNumero('8');
        }

        private void button30_Click(object sender, EventArgs e)
        {
            //5
            ColocarNumero('5');
        }

        private void button31_Click(object sender, EventArgs e)
        {
            //2
            ColocarNumero('2');
        }

        private void button32_Click(object sender, EventArgs e)
        {
            //7
            ColocarNumero('7');
        }

        private void button34_Click(object sender, EventArgs e)
        {
            //1
            ColocarNumero('1');
        }

        private void button35_Click(object sender, EventArgs e)
        {
            //4
            ColocarNumero('4');
        }

        private void comboBox8_Enter(object sender, EventArgs e)
        {
            controlFocus = comboBox8;
            CambiarColor(false);
        }

        private void textBox16_Enter(object sender, EventArgs e)
        {
            textBox16.SelectAll();
            controlFocus = textBox16;            
        }

        private void button7_Enter(object sender, EventArgs e)
        {
            controlFocus = button7;
        }

        private void comboBox4_Enter(object sender, EventArgs e)
        {
            controlFocus = comboBox4;
            CambiarColor(false);
        }

        private void dateTimePicker1_Enter(object sender, EventArgs e)
        {
            controlFocus = dateTimePicker1;
        }

        private void radioButton12_Enter(object sender, EventArgs e)
        {
            controlFocus = radioButton12;
        }

        private void radioButton13_Enter(object sender, EventArgs e)
        {
            controlFocus = radioButton13;
        }

        private void dateTimePicker2_Enter(object sender, EventArgs e)
        {
            controlFocus = dateTimePicker2;
        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {
            (numericUpDown1.Controls[1] as TextBox).SelectAll();
            controlFocus = numericUpDown1;
        }

        private void numericUpDown2_Enter(object sender, EventArgs e)
        {
            (numericUpDown2.Controls[1] as TextBox).SelectAll();
            controlFocus = numericUpDown2;
        }

        private void numericUpDown3_Enter(object sender, EventArgs e)
        {
            (numericUpDown3.Controls[1] as TextBox).SelectAll();
            controlFocus = numericUpDown3;
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.SelectAll();
            controlFocus = textBox4;            
        }

        private void textBox24_Enter(object sender, EventArgs e)
        {
            textBox24.SelectAll();
            controlFocus = textBox24;            
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.SelectAll();
            controlFocus = textBox3;
        }

        private void button3_Enter(object sender, EventArgs e)
        {
            controlFocus = button3;
        }

        private void comboBox5_Enter(object sender, EventArgs e)
        {
            controlFocus = comboBox5;
            CambiarColor(false);
        }

        private void button4_Enter(object sender, EventArgs e)
        {
            controlFocus = button4;
        }

        private void comboBox6_Enter(object sender, EventArgs e)
        {
            controlFocus = comboBox6;
            CambiarColor(false);
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            textBox10.SelectAll();
            controlFocus = textBox10;            
        }

        private void button5_Enter(object sender, EventArgs e)
        {
            controlFocus = button5;
        }

        private void comboBox7_Enter(object sender, EventArgs e)
        {
            controlFocus = comboBox7;
            CambiarColor(false);
        }

        private void textBox17_Enter(object sender, EventArgs e)
        {
            textBox17.SelectAll();
            controlFocus = textBox17;            
        }

        private void button6_Enter(object sender, EventArgs e)
        {
            controlFocus = button6;
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            textBox9.SelectAll();
            controlFocus = textBox9;            
        }

        private void button33_Click(object sender, EventArgs e)
        {
            //<--
            int SelectionStart = 0, SelectionLength = 0;
            TextBox tb;
            if ((!mr3 && SePuede && (controlFocus.Equals(textBox22) || (!controlFocus.GetType().Name.Equals("TextBox") && !controlFocus.GetType().Name.Equals("NumericUpDown") && !controlFocus.GetType().Name.Equals("DateTimePicker") && !controlFocus.GetType().Name.Equals("RadioButton")))) || ((controlFocus.GetType().Name.Equals("TextBox") && !controlFocus.Equals(textBox22)) || controlFocus.GetType().Name.Equals("NumericUpDown")))
            {
                if (controlFocus.GetType().Name.Equals("TextBox") || controlFocus.GetType().Name.Equals("NumericUpDown"))
                {
                    tb = (controlFocus.GetType().Name.Equals("NumericUpDown") == true) ? ((NumericUpDown)controlFocus).Controls[1] as TextBox : (TextBox)controlFocus;
                    if (tb.Name.Equals("textBox22") && tb.TextLength == 1)
                    {
                        if (textBox22.Text != "0")
                            tb.Text = "0";
                        else
                            Ding.Play();
                        SelectionStart = tb.TextLength;
                    }
                    else if (tb.Name.Equals("textBox22") && tb.TextLength > 0)
                    {
                        tb.Text = tb.Text.Remove(tb.TextLength - 1);
                        if (tb.Text == "-")
                           tb.Text = "0";
                        SelectionStart = tb.TextLength;                        
                    }
                    else if (!tb.ReadOnly)
                    {
                        if (!(tb.TextLength == 0 || tb.Text == "Escribir valor"))
                        {
                            if (!(TieneCerosIzquierda(tb, (char)Keys.Back)))
                            {
                                if (tb.SelectionLength > 0)
                                {
                                    SelectionStart = tb.SelectionStart;
                                    tb.Text = tb.Text.Remove(tb.SelectionStart, tb.SelectionLength);
                                }
                                else
                                {
                                    if (tb.SelectionStart > 0)
                                    {
                                        SelectionStart = tb.SelectionStart - 1;
                                        tb.Text = tb.Text.Remove(tb.SelectionStart - 1, 1);
                                    }
                                }
                                if (!(controlFocus.GetType().Name.Equals("NumericUpDown")))
                                {
                                    errorProvider1.SetError(controlFocus, "");
                                    ModificarTextBox(tb, false);
                                }
                                else
                                {
                                    if (((((NumericUpDown)controlFocus).Controls[1]) as TextBox).Text.Equals(""))
                                    {
                                        ((NumericUpDown)controlFocus).Value = System.Convert.ToDecimal(1);
                                        ((NumericUpDown)controlFocus).Value = System.Convert.ToDecimal(0);
                                        (((NumericUpDown)controlFocus).Controls[1] as TextBox).Text = "";
                                    }
                                    else
                                        ((NumericUpDown)controlFocus).Value = System.Convert.ToDecimal((((NumericUpDown)controlFocus).Controls[1] as TextBox).Text);
                                }
                            }
                            else
                            {
                                SelectionStart = tb.SelectionStart;
                                SelectionLength = tb.SelectionLength;
                                if (!controlFocus.GetType().Name.Equals("NumericUpDown"))
                                    ModificarTextBox(tb, true);
                                else
                                    errorProvider1.SetError(tb, "");
                            }
                        }
                    }
                    else
                    {
                        SelectionStart = tb.SelectionStart;
                        SelectionLength = tb.SelectionLength;
                    }
                    tb.Focus();
                    tb.Select(SelectionStart, SelectionLength);
                }
                else
                {
                    if (!controlFocus.GetType().Name.Equals("DateTimePicker") && !controlFocus.GetType().Name.Equals("RadioButton"))
                    {
                        if (textBox22.TextLength == 1)
                        {
                            if (textBox22.Text != "0")
                                textBox22.Text = "0";
                            else
                                Ding.Play();
                            SelectionStart = textBox22.TextLength;
                        }
                        else if (textBox22.TextLength > 0)
                        {
                            textBox22.Text = textBox22.Text.Remove(textBox22.TextLength - 1);
                            if (textBox22.Text == "-")
                                textBox22.Text = "0";
                            SelectionStart = textBox22.TextLength;
                        }
                        textBox22.Focus();
                    }
                    else
                        controlFocus.Select();
                }
            }
            else
            {
                Ding.Play();
                textBox22.Focus();
            }
        }

        private string DevolverCadena(TextBox control, char caracter)
        {
           string s = control.Text;
           switch(caracter)
           {
                case (char)Keys.Delete:
                    if(!(control.SelectionStart == control.TextLength && control.SelectionLength == 0))
                        return (control.SelectionLength > 0) ? s.Remove(control.SelectionStart, control.SelectionLength) : s.Remove(control.SelectionStart, 1);                                           
                    break;
                case (char)Keys.Back:
                    if(!(control.SelectionStart == 0 && control.SelectionLength == 0))
                        return (control.SelectionLength > 0) ? s.Remove(control.SelectionStart, control.SelectionLength) : s.Remove(control.SelectionStart - 1, 1);                                           
                    break;
                case (char)Keys.D0:
                case (char)Keys.D1:
                case (char)Keys.D2:
                case (char)Keys.D3:
                case (char)Keys.D4:
                case (char)Keys.D5:
                case (char)Keys.D6:
                case (char)Keys.D7:
                case (char)Keys.D8:
                case (char)Keys.D9:
                    return s.Remove(control.SelectionStart, control.SelectionLength).Insert(control.SelectionStart,caracter.ToString());
           }
           return s;
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != (char)Keys.Back)
                e.KeyChar = (char)Keys.Escape;
            else if ((e.KeyChar == (char)Keys.Back || (e.KeyChar > 47 && e.KeyChar < 58)) && ((DevolverCadena(numericUpDown1.Controls[1] as TextBox, e.KeyChar).Length > 3) || (TieneCerosIzquierda(numericUpDown1.Controls[1] as TextBox, e.KeyChar))))
            {
                errorProvider1.SetError(numericUpDown1.Controls[1] as TextBox, "");
                e.KeyChar = (char)Keys.Escape;
            }
            else
            {
                string s = DevolverCadena(numericUpDown1.Controls[1] as TextBox, e.KeyChar);
                string s1 = (numericUpDown1.Controls[1] as TextBox).Text;
                int SelectionStart = (numericUpDown1.Controls[1] as TextBox).SelectionStart, SelectionLength = (numericUpDown1.Controls[1] as TextBox).SelectionLength;
                if (s.Equals(""))
                {
                    numericUpDown1.Value = System.Convert.ToDecimal(1);
                    numericUpDown1.Value = System.Convert.ToDecimal(0);
                    (numericUpDown1.Controls[1] as TextBox).Text = "";
                }
                else
                {
                    numericUpDown1.Value = System.Convert.ToDecimal(1);
                    numericUpDown1.Value = System.Convert.ToDecimal(s);
                    (numericUpDown1.Controls[1] as TextBox).Text = s1;
                    (numericUpDown1.Controls[1] as TextBox).SelectionStart = SelectionStart;
                    (numericUpDown1.Controls[1] as TextBox).SelectionLength = SelectionLength;
                }
            }
        }

        private void radioButton1_Enter(object sender, EventArgs e)
        {
            controlFocus = radioButton1;
        }

        private void radioButton2_Enter(object sender, EventArgs e)
        {
            controlFocus = radioButton2;
        }

        private void radioButton3_Enter(object sender, EventArgs e)
        {
            controlFocus = radioButton3;
        }

        private void radioButton4_Enter(object sender, EventArgs e)
        {
            controlFocus = radioButton4;
            button9.Enabled = false;
        }

        private void radioButton5_Enter(object sender, EventArgs e)
        {
            controlFocus = radioButton5;
            button9.Enabled = false;
        }

        private void radioButton6_Enter(object sender, EventArgs e)
        {
            controlFocus = radioButton6;
            button9.Enabled = false;
        }

        private void radioButton7_Enter(object sender, EventArgs e)
        {
            controlFocus = radioButton7;
            button9.Enabled = false;
        }

        private void radioButton8_Enter(object sender, EventArgs e)
        {
            controlFocus = radioButton8;
            button9.Enabled = false;
        }

        private void radioButton9_Enter(object sender, EventArgs e)
        {
            controlFocus = radioButton9;
            button9.Enabled = false;
        }

        private void radioButton10_Enter(object sender, EventArgs e)
        {
            controlFocus = radioButton10;
            button9.Enabled = false;
        }

        private void radioButton11_Enter(object sender, EventArgs e)
        {
            controlFocus = radioButton11;
            button9.Enabled = false;
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            if (estándarToolStripMenuItem.Checked || estadísticasToolStripMenuItem.Checked)
            {
                if (textBox22.Text.Length > 14 && textBox22.Font.Size == 16)
                   textBox22.Font = new Font(this.textBox22.Font.FontFamily, 14);
                else if (textBox22.Text.Length <= 14 && textBox22.Font.Size == 14)
                   textBox22.Font = new Font(this.textBox22.Font.FontFamily, 16);
            }
            else if (programadorToolStripMenuItem.Checked)
            {
                if (radioButton6.Checked)
                   Tamanno();
                if (textBox22.TextLength > 0)
                {
                    string s;
                    s = DevolverBin();
                    Modificar8(s);
                }
            }
            textBox22.Select(textBox22.TextLength, 0);
        }

        private void numericUpDown2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != (char)Keys.Back)
                e.KeyChar = (char)Keys.Escape;
            else if ((e.KeyChar == (char)Keys.Back || (e.KeyChar > 47 && e.KeyChar < 58)) && ((DevolverCadena(numericUpDown2.Controls[1] as TextBox, e.KeyChar).Length > 3) || (TieneCerosIzquierda(numericUpDown2.Controls[1] as TextBox, e.KeyChar))))
            {
                errorProvider1.SetError(numericUpDown2.Controls[1] as TextBox, "");
                e.KeyChar = (char)Keys.Escape;
            }
            else
            {
                string s = DevolverCadena(numericUpDown2.Controls[1] as TextBox, e.KeyChar);
                string s1 = (numericUpDown2.Controls[1] as TextBox).Text;
                int SelectionStart = (numericUpDown2.Controls[1] as TextBox).SelectionStart, SelectionLength = (numericUpDown2.Controls[1] as TextBox).SelectionLength;
                if (s.Equals(""))
                {
                    numericUpDown2.Value = System.Convert.ToDecimal(1);
                    numericUpDown2.Value = System.Convert.ToDecimal(0);
                    (numericUpDown2.Controls[1] as TextBox).Text = "";
                }
                else
                {
                    numericUpDown1.Value = System.Convert.ToDecimal(1);
                    numericUpDown2.Value = System.Convert.ToDecimal(s);
                    (numericUpDown2.Controls[1] as TextBox).Text = s1;
                    (numericUpDown2.Controls[1] as TextBox).SelectionStart = SelectionStart;
                    (numericUpDown2.Controls[1] as TextBox).SelectionLength = SelectionLength;
                }
            }
        }

        private void numericUpDown3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)Keys.D0 || e.KeyChar > (char)Keys.D9) && e.KeyChar != (char)Keys.Back)
                e.KeyChar = (char)Keys.Escape;
            else if ((e.KeyChar == (char)Keys.Back || (e.KeyChar > 47 && e.KeyChar < 58)) && ((DevolverCadena(numericUpDown3.Controls[1] as TextBox, e.KeyChar).Length > 3) || (TieneCerosIzquierda(numericUpDown3.Controls[1] as TextBox, e.KeyChar))))
            {
                errorProvider1.SetError(numericUpDown3.Controls[1] as TextBox, "");
                e.KeyChar = (char)Keys.Escape;
            }
            else
            {
                string s = DevolverCadena(numericUpDown3.Controls[1] as TextBox, e.KeyChar);
                string s1 = (numericUpDown3.Controls[1] as TextBox).Text;
                int SelectionStart = (numericUpDown3.Controls[1] as TextBox).SelectionStart, SelectionLength = (numericUpDown3.Controls[1] as TextBox).SelectionLength;
                if (s.Equals(""))
                {
                    numericUpDown3.Value = System.Convert.ToDecimal(1);
                    numericUpDown3.Value = System.Convert.ToDecimal(0);
                    (numericUpDown3.Controls[1] as TextBox).Text = "";
                }
                else
                {
                    numericUpDown1.Value = System.Convert.ToDecimal(1);
                    numericUpDown3.Value = System.Convert.ToDecimal(s);
                    (numericUpDown3.Controls[1] as TextBox).Text = s1;
                    (numericUpDown3.Controls[1] as TextBox).SelectionStart = SelectionStart;
                    (numericUpDown3.Controls[1] as TextBox).SelectionLength = SelectionLength;
                }
            }
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if ((DevolverCadena(numericUpDown1.Controls[1] as TextBox, (char)e.KeyCode).Length > 3) || (TieneCerosIzquierda(numericUpDown1.Controls[1] as TextBox, (char)e.KeyCode)))
                {
                    errorProvider1.SetError(numericUpDown1.Controls[1] as TextBox, "");
                    Ding.Play();
                    e.Handled = true;
                }
                else
                {
                    string s = DevolverCadena(numericUpDown1.Controls[1] as TextBox, (char)e.KeyCode);
                    string s1 = (numericUpDown1.Controls[1] as TextBox).Text;
                    int SelectionStart = (numericUpDown1.Controls[1] as TextBox).SelectionStart, SelectionLength = (numericUpDown1.Controls[1] as TextBox).SelectionLength;
                    if (s.Equals(""))
                    {
                        numericUpDown1.Value = System.Convert.ToDecimal(1);
                        numericUpDown1.Value = System.Convert.ToDecimal(0);
                        (numericUpDown1.Controls[1] as TextBox).Text = "";
                    }
                    else
                    {
                        numericUpDown1.Value = System.Convert.ToDecimal(1);
                        numericUpDown1.Value = System.Convert.ToDecimal(s);
                        (numericUpDown1.Controls[1] as TextBox).Text = s1;
                        (numericUpDown1.Controls[1] as TextBox).SelectionStart = SelectionStart;
                        (numericUpDown1.Controls[1] as TextBox).SelectionLength = SelectionLength;
                    }
                }
            }            
        }

        private void numericUpDown2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if ((DevolverCadena(numericUpDown2.Controls[1] as TextBox, (char)e.KeyCode).Length > 3) || (TieneCerosIzquierda(numericUpDown2.Controls[1] as TextBox, (char)e.KeyCode)))
                {
                    errorProvider1.SetError(numericUpDown2.Controls[1] as TextBox, "");
                    Ding.Play();
                    e.Handled = true;
                }
                else
                {
                    string s = DevolverCadena(numericUpDown2.Controls[1] as TextBox, (char)e.KeyCode);
                    string s1 = (numericUpDown2.Controls[1] as TextBox).Text;
                    int SelectionStart = (numericUpDown2.Controls[1] as TextBox).SelectionStart, SelectionLength = (numericUpDown2.Controls[1] as TextBox).SelectionLength;
                    if (s.Equals(""))
                    {
                        numericUpDown2.Value = System.Convert.ToDecimal(1);
                        numericUpDown2.Value = System.Convert.ToDecimal(0);
                        (numericUpDown2.Controls[1] as TextBox).Text = "";
                    }
                    else
                    {
                        numericUpDown1.Value = System.Convert.ToDecimal(1);
                        numericUpDown2.Value = System.Convert.ToDecimal(s);
                        (numericUpDown2.Controls[1] as TextBox).Text = s1;
                        (numericUpDown2.Controls[1] as TextBox).SelectionStart = SelectionStart;
                        (numericUpDown2.Controls[1] as TextBox).SelectionLength = SelectionLength;
                    }
                }
            }
        }

        private void numericUpDown3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if ((DevolverCadena(numericUpDown3.Controls[1] as TextBox, (char)e.KeyCode).Length > 3) || (TieneCerosIzquierda(numericUpDown3.Controls[1] as TextBox, (char)e.KeyCode)))
                {
                    errorProvider1.SetError(numericUpDown3.Controls[1] as TextBox, "");
                    Ding.Play();
                    e.Handled = true;
                }
                else
                {
                    string s = DevolverCadena(numericUpDown3.Controls[1] as TextBox, (char)e.KeyCode);
                    string s1 = (numericUpDown3.Controls[1] as TextBox).Text;
                    int SelectionStart = (numericUpDown3.Controls[1] as TextBox).SelectionStart, SelectionLength = (numericUpDown3.Controls[1] as TextBox).SelectionLength;
                    if (s.Equals(""))
                    {
                        numericUpDown3.Value = System.Convert.ToDecimal(1);
                        numericUpDown3.Value = System.Convert.ToDecimal(0);
                        (numericUpDown3.Controls[1] as TextBox).Text = "";
                    }
                    else
                    {
                        numericUpDown1.Value = System.Convert.ToDecimal(1);
                        numericUpDown3.Value = System.Convert.ToDecimal(s);
                        (numericUpDown3.Controls[1] as TextBox).Text = s1;
                        (numericUpDown3.Controls[1] as TextBox).SelectionStart = SelectionStart;
                        (numericUpDown3.Controls[1] as TextBox).SelectionLength = SelectionLength;
                    }
                }
            }
        }

        private void textBox22_SizeChanged(object sender, EventArgs e)
        {
            HideCaret(textBox22.Handle);
        }        

        private void panel5_Enter(object sender, EventArgs e)
        {
            this.Modificar1(true);
            this.Modificar2(true);
            button9.Enabled = true;
            this.Modificar3(false);
            CambiarColor(false);
        }

        private void panel6_Enter(object sender, EventArgs e)
        {
            this.Modificar1(true);
            this.Modificar2(true);
            button9.Enabled = true;
            this.Modificar3(false);
            CambiarColor(false);
        }

        private void panel7_Enter(object sender, EventArgs e)
        {
            this.Modificar1(true);
            this.Modificar2(true);
            button9.Enabled = true;
            this.Modificar3(false);
            CambiarColor(false);
        }

        private void panel8_Enter(object sender, EventArgs e)
        {
            this.Modificar1(true);
            this.Modificar2(true);
            button9.Enabled = true;
            this.Modificar3(false);
            CambiarColor(false);
        }

        private void panel9_Enter(object sender, EventArgs e)
        {
            this.Modificar1(true);
            this.Modificar2(true);
            button9.Enabled = true;
            this.Modificar3(false);
            CambiarColor(false);
        }

        private void panel10_Enter(object sender, EventArgs e)
        {
            this.Modificar1(true);
            this.Modificar2(true);
            button9.Enabled = true;
            this.Modificar3(false);
            CambiarColor(false);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                this.ChequearRadioButtons();
                switch(controlFocusOld.Name)
                {
                    case "radioButton5":
                        /*
                        if (textBox22.Text[textBox22.TextLength - 1] == '-')
                        {
                            b = false;
                            textBox22.Text = textBox22.Text.Remove(textBox22.TextLength - 1, 1).Insert(0, "-");
                        }
                        b = true;
                        */
                        textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(textBox22.Text,10), 16).ToUpper();
                        break;
                    case "radioButton6":
                        textBox22.Font = new Font(this.textBox22.Font.FontFamily, 16);
                        textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(textBox22.Text, 2), 16).ToUpper();
                        break;                        
                    case "radioButton7":
                        textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(textBox22.Text, 8), 16).ToUpper();
                        break;
                }
                controlFocusOld = radioButton4;
                textBox22.Focus();
                textBox22.Select(textBox22.TextLength, 0);
            }
            else
                controlFocusOld = radioButton4;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                this.ChequearRadioButtons();
                switch (controlFocusOld.Name)
                {                    
                    case "radioButton4":
                        textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(textBox22.Text, 16), 10);
                        break;
                    case "radioButton6":
                        textBox22.Font = new Font(this.textBox22.Font.FontFamily, 16);
                        textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(textBox22.Text, 2), 10);
                        break;
                    case "radioButton7":
                        textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(textBox22.Text, 8), 10);
                        break;                    
                }
                if (textBox22.Text[0] == '-')
                {
                    textBox22.Text = textBox22.Text.Remove(0, 1).Insert(textBox22.TextLength - 1, "-");
                }
                controlFocusOld = radioButton5;
                textBox22.Focus();
                textBox22.Select(textBox22.TextLength, 0);
            }
            else
                controlFocusOld = radioButton5;
        }

        private void Tamanno()
        { 
           if(textBox22.TextLength > 56)
              textBox22.Font = new Font(this.textBox22.Font.FontFamily, 7);
           else if (textBox22.TextLength > 46 && textBox22.TextLength <= 56)
              textBox22.Font = new Font(this.textBox22.Font.FontFamily, 8);
           else if (textBox22.TextLength > 38 && textBox22.TextLength <= 46)
              textBox22.Font = new Font(this.textBox22.Font.FontFamily, 10);
           else if (textBox22.TextLength > 32 && textBox22.TextLength <= 38)
              textBox22.Font = new Font(this.textBox22.Font.FontFamily, 12);
           else if (textBox22.TextLength > 25 && textBox22.TextLength <= 32)
              textBox22.Font = new Font(this.textBox22.Font.FontFamily, 14);
           else if (textBox22.TextLength <= 25)
              textBox22.Font = new Font(this.textBox22.Font.FontFamily, 16);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                this.ChequearRadioButtons();
                switch (controlFocusOld.Name)
                {
                    case "radioButton5":
                        /*
                        if (textBox22.Text[textBox22.TextLength - 1] == '-')
                        {
                            b = false;
                            textBox22.Text = textBox22.Text.Remove(textBox22.TextLength - 1, 1).Insert(0, "-");
                        }
                        b = true;
                        */
                        textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(textBox22.Text, 10), 2);
                        break;
                    case "radioButton4":
                        textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(textBox22.Text, 16), 2);
                        break;
                    case "radioButton7":
                        textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(textBox22.Text, 8), 2);
                        break;
                }
                Tamanno();
                controlFocusOld = radioButton6;
                textBox22.Focus();
                textBox22.Select(textBox22.TextLength, 0);
            }
            else
                controlFocusOld = radioButton6;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                this.ChequearRadioButtons();
                switch (controlFocusOld.Name)
                {
                    case "radioButton5":
                        /*
                        if (textBox22.Text[textBox22.TextLength - 1] == '-')
                        {
                            b = false;
                            textBox22.Text = textBox22.Text.Remove(textBox22.TextLength - 1, 1).Insert(0, "-");
                        }
                        b = true;
                        */
                        textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(textBox22.Text, 10), 8);
                        break;
                    case "radioButton6":
                        textBox22.Font = new Font(this.textBox22.Font.FontFamily, 16);
                        textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(textBox22.Text, 2), 8);
                        break;
                    case "radioButton4":
                        textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(textBox22.Text, 16), 8);
                        break;
                }
                controlFocusOld = radioButton7;
                textBox22.Focus();
                textBox22.Select(textBox22.TextLength, 0);
            }
            else
                controlFocusOld = radioButton7;
        }

        private string DevolverBin()
        {
            string s = textBox22.Text;
            if(radioButton5.Checked)
            {
                    /*
                    if (s[s.Length - 1] == '-')
                    {
                        s = s.Remove(s.Length - 1, 1);
                        s = s.Insert(0, "-");
                    }
                    */
                    s = System.Convert.ToString(System.Convert.ToInt64(s, 10), 2);
            }
            else if(radioButton4.Checked)
            {
                    s = System.Convert.ToString(System.Convert.ToInt64(s, 16), 2);
            }
            else if(radioButton7.Checked)
            {
                    s = System.Convert.ToString(System.Convert.ToInt64(s, 8), 2);
            }            
            return s;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            this.ChequearRadioButtons();
            if (radioButton8.Checked)
            {
                ChequearRadioButtons1();
                textBox22.Focus();
                textBox22.Select(textBox22.TextLength, 0);
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            this.ChequearRadioButtons();
            if (radioButton9.Checked)
            {
                ChequearRadioButtons1();
                textBox22.Focus();
                textBox22.Select(textBox22.TextLength, 0);
            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            this.ChequearRadioButtons();
            if (radioButton10.Checked)
            {
                ChequearRadioButtons1();
                textBox22.Focus();
                textBox22.Select(textBox22.TextLength, 0);
            }
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            this.ChequearRadioButtons();
            if (radioButton11.Checked)
            {
                ChequearRadioButtons1();
                textBox22.Focus();
                textBox22.Select(textBox22.TextLength, 0);
            }
        }

        private void ColocarCaracter(char caracter)
        {
            if (!SePuede)
            {
                textBox22.Text = "0";
                SePuede = true;
            }
            if (mr3)
            {
                textBox22.Text = "0";
            }
            if (textBox22.Text == "0")
                textBox22.Text = "";
            string s = textBox22.Text.Insert(textBox22.TextLength, caracter.ToString());
            if (PuedeImprimir(caracter))
            {
                textBox22.Text = s;
                if (mr3)
                    mr3 = false;
            }
            else
                Ding.Play();
            textBox22.Focus();
            textBox22.Select(textBox22.TextLength, 0);
        }

        private void button72_Click(object sender, EventArgs e)
        {
            ColocarCaracter('A');
        }

        private void button80_Click(object sender, EventArgs e)
        {
            ColocarCaracter('B');
        }

        private void button71_Click(object sender, EventArgs e)
        {
            ColocarCaracter('C');
        }

        private void button73_Click(object sender, EventArgs e)
        {
            ColocarCaracter('D');
        }

        private void button59_Click(object sender, EventArgs e)
        {
            ColocarCaracter('E');
        }

        private void button61_Click(object sender, EventArgs e)
        {
            ColocarCaracter('F');
        }

        private string Operador1(string s)
        {
            if (s[0] != '-')
                return s.Insert(0, "-");
            else
                return s.Remove(0, 1);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (textBox22.Text != "0")
            {
                if (estándarToolStripMenuItem.Checked || estadísticasToolStripMenuItem.Checked || científicaToolStripMenuItem.Checked)
                {
                    textBox22.Text = Operador1(textBox22.Text);
                }
                else if (programadorToolStripMenuItem.Checked)
                {
                    if (radioButton4.Checked)
                    {
                        textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(Operador1(System.Convert.ToString(System.Convert.ToInt64(textBox22.Text, 16), 10)), 10), 16).ToUpper();
                    }
                    else if (radioButton6.Checked)
                    {
                        textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(Operador1(System.Convert.ToString(System.Convert.ToInt64(textBox22.Text, 2), 10)), 10), 2);
                    }
                    else if (radioButton7.Checked)
                    {
                        textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(Operador1(System.Convert.ToString(System.Convert.ToInt64(textBox22.Text, 8), 10)), 10), 8);
                    }
                    else
                        textBox22.Text = Operador1(textBox22.Text);
                }
                mr2 = true;
            }
            textBox22.Focus();
        }

        private decimal TextBox22To()
        {
            if (estándarToolStripMenuItem.Checked || científicaToolStripMenuItem.Checked || estadísticasToolStripMenuItem.Checked)
            {
                return System.Convert.ToDecimal(textBox22.Text);
            }
            else if (programadorToolStripMenuItem.Checked)
            {
                if (radioButton4.Checked)
                    return System.Convert.ToInt64(textBox22.Text, 16);
                else if (radioButton6.Checked)
                    return System.Convert.ToInt64(textBox22.Text, 2);
                else if (radioButton7.Checked)
                    return System.Convert.ToInt64(textBox22.Text, 8);
                else if (radioButton5.Checked)
                    return System.Convert.ToInt64(textBox22.Text, 10);
            }
            return 0;
        }

        private decimal Operacion1(decimal o1, string opp, decimal o2)
        {
            switch (opp)
            {
                case "+":
                    return o1 + o2;
                case "-":
                    return o1 - o2;
                case "*":
                    return o1 * o2;
                case "/":
                    if (o2 == 0)
                        throw new DivideByZeroException("No se puede dividir entre cero");
                    return o1 / o2;
            }
            if (opp == null)
               return o1;
            else
               return 0;            
        }

        private void Operacion2()
        {
            if (controlFocus.Name.Equals("textBox22") || controlFocus.GetType().Name.Contains("RadioButton") || controlFocus.GetType().Name.Contains("ComboBox") || controlFocus.Name.Equals("button3") || controlFocus.Name.Equals("button4") || controlFocus.Name.Equals("button5") || controlFocus.Name.Equals("button6") || controlFocus.Name.Equals("button7"))
            {
                mr3 = true;
                if (op != "" && op != null)
                {
                    try
                    {
                        if (textBox23.Text != "")
                        {
                            if (SePuede || (!SePuede && mr2) || (!SePuede && mr1) || raiz)
                            {
                                bb = TextBox22To();
                                M2 = (decimal?)bb;
                                aa = Operacion1(aa, op, bb);
                                SePuede = !SePuede;
                                mr2 = false;
                                mr1 = false;
                                if (EsEntero(aa.ToString()))
                                    ToTextBox22((Int64)aa);
                                else
                                    ToTextBox22(aa);
                            }
                            else if (!SePuede && !mr2)
                            {
                                bb = aa;
                                aa = Operacion1(bb, op, bb);
                                M2 = null;
                                SePuede = true;
                                if (EsEntero(aa.ToString()))
                                    ToTextBox22((Int64)aa);
                                else
                                    ToTextBox22(aa);
                            }
                            textBox23.Text = "";
                            raiz = false;
                        }
                        else
                        {
                            if (M2 == null)
                            {
                                aa = Operacion1(TextBox22To(), op, bb);
                                if (EsEntero(aa.ToString()))
                                    ToTextBox22((Int64)aa);
                                else
                                    ToTextBox22(aa);
                            }
                            else
                            {
                                aa = Operacion1(TextBox22To(), op, (decimal)M2);
                                if (EsEntero(aa.ToString()))
                                    ToTextBox22((Int64)aa);
                                else
                                    ToTextBox22(aa);
                            }
                            SePuede = false;

                        }
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("El valor resultante de la operación aritmética es demasiado grande o demasiado pequeño", "Error de desbordamiento para operaciones aritméticas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox22.Text = "0";
                        textBox23.Text = "";
                        SePuede = true;
                        mr1 = false;
                        mr2 = false;
                        mr3 = false;
                        M = 0;
                        M2 = null;
                        label53.Visible = false;
                        op = null;
                        aa = bb = 0;
                        raiz = false;
                    }
                    catch (DivideByZeroException e)
                    {
                        MessageBox.Show(e.Message, "Error de división por cero", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox22.Text = "0";
                        textBox23.Text = "";
                        SePuede = true;
                        mr1 = false;
                        mr2 = false;
                        mr3 = false;
                        M = 0;
                        M2 = null;
                        label53.Visible = false;
                        op = null;
                        aa = bb = 0;
                        raiz = false;
                    }
                }
                else
                {
                    if (EsEntero(TextBox22To().ToString()))
                        ToTextBox22((Int64)TextBox22To());
                    else
                        ToTextBox22(TextBox22To());
                    textBox23.Text = "";
                    if (raiz)
                    {
                        aa = TextBox22To();
                        raiz = false;
                    }                    
                }
            }            
            textBox22.Focus();
        }

        private void Dev(decimal o1, int a, int i)
        {
            string s;
            if(o1.ToString().Length > a + i)
               s = o1.ToString().Substring(0, a + i - 1);
            else
               s = o1.ToString();
            textBox22.Text = (s[s.Length - 1] == ',') ? s.Remove(s.Length-1): s;
        }

        private void ToTextBox22(decimal o1)
        {
            int i = (o1.ToString().Contains('-')) ? (1 + (o1.ToString().Contains(',') ? 1 : 0)) : (0 + (o1.ToString().Contains(',') ? 1 : 0));
            if (estándarToolStripMenuItem.Checked || estadísticasToolStripMenuItem.Checked)
            {
                Dev(o1, 16, i);
            }
            else if (científicaToolStripMenuItem.Checked)
            {
                Dev(o1,28,i);
            }
            else if (programadorToolStripMenuItem.Checked)
            {
                if (radioButton4.Checked)
                    textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(o1.ToString(), 10), 16).ToUpper();
                else if (radioButton6.Checked)
                    textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(o1.ToString(), 10), 2);
                else if (radioButton7.Checked)
                    textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(o1.ToString(), 10), 8);
                else if (radioButton5.Checked)
                    textBox22.Text = System.Convert.ToString(System.Convert.ToInt64(o1.ToString(), 10), 10);
            }
        }

        private bool EsEntero(string numero)
        {
            return (numero.Contains(',')) ? ((numero.IndexOf('1', numero.IndexOf(',')) == -1) && 
                                             (numero.IndexOf('2', numero.IndexOf(',')) == -1) && 
                                             (numero.IndexOf('3', numero.IndexOf(',')) == -1) && 
                                             (numero.IndexOf('4', numero.IndexOf(',')) == -1) && 
                                             (numero.IndexOf('5', numero.IndexOf(',')) == -1) && 
                                             (numero.IndexOf('6', numero.IndexOf(',')) == -1) && 
                                             (numero.IndexOf('7', numero.IndexOf(',')) == -1) && 
                                             (numero.IndexOf('8', numero.IndexOf(',')) == -1) && 
                                             (numero.IndexOf('9', numero.IndexOf(',')) == -1)
                                            ) : true;
        }

        private void Operacion(string opp)
        {
            if (controlFocus.Name.Equals("textBox22") || controlFocus.GetType().Name.Contains("RadioButton") || controlFocus.GetType().Name.Contains("ComboBox") || controlFocus.Name.Equals("button3") || controlFocus.Name.Equals("button4") || controlFocus.Name.Equals("button5") || controlFocus.Name.Equals("button6") || controlFocus.Name.Equals("button7"))
            {
                if (!SePuede && !mr2 && !raiz)
                {
                    if (!mr1)
                    {
                        string s = textBox23.Text;
                        if (textBox23.TextLength > 0)
                        {
                            s = s.Remove(s.Length - 2);
                            textBox23.Text = s.Insert(s.Length, opp + " ");
                        }
                        else
                            textBox23.Text = textBox22.Text + "  " + opp + " ";
                        op = opp;
                    }
                    else
                    {
                        try
                        {
                            try
                            {
                                if (textBox23.TextLength > 0)
                                {
                                    aa = Operacion1(aa, op, M);
                                    textBox23.Text = textBox23.Text + " " + M.ToString() + "  " + opp + " ";
                                    if (EsEntero(aa.ToString()))
                                        ToTextBox22((Int64)aa);
                                    else
                                        ToTextBox22(aa);
                                    op = opp;
                                    //mr1 = false;
                                }
                                else
                                {
                                    textBox23.Text = textBox22.Text + "  " + opp + " ";
                                    if (op == null)
                                    {
                                        op = opp;
                                        aa = TextBox22To();
                                    }
                                    else
                                        aa = Operacion1(aa, op, M);
                                    //mr1 = false;
                                }
                            }
                            catch (OverflowException)
                            {
                                MessageBox.Show("El valor resultante de la operación aritmética es demasiado grande o demasiado pequeño", "Error de desbordamiento para operaciones aritméticas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox22.Text = "0";
                                textBox23.Text = "";
                                SePuede = true;
                                //mr1 = false;
                                mr2 = false;
                                mr3 = false;
                                M = 0;
                                M2 = null;
                                label53.Visible = false;
                                op = null;
                                aa = bb = 0;
                                raiz = false;
                            }
                        }
                        catch (DivideByZeroException e)
                        {
                            MessageBox.Show(e.Message, "Error de división por cero", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox22.Text = "0";
                            textBox23.Text = "";
                            SePuede = true;
                            //mr1 = false;
                            mr2 = false;
                            mr3 = false;
                            M = 0;
                            M2 = null;
                            label53.Visible = false;
                            op = null;
                            aa = bb = 0;
                            raiz = false;
                        }
                        mr1 = false;
                    }
                }
                else if (SePuede || (!SePuede && mr2) || raiz)
                {
                    if (textBox23.TextLength == 0 || (raiz && NoHayOperador()))
                    {
                        aa = TextBox22To();
                        if (raiz && NoHayOperador())
                            textBox23.Text = textBox23.Text + " " + opp + " ";
                        else
                            textBox23.Text = aa.ToString() + "  " + opp + " ";
                        op = opp;
                        //mr2 = false;
                        //mr1 = false;
                    }
                    else
                    {
                        bb = TextBox22To();
                        try
                        {
                            try
                            {
                                aa = Operacion1(aa, op, bb);
                                if (raiz)
                                    textBox23.Text = textBox23.Text + " " + opp + " ";
                                else
                                    textBox23.Text = textBox23.Text + " " + bb.ToString() + "  " + opp + " ";
                                if (EsEntero(aa.ToString()))
                                    ToTextBox22((Int64)aa);
                                else
                                    ToTextBox22(aa);
                                op = opp;
                                //mr1 = false;
                            }
                            catch (OverflowException)
                            {
                                MessageBox.Show("El valor resultante de la operación aritmética es demasiado grande o demasiado pequeño", "Error de desbordamiento para operaciones aritméticas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox22.Text = "0";
                                textBox23.Text = "";
                                SePuede = true;
                                //mr1 = false;
                                //mr2 = false;
                                mr3 = false;
                                M = 0;
                                M2 = null;
                                label53.Visible = false;
                                op = null;
                                aa = bb = 0;
                                raiz = false;
                            }
                        }
                        catch (DivideByZeroException e)
                        {
                            MessageBox.Show(e.Message, "Error de división por cero", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox22.Text = "0";
                            textBox23.Text = "";
                            SePuede = true;
                            //mr1 = false;
                            //mr2 = false;
                            mr3 = false;
                            M = 0;
                            M2 = null;
                            label53.Visible = false;
                            op = null;
                            aa = bb = 0;
                            raiz = false;
                        }
                    }
                    mr2 = false;
                    mr1 = false;
                    raiz = false;
                }
                textBox22.Focus();
            }
            else
                controlFocus.Focus();
        }

        private bool NoHayOperador()
        {
            return (textBox23.Text.IndexOf('+') == -1 && textBox23.Text.IndexOf('-') == -1 && textBox23.Text.IndexOf('*') == -1 && textBox23.Text.IndexOf('/') == -1);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Operacion("+");
            SePuede = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Operacion("-");
            SePuede = false;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Operacion("*");
            SePuede = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Operacion("/");
            SePuede = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Operacion2();
        }

        private void MC()//
        {
            //MC (Memory Clear):
            //Elimina cualquier número almacenado en memoria.
            //Combinación de teclas: CTRL+L
            M = 0;
            label53.Visible = false;
            mr1 = false;
            textBox22.Focus();
        }

        private decimal MR()//ya
        {
            //MR (Memory Recall):
            //Recupera el número almacenado en memoria. El número permanece en memoria.
            //Combinación de teclas: CTRL+R
            mr1 = true;
            mr2 = false;
            textBox22.Focus();
            return M;            
        }

        private void MS()//ya
        { 
           //MS (Memory Storage):
           //Almacena en memoria el número mostrado.
           //Combinación de teclas: CTRL+M
           if ((SePuede || (M.ToString() != textBox22.Text)) && textBox22.Text != "0")
           {
               M = System.Convert.ToDecimal(textBox22.Text);
               label53.Visible = true;
               mr2 = true;
               if (SePuede)// && !mr1)
               {
                   //mr1 = true;
                   SePuede = false;
               }
           }
           textBox22.Focus();                      
        }

        private void M_Plus()
        {
            //M+:
            //Suma el número mostrado a otro número que se encuentre en memoria pero no muestra la suma de estos números.
            //Combinación de teclas: CTRL+P

            textBox22.Focus();
        }

        private void M_Minus()
        { 
           //M-:
           //Resta el número mostrado a otro número que se encuentre en memoria pero no muestra la resta de estos números.
           //Combinación de teclas: CTRL+Q
           
           textBox22.Focus();
        }

        private void CE()//ya
        { 
           //CE (Clear Error):
           //Elimina el número mostrado. Se utiliza para cuando se comete un error en el ingreso de datos pero sin eliminar todo el calculo que se encuentra realizando.
           //Combinación de teclas: SUPRIMIR
           textBox22.Text = "0";
           if (raiz) 
               raiz = false;
           if (NoHayOperador())
               textBox23.Text = "";
           else if(!OperadorAlFinal())
               textBox23.Text = textBox23.Text.Remove(System.Math.Max(System.Math.Max(textBox23.Text.LastIndexOf('+'), textBox23.Text.LastIndexOf('-')), System.Math.Max(textBox23.Text.LastIndexOf('*'), textBox23.Text.LastIndexOf('/'))) + 2);
           mr2 = true;
           textBox22.Focus();
        }

        private void C()//ya
        { 
           //C (Clear):
           //Elimina todo el cálculo actual.
           //Combinación de teclas: ESC
           textBox22.Text = "0";
           textBox23.Text = "";
           op = "";
           aa = bb = 0;
           M2 = null;
           raiz = false;
           //bool v, SePuede = true, mr1 = false, mr2 = false, mr3 = false, Handled = false;
           textBox22.Focus();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox22.Text = MR().ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            C();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            CE();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MS();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MC();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            double valor;
            if (controlFocus.Name.Equals("textBox22") || controlFocus.GetType().Name.Contains("RadioButton") || controlFocus.GetType().Name.Contains("ComboBox") || controlFocus.Name.Equals("button3") || controlFocus.Name.Equals("button4") || controlFocus.Name.Equals("button5") || controlFocus.Name.Equals("button6") || controlFocus.Name.Equals("button7"))
            {
                if (textBox22.Text != "")
                {
                    System.Double.TryParse(textBox22.Text, out valor);
                    try
                    {
                        if (valor < 0)
                            throw new Exception("Entrada no válida");
                        string x = textBox22.Text;
                        ToTextBox22(System.Convert.ToDecimal(System.Math.Sqrt(valor)));
                        if (textBox23.Text != "")
                        {
                            if (raiz == false)
                                textBox23.Text = textBox23.Text + " sqrt(" + x + ") ";
                            else
                            {
                                textBox23.Text = textBox23.Text.Insert(textBox23.Text.LastIndexOf("sqrt"), "sqrt(");
                                textBox23.Text = textBox23.Text.Insert(textBox23.Text.LastIndexOf(')'), ")");
                            }
                        }
                        else
                            textBox23.Text = "sqrt(" + x + ") ";
                        SePuede = false;
                        raiz = true;
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message, "Error de entrada de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox22.Text = "0";
                        textBox23.Text = "";
                        SePuede = true;
                        mr1 = false;
                        mr2 = false;
                        mr3 = false;
                        M = 0;
                        M2 = null;
                        label53.Visible = false;
                        op = null;
                        aa = bb = 0;
                        raiz = false;
                    }
                }
                textBox22.Focus();
            }
            else
                controlFocus.Focus();
        }

        public bool OperadorAlFinal()
        {
            int l = textBox23.TextLength;
            return (textBox23.Text.LastIndexOf('+') == l - 2 || textBox23.Text.LastIndexOf('-') == l - 2 || textBox23.Text.LastIndexOf('*') == l - 2 || textBox23.Text.LastIndexOf('/') == l - 2);
        }
    }
}
