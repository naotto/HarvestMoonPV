using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class data
    {
        public string nama;
        public string jenis;
        public int jumlah;
        public int beli;
        public int jual;
        public data(string nama, string jenis, int jumlah, int beli, int jual)
        {
            this.nama = nama;
            this.jenis = jenis;
            this.jumlah = jumlah;
            this.beli = beli;
            this.jual = jual;
        }
    }
}
