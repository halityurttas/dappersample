using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DapperSample.Model
{
    public class DbContext
    {
        public IDbConnection OpenConnection()
        {
            IDbConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString);
            con.Open();
            return con;
        }

        public IEnumerable<TelefonDefteri> GetAll()
        {
            using (var con = OpenConnection())
            {
                return con.Query<TelefonDefteri>("Select * From TelefonDefteri");
            }

        }

        public TelefonDefteri Get(int Id)
        {
            using (var con = OpenConnection())
            {
                return con.Query<TelefonDefteri>("Select * From TelefonDefteri Where Id = @Id", new { Id = Id }).SingleOrDefault();
            }

        }

        public bool Insert(TelefonDefteri model)
        {
            using (var con = OpenConnection())
            {
                return con.Execute("Insert Into TelefonDefteri(AdSoyad, Telefon, Adres) Values(@AdSoyad, @Telefon, @Adres)", model) > 0;
            }
        }

        public bool Update(TelefonDefteri model)
        {
            using (var con = OpenConnection())
            {
                return con.Execute("Update TelefonDefteri Set AdiSoyadi = @AdiSoyadi, Telefon = @Telefon, Adres = @Adres Where Id = @Id", model) > 0;
            }
        }

    }
}
