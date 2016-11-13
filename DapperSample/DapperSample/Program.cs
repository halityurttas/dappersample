using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new Model.DbContext();
            bool bekle = true;
            while (bekle)
            {
                Console.Clear();
                Console.WriteLine("Yapmak istediğiniz işlemin numarasını girin:");
                Console.WriteLine("1- Listele");
                Console.WriteLine("2- Yeni Kayıt");
                Console.WriteLine("3- Düzenle");
                string islem = Console.ReadLine();
                switch (islem)
                {
                    case "1":
                        var liste = ctx.GetAll().ToList();
                        Console.WriteLine("No\tAd Soyad\tTelefon\tAdres");
                        foreach (var elm in liste)
                        {
                            Console.Write(elm.Id); Console.Write("\t");
                            Console.Write(elm.AdSoyad); Console.Write("\t");
                            Console.Write(elm.Telefon); Console.Write("\t");
                            Console.Write(elm.Adres); Console.WriteLine("\t");
                        }
                        Console.ReadKey();
                        break;
                    case "2":
                        var teldef = new Model.TelefonDefteri();
                        Console.Write("Ad Soyad:");
                        teldef.AdSoyad = Console.ReadLine();
                        Console.Write("Telefon:");
                        teldef.Telefon = Console.ReadLine();
                        Console.Write("Adres:");
                        teldef.Adres = Console.ReadLine();
                        Console.WriteLine(ctx.Insert(teldef));
                        Console.ReadKey();
                        break;
                    case "3":
                        var teldef2 = new Model.TelefonDefteri();
                        Console.Write("Kayıt No:");
                        teldef2.Id = int.Parse(Console.ReadLine());
                        Console.Write("Ad Soyad:");
                        teldef2.AdSoyad = Console.ReadLine();
                        Console.Write("Telefon:");
                        teldef2.Telefon = Console.ReadLine();
                        Console.Write("Adres:");
                        teldef2.Adres = Console.ReadLine();
                        Console.WriteLine(ctx.Update(teldef2));
                        Console.ReadKey();
                        break;
                    default:
                        bekle = false;
                        break;
                }
            }
        }
    }
}
