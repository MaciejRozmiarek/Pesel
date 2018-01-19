using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pesel
{
    public partial class Form1 : Form
    {

        private int sumaKontrolnaPesel;
        private int sumaKontrolnaNIP;
        private string czyPrawidłowy;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pesel = textBox1.Text;
            string[] tablica = new string[pesel.Length];
            int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int licz = 0;
            int suma = 0;

            if (pesel.Length == 11)
            {

            
            try
            {
                for (int p = 0; p < pesel.Length; p++)
                {
                    tablica[p] = pesel.Substring(licz, 1);
                    licz++;
                }

                for (int i = 0; i < wagi.Length; i++)
                {
                    suma += wagi[i] * Int32.Parse(tablica[i]);
                }
                int wynik = suma % 10;

                if (wynik == 10)
                {
                    sumaKontrolnaPesel = 0;
                }
                else
                {
                    sumaKontrolnaPesel = 10 - wynik;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
            //weryfikacja poprawności peselu

            if (tablica[10] == sumaKontrolnaPesel.ToString())
            {
                czyPrawidłowy = "jest PRAWIDŁOWY!!!";
            }
            else
            {
                czyPrawidłowy = "jest NIEPRAWIDŁOWY!!!";
            }

            MessageBox.Show("Suma kontrolna z podanego peselu to " + tablica[10] + "\nGdzie wyliczona suma kontrolna " + sumaKontrolnaPesel + ". \nPesel " + czyPrawidłowy);
            }
            else
            {
                MessageBox.Show("Pesel za krótki ");
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nip = textBox2.Text;
            string[] tablica = new string[nip.Length];
            int[] wagi = { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
            int licz = 0;
            int suma = 0;

            if (nip.Length == 10)
            {

            
            try
            {
                for (int p = 0; p < nip.Length; p++)
                {
                    tablica[p] = nip.Substring(licz, 1);
                    licz++;
                }

                for (int i = 0; i < wagi.Length; i++)
                {
                    suma += wagi[i] * Int32.Parse(tablica[i]);
                }
                sumaKontrolnaNIP = suma % 11;
                
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
            //weryfikacja poprawności peselu

            if (tablica[9] == sumaKontrolnaNIP.ToString())
            {
                czyPrawidłowy = "jest PRAWIDŁOWY!!!";
            }
            else
            {
                czyPrawidłowy = "jest NIEPRAWIDŁOWY!!!";
            }

            MessageBox.Show("Suma kontrolna z podanego peselu to " + tablica[9] + "\nGdzie wyliczona suma kontrolna " + sumaKontrolnaNIP + ". \nNIP " + czyPrawidłowy);
        }
            else
            {
                MessageBox.Show("NIP za krótki ");
            }
}
    }
}
