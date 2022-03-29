using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuruController : ControllerBase
    {
        private GuruContext _context;

        public GuruController(GuruContext context)
        {
            this._context = context;
        }

        // GET: api/guru
        [HttpGet]
        public ActionResult<IEnumerable<GuruItem>> GetGuruItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(GuruContext)) as GuruContext;
            return _context.GetAllGuru();
        }

        //Get : api/guru/{nip}
        [HttpGet("{nip}", Name = "Get")]
        public ActionResult<IEnumerable<GuruItem>> GetGuruItem(String nip)
        {
            _context = HttpContext.RequestServices.GetService(typeof(GuruContext)) as GuruContext;
            return _context.GetGuru(nip);
        }
        //post: api/kelas
        [HttpPost]
        public ActionResult<GuruItem> AddGuru([FromForm] string rfid, [FromForm] string nip, [FromForm] string nama_guru, [FromForm] string alamat, [FromForm] int status_guru)
        {
            GuruItem gi = new GuruItem();
            gi.rfid = rfid;
            gi.nip = nip;
            gi.nama_guru = nama_guru;
            gi.alamat = alamat;
            gi.status_guru = status_guru;

            _context = HttpContext.RequestServices.GetService(typeof(GuruContext)) as GuruContext;
            return _context.AddGuru(gi);
        }
    }
}