using CatalogosCore.Context;
using CatalogosCore.Entities;
using CatalogosCore.Models;
using CatalogosCore.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogosCore.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration;

        private CatalogosContext dbcontext { get; }

        private readonly IFabricantes _fabricantes;

        private readonly IArticulos _articulos;

        private readonly IImagenXArticulo _imagenxarticulo;

        public HomeController(IConfiguration configuration, IFabricantes ifabricantes, IArticulos iarticulos, IImagenXArticulo iimagenxarticulo)
        {
            _fabricantes = ifabricantes;
            _articulos = iarticulos;
            _imagenxarticulo = iimagenxarticulo;
            _configuration = configuration;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Fabricantes()
        {

            SortingPagingInfo info = new SortingPagingInfo();
            info.SortField = "FabricanteId";
            info.SortDirection = "ascending";
            info.PageSize = 5;
           
            ViewBag.SortingPagingInfo = info;


            

            var fabricantes = _fabricantes.GetFabricantes().OrderByDescending(x => x.FabricanteId).Take(info.PageSize);



            info.PageCount = (_fabricantes.Count(fabricantes) + info.PageSize - 1) / info.PageSize;
            info.CurrentPageIndex = 0;
            return View(fabricantes);
        }

        [HttpPost]
        public IActionResult Fabricantes(SortingPagingInfo info)
        {
            IEnumerable<Fabricantes> query = null;

            switch (info.SortField)
            {
                case "FabricanteId":
                    query = (info.SortDirection == "ascending" ? _fabricantes.GetFabricantes().OrderBy(c => c.FabricanteId) : _fabricantes.GetFabricantes().OrderByDescending(c => c.FabricanteId));
                    break;
                case "Codigo":
                    query = (info.SortDirection == "ascending" ? _fabricantes.GetFabricantes().OrderBy(c => c.Codigo) : _fabricantes.GetFabricantes().OrderByDescending(c => c.Codigo));
                    break;
                case "Descripcion":
                    query = (info.SortDirection == "ascending" ? _fabricantes.GetFabricantes().OrderBy(c => c.Descripcion) : _fabricantes.GetFabricantes().OrderByDescending(c => c.Descripcion));
                    break;
               
                default:
                    query = (info.SortDirection == "ascending" ? _fabricantes.GetFabricantes().OrderBy(c => c.FabricanteId) : _fabricantes.GetFabricantes().OrderByDescending(c => c.FabricanteId));
                    break;
            }

            


            query = query.Skip(info.CurrentPageIndex * info.PageSize).Take(info.PageSize);

            ViewBag.SortingPagingInfo = info;
           
            return View(query);

        }

        public IActionResult Articulos()
        {
            SortingPagingInfo info = new SortingPagingInfo();
            info.SortField = "ArticuloId";
            info.SortDirection = "ascending";
            info.PageSize = 5;

            ViewBag.SortingPagingInfo = info;




            var articulos = _articulos.GetArticulos().OrderByDescending(x => x.ArticuloId).Take(info.PageSize);



            info.PageCount = (_articulos.Count(articulos) + info.PageSize - 1) / info.PageSize;
            info.CurrentPageIndex = 0;
            return View(articulos);
        }

  
        [HttpPost]
        public IActionResult Articulos(SortingPagingInfo info)
        {
            IEnumerable<Articulos> query = null;

            switch (info.SortField)
            {
                case "ArticuloId":
                    query = (info.SortDirection == "ascending" ? _articulos.GetArticulos().OrderBy(c => c.ArticuloId) : _articulos.GetArticulos().OrderByDescending(c => c.ArticuloId));
                    break;
                case "Codigo":
                    query = (info.SortDirection == "ascending" ? _articulos.GetArticulos().OrderBy(c => c.Codigo) : _articulos.GetArticulos().OrderByDescending(c => c.Codigo));
                    break;
                case "Descripcion":
                    query = (info.SortDirection == "ascending" ? _articulos.GetArticulos().OrderBy(c => c.Descripcion) : _articulos.GetArticulos().OrderByDescending(c => c.Descripcion));
                    break;

                default:
                    query = (info.SortDirection == "ascending" ?_articulos.GetArticulos().OrderBy(c => c.ArticuloId) : _articulos.GetArticulos().OrderByDescending(c => c.ArticuloId));
                    break;
            }




            query = query.Skip(info.CurrentPageIndex * info.PageSize).Take(info.PageSize);

            ViewBag.SortingPagingInfo = info;

            return View(query);

        }

    }
}
