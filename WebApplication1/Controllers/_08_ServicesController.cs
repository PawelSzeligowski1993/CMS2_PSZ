using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using WebApplication1.Models.DTO;

namespace CMS_Projekt_API.Controllers
{
    //------------------------------------------- GET ------------------------------------------------
    //-------------------Get all-------------------
    [Route("api/[controller]")]
    [ApiController]
    public class _08_ServicesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public _08_ServicesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

            [HttpGet]
            public JsonResult Get()
            {
                string query = @"
                select id as ""id"",
                        name as ""name"",
                        description as ""description""    
                from services
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

        //-------------------Get by name-------------------

        [HttpGet("{name}")]
        public JsonResult GeteByname1(string name)
        {
            string query = @"
                 select id as ""id"",
                       name as ""name"",
                       description as ""description"" 
                from services
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
        public JsonResult Post(ServicesDTO services)
        {
            int id = 0;

            string query = @"
                insert into services
                (id,name,description)
                values 
                (@id,@name,@description)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", services.id);
                    myCommand.Parameters.AddWithValue("@name", services.name);
                    myCommand.Parameters.AddWithValue("@description", services.description);


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
        public JsonResult Put(ServicesDTO adv)
        {
            string query = @"
                update services
                set name = @name,
                description = @description
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
                    myCommand.Parameters.AddWithValue("@description", adv.description);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Updated Successfully");
        }


        //------------------------------------------- DELETE by id ------------------------------------------------
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                delete from services
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
