using Microsoft.AspNetCore.Mvc;
using PRG4_M3_P1_108.Models;

namespace PRG4_M3_P1_108.Controllers
{
    public class AnggotaController : Controller
    {
        private static List<Anggota> anggotas = InitializeData();

        private static List<Anggota> InitializeData()
        {
            List<Anggota> initialData = new List<Anggota>
            {
                new Anggota
                {
                    id = 1,
                    nama = "Anggun Harlisa Puspitasari",
                    umur = 19,
                    alamat = "Jl. Azalea 1",
                    nomor = "081257028251"
                },
                new Anggota
                {
                    id = 2,
                    nama = "Sekar Ayu Ramadhani",
                    umur = 19,
                    alamat = "Jl. Azalea 1",
                    nomor = "081290060072"
                }
            };
            return initialData;
        }

        public IActionResult Index()
        {
            List<Anggota> anggotaList = anggotas.ToList();
            return View(anggotaList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Anggota anggota)
        {
            if (ModelState.IsValid)
            {
                int new_id = 1;

                while (anggotas.Any(b => b.id == new_id))
                {
                    new_id++;
                }

                anggota.id = new_id;

                anggotas.Add(anggota);
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }
            return View(anggota);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var response = new { success = false, message = "Gagal menghapus anggota." };
            try
            {
                var anggota = anggotas.FirstOrDefault(b => b.id == id);
                if (anggota != null)
                {
                    anggotas.Remove(anggota);
                    response = new { success = true, message = "Anggota berhasil dihapus." };
                }
                else
                {
                    response = new { success = false, message = "Anggota tidak ditemukan." };
                }
            }
            catch (Exception ex)
            {
                response = new { success = false, message = ex.Message };
            }
            return Json(response);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            Anggota anggota = anggotas.FirstOrDefault(a => a.id == id);

            if (anggota == null)
            {
                return NotFound();
            }

            return View(anggota);
        }

        [HttpPost]

        public IActionResult Edit(Anggota anggota)
        {
            if (ModelState.IsValid)
            {
                Anggota newAnggota = anggotas.FirstOrDefault(a => a.id == anggota.id);
                if (newAnggota == null) 
                {
                    return NotFound();
                }
                newAnggota.nama = anggota.nama;
                newAnggota.umur = anggota.umur;
                newAnggota.alamat = anggota.alamat;
                newAnggota.nomor = anggota.nomor;


                TempData["SuccessMessage"] = "Anggota berhasil diupdate.";
                return RedirectToAction("Index");
            }
            return View(anggota);
        }
    }
}
