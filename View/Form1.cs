using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECED_FORMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBuscarCep_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtCep.Text))
            {

                using (var ws = new correio.AtendeClienteClient())
                {
                    try
                    {

                        var endereco = ws.consultaCEP(txtCep.Text.Trim());
                        txtEstado.Text = endereco.uf;
                        txtCidade.Text = endereco.cidade;
                        txtBairro.Text = endereco.bairro;
                        txtRua.Text = endereco.end;

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Informe um cep valido..", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpaCep_Click(object sender, EventArgs e)
        {
            txtCep.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtRua.Text = string.Empty;
        }
    }
}
