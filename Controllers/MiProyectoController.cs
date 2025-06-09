using Microsoft.AspNetCore.Mvc;
using Configuracion_de_Proyecto.Models;
using MongoDB.Driver;

namespace Configuracion_de_Proyecto.Controllers.Api;

[ApiController]
[Route("mi-proyecto")]
public class MiProyectoController : ControllerBase
{
    [HttpGet("integrantes")]
    public ActionResult<MiProyecto> Integrantes()
    {
        var proyecto = new MiProyecto
        {
            NombreIntegrante1 = "Joseph Alexander Garcia Gonzalez",
            NombreIntegrante2 = "Jose Armando Rosalino Cristobal"
        };
        return Ok(proyecto);
    }



    [HttpGet("presentacion")]

    public IActionResult Presentacion()
    {
        MongoClient client = new MongoClient(CadenasConexion.Mongo_DB);
        var db = client.GetDatabase("Equipo_Armando_Joseph");
        var collection = db.GetCollection<Equipo>("Equipo");

        var lista = collection.Find(FilterDefinition<Equipo>.Empty).ToList();
        return Ok(lista);
    }
}