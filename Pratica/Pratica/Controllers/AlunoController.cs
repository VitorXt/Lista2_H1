using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pratica.Models.Request;

namespace Pratica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly string _alunoCaminhoArquivo;

        public AlunoController()
        {
            _alunoCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "aluno.json");
        }

        #region Métodods Arquivo

        private List<AlunoViewModel> LerAlunosDoArquivo()
        {
            if (!System.IO.File.Exists(_alunoCaminhoArquivo))
            {
                return new List<AlunoViewModel>();
            }

            string json = System.IO.File.ReadAllText(_alunoCaminhoArquivo);
            return JsonConvert.DeserializeObject<List<AlunoViewModel>>(json);
        }

        private int ObterProximoRADisponivel()
        {
            List<AlunoViewModel> alunos = LerAlunosDoArquivo();

            if (alunos.Any())
            {
                return alunos.Max(a => a.RA) + 1;
            }
            else
            {
                return 1;
            }
        }

        private void EscreverAlunosNoArquivo(List<AlunoViewModel> alunos)
        {
            string json = JsonConvert.SerializeObject(alunos);
            System.IO.File.WriteAllText(_alunoCaminhoArquivo, json);
        }

        #endregion


        #region Métodos CRUD

        [HttpGet]
        public IActionResult Get()
        {
            List<AlunoViewModel> alunos = LerAlunosDoArquivo();
            return Ok(alunos);
        }


        [HttpGet("{ra}")]
        public IActionResult Get(int ra)
        {
            List<AlunoViewModel> alunos = LerAlunosDoArquivo();
            AlunoViewModel aluno = alunos.Find(a => a.RA == ra);
            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }


        [HttpPost]
        public IActionResult Post([FromBody] NovoAlunoViewModel aluno)
        {
            if (aluno == null)
            {
                return BadRequest();
            }

            if (!ValidacaoAluno(aluno))
            {
                return BadRequest();
            }

            List<AlunoViewModel> alunos = LerAlunosDoArquivo();
            int proximoRA = ObterProximoRADisponivel();

            AlunoViewModel novoAluno = new AlunoViewModel()
            {
                RA = proximoRA,
                Nome = aluno.Nome,
                Email = aluno.Email,
                CPF = aluno.CPF,
                Ativo = aluno.Ativo
            };

            alunos.Add(novoAluno);
            EscreverAlunosNoArquivo(alunos);

            return CreatedAtAction(nameof(Get), new { ra = novoAluno.RA }, novoAluno);
        }


        [HttpPut("{ra}")]
        public IActionResult Put(int ra, [FromBody] EditaAlunoViewModel aluno)
        {
            if (aluno == null)
            {
                return BadRequest();
            }

            List<AlunoViewModel> alunos = LerAlunosDoArquivo();
            int index = alunos.FindIndex(a => a.RA == ra);
            if (index == -1)
            {
                return NotFound();
            }

            AlunoViewModel alunoEditado = new AlunoViewModel()
            {
                RA = ra,
                Nome = aluno.Nome,
                Email = aluno.Email,
                CPF = aluno.CPF,
                Ativo = aluno.Ativo
            };

            alunos[index] = alunoEditado;
            EscreverAlunosNoArquivo(alunos);

            return NoContent();
        }


        [HttpDelete("{ra}")]
        public IActionResult Delete(int ra)
        {
            List<AlunoViewModel> alunos = LerAlunosDoArquivo();
            AlunoViewModel aluno = alunos.Find(a => a.RA == ra);
            if (aluno == null)
            {
                return NotFound();
            }

            alunos.Remove(aluno);
            EscreverAlunosNoArquivo(alunos);

            return NoContent();
        }

        #endregion

        private bool ValidacaoAluno(NovoAlunoViewModel aluno)
        {
            if (aluno.Nome == "")
            {
                return false;
            }
            if (aluno.CPF == "")
            {
                return false;
            }
            if (aluno.Email == "")
            {
                return false;
            }

            return true;
        }
    }
}
