using CatalogosCore.Context;
using CatalogosCore.Entities;
using CatalogosCore.Models;
using CatalogosCore.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CatalogosCore.Controllers
{
    public class ArticuloController : Controller
    {
        private IConfiguration _configuration;

        private CatalogosContext dbcontext { get; }

        private readonly IArticulos _articulos;

        private readonly IFabricantes _fabricantes;

        private readonly IImagenXArticulo _imagenxarticulo;

        public ArticuloController(IConfiguration configuration, IArticulos iarticulos, IFabricantes ifabricantes, IImagenXArticulo iimagenxarticulo)
        {
            _articulos = iarticulos;
            _fabricantes = ifabricantes;
            _imagenxarticulo = iimagenxarticulo;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ArticulosModel model = new ArticulosModel();
            model.listFabricantes = GetFabricantes();
            return View(model);
        }

        private IEnumerable<SelectListItem> GetFabricantes()
        {

            var fabricantes = _fabricantes.GetFabricantes()
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.FabricanteId.ToString(),
                                    Text = x.Descripcion
                                });

            return new SelectList(fabricantes, "Value", "Text");
        }

        [HttpPost]
        public IActionResult GuardarArticulo(ArticulosModel model, IEnumerable<IFormFile> files)
        {

            try
            {

                Articulos articulos = new Articulos();

                articulos.Codigo = model.CodigoArticulo;
                articulos.Descripcion = model.DescripcionArticulo;
                articulos.FabricanteId = model.selectValueFabricante;


                _articulos.Insert(articulos);

                int id = articulos.ArticuloId;

                if (id > 0)
                {

                    ImagenXArticulo imagen = new ImagenXArticulo();

                    foreach (var item in files)
                    {

                        imagen.ImagenArticuloId = 0;
                        imagen.ArticuloId = id;
                        imagen.Imagen = ReadToEnd(item.OpenReadStream());
                        imagen.NombreArchivo = item.FileName;

                        _imagenxarticulo.Insert(imagen);
                   
                    }
                }


                return Json(new { success = true, responseText = string.Concat("Se ha registrado el Articulo No ", id), Data = id });


            }
            catch (Exception Exc)
            {

                return Json(new { success = false, responseText = string.Concat("Ha ocurrido el siguiente error: ", Exc.Message), Data = 0 });
            }
        }

        public static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }

        [HttpGet]
        public IActionResult Edit(int idArticulo)
        {
            var articulos = _articulos.GetById(idArticulo);
            ArticulosModel model = new ArticulosModel();

            model.id = articulos.ArticuloId;
            model.CodigoArticulo = articulos.Codigo;
            model.DescripcionArticulo = articulos.Descripcion;
            model.listFabricantes = GetFabricantes();
            model.selectValueFabricante = articulos.FabricanteId;

            return View(model);
        }

        [HttpPost]
        public IActionResult EditarArticulo([FromBody] ArticulosModel model)
        {
            try
            {

                Articulos articulos = new Articulos();

                articulos = _articulos.GetById(model.id);

                articulos.Codigo = model.CodigoArticulo;
                articulos.Descripcion = model.DescripcionArticulo;
                articulos.FabricanteId = model.selectValueFabricante;

                _articulos.Update(articulos);

                int id = articulos.ArticuloId;


                return Json(new { success = true, responseText = string.Concat("Se ha modificado el Articulo No ", id), Data = id });


            }
            catch (Exception Exc)
            {

                return Json(new { success = false, responseText = string.Concat("Ha ocurrido el siguiente error: ", Exc.Message), Data = 0 });
            }
        }


        [HttpGet]
        public IActionResult Delete(int idArticulo)
        {
            ArticulosModel model = new ArticulosModel();

            model.id = idArticulo;

            return View(model);
        }


        [HttpPost]
        public IActionResult EliminarArticulo([FromBody] ArticulosModel model)
        {

            try
            {
                var imagenarticulo = _imagenxarticulo.GetImagenArticulo().Where(x => x.ArticuloId == model.id);
                _imagenxarticulo.DeleteMultiple(imagenarticulo);


                var articulos = _articulos.GetById(model.id);


                _articulos.Remove(articulos);

                return Json(new { success = true, responseText = "Se ha eliminado el articulo exitosamente", Data = 0 });

            }
            catch (Exception exc)
            {
                return Json(new { success = false, responseText = string.Concat("Ha ocurrido el siguiente error: ", exc.Message), Data = 0 });
            }

        }

    }
}
