using Microsoft.AspNetCore.Mvc;
using Aplicacao.Data;
using Aplicacao.Dispositivos;
using Microsoft.EntityFrameworkCore;
using Aplicacao.Models.Temeperatura;

namespace Aplicacao.Controllers
{

    [Route("api/dispositivos")]  
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly DbContextMemory _dataBase;

        public DeviceController (DbContextMemory database)
        {
            _dataBase = database;
        }

        [HttpGet]
        public ActionResult ListarDispositivos()
        {
            var devices = _dataBase.Dispositivos.ToList();
            return Ok(devices);
        }
        
        [HttpGet("{id:guid}")]
        public ActionResult ListarDispositivosId(Guid id)
        {
            var devices = _dataBase.Dispositivos
            .Include(v => v.ValvulasAcionamentos)
            .FirstOrDefault(i => i.Id == id);

            return Ok(devices);
        }

        [HttpPost]
        public ActionResult AdicionarDispositivo(Dispositivo dispositivo){

            _dataBase.Dispositivos.Add(dispositivo);
            _dataBase.SaveChanges();

            return Ok(dispositivo);
        }
        [HttpPost("temperatura")]
        public ActionResult AdicionarDispositivo(Temperatura temperatura){

            _dataBase.Temperaturas.Add(temperatura);
            _dataBase.SaveChanges();

            return Ok(temperatura);
        }

    }
}