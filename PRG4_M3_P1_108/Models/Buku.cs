﻿using System.ComponentModel.DataAnnotations;

namespace PRG4_M3_P1_108.Models
{
    public class Buku
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Judul wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Judul maksimal 30 karakter.")]

        public string judul { get; set; }

        [Required(ErrorMessage = "Penulis wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Penulis maksimal 30 karakter.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Penulis hanya boleh berisi huruf.")]

        public string penulis { get; set; }

        [Required(ErrorMessage = "Penerbit wajib diisi.")]

        public string penerbit { get; set; }

        [Required(ErrorMessage = "ISSN wajib diisi.")]
        [RegularExpression("^[0-9]{4}-[0-9]{4}$", ErrorMessage = "Format ISSN tidak valid. Gunakan format XXXX-XXXX.")]

        public string issn { get; set; }

        [Range(1900, int.MaxValue, ErrorMessage = "Tahun tidak valid.")] // Perbaikan: Ubah rentang tahun.
        [RegularExpression("^(19|20)\\d{2}$", ErrorMessage = "Tahun tidak valid.")]

        public int tahun { get; set; }

        [Range(0, 1, ErrorMessage = "Status tidak valid.")]

        public int status { get; set; }
    }
}
