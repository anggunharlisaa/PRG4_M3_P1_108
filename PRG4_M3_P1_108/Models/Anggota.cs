using System.ComponentModel.DataAnnotations;

namespace PRG4_M3_P1_108.Models
{
    public class Anggota
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Nama wajib diisi.")]
        [MaxLength(50, ErrorMessage = "Nama maksimal 50 karakter.")]

        public string nama { get; set; }

        public int umur { get; set; }

        [Required(ErrorMessage = "Alamat wajib diisi.")]

        public string alamat { get; set; }

        [Required(ErrorMessage = "Nomor HP harus diisi.")]
        [RegularExpression(@"^\d{10,13}$", ErrorMessage = "Nomor HP harus terdiri dari 10 hingga 13 digit.")]
        public string nomor { get; set; }

        
    }
}

