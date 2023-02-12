using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;
using System.Drawing;
using WebApplication1.Data;
using WebApplication1.Models.DTO;

namespace CMS_Projekt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _06_AdvantagesCoontroller : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public _06_AdvantagesCoontroller(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //------------------------------------------- GET ------------------------------------------------
        //------------------- Get all -------------------
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select id as ""id"",
                        name as ""name"",
                        text as ""text""
                from advantages
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult(table);
        }

        //------------------- Get by name -------------------

        [HttpGet("{name}")]
        public JsonResult GeteByname1(string name)
        {
            string query = @"
                  select id as ""id"",
                        name as ""name"",
                        text as ""text""
                from advantages
                where name=@name 
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@name", name);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult(table);
        }

        //------------------------------------------- POST ------------------------------------------------
        [HttpPost]
        public JsonResult Post(AdvantagesDTO adv)
        {
            int id = 0;

            string query = @"
                insert into advantages(id,name,text)
                values (@id,@name,@text)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", adv.id);
                    myCommand.Parameters.AddWithValue("@name", adv.name);
                    myCommand.Parameters.AddWithValue("@text", adv.text);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Added Successfully");
        }


        //------------------------------------------- PUT (update) ------------------------------------------------
        [HttpPut]
        public JsonResult Put(AdvantagesDTO adv)
        {
            string query = @"
                update advantages
                set name = @name,
                text = @text
                where id = @id 
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", adv.id);
                    myCommand.Parameters.AddWithValue("@name", adv.name);
                    myCommand.Parameters.AddWithValue("@text", adv.text);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Updated Successfully");
        }


        //---------------------------------------------- Delete by name ----------------------------------------------
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                delete from advantages
                where id=@id 
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
}
