using DALProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BALProject
{
    public class ControllerInsert
    {
        public static Response AlunoInsert(Aluno al)
        {
            if (!String.IsNullOrWhiteSpace(al.NomeAluno) && !String.IsNullOrWhiteSpace(al.DataNascimento) && !String.IsNullOrWhiteSpace(al.CorERaca) && !String.IsNullOrWhiteSpace(al.Sexo) && !String.IsNullOrWhiteSpace(al.EstadoCivil) && !String.IsNullOrWhiteSpace(al.naturalidade) && !String.IsNullOrWhiteSpace(al.nacionalidade) && !String.IsNullOrWhiteSpace(al.UF))
            {
                return AlunoDB.Insert(al);
            }
            else
            {
                return new Response { Message = "Preencha todos os dados do aluno!", Executed = false };
            }
        }
        public static Response DocumentoInsert(DocumentosAluno docAluno, Aluno aluno)
        {
            if (!String.IsNullOrWhiteSpace(docAluno.RegistroCivil) && !String.IsNullOrWhiteSpace(docAluno.NumCertidaoNascimento) && !String.IsNullOrWhiteSpace(docAluno.Cpf) && !String.IsNullOrWhiteSpace(docAluno.Rg) && !String.IsNullOrWhiteSpace(docAluno.Email) && !String.IsNullOrWhiteSpace(docAluno.Folha) && !String.IsNullOrWhiteSpace(docAluno.Livro) && !String.IsNullOrWhiteSpace(docAluno.OrgaoEmissor) && !String.IsNullOrWhiteSpace(docAluno.DataEmissaoRegCivil) && !String.IsNullOrWhiteSpace(docAluno.DataEmissaoCertNascimento) && !String.IsNullOrWhiteSpace(docAluno.DataExpedicaoRg) && !String.IsNullOrWhiteSpace(docAluno.UfRg) && !String.IsNullOrWhiteSpace(docAluno.UfCartorio) && !String.IsNullOrWhiteSpace(docAluno.NomeCartorio) && !String.IsNullOrWhiteSpace(aluno.NomeAluno))
            {
                if (docAluno.Cpf.Length == 14 && docAluno.Rg.Length == 9 && docAluno.Folha.Length == 3 && docAluno.Livro.Length == 5)
                {
                    return DocumentosDB.InsertDocumentos(docAluno, aluno);
                }
                else
                {
                    return new Response
                    {
                        Message = "Insira o CPF/RG/Folha/Livro corretamente!",
                        Executed = false
                    };
                }
            }
            else
            {
                return new Response { Message = "Preencha todos os documentos necessários!", Executed = false };
            }
        }
        public static Response EnderecoInsert(EnderecoAluno endereco, Aluno aluno)
        {
            if (!String.IsNullOrEmpty(endereco.Cep) && !String.IsNullOrEmpty(endereco.Rua) && !String.IsNullOrEmpty(endereco.Bairro) && !String.IsNullOrEmpty(endereco.Cidade) && !String.IsNullOrEmpty(endereco.Numero) && !String.IsNullOrEmpty(endereco.Estado))
            {
                if (endereco.Cep.Length == 9)
                {
                    return EnderecoDB.InsertEndereco(endereco, aluno);
                }
                else
                {
                    return new Response { Message = "Insira o CEP/número corretamente!", Executed = false };
                }
            }
            else
            {
                return new Response { Message = "Preencha todos os campos de endereço!", Executed = false };
            }
        }
        public static Response IdentificacaoEscolaInsert(IdentificacaoEscolar identEscola, Aluno aluno)
        {
            if (!String.IsNullOrWhiteSpace(identEscola.UnidadeEscolar) && !String.IsNullOrWhiteSpace(identEscola.CodigoDoInep) && !String.IsNullOrWhiteSpace(identEscola.DataMatricula) && !String.IsNullOrWhiteSpace(identEscola.Turno) && !String.IsNullOrWhiteSpace(identEscola.Turma) && !String.IsNullOrWhiteSpace(identEscola.AuthBuscarCrianca) && !String.IsNullOrWhiteSpace(identEscola.TelefoneAutorizado) && !String.IsNullOrWhiteSpace(identEscola.GrauParentAuto) && !String.IsNullOrWhiteSpace(identEscola.Idade) && !String.IsNullOrWhiteSpace(identEscola.PessoaAviso) && !String.IsNullOrWhiteSpace(identEscola.GrauParentAviso) && !String.IsNullOrWhiteSpace(identEscola.TelefoneAviso) && !String.IsNullOrWhiteSpace(identEscola.IrmaoEstuda) && !String.IsNullOrWhiteSpace(identEscola.TurmaIrmao) && !String.IsNullOrWhiteSpace(identEscola.TurnoIrmao) && !String.IsNullOrWhiteSpace(aluno.NomeAluno))
            {
                if (Convert.ToInt32(identEscola.Idade) < 102 && Convert.ToInt32(identEscola.Idade) > 18)
                {
                    if (identEscola.TelefoneAutorizado.Length > 13 && identEscola.TelefoneAviso.Length > 13)
                    {
                        return IdentificacaoEscolaDB.InsertIdentEscola(identEscola, aluno);
                    }
                    else
                    {
                        return new Response { Message = "Insira o telefone corretamente!", Executed = false };
                    }
                }
                else
                {
                    return new Response { Message = "Insira a idade corretamente(Maior de idade)!", Executed = false };
                }
            }
            else
            {
                return new Response { Message = "Preencha todos os campos de identificação escolar!", Executed = false };
            }
        }
        public static Response SaudeAlunoInsert(SaudeAluno saude, Aluno aluno)
        {
            if (!String.IsNullOrWhiteSpace(saude.ContatoEmergUm) && !String.IsNullOrWhiteSpace(saude.TelefoneEmergUm) && !String.IsNullOrWhiteSpace(saude.ContatoEmergDois) && !String.IsNullOrWhiteSpace(saude.TelefoneEmergDois) && !String.IsNullOrWhiteSpace(saude.TelefoneContato) && !String.IsNullOrWhiteSpace(aluno.NomeAluno))
            {
                if (VerificaCb(saude.Deficiencia, saude.DeficienciaDetalhe) == false)
                {
                    return new Response { Message = "Insira a deficiência presente!", Executed = false };
                }
                if (VerificaCb(saude.ProblemaSaude, saude.ProblemaSaudeDetalhe) == false)
                {
                    return new Response { Message = "Insira o o problema de saúde!", Executed = false };
                }
                if (VerificaCb(saude.AlergiaMedicamento, saude.AlergiaMedicamentoDetalhe) == false)
                {
                    return new Response { Message = "Insira o medicamento!", Executed = false };
                }
                if (VerificaCb(saude.IntoleranciaAlimento, saude.IntoleranciaAlimentoDetalhe) == false)
                {
                    return new Response { Message = "Insira o alimento!", Executed = false };
                }
                if (VerificaCb(saude.DietaEspecifica, saude.DietaEspecificaDetalhe) == false)
                {
                    return new Response { Message = "Insira a dieta necessária!", Executed = false };
                }
                if (saude.TelefoneContato.Length > 13 && saude.TelefoneEmergUm.Length > 13 && saude.TelefoneEmergDois.Length > 13)
                {
                    return SaudeAlunoDB.InsertSaude(saude, aluno);
                }
                else
                {
                    return new Response { Message = "Insira o telefone corretamente!", Executed = false };
                }
            }
            else
            {
                return new Response { Message = "Preencha todos os campos da saúde do aluno!", Executed = false };
            }
        }
        public static Response DadosPaisInsert(DadosPais dadosPais, Aluno aluno)
        {
            if (!String.IsNullOrWhiteSpace(dadosPais.NomeResponsavelUm) && !String.IsNullOrWhiteSpace(dadosPais.DataNascimentoRespUm) && !String.IsNullOrWhiteSpace(dadosPais.TelefoneRespUm) && !String.IsNullOrWhiteSpace(dadosPais.CpfRespUm) && !String.IsNullOrWhiteSpace(dadosPais.RgRespUm) && !String.IsNullOrWhiteSpace(dadosPais.DataExpedicaoRgRespUm) && !String.IsNullOrWhiteSpace(dadosPais.UfRgRespUm) && !String.IsNullOrWhiteSpace(dadosPais.orgaoEmissorRgRespUm) && !String.IsNullOrWhiteSpace(dadosPais.EstadoCivilRespUm) && !String.IsNullOrWhiteSpace(dadosPais.EscolaridadeRespUm) && !String.IsNullOrWhiteSpace(dadosPais.ProfissaoRespUm) && !String.IsNullOrWhiteSpace(dadosPais.LocalTrabalhoRespUm) && !String.IsNullOrWhiteSpace(dadosPais.HorarioTrabalhoRespUm) && !String.IsNullOrWhiteSpace(dadosPais.RamalRespUm) && !String.IsNullOrWhiteSpace(dadosPais.NomeResponsavelDois) && !String.IsNullOrWhiteSpace(dadosPais.DataNascimentoRespDois) && !String.IsNullOrWhiteSpace(dadosPais.TelefoneRespDois) && !String.IsNullOrWhiteSpace(dadosPais.CpfRespDois) && !String.IsNullOrWhiteSpace(dadosPais.RgRespDois) && !String.IsNullOrWhiteSpace(dadosPais.DataExpedicaoRgRespDois) && !String.IsNullOrWhiteSpace(dadosPais.UfRgRespDois) && !String.IsNullOrWhiteSpace(dadosPais.orgaoEmissorRgRespDois) && !String.IsNullOrWhiteSpace(dadosPais.EstadoCivilRespDois) && !String.IsNullOrWhiteSpace(dadosPais.EscolaridadeRespDois) && !String.IsNullOrWhiteSpace(dadosPais.ProfissaoRespDois) && !String.IsNullOrWhiteSpace(dadosPais.LocalTrabalhoRespDois) && !String.IsNullOrWhiteSpace(dadosPais.HorarioTrabalhoRespDois) && !String.IsNullOrWhiteSpace(dadosPais.RamalRespDois))
            {
                if (dadosPais.CpfRespUm.Length == 14 && dadosPais.CpfRespDois.Length == 14 && dadosPais.RgRespUm.Length == 9 && dadosPais.RgRespDois.Length == 9 && dadosPais.TelefoneRespUm.Length > 13 && dadosPais.TelefoneRespDois.Length > 13)
                {
                    return DadosPaisBD.InsertDadosPais(dadosPais, aluno);
                }
                else
                {
                    return new Response { Message = "Insira as informações corretamente!", Executed = false };
                }
            }
            else
            {
                return new Response { Message = "Preencha todos os dados dos pais!", Executed = false };
            }
        }
        public static Response NotasInsert(Boletim notas)
        {
            return BoletimDB.InsertBoletim(notas);
        }
        private static bool VerificaCb(bool cb, string txt)
        {
            if (cb && !String.IsNullOrWhiteSpace(txt))
            {
                return true;
            }
            else if (cb && String.IsNullOrWhiteSpace(txt))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}