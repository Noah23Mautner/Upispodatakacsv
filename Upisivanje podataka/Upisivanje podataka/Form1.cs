using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upisivanje_podataka
{
    public partial class Form1 : Form
    {
        List<Osoba> listaOsoba = new List<Osoba>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_brisanje_Click(object sender, EventArgs e)
        {
            txt_email.Clear();
            txt_godinaRodjenja.Clear(); 
            txt_ime.Clear();
            txt_prezime.Clear();
        }

        private void btn_upis_Click(object sender, EventArgs e)
        {
            // Osoba osoba = new Osoba();
            try
            {
                Osoba osoba = new Osoba(txt_ime.Text, txt_prezime.Text, txt_email.Text, Convert.ToInt16(txt_godinaRodjenja.Text));

                txt_email.Clear();
                txt_godinaRodjenja.Clear();
                txt_ime.Clear();
                txt_prezime.Clear();
                txt_ime.Focus();

              DialogResult upit =  MessageBox.Show("Želi teli unesti još podataka", "Upit",
                  MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                switch(upit) { 
                case DialogResult.Yes:
                        {
                            listaOsoba.Add(osoba);
                            break;
                        }
                        case DialogResult.No:
                        {

                            txt_ime.Enabled = false;    
                            txt_prezime.Enabled = false;    
                            txt_godinaRodjenja.Enabled = false;
                            txt_email.Enabled = false;
                            break;
                        }
                }
            }
            catch(Exception greska) { 
                MessageBox.Show(greska.Message,"Pogrešan unos"
                  ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }   
        }
    }
}
