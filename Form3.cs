using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MixMaster_decrypter_ver_2
{
    public partial class Form3 : Form
    {
        Confs cf = new Confs();

        public Form3()
        {
            InitializeComponent();
            int tipo =  cf.MinhaCriptografia;

            if (tipo == -1)
            {
                comboBox1.Text = "MixMaster Up";
            }
            else if (tipo == 0)
            {
                comboBox1.Text = "MixMaster normal";
            }
            else if (tipo == 1)
            {
                comboBox1.Text = "MixMaster AU 2009";
            }
            else if (tipo == 2)
            { 
                comboBox1.Text = "MixMaster FR";
            }
            else if (tipo == 3)
            {
                comboBox1.Text = "MixMaster 77PB";
            }
            else if (tipo == 4)
            {
                comboBox1.Text = "MixMaster World";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string type = comboBox1.Text;

            if (type == "MixMaster Up")
            {
                cf.MinhaCriptografia = -1;
            }
            else if(type == "MixMaster normal")
            {
                cf.MinhaCriptografia = 0;
            }
            else if (type == "MixMaster AU 2009")
            {
                cf.MinhaCriptografia = 1;
            }
            else if (type == "MixMaster FR")
            {
                cf.MinhaCriptografia = 2;
            }
            else if (type == "MixMaster 77PB")
            {
                cf.MinhaCriptografia = 3;
            }
            else if (type == "MixMaster World")
            {
                cf.MinhaCriptografia = 4;
            }
            MessageBox.Show("Criptografia trocada para: " + type.ToString());
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
