using DALProject;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECED_FORMS.View
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login("login");
        }


        private void DegradeTela(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics; Rectangle gradient_rect = new Rectangle(0, 0, Width, Height);
            //RGB vermelho verde azul
            Brush br = new LinearGradientBrush(gradient_rect, Color.FromArgb(108, 226, 252), Color.FromArgb(221, 247, 220), 15f);
            graphics.FillRectangle(br, gradient_rect);
        }

        private void TelaLogin_Paint(object sender, PaintEventArgs e)
        {
            DegradeTela(sender, e);
        }



        async void login(string name)
        {
            //bool co=false;
            //Login lo= new Login ()
            //{
            //    UserName = txtlogin.Text,
            //    Senha=txtSenha.Text

            //};

            //await ControllerLogin.confLogin(lo,co);
            //if (co==true)
            //{
            //    MessageBox.Show("ok");
            //}
            try
            {
                DocumentReference docref = DBConection.Getdatabase().Collection(txtlogin.Text).Document(txtSenha.Text);

                bool con = false;
                DocumentSnapshot snap = await docref.GetSnapshotAsync();
                if (snap.Exists)
                {
                    con = true;
                    if (con)
                    {

                        MessageBox.Show("Login efetuado");
                        telaCadastro Telapr = new telaCadastro();
                        this.Visible = false;
                        Telapr.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Informe uma Credencial correta!");
                }
            }
            catch (Exception )
            {

                MessageBox.Show("Falha na conexão");
            }

        }


    }
}
