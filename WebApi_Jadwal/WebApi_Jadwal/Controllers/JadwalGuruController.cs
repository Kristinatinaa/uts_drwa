using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Jadwal.Models;

namespace WebApi_Jadwal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JadwalGuruController : ControllerBase
    {
        private JadwalGuruContext _context;

        public JadwalGuruController(JadwalGuruContext context)
        {
            this._context = context;
        }

        // GET: api/guru
        [HttpGet]
        public ActionResult<IEnumerable<JadwalGuruItem>> GetJadwalGuruItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(JadwalGuruContext)) as JadwalGuruContext;
            return _context.GetAllJadwalGuru();
        }

        //Get : api/guru/{nip}
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<JadwalGuruItem>> GetJadwalGuruItem(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(JadwalGuruContext)) as JadwalGuruContext;
            return _context.GetJadwalGuru(id);
        }
        //post: api/jadwal
        [HttpPost]
        public ActionResult<JadwalGuruItem> AddGuru([FromForm] string tahun_akademik, [FromForm] string semester, [FromForm] int id_guru, [FromForm] string hari, [FromForm] int id_kelas, [FromForm] int id_mapel, [FromForm] string jam_mulai, [FromForm] string jam_selesai)
        {

            JadwalGuruItem jgi = new JadwalGuruItem();
            jgi.tahun_akademik = tahun_akademik;
            jgi.semester = semester;
            jgi.id_guru = id_guru;
            jgi.hari = hari;
            jgi.id_kelas = id_kelas;
            jgi.id_mapel = id_mapel;
            jgi.jam_mulai = jam_mulai;
            jgi.jam_selesai = jam_selesai;

            _context = HttpContext.RequestServices.GetService(typeof(JadwalGuruContext)) as JadwalGuruContext;
            return _context.AddJadwalGuru(jgi);
        }
    }
}