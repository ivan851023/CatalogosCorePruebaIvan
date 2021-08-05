using CatalogosCore.Context;
using CatalogosCore.Entities;
using CatalogosCore.Models;
using CatalogosCore.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogosCore.Controllers
{
    public class FabricanteController : Controller
    {

        private IConfiguration _configuration;

        private CatalogosContext dbcontext { get; }

        private readonly IFabricantes _fabricantes;

        public FabricanteController(IConfiguration configuration, IFabricantes ifabricantes)
        {
            _fabricantes = ifabricantes;
            _configuration = configuration;

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int idFabricante)
        {
            var fabricantes = _fabricantes.GetById(idFabricante);
            FabricantesModel model = new FabricantesModel();

            model.id = fabricantes.FabricanteId;
            model.CodigoFabricante = fabricantes.Codigo;
            model.DescripcionFabricante = fabricantes.Descripcion;
        
            return View(model);
        }


        [HttpPost]
        public IActionResult GuardarFabricante([FromBody] FabricantesModel model)
        {

            try
            {

                Fabricantes fabricantes = new Fabricantes();
                fabricantes.FabricanteId = model.id;
                fabricantes.Codigo = model.CodigoFabricante;
                fabricantes.Descripcion = model.DescripcionFabricante;
                fabricantes.Fecha_Creacion = DateTime.Now;


                _fabricantes.Insert(fabricantes);

                int id = fabricantes.FabricanteId;


                return Json(new { success = true, responseText = string.Concat("Se ha registrado el fabricante No ", id), Data = id });


            }
            catch (Exception Exc)
            {

                return Json(new { success = false, responseText = string.Concat("Ha ocurrido el siguiente error: ", Exc.Message), Data = 0 });
            }
        }

        [HttpPost]
        public IActionResult EditarFabricante([FromBody] FabricantesModel model)
        {
            try
            {

                Fabricantes fabricantes = new Fabricantes();

                fabricantes = _fabricantes.GetById(model.id);

                fabricantes.Codigo = model.CodigoFabricante;
                fabricantes.Descripcion = model.DescripcionFabricante;
                
                _fabricantes.Update(fabricantes);

                int id = fabricantes.FabricanteId;


                return Json(new { success = true, responseText = string.Concat("Se ha modificado el fabricante No ", id), Data = id });


            }
            catch (Exception Exc)
            {

                return Json(new { success = false, responseText = string.Concat("Ha ocurrido el siguiente error: ", Exc.Message), Data = 0 });
            }
        }

        [HttpGet]
        public IActionResult Delete(int idFabricante)
        {
            FabricantesModel model = new FabricantesModel();

            model.id = idFabricante;

            return View(model);
        }


        [HttpPost]
        public IActionResult EliminarFabricante([FromBody]FabricantesModel model)
        {

            try
            {
                var fabricantes = _fabricantes.GetById(model.id);

                _fabricantes.Remove(fabricantes);

                return Json(new { success = true, responseText = "Se ha eliminado el fabricante exitosamente", Data = 0 });

            }
            catch (Exception exc)
            {
                return Json(new { success = false, responseText = string.Concat("Ha ocurrido el siguiente error: ", exc.Message), Data = 0 });
            }
            
        }
    }
}
