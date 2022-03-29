using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Mapel.Models;

namespace WebApi_Mapel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapelController : ControllerBase
    {
        private MapelContext _context;

        public MapelController(MapelContext context)
        {
            this._context = context;
        }

        // GET: api/mapel
        [HttpGet]
        public ActionResult<IEnumerable<MapelItem>> GetMapelItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.GetAllMapel();
        }

        //Get : api/mapel/{id}
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<MapelItem>> GetMapelItem(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.GetMapel(id);
        }
        //post: api/mapel
        [HttpPost]
        public ActionResult<MapelItem> AddKelas([FromForm] string nama_mapel, [FromForm] string deskripsi)
        {
            MapelItem mi = new MapelItem();
            mi.nama_mapel = nama_mapel;
            mi.deskripsi = deskripsi;

            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.AddMapel(mi);
        }
    }
}
