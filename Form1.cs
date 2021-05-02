using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtspekSkaiciuZaidimas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // Sukuriu tuščią int tipo kintamąjį
        int randsk = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            // Programos starto metu iš random klasės susikuriu objektą ir iškviečiu jam Next metodą, kuris nurodytame rėžyje sugeneruoja int tipo skaičių.
            Random skObj = new Random();
            randsk = skObj.Next(1, 100);
        }

        // Susikuriu string tipo kintamąjį be egzituojančios reikšmės
        string spejimastxt = null;
        private void txt_box_TextChanged(object sender, EventArgs e)
        {
            // Užpildžius teksto langlelį, reikšmė nuskaitoma ir patalpinama į anskčiau sukurtą string tipo kintamąjį
            spejimastxt = txt_box.Text;
        }

        int spejimas = 0;
        private void button1_Click(object sender, EventArgs e)

        {

            // TryParse metodo pagalba įvestą string tipo skaičių verčiu į int ir jei pavyksta, tuomet, vykdomas tolimesnis kodas, jei ne,
            // rodoma klaida, kad įvestas ne skaičius.
            if (int.TryParse(spejimastxt, out spejimas))
            {

                if (spejimas > randsk && spejimas <= 100)
                {
                    lbl_ats.Text = "Neteisingai, eik į mažesnę pusę...";
                    lbl_message.Text = $"Paskutinis spėjimas: {spejimas}";
                    txt_box.Focus();
                    
                }
                else if (spejimas < randsk && spejimas > 0)
                {
                    lbl_ats.Text = "Suklydai, eik į didesnę pusę...";
                    lbl_message.Text = $"Paskutinis spėjimas: {spejimas}";
                    txt_box.Focus();
                }
                else if (spejimas == randsk)
                {
                    lbl_ats.Text = $"ATSPĖJAI, SKAIČIUS YRA {randsk}\n SVEIKINU! :)";
                    txt_box.Enabled = false;
                    btn_click.Visible = false;
                    btn_restart.Visible = true;

                }
                else
                {
                    MessageBox.Show("Skaičius nepatenka į 1-100 rėžius!");
                }
                txt_box.Clear();

            }
            else
            {
                MessageBox.Show("Įvesk skaičių!");
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
