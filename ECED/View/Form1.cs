using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;

using System.Collections;
using DALProject;
using BALProject;

namespace ECED_FORMS
{
    public partial class Form1 : Form
    {
        FirestoreDb database;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"eced-e3031-firebase-adminsdk-fxr0o-786505f761.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            database = FirestoreDb.Create("eced-e3031");

        }
        private void btnSalvarCadastro_Click(object sender, EventArgs e)
        {
            // AdicionaDados();
            AdicionaDadosPersonalizados();

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
        
        void AdicionaDadosPersonalizados()
        {
            Aluno al = new Aluno()
            {
                NomeAluno = txtNomeAluno.Text,
                DataNascimento=dtNacimentoAluno.Text,
                naturalidade=txtNaturalidade.Text,
                nacionalidade=txtNacionalidade.Text,
                Sexo=cmbSexo.Text,
                UF=txtUf.Text,
                CorERaca=cmbCor.Text,
                EstadoCivil=cmbEstadoCivil.Text
                



            };
            DocumentosAluno docAluno = new DocumentosAluno()
            {
                Cpf = txtCpf.Text,
                Rg = txtRg.Text,
                DataExpedicaoRg = dtDataExpedicaoRG.Text,
                OrgaoEmissor =txtOrgaoEmissor.Text,
                UfRg = txtUfRg.Text,
                NumCertidaoNascimento = txtCertidaoNascimento.Text,
                DataEmissaoCertNascimento =dtDataEmissao.Text,
                Folha = txtFolha.Text,
                Livro = txtLivro.Text,
                RegistroCivil = dtRegistroCivilData.Text,
                DataEmissaoRegCivil = dtDataEmissao.Text
            };
            EnderecoAluno enderecoAluno = new EnderecoAluno()
            {
                Cep = txtCep.Text,
                Rua = txtRua.Text,
                Numero = txtNumRua.Text,
                Bairro = txtBairro.Text,
                Cidade = txtCidade.Text,
                Estado = txtEstado.Text
            };
            IdentificacaoEscolar identEscola = new IdentificacaoEscolar()
            {
                CodigoDoInep = txtCodInep.Text,
                AuthBuscarCrianca = txtAuthPegarCrianca.Text,
                DataMatricula = dtDataMatricula.Text,
                Idade = txtIdade.Text,
                GrauParent = cbGrauParent.Text,
                Telefone = txtTelefone.Text,
                Turma = cbTurma.Text,
                Turno = cbTurno.Text,
                UnidadeEscolar = txtUnidadeEscolar.Text,
            };
            Response res = Controller.AlunoInsert(al);
            res = Controller.DocumentoInsert(docAluno, al);
            res = Controller.EnderecoInsert(enderecoAluno, al);
            res = Controller.IdentificacaoEscolaInsert(identEscola, al);



            //DocumentReference doc = database.Collection("Aluno").Document(txtNomeAluno.Text);
            //Dictionary<string, object> DadosPessoais = new Dictionary<string, object>();

            //Dictionary<string, object> data1 = new Dictionary<string, object>()

            //{
            //    {"NOME",txtNomeAluno.Text},
            //    {"Data de Nascimento",dtNacimentoAluno.Text},
            //    {"Cor / Raça",cmbCor.Text },
            //    {"Sexo",cmbSexo.Text },
            //    {"Naturalidade",txtNacionalidade.Text },
            //    {"Nacionalidade",txtNacionalidade.Text},
            //    {"Uf",txtUf.Text },
            //    {"Estado civil",txtEstado.Text },

            //};
            //DadosPessoais.Add("Dados Pessoais",data1);

            //doc.SetAsync(DadosPessoais);
            //MessageBox.Show("Dados Adicionados com sucesso!");

        }


    }
}
