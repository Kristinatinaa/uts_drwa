using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Jadwal.Models
{
    public class JadwalGuruContext : DbContext
    {
        public JadwalGuruContext(DbContextOptions<JadwalGuruContext> options) : base(options)
        {
        }
        public string ConnectionString { get; set; }


        private MySqlConnection GetConnection()
        {
            return new MySqlConnection("Server = localhost; Database = sibaru; Uid = root; Pwd =");
        }

        public List<JadwalGuruItem> GetAllJadwalGuru()
        {
            List<JadwalGuruItem> list = new List<JadwalGuruItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM jadwal_guru", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new JadwalGuruItem()
                        {
                            id_jadwal_guru = reader.GetInt32("id_jadwal_guru"),
                            tahun_akademik = reader.GetString("tahun_akademik"),
                            semester = reader.GetString("semester"),
                            id_guru = reader.GetInt32("id_guru"),
                            hari = reader.GetString("hari"),
                            id_kelas = reader.GetInt32("id_kelas"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai"),
                        });
                    }
                }
            }
            return list;
        }

        public List<JadwalGuruItem> GetJadwalGuru(string id)
        {
            List<JadwalGuruItem> list = new List<JadwalGuruItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM jadwal_guru WHERE id_mapel= @id_mapel", conn);
                cmd.Parameters.AddWithValue("@id_mapel", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new JadwalGuruItem()
                        {
                            id_jadwal_guru = reader.GetInt32("id_jadwal_guru"),
                            tahun_akademik = reader.GetString("tahun_akademik"),
                            semester = reader.GetString("semester"),
                            id_guru = reader.GetInt32("id_guru"),
                            hari = reader.GetString("hari"),
                            id_kelas = reader.GetInt32("id_kelas"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai")
                        });
                    }
                }
            }
            return list;
        }
        
        public JadwalGuruItem AddJadwalGuru(JadwalGuruItem jgi)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO jadwal_guru(tahun_akademik,semester,id_guru,hari,id_kelas,id_mapel,jam_mulai,jam_selesai) VALUES (@tahun_akademik,@semester,@id_guru,@hari,@id_kelas,@id_mapel,@jam_mulai,@jam_selesai)", conn);
                cmd.Parameters.AddWithValue("@tahun_akademik", jgi.tahun_akademik);
                cmd.Parameters.AddWithValue("@semester", jgi.semester);
                cmd.Parameters.AddWithValue("@id_guru", jgi.id_guru);
                cmd.Parameters.AddWithValue("@hari", jgi.hari);
                cmd.Parameters.AddWithValue("@id_kelas", jgi.id_kelas);
                cmd.Parameters.AddWithValue("@id_mapel", jgi.id_mapel);
                cmd.Parameters.AddWithValue("@jam_mulai", jgi.jam_mulai);
                cmd.Parameters.AddWithValue("@jam_selesai", jgi.jam_selesai);

                cmd.ExecuteReader();
            }
            return jgi;
        }
    }
}
