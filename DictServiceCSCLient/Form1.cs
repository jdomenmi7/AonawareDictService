using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictServiceCSClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            defineWord();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                defineWord();
            }
        }

        /*
         * Reads the word in the textbox and writes the definition
         * returned from Aonaware DictService
         * @see: http://free-web-services.com/web-services/documentation/aonaware-dict-service.html
         */
        private void defineWord()
        {
            String definiciones;
            Dictionari.DictService definition = new Dictionari.DictService();
            String texto = textBox1.Text.ToString();
            Dictionari.Definition[] b = definition.Define(texto).Definitions;
            if (b.Length > 0)
            {
                definiciones = b[0].Word + "\n";
                foreach (var entry in b)
                {
                    definiciones += "dictionary: " + entry.Dictionary.Name + "\n definition: \n" + entry.WordDefinition + "\n";
                }
            }
            else
            {
                definiciones = "Word not found";
            }
            label4.Text = "Definition: \n" + definiciones;
        }
    }
}
