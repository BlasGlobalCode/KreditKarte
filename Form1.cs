using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kreditkarte
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }
        int[] Ziffern;
        bool Pruefen = false;
        int Pruefziffer;

        public void button1_Click(object sender, EventArgs e)
        {
           

            int PZiffer = 0;

            
            

            if (TXTZIFFER.Text.Length == 16)
            {
                Pruefen = true;
                Pruefziffer = int.Parse(TXTZIFFER.Text[15].ToString());
            }
            else if (TXTZIFFER.Text.Length > 16 || TXTZIFFER.Text.Length < 15) return;
            {
                Error();
            }
            Ziffern = StringToInt(TXTZIFFER.Text);
            if(Ziffern == null)
            {
                Error();
            }
            Berechnungen();
            
        }

        private int[] StringToInt(string Eingabe)
        {
            int i = 0;
            char[] CharEingabe = Eingabe.ToCharArray();
            int[] ausgabe = new int[Eingabe.Length];
            foreach(char Num in CharEingabe)
            {
                
                if (!int.TryParse(Num.ToString(), out ausgabe[i]))
                
                    return null;
                    i++;
            }
            return ausgabe;
        }

        private int QuerSumme(int ziffer)
        {
            string StrZiffer = ziffer.ToString();
            int ausgabe = int.Parse(StrZiffer[0].ToString()) + int.Parse(StrZiffer[1].ToString());
            return ausgabe;
        }

        public void Error()
        {
            MessageBox.Show("Fehlermeldung,Überprüft deine Eingabe");
        }

        public void Berechnungen()
        {
            for (int i = 0; i < 15; i++)
            {
                if (i % 2 == 0)
                {
                    Ziffern[i] *= 2;
                }
            }
            for (int i = 0; i < 15; i++)
            {
                if (Ziffern[i] > 9)
                {
                    Ziffern[i] = QuerSumme(Ziffern[i]);
                }
            }
            int Summe = 0;
            for (int i = 0; i < 15; i++)
            {
                Summe += Ziffern[i];
            }
            int rest = Summe % 10;
            if (Pruefen)
            {
                TXTPRUEFZIFFER.Text = (Pruefziffer == 10 - rest).ToString();
            }
            else
            {
                Pruefziffer = 10 - rest;
                TXTPRUEFZIFFER.Text = Pruefziffer.ToString();
            }
        }

        private void EingabeZiffer(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8)
            {e.Handled = false;}
            else{e.Handled = true;}
        }
    }
}