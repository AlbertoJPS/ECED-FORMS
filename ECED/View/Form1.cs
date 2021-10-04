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

            chAlergiaMedicamentoNao.Checked = true;
            chCarteiraSim.Checked = true;
            chDeficienciaNao.Checked = true;
            chDietaEspecificaNao.Checked = true;
            chIntoleranciaAlimentoNao.Checked = true;
            chProblemaSaudeNao.Checked = true;
            chMaeUm.Checked = true;
            chPaiUm.Checked = true;
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
                DataNascimento = dtNacimentoAluno.Text,
                naturalidade = txtNaturalidade.Text,
                nacionalidade = txtNacionalidade.Text,
                Sexo = cmbSexo.Text,
                UF = txtUf.Text,
                CorERaca = cmbCor.Text,
                EstadoCivil = cmbEstadoCivil.Text
            };
            DocumentosAluno docAluno = new DocumentosAluno()
            {
                Cpf = txtCpf.Text,
                Rg = txtRgAluno.Text,
                DataExpedicaoRg = dtDataExpedicaoRG.Text,
                OrgaoEmissor = txtOrgaoEmissor.Text,
                UfRg = txtUfRg.Text,
                NumCertidaoNascimento = txtCertidaoNascimento.Text,
                DataEmissaoCertNascimento = dtDataEmissao.Text,
                Folha = txtFolha.Text,
                Livro = txtLivro.Text,
                RegistroCivil = dtRegistroCivilData.Text,
                DataEmissaoRegCivil = dtDataEmissao.Text
            };
            EnderecoAluno enderecoAluno = new EnderecoAluno()
            {
                Cep = txtCep.Text,
                Rua = txtRua.Text,
                Numero = txtNumero.Text,
                Bairro = txtBairro.Text,
                Cidade = txtCidade.Text,
                Estado = txtEstado.Text
            };
            IdentificacaoEscolar identEscola = new IdentificacaoEscolar()
            {
                CodigoDoInep = txtInep.Text,
                AuthBuscarCrianca = txtPessoaAutorizada.Text,
                DataMatricula = dtMatricula.Text,
                Idade = txtIdadeParentesco.Text,
                GrauParent = cmbParentesco.Text,
                Telefone = txtTelefonePessAutorizada.Text,
                Turma = cmbTurma.Text,
                Turno = cmbPeriodo.Text,
                UnidadeEscolar = txtUnidadeEscolar.Text,
            };
            SaudeAluno saudeAluno = new SaudeAluno()
            {
                ProblemaSaudeDetalhe = txtProblemaSaude.Text,
                AlergiaMedicamentoDetalhe = txtAlergiaMedicamento.Text,
                IntoleranciaAlimentoDetalhe = txtIntoleranciaAlimento.Text,
                DietaEspecificaDetalhe = txtDietaEspecifica.Text,
                ContatoEmergUm = txtContatoEmergUm.Text,
                TelefoneEmergUm = txtTelefoneEmergUm.Text,
                ContatoEmergDois = txtContatoEmergDois.Text,
                TelefoneEmergDois = txtTelefoneEmergDois.Text,
                TelefoneContato = txtTelefoneContato.Text
            };
            saudeAluno.ProblemaSaude = FuncaoPropCheckBox(chProblemaSaudeSim);
            saudeAluno.AlergiaMedicamento = FuncaoPropCheckBox(chAlergiaMedicamentoSim);
            saudeAluno.IntoleranciaAlimento = FuncaoPropCheckBox(chIntoleranciaAlimentoSim);
            saudeAluno.DietaEspecifica = FuncaoPropCheckBox(chDietaEspecificaSim);
            DadosPais dadosPais = new DadosPais()
            {
                NomeResponsavelUm = txtNomeRespUm.Text,
                DataNascimentoRespUm = dtDataNascRespUm.Text,
                TelefoneRespUm = txtTelefoneRespUm.Text,
                CpfRespUm = txtCpfRespUm.Text,
                RgRespUm = txtRgRespUm.Text,
                DataExpedicaoRgRespUm = dtDataExpedicaoRespUm.Text,
                UfRgRespUm = txtRgRespUm.Text,
                orgaoEmissorRgRespUm = txtOrgaoEmissorRespUm.Text,
                EstadoCivilRespUm = cbEstadoCivilRespUm.Text,
                EscolaridadeRespUm = txtEscolaridadeRespUm.Text,
                ProfissaoRespUm = txtProfissaoRespUm.Text,
                LocalTrabalhoRespUm = txtLocalTrabalhoRespUm.Text,
                HorarioTrabalhoRespUm = txtHorarioTrabalhoRespUm.Text,
                RamalRespUm = txtHorarioTrabalhoRespUm.Text,
                NomeResponsavelDois = txtNomeRespDois.Text,
                DataNascimentoRespDois = dtDataNascRespDois.Text,
                TelefoneRespDois = txtTelefoneRespDois.Text,
                CpfRespDois = txtCpfRespDois.Text,
                RgRespDois = txtRgRespDois.Text,
                DataExpedicaoRgRespDois = dtDataExpedicaoRespDois.Text,
                UfRgRespDois = txtRgRespDois.Text,
                orgaoEmissorRgRespDois = txtOrgaoEmissorRespDois.Text,
                EstadoCivilRespDois = cbEstadoCivilRespDois.Text,
                EscolaridadeRespDois = txtEscolaridadeRespDois.Text,
                ProfissaoRespDois = txtProfissaoRespDois.Text,
                LocalTrabalhoRespDois = txtLocalTrabalhoRespDois.Text,
                HorarioTrabalhoRespDois = txtHorarioTrabalhoRespDois.Text,
                RamalRespDois = txtHorarioTrabalhoRespDois.Text
            };
            Response res = Controller.AlunoInsert(al);
            res = Controller.DocumentoInsert(docAluno, al);
            res = Controller.EnderecoInsert(enderecoAluno, al);
            res = Controller.IdentificacaoEscolaInsert(identEscola, al);
            res = Controller.SaudeAlunoInsert(saudeAluno, al);
            res = Controller.DadosPaisInsert(dadosPais, al);
        }
        private void btnBuscarAluno_Click(object sender, EventArgs e)
        {
            MostrarTodosAlunos("Aluno");
        }
        async void MostrarTodosAlunos(string NomeAluno)
        {
            Query alunodt = database.Collection(NomeAluno);
            QuerySnapshot snap = await alunodt.GetSnapshotAsync();
            foreach (DocumentSnapshot docsnap in snap.Documents)
            {
                Aluno alsa = docsnap.ConvertTo<Aluno>();

                if (docsnap.Exists)
                {
                    dtgMostrarAlunos.Rows.Add(docsnap.Id, alsa.NomeAluno, alsa.DataNascimento);
                    dtgMostrarAlunos.Rows.Add(docsnap.Id, docsnap);
                }
            }
        }
        void FuncaoCheckBox(CheckBox cb, CheckBox cb2)
        {
            if (cb.Checked)
            {
                cb2.Checked = false;
            }
            else
            {
                cb2.Checked = true;
            }
        }
        bool FuncaoPropCheckBox(CheckBox cb)
        {
            if (cb.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void chCarteiraSim_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chCarteiraSim, chCarteiraNao);
        }
        private void chCarteiraNao_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chCarteiraNao, chCarteiraSim);
        }
        private void chDeficienciaSim_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chDeficienciaSim, chDeficienciaNao);
            cbDeficiencia.Enabled = true;
        }
        private void chDeficienciaNao_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chDeficienciaNao, chDeficienciaSim);
            cbDeficiencia.Enabled = false;
        }
        private void chProblemaSaudeSim_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chProblemaSaudeSim, chProblemaSaudeNao);
            txtProblemaSaude.Enabled = true;
        }
        private void chProblemaSaudeNao_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chProblemaSaudeNao, chProblemaSaudeSim);
            txtProblemaSaude.Enabled = false;
        }
        private void chAlergiaMedicamentoSim_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chAlergiaMedicamentoSim, chAlergiaMedicamentoNao);
            txtAlergiaMedicamento.Enabled = true;
        }
        private void chAlergiaMedicamentoNao_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chAlergiaMedicamentoNao, chAlergiaMedicamentoSim);
            txtAlergiaMedicamento.Enabled = false;
        }
        private void chIntoleranciaAlimentoSim_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chIntoleranciaAlimentoSim, chIntoleranciaAlimentoNao);
            txtIntoleranciaAlimento.Enabled = true;
        }
        private void chIntoleranciaAlimentoNao_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chIntoleranciaAlimentoNao, chIntoleranciaAlimentoSim);
            txtIntoleranciaAlimento.Enabled = false;
        }
        private void chDietaEspecificaSim_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chDietaEspecificaSim, chDietaEspecificaNao);
            txtDietaEspecifica.Enabled = true;
        }
        private void chDietaEspecificaNao_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chDietaEspecificaNao, chDietaEspecificaSim);
            txtDietaEspecifica.Enabled = false;
        }
    }
}
