using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Patrimonio.Contexts;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.Utils;

namespace Patrimonio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentosController : ControllerBase
    {
        private readonly IEquipamentoRepository _equipamentoRepository;

        public EquipamentosController(IEquipamentoRepository repo)
        {
            _equipamentoRepository = repo;
        }

        // GET: api/Equipamentos
        [HttpGet]
        public ActionResult<IEnumerable<Equipamento>> GetEquipamentos()
        {
            return Ok(_equipamentoRepository.Listar());
        }

        // GET: api/Equipamentos/5
        [HttpGet("{id}")]
        public ActionResult<Equipamento> GetEquipamento(int id)
        {
            var equipamento = _equipamentoRepository.BuscarPorID(id);

            if (equipamento == null)
            {
                return NotFound();
            }

            return equipamento;
        }

        // PUT: api/Equipamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<Equipamento> PutEquipamento(int id, Equipamento equipamento)
        {
            if (id != equipamento.Id)
            {
                return BadRequest();
            }

            _equipamentoRepository.Cadastrar(equipamento);

            try
            {
                 //_equipamentoRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Equipamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Equipamento> PostEquipamento([FromForm] Equipamento equipamento, IFormFile arquivo)
        {

            #region Upload da Imagem com extensões permitidas apenas
                string[] extensoesPermitidas = { "jpg", "png", "jpeg", "gif" };
                string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas);

                if (uploadResultado == "")
                {
                    return BadRequest("Arquivo não encontrado");
                }

                if (uploadResultado == "Extensão não permitida")
                {
                    return BadRequest("Extensão de arquivo não permitida");
                }

                equipamento.Imagem = uploadResultado; 
            #endregion

            // Pegando o horário do sistema
            equipamento.DataCadastro = DateTime.Now;

            _equipamentoRepository.Cadastrar(equipamento);
            //_equipamentoRepository.SaveChangesAsync();

            return Created("Equipamento", equipamento);
        }

        // DELETE: api/Equipamentos/5
        [HttpDelete("{id}")]
        public ActionResult DeleteEquipamento(int id)
        {
            var equipamento = _equipamentoRepository.BuscarPorID(id);
            if (equipamento == null)
            {
                return NotFound();
            }

            _equipamentoRepository.Excluir(equipamento);
            //_equipamentoRepository.SaveChangesAsync();

            // Removendo Arquivo do servidor
            Upload.RemoverArquivo(equipamento.Imagem);

            return NoContent();
        }

        private bool EquipamentoExists(int id)
        {
            var resultado = _equipamentoRepository.BuscarPorID(id);
            if(resultado != null)
            {
                return true;
            }

            return false;
        }
    }
}
