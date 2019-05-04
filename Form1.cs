using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MixMaster_decrypter_ver_2
{
    public partial class Form1 : Form
    {
        public FileInfo[] allFiles;
        Confs conf = new Confs();

        byte[] key = { 0x32, 0x5E, 0xC1, 0xA0, 0x72, 0x13, 0xBB, 0x43, 0x4C, 0x61, 0xD4, 0xCE, 0x98, 0x9A, 0x49, 0x23, 0x05, 0x11, 0xE5, 0x51, 0xDF, 0x9E, 0xD5, 0x96, 0x5A, 0x45, 0x10, 0x3E, 0x6A, 0xDC, 0x1F, 0x84, 0x1B, 0x0E, 0x2B, 0x0C, 0xA3, 0x7B, 0x9D, 0xDE, 0xC5, 0x01, 0x60, 0xAE, 0x92, 0xC7, 0x3D, 0x20, 0x8E, 0x64, 0x1A, 0xC3, 0xE0, 0x73, 0x67, 0x1E, 0x50, 0x0D, 0xB0, 0xC6, 0x2D, 0x82, 0x63, 0x6D, 0x99, 0x48, 0xFE, 0x14, 0xA4, 0x83, 0xE1, 0xA7, 0x8C, 0x8A, 0x1D, 0xC4, 0x8D, 0x03, 0x90, 0x5D, 0xD3, 0x12, 0x74, 0x57, 0x3A, 0xE9, 0x5B, 0xAF, 0x7A, 0x25, 0xA1, 0xE4, 0x26, 0x80, 0x0A, 0xDA, 0xFB, 0xF7, 0x47, 0x6B, 0x93, 0x1C, 0xCF, 0x0B, 0x24, 0xF2, 0x9C, 0x76, 0xEB, 0x30, 0x3F, 0xC9, 0xBE, 0x2A, 0xD1, 0x6E, 0x75, 0x86, 0xF5, 0xC2, 0xF8, 0x6C, 0x36, 0x06, 0x87, 0x35, 0x58, 0x81, 0x4D, 0xF9, 0x89, 0x02, 0x55, 0xDB, 0xCB, 0xB3, 0x28, 0xCA, 0x15, 0x9B, 0xED, 0x7C, 0xEA, 0x7F, 0xF3, 0x21, 0xB8, 0xB9, 0x9F, 0x29, 0x8F, 0x37, 0xB7, 0x19, 0x97, 0x4E, 0x68, 0x6F, 0x7D, 0x44, 0xE7, 0x2E, 0xAA, 0x08, 0xD7, 0xA9, 0xF0, 0x59, 0x18, 0xFA, 0x3C, 0x41, 0xC0, 0x71, 0xAC, 0xA5, 0x00, 0x7E, 0xFD, 0x07, 0xB4, 0x31, 0xB5, 0x52, 0x94, 0x40, 0xEC, 0x5C, 0xA8, 0xA2, 0xD6, 0xE3, 0xAB, 0x79, 0x2C, 0x0F, 0xBD, 0xE8, 0xD9, 0xB6, 0x2F, 0x77, 0xA6, 0x56, 0x8B, 0xF4, 0x42, 0x5F, 0x27, 0xAD, 0xDD, 0x53, 0xE6, 0x34, 0xFC, 0xD8, 0xEE, 0x91, 0x16, 0x85, 0xB1, 0xCD, 0x54, 0xD2, 0xB2, 0x65, 0xBF, 0x62, 0xF1, 0x88, 0xFF, 0x78, 0x70, 0x3B, 0x4A, 0x95, 0xEF, 0xBC, 0xC8, 0x38, 0xBA, 0x17, 0x22, 0x4B, 0x39, 0x33, 0x46, 0x69, 0x09, 0xCC, 0x66, 0xD0, 0x4F, 0x04, 0xF6, 0xE2 };
        byte bin_key = 0x66;
        byte bin_key2 = 0x55;


        public Form1()
        {
            InitializeComponent();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    var extensions = new List<string>();

                    var dir = new DirectoryInfo(fbd.SelectedPath);

                    if (checkBox1.Checked && checkBox2.Checked)
                    {
                        extensions.Add(".sct");
                        extensions.Add(".cfg");
                    }
                    else if (checkBox1.Checked)
                    {
                        extensions.Add(".sct");
                    }
                    else if (checkBox2.Checked)
                    {
                        extensions.Add(".cfg");
                    }

                    extensions.Add(".fil");
                    extensions.Add(".dat");

                    FileInfo[] allFiles = dir.EnumerateFiles().Where(f => extensions.Contains(f.Extension.ToLower())).ToArray();
                
                    
                    
                    textBox1.Text = fbd.SelectedPath;


                    listBox1.Items.Clear();

                    int files = 0;
                    foreach (FileInfo file in allFiles)
                    {
                        listBox1.Items.Add(file);
                        files++;
                    }
                    label3.Text = "Arquivos: " + files.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBox2.Text = fbd.SelectedPath;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Cript();
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Diretório de entrada invalido!");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Diretório de saída invalido!");
            }
        }

        

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void sobreToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();

            fr2.Show();
        }

        private void configuraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fr3 = new Form3();
            fr3.Show();
        }

        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (RBDescryptar.Checked == true)
            {
                button3.Text = "Decryptar todos";
                button4.Text = "Decryptar Selecionado";
            }
            else if(RBEncryptar.Checked == true)
            {
                button3.Text = "Encryptador Todos";
                button4.Text = "Encryptar Selecionado";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem;
            if (item != null)
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    CriptSelected(item.ToString());
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Diretório de entrada invalido!");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Diretório de saída invalido!");
                }
            }
            
        }

        public void Cript()
        {
            int tipo = conf.MinhaCriptografia;

            if (tipo == -1)
            {
                bin_key = conf.GetMixMasterUpPublicsKey[0];
                bin_key2 = conf.GetMixMasterUpPublicsKey[1];
            }

            else if (tipo == 0)
            {
                bin_key = conf.GetMixMasterNormalPublicsKey[0];
                bin_key2 = conf.GetMixMasterNormalPublicsKey[1];
            }
            else if (tipo == 1)
            {
                bin_key = conf.GetMixMasterAU2009PublicsKey[0];
                bin_key2 = conf.GetMixMasterAU2009PublicsKey[1];
            }
            else if (tipo == 2)
            {
                bin_key = conf.GetMixMasterFRPublicsKey[0];
                bin_key2 = conf.GetMixMasterFRPublicsKey[1];
            }
            else if (tipo == 3)
            {
                bin_key = conf.GetMixMaster77PBPublicsKey[0];
                bin_key2 = conf.GetMixMaster77PBPublicsKey[1];
            }
            else if (tipo == 4)
            {
                bin_key = conf.GetMixMasterWorldPubicsKey[0];
                bin_key2 = conf.GetMixMasterWorldPubicsKey[1];
            }
     



            if (RBDescryptar.Checked)
            {
                int contador = 0;
                foreach (var arquivo in listBox1.Items)
                {
                    contador++;
                    byte[] bytesArquivos = File.ReadAllBytes(textBox1.Text + @"\" + arquivo);
                    int keyValue = -1;

                    for (int i = 0; i < bytesArquivos.Length; i++)
                    {
                        if (keyValue == 255)
                            keyValue = 0;
                        else
                            keyValue += 1;

                        byte xor1 = (byte)(bin_key ^ key[keyValue]);
                        byte xor2 = (byte)(xor1 ^ bytesArquivos[i]);
                        bytesArquivos[i] = (byte)(xor2 ^ bin_key2);
                    }
                    File.WriteAllBytes(textBox2.Text + @"\" + arquivo, bytesArquivos);
                    label3.Text = "Arquivos: " + (listBox1.Items.Count - contador).ToString();
                }
                MessageBox.Show("Arquivos Descryptados: " + contador.ToString());

            }
            else if (RBEncryptar.Checked)
            {
                int contador = 0;
                foreach (var arquivo in listBox1.Items)
                {
                    contador++;
                    byte[] bytesArquivos = File.ReadAllBytes(textBox1.Text + @"\" + arquivo);
                    int keyValue = -1;

                    for (int i = 0; i < bytesArquivos.Length; i++)
                    {
                        if (keyValue == 255)
                            keyValue = 0;
                        else
                            keyValue += 1;

                        byte xor1 = (byte)(bin_key2 ^ key[keyValue]);
                        byte xor2 = (byte)(xor1 ^ bytesArquivos[i]);
                        bytesArquivos[i] = (byte)(xor2 ^ bin_key);
                    }
                    File.WriteAllBytes(textBox2.Text + @"\" + arquivo, bytesArquivos);
                    label3.Text = "Arquivos: " + (listBox1.Items.Count - contador).ToString();
                }
                MessageBox.Show("Arquivos Encryptados: " + contador.ToString());

            }

        }

        public void CriptSelected(string file)
        {
            int tipo = conf.MinhaCriptografia;


            if (tipo == -1)
            {
                bin_key = conf.GetMixMasterUpPublicsKey[0];
                bin_key2 = conf.GetMixMasterUpPublicsKey[1];
            }
            else if (tipo == 0)
            {
                bin_key = conf.GetMixMasterNormalPublicsKey[0];
                bin_key2 = conf.GetMixMasterNormalPublicsKey[1];
            }
            else if (tipo == 1)
            {
                bin_key = conf.GetMixMasterAU2009PublicsKey[0];
                bin_key2 = conf.GetMixMasterAU2009PublicsKey[1];
            }
            else if (tipo == 2)
            {
                bin_key = conf.GetMixMasterFRPublicsKey[0];
                bin_key2 = conf.GetMixMasterFRPublicsKey[1];
            }
            else if (tipo == 3)
            {
                bin_key = conf.GetMixMaster77PBPublicsKey[0];
                bin_key2 = conf.GetMixMaster77PBPublicsKey[1];
            }
            else if (tipo == 4)
            {
                bin_key = conf.GetMixMasterWorldPubicsKey[0];
                bin_key2 = conf.GetMixMasterWorldPubicsKey[1];
            }

            if (RBDescryptar.Checked)
            {
                    byte[] bytesArquivos = File.ReadAllBytes(textBox1.Text + @"\" + file);
                    int keyValue = -1;

                    for (int i = 0; i < bytesArquivos.Length; i++)
                    {
                        if (keyValue == 255)
                            keyValue = 0;
                        else
                            keyValue += 1;

                        byte xor1 = (byte)(bin_key ^ key[keyValue]);
                        byte xor2 = (byte)(xor1 ^ bytesArquivos[i]);
                        bytesArquivos[i] = (byte)(xor2 ^ bin_key2);
                    }
                    File.WriteAllBytes(textBox2.Text + @"\" + file, bytesArquivos);
                    label3.Text = "Arquivos: " + (listBox1.Items.Count - 1).ToString();
                MessageBox.Show(file + " Foi descryptado!");
            }
            else if (RBEncryptar.Checked)
            {
                    byte[] bytesArquivos = File.ReadAllBytes(textBox1.Text + @"\" + file);
                    int keyValue = -1;

                    for (int i = 0; i < bytesArquivos.Length; i++)
                    {
                        if (keyValue == 255)
                            keyValue = 0;
                        else
                            keyValue += 1;

                        byte xor1 = (byte)(bin_key2 ^ key[keyValue]);
                        byte xor2 = (byte)(xor1 ^ bytesArquivos[i]);
                        bytesArquivos[i] = (byte)(xor2 ^ bin_key);
                    }
                    File.WriteAllBytes(textBox2.Text + @"\" + file, bytesArquivos);
                    label3.Text = "Arquivos: " + (listBox1.Items.Count - 1).ToString();
                MessageBox.Show(file + " Foi Encryptado!");
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }



    }
}
