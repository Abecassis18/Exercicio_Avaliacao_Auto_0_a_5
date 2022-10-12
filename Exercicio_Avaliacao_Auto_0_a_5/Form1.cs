using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercicio_Avaliacao_Auto_0_a_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (object objeto in grpAvaliacao.Controls)
            {
                if (objeto is ComboBox)
                {
                    for (int cont = 1; cont <= 5; cont++)
                    {
                        ((ComboBox)objeto).Items.Add(cont);
                    }
                    ((ComboBox)objeto).Text = "1";
                }
            }
        }
        private string pontuacao()
        {
            int soma = 0;
            string resultado = "";

            foreach (Object objeto in grpAvaliacao.Controls)
            {
                if (objeto is ComboBox)
                {
                    for (int cont = 1; cont <= 5; cont++)
                    {
                        ((ComboBox)objeto).Items.Add(cont);
                    }
                    soma += int.Parse(((ComboBox)objeto).Text);

                    if (soma <= 5) resultado = "Fraco";
                    else if (soma <= 10) resultado = "Insuficiente";
                    else if (soma <= 15) resultado = "Suficiente";
                    else if (soma <= 20) resultado = "Bom";
                    else if (soma <= 25) resultado = "Muito Bom";
                    else if (soma <= 30) resultado = "Excelente";
                }
            }
            return resultado;
        }

        private void fechar()
        {
            this.Close();
        }
        private void btnCaalcular_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text != "" && txtModelo.Text != "")
            {
                string marca = txtMarca.Text;
                string modelo = txtModelo.Text;
                string resultado = pontuacao();

                ListViewItem Novo = new ListViewItem(marca.ToString());//Tem que ser aqui a setar o primeiro item pq se não ele desconfigura os outrso itens da listview.

                Novo.SubItems.Add(modelo.ToString());
                Novo.SubItems.Add(resultado.ToString());

                lstNotas.Items.Add(Novo);

                txtMarca.Focus();
                txtMarca.ResetText();
                txtModelo.ResetText();

                
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            fechar();
        }
    }
}
