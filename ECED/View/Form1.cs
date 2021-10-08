﻿using System;
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
using System.Drawing.Drawing2D;

namespace ECED_FORMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;
            chAlergiaMedicamentoNao.Checked = true;
            chCarteiraSim.Checked = true;
            chDeficienciaNao.Checked = true;
            chDietaEspecificaNao.Checked = true;
            chIntoleranciaAlimentoNao.Checked = true;
            chProblemaSaudeNao.Checked = true;
            chMaeUm.Checked = true;
            chPaiDois.Checked = true;
        }
        private void btnSalvarCadastro_Click(object sender, EventArgs e)
        {
            AdicionaDadosAlunos();
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
        private void btnAddNota_Click(object sender, EventArgs e)
        {
            AdicionaNota();
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O cadastro do aluno " + txtPesquisarAluno.Text + " foi deletado do sistema.");
            deletarCadastro("Name");
            txtPesquisarAluno.Clear();
            ritMostra.Clear();

        }
        void AdicionaDadosAlunos()
        {
            //Cria objetos para serem adicionados no banco de dados
            Aluno al = new Aluno()
            {
                NomeAluno = txtNomeAluno.Text,
                DataNascimento = dtNascimentoAluno.Text,
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
                RegistroCivil = dtDataEmissaoCertNasc.Text,
                DataEmissaoRegCivil = dtDataEmissao.Text
            };
            EnderecoAluno enderecoAluno = new EnderecoAluno()
            {
                Cep = txtCep.Text,
                Rua = txtRua.Text,
                Numero = txtNumero.Text,
                Bairro = txtBairro.Text,
                Cidade = txtCidade.Text,
                Estado = txtEstado.Text,
                Avenida = txtAvenida.Text,
                Complemento = txtComplemento.Text,
                PontoReferencia = txtPontoReferencia.Text,
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
                DeficienciaDetalhe = cbDeficiencia.Text,
                ContatoEmergUm = txtContatoEmergUm.Text,
                TelefoneEmergUm = txtTelefoneEmergUm.Text,
                ContatoEmergDois = txtContatoEmergDois.Text,
                TelefoneEmergDois = txtTelefoneEmergDois.Text,
                TelefoneContato = txtTelefoneContato.Text
            };
            //Define os valores das propriedades vindas de CheckBox
            saudeAluno.ProblemaSaude = FuncaoPropCheckBox(chProblemaSaudeSim);
            saudeAluno.AlergiaMedicamento = FuncaoPropCheckBox(chAlergiaMedicamentoSim);
            saudeAluno.IntoleranciaAlimento = FuncaoPropCheckBox(chIntoleranciaAlimentoSim);
            saudeAluno.DietaEspecifica = FuncaoPropCheckBox(chDietaEspecificaSim);
            saudeAluno.Deficiencia = FuncaoPropCheckBox(chDeficienciaSim);
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
            dadosPais.ResponsavelUm = FuncaoPropCheckBox(chMaeUm, chPaiUm, chResponsavelUm);
            dadosPais.ResponsavelDois = FuncaoPropCheckBox(chMaeDois, chPaiDois, chResponsavelDois);
            Response res = ControllerInsert.AlunoInsert(al, txtNomeAluno.Text, dtNascimentoAluno.Text, cmbSexo.Text, cmbCor.Text, cmbEstadoCivil.Text, txtNaturalidade.Text, txtNacionalidade.Text, txtUf.Text);
            if (res.Executed)
            {
                res = ControllerInsert.DocumentoInsert(docAluno, al, txtRegCivil.Text, txtCertidaoNascimento.Text, txtCpf.Text, txtRgAluno.Text, txtEmailAluno.Text, txtFolha.Text, txtLivro.Text, txtOrgaoEmissor.Text, dtDataEmissaoCertNasc.Text, dtDataEmissaoCertNasc.Text, dtDataExpedicaoRG.Text, txtUfRg.Text, txtUfCartorio.Text, txtNomeCartorio.Text);
                if (res.Executed)
                {
                    res = ControllerInsert.EnderecoInsert(enderecoAluno, al, txtCep.Text, txtRua.Text, txtBairro.Text, txtCidade.Text, txtNumero.Text, txtEstado.Text);
                    if (res.Executed)
                    {
                        if (res.Executed)
                        {
                            res = ControllerInsert.IdentificacaoEscolaInsert(identEscola, al, txtUnidadeEscolar.Text, txtInep.Text, dtMatricula.Text, cmbPeriodo.Text, cmbTurma.Text, txtPessoaAutorizada.Text, txtTelefonePessAutorizada.Text, cmbParentesco.Text, txtIdadeParentesco.Text, txtAvisoUrgencia.Text, cmbGrauUrgencia.Text, txtTelUrgencia.Text, txtNomeIrmaoEstuda.Text, cmbTurmaIrmao.Text, cmbPeriodoIrmao.Text);
                            if (res.Executed)
                            {
                                res = ControllerInsert.SaudeAlunoInsert(saudeAluno, al, txtContatoEmergUm.Text, txtTelefoneEmergUm.Text, txtContatoEmergDois.Text, txtTelefoneEmergDois.Text, txtTelefoneContato.Text);
                                if (res.Executed)
                                {
                                    res = ControllerInsert.DadosPaisInsert(dadosPais, al, txtNomeRespUm.Text, dtDataNascRespUm.Text, txtTelefoneRespUm.Text, txtCpfRespUm.Text, txtRgRespUm.Text, dtDataExpedicaoRespUm.Text, txtUfRespUm.Text, txtOrgaoEmissorRespUm.Text, cbEstadoCivilRespUm.Text, txtEscolaridadeRespUm.Text, txtProfissaoRespUm.Text, txtLocalTrabalhoRespUm.Text, txtHorarioTrabalhoRespUm.Text, txtRamalRespUm.Text, txtNomeRespDois.Text, dtDataNascRespDois.Text, txtTelefoneRespDois.Text, txtCpfRespDois.Text, txtRgRespDois.Text, dtDataExpedicaoRespDois.Text, txtUfRespDois.Text, txtOrgaoEmissorRespDois.Text, cbEstadoCivilRespDois.Text, txtEscolaridadeRespDois.Text, txtProfissaoRespDois.Text, txtLocalTrabalhoRespDois.Text, txtHorarioTrabalhoRespDois.Text, txtRamalRespDois.Text);
                                    if (res.Executed)
                                    {
                                        MessageBox.Show(res.Message);
                                    }
                                    else //Verifica se o insert foi executado, caso não retorna a mensagem de erro e deleta o perfil que está pela metade
                                    {
                                        MessageBox.Show(res.Message);
                                        Deletar();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(res.Message);
                                    Deletar();
                                }
                            }
                            else
                            {
                                MessageBox.Show(res.Message);
                                Deletar();
                            }
                        }
                        else
                        {
                            MessageBox.Show(res.Message);
                            Deletar();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(res.Message);
                    Deletar();
                }
            }
            else
            {
                MessageBox.Show(res.Message);
                Deletar();
            }
        }
        void AdicionaNota()
        {
            //Boletim bole = new Boletim();
            Boletim boletim = new Boletim()
            {
                NomeAluno = cbNomeAlunoNota.Text,
                Materia = cbMateriaNota.Text,
                Turma = cbTurmaNota.Text,
                Nota1 = Convert.ToDouble(txtNota1.Text),
                Nota2 = Convert.ToDouble(txtNota2.Text),
                Nota3 = Convert.ToDouble(txtNota3.Text),
            };
            Response res = ControllerInsert.NotasInsert(boletim);
        }
        private void btnBuscarAluno_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtPesquisarAluno.Text))
            {
                mostrardocumento("Documento");
                mostrarDdosPessoais("Nome");
                mostrarEndereco("Endereco");
                mostrarDadosPais("DadosPais");
                mostrarIdentificacaoEscolar("Identificação");
                mostrarSaudeAluno("Saude");
                ritMostra.Clear();
            }
            else
            {
                MessageBox.Show("Insira um nome!");
            }
        }
        async void mostrarDdosPessoais(string name)
        {
            //Aluno al = new Aluno()
            //{
            //    NomeAluno = txtPesquisarAluno.Text,
            //    Tipo=cmbTipo.Text
            //};
            ////string[] vetor = new string[1];
            //List<string> vetor=new List<string>();
            //await ControllerSelect.MostrarDados(al, vetor);
            //string[]elementos = vetor.ToArray();
            //dtgDadosPessoais.Rows.Add(elementos);
            //dtgDocumento.Rows.Add(elementos);
            //dtgDadosPais.Rows.Add(elementos);
            //dtgEndereco.Rows.Add(elementos);
            //string acumulado = " ";
            //foreach (var item in elementos)
            //{
            //    acumulado += "Dados Pessoais";
            //    acumulado += item +  "\n";

            //}
            //ritmostrar.Text = acumulado;
            DocumentReference docref = DBConection.Getdatabase().Collection(txtPesquisarAluno.Text).Document("Dados Pessoais");
            DocumentSnapshot snap = await docref.GetSnapshotAsync();
            if (snap.Exists)
            {
                Dictionary<string, object> city = snap.ToDictionary();
                ritMostra.Text += string.Format("\n \n                                                       Dados Pessoais     \n  ");
                foreach (var item in city)
                {
                    ritMostra.Text += string.Format("\n                                          {0}: {1}\n", item.Key, item.Value);
                }
            }
        }
        async void mostrarBolet(string name)
        {

            Boletim al = new Boletim()
            {
                NomeAluno = cbNomeAlunoNota.Text

            };
            //string[] vetor = new string[1];
            List<string> vetor = new List<string>();
            await ControllerBoletim.MostrarBoletim(al, vetor);
            string[] elementos = vetor.ToArray();

        }
        async void mostrardocumento(string name)
        {
            DocumentReference docref = DBConection.Getdatabase().Collection(txtPesquisarAluno.Text).Document("Documento");

            DocumentSnapshot snap = await docref.GetSnapshotAsync();
            if (snap.Exists)
            {
                Dictionary<string, object> city = snap.ToDictionary();

                ritMostra.Text += string.Format("\n \n                                                    Documentos do Aluno     \n  ");
                foreach (var item in city)
                {
                    ritMostra.Text += string.Format("\n                                          {0}: {1}\n", item.Key, item.Value);
                }
            }
        }
        async void mostrarIdentificacaoEscolar(string name)
        {
            DocumentReference docref = DBConection.Getdatabase().Collection(txtPesquisarAluno.Text).Document("Identificação escolar");

            DocumentSnapshot snap = await docref.GetSnapshotAsync();
            if (snap.Exists)
            {
                Dictionary<string, object> city = snap.ToDictionary();

                ritMostra.Text += string.Format("\n \n                                                       Identificação Escolar     \n  ");
                foreach (var item in city)
                {
                    ritMostra.Text += string.Format("\n                                          {0}: {1}\n", item.Key, item.Value);
                }
            }
        }
        async void mostrarDadosPais(string name)
        {
            DocumentReference docref = DBConection.Getdatabase().Collection(txtPesquisarAluno.Text).Document("Dados dos pais");

            DocumentSnapshot snap = await docref.GetSnapshotAsync();
            if (snap.Exists)
            {
                Dictionary<string, object> city = snap.ToDictionary();

                ritMostra.Text += string.Format("\n \n                                                         Dados dos Pais     \n  ");
                foreach (var item in city)
                {
                    ritMostra.Text += string.Format("\n                                          {0}: {1}\n", item.Key, item.Value);
                }
            }
        }

        async void mostrarEndereco(string name)
        {
            DocumentReference docref = DBConection.Getdatabase().Collection(txtPesquisarAluno.Text).Document("Endereço");

            DocumentSnapshot snap = await docref.GetSnapshotAsync();
            if (snap.Exists)
            {
                Dictionary<string, object> city = snap.ToDictionary();

                ritMostra.Text += string.Format("\n \n                                                          ENDEREÇO      \n  ");
                foreach (var item in city)
                {
                    ritMostra.Text += string.Format("\n                                          {0}: {1}\n", item.Key, item.Value);
                }
            }
        }
        async void mostrarSaudeAluno(string name)
        {
            DocumentReference docref = DBConection.Getdatabase().Collection(txtPesquisarAluno.Text).Document("Saude Aluno");

            DocumentSnapshot snap = await docref.GetSnapshotAsync();
            if (snap.Exists)
            {
                Dictionary<string, object> city = snap.ToDictionary();

                ritMostra.Text += string.Format("\n \n                                                          Saúde Aluno    \n  ");
                foreach (var item in city)
                {
                    ritMostra.Text += string.Format("\n                                          {0}: {1}\n", item.Key, item.Value);
                }
            }
        }
        /// <summary>
        /// Função para deletar o aluno do banco de dados
        /// </summary>
        /// <param name="name"></param>
        void deletarCadastro(string name)
        {
            DeletarAluno delete = new DeletarAluno()
            {
                Nome = txtPesquisarAluno.Text,

            };
            _ = ControllerDeletarAluno.DeletarAluno(delete);
        }
        void Deletar()
        {
            DeletarAluno delete = new DeletarAluno()
            {
                Nome = txtNomeAluno.Text,

            };
            _ = ControllerDeletarAluno.DeletarAluno(delete);
        }
        //Funções para a View
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
        void FuncaoCheckBox(CheckBox cb, CheckBox cb2, CheckBox cb3)
        {
            if (cb.Checked)
            {
                cb2.Checked = false;
                cb3.Checked = false;
            }
            else if (cb2.Checked)
            {
                cb.Checked = false;
                cb3.Checked = false;
            }
            else
            {
                cb.Checked = false;
                cb2.Checked = false;
            }
            if (!cb2.Checked && !cb3.Checked)
            {
                cb.Checked = true;
            }
        }
        void TextoNao(CheckBox cb, TextBox txt)
        {
            if (cb.Checked)
            {
                txt.Enabled = false;
            }
        }
        void TextoSim(CheckBox cb, TextBox txt)
        {
            if (cb.Checked)
            {
                txt.Enabled = true;
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
        string FuncaoPropCheckBox(CheckBox cb, CheckBox cb2, CheckBox cb3)
        {
            if (cb.Checked)
            {
                return cb.Text;
            }
            else if (cb2.Checked)
            {
                return cb2.Text;
            }
            else
            {
                return cb3.Text;
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
            if (chDeficienciaSim.Checked)
            {
                cbDeficiencia.Enabled = true;
            }
        }
        private void chDeficienciaNao_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chDeficienciaNao, chDeficienciaSim);
            if (chDeficienciaNao.Checked)
            {
                cbDeficiencia.Text = cbDeficiencia.Items[8].ToString();
                cbDeficiencia.Enabled = false;
            }
        }
        private void chProblemaSaudeSim_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chProblemaSaudeSim, chProblemaSaudeNao);
            TextoSim(chProblemaSaudeSim, txtProblemaSaude);
        }
        private void chProblemaSaudeNao_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chProblemaSaudeNao, chProblemaSaudeSim);
            TextoNao(chProblemaSaudeNao, txtProblemaSaude);
        }
        private void chAlergiaMedicamentoSim_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chAlergiaMedicamentoSim, chAlergiaMedicamentoNao);
            TextoSim(chAlergiaMedicamentoSim, txtAlergiaMedicamento);
        }
        private void chAlergiaMedicamentoNao_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chAlergiaMedicamentoNao, chAlergiaMedicamentoSim);
            TextoNao(chAlergiaMedicamentoNao, txtAlergiaMedicamento);
        }
        private void chIntoleranciaAlimentoSim_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chIntoleranciaAlimentoSim, chIntoleranciaAlimentoNao);
            TextoSim(chIntoleranciaAlimentoSim, txtIntoleranciaAlimento);
        }
        private void chIntoleranciaAlimentoNao_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chIntoleranciaAlimentoNao, chIntoleranciaAlimentoSim);
            TextoNao(chIntoleranciaAlimentoNao, txtIntoleranciaAlimento);
        }
        private void chDietaEspecificaSim_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chDietaEspecificaSim, chDietaEspecificaNao);
            TextoSim(chDietaEspecificaSim, txtDietaEspecifica);
        }
        private void chDietaEspecificaNao_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chDietaEspecificaNao, chDietaEspecificaSim);
            TextoNao(chDietaEspecificaNao, txtDietaEspecifica);
        }
        private void chMaeUm_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chMaeUm, chPaiUm, chResponsavelUm);
        }
        private void chPaiUm_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chPaiUm, chMaeUm, chResponsavelUm);
        }
        private void chResponsavelUm_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chResponsavelUm, chMaeUm, chPaiUm);
        }
        private void chMaeDois_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chMaeDois, chPaiDois, chResponsavelDois);
        }
        private void chPaiDois_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chPaiDois, chMaeDois, chResponsavelDois);
        }
        private void chResponsavelDois_CheckedChanged(object sender, EventArgs e)
        {
            FuncaoCheckBox(chResponsavelDois, chMaeDois, chPaiDois);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnMostrarBoletim_Click(object sender, EventArgs e)
        {
            mostrarBolet("boletim");
        }
        //private void SetBackColorDegrade(object sender, PaintEventArgs e)
        //{
        //    Graphics graphics = e.Graphics; Rectangle gradient_rect = new Rectangle(0, 0, Width, Height);
        //    //RGB vermelho verde azul
        //    Brush br = new LinearGradientBrush(gradient_rect, Color.FromArgb(108, 226, 252), Color.FromArgb(221, 247, 220), 15f);
        //    graphics.FillRectangle(br, gradient_rect);
        //}

        //private void Form1_Paint(object sender, PaintEventArgs e)
        //{
        //    SetBackColorDegrade(sender,e);
        //}
    }
}