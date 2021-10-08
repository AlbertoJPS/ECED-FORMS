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
        public static Response AlunoInsert(Aluno al, string nome, string dataNasc, string sexo, string cor, string estadoCivil, string naturalidade, string nacionalidade, string uf)
        {
            if (!String.IsNullOrWhiteSpace(nome) && !String.IsNullOrWhiteSpace(dataNasc) && !String.IsNullOrWhiteSpace(sexo) && !String.IsNullOrWhiteSpace(cor) && !String.IsNullOrWhiteSpace(estadoCivil) && !String.IsNullOrWhiteSpace(naturalidade) && !String.IsNullOrWhiteSpace(nacionalidade) && !String.IsNullOrWhiteSpace(uf))
            {
                return AlunoDB.Insert(al);
            }
            else
            {
                return new Response { Message = "Preencha todos os dados do aluno!", Executed = false };
            }
        }
        public static Response DocumentoInsert(DocumentosAluno docAluno, Aluno aluno, string regCivil, string certNasc, string cpf, string rg, string email, string folha, string livro, string orgEmissorRg, string dataEmissaoRegCivil, string dataEmissaoCertNasc, string dataExpedRg, string ufRg, string ufCartorio, string nomeCartorio)
        {
            if (!String.IsNullOrWhiteSpace(regCivil) && !String.IsNullOrWhiteSpace(certNasc) && !String.IsNullOrWhiteSpace(cpf) && !String.IsNullOrWhiteSpace(rg) && !String.IsNullOrWhiteSpace(email) && !String.IsNullOrWhiteSpace(folha) && !String.IsNullOrWhiteSpace(livro) && !String.IsNullOrWhiteSpace(orgEmissorRg) && !String.IsNullOrWhiteSpace(dataEmissaoRegCivil) && !String.IsNullOrWhiteSpace(dataEmissaoCertNasc) && !String.IsNullOrWhiteSpace(dataExpedRg) && !String.IsNullOrWhiteSpace(ufRg) && !String.IsNullOrWhiteSpace(ufCartorio) && !String.IsNullOrWhiteSpace(nomeCartorio))
            {
                if (cpf.Length == 14 && rg.Length == 9 && folha.Length == 3 && livro.Length == 5)
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

        public static Response EnderecoInsert(EnderecoAluno endereco, Aluno aluno, string cep, string rua, string bairro, string cidade, string numero, string estado)
        {
            if (!String.IsNullOrEmpty(cep) && !String.IsNullOrEmpty(rua) && !String.IsNullOrEmpty(bairro) && !String.IsNullOrEmpty(cidade) && !String.IsNullOrEmpty(numero) && !String.IsNullOrEmpty(estado))
            {
                if (cep.Length == 9 && Convert.ToInt32(numero) > 0)
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
        public static Response IdentificacaoEscolaInsert(IdentificacaoEscolar identEscola, Aluno aluno, string uniEscola, string codInep, string dataMatricula, string periodo, string turma, string autoPegarCrianca, string telefoneAuto, string grauParentAuto, string idadeAuto, string pessoaUrgencia, string grauParentUrgencia, string telefoneUrgencia, string irmaoEscola, string turmaIrmao, string periodoIrmao)
        {
            if (!String.IsNullOrWhiteSpace(uniEscola) && !String.IsNullOrWhiteSpace(codInep) && !String.IsNullOrWhiteSpace(dataMatricula) && !String.IsNullOrWhiteSpace(periodo) && !String.IsNullOrWhiteSpace(turma) && !String.IsNullOrWhiteSpace(autoPegarCrianca) && !String.IsNullOrWhiteSpace(telefoneAuto) && !String.IsNullOrWhiteSpace(grauParentAuto) && !String.IsNullOrWhiteSpace(idadeAuto) && !String.IsNullOrWhiteSpace(pessoaUrgencia) && !String.IsNullOrWhiteSpace(grauParentUrgencia) && !String.IsNullOrWhiteSpace(telefoneUrgencia) && !String.IsNullOrWhiteSpace(irmaoEscola) && !String.IsNullOrWhiteSpace(turmaIrmao) && !String.IsNullOrWhiteSpace(periodoIrmao))
            {
                if (Convert.ToInt32(idadeAuto) < 102 && Convert.ToInt32(idadeAuto) > 18)
                {
                    if (telefoneAuto.Length > 13 && telefoneUrgencia.Length > 13)
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
        public static Response SaudeAlunoInsert(SaudeAluno saude, Aluno aluno, string pessoaEmerg, string telefoneEmerg, string pessoaEmergDois, string telefoneEmergDois, string telefoneContato)
        {
            if (!String.IsNullOrWhiteSpace(pessoaEmerg) && !String.IsNullOrWhiteSpace(telefoneEmerg) && !String.IsNullOrWhiteSpace(pessoaEmergDois) && !String.IsNullOrWhiteSpace(telefoneEmergDois) && !String.IsNullOrWhiteSpace(telefoneContato))
            {
                if (telefoneContato.Length > 13 && telefoneEmerg.Length > 13 && telefoneEmergDois.Length > 13)
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
        public static Response DadosPaisInsert(DadosPais dadosPais, Aluno aluno, string nomeRespUm, string dtNascUm, string telefoneUm, string cpfUm, string rgUm, string dtExpedicaoUm, string ufRgUm, string orgEmissorUm, string estadoCivilUm, string escolaridadeUm, string profissaoUm, string localTrabalhoUm, string horarioUm, string ramalUm, string nomeRespD, string dtNascD, string telefoneD, string cpfD, string rgD, string dtExpedicaoD, string ufRgD, string orgEmissorD, string estadoCivilD, string escolaridadeD, string profissaoD, string localTrabalhoD, string horarioD, string ramalD)
        {
            if (!String.IsNullOrWhiteSpace(nomeRespUm) && !String.IsNullOrWhiteSpace(dtNascUm) && !String.IsNullOrWhiteSpace(telefoneUm) && !String.IsNullOrWhiteSpace(cpfUm) && !String.IsNullOrWhiteSpace(rgUm) && !String.IsNullOrWhiteSpace(dtExpedicaoUm) && !String.IsNullOrWhiteSpace(ufRgUm) && !String.IsNullOrWhiteSpace(orgEmissorUm) && !String.IsNullOrWhiteSpace(estadoCivilUm) && !String.IsNullOrWhiteSpace(escolaridadeUm) && !String.IsNullOrWhiteSpace(profissaoUm) && !String.IsNullOrWhiteSpace(localTrabalhoUm) && !String.IsNullOrWhiteSpace(horarioUm) && !String.IsNullOrWhiteSpace(ramalUm) && !String.IsNullOrWhiteSpace(nomeRespD) && !String.IsNullOrWhiteSpace(dtNascD) && !String.IsNullOrWhiteSpace(telefoneD) && !String.IsNullOrWhiteSpace(cpfD) && !String.IsNullOrWhiteSpace(rgD) && !String.IsNullOrWhiteSpace(dtExpedicaoD) && !String.IsNullOrWhiteSpace(ufRgD) && !String.IsNullOrWhiteSpace(orgEmissorD) && !String.IsNullOrWhiteSpace(estadoCivilD) && !String.IsNullOrWhiteSpace(escolaridadeD) && !String.IsNullOrWhiteSpace(profissaoD) && !String.IsNullOrWhiteSpace(localTrabalhoD) && !String.IsNullOrWhiteSpace(horarioD) && !String.IsNullOrWhiteSpace(ramalD))
            {
                if (cpfUm.Length == 14 && cpfD.Length == 14 && rgUm.Length == 9 && rgD.Length == 9 && telefoneUm.Length > 13 && telefoneD.Length > 13)
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
    }
}
