using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using WebApplication1.Models.DTO;

namespace CMS_Projekt_API.Controllers
{


    
    [Route("api/[controller]")]
    [ApiController]
    public class _01_UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public _01_UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //------------------------------------------- GET ------------------------------------------------
        //-------------------Get all-------------------
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select id as ""id"",
                       full_name as ""full_name"",
                       email as ""email"",
                       cms_role as ""cms_role"",
                       password as ""password"",
                       created_date as ""created_date""
                from users
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

        [HttpGet("{full_name}")]
        public JsonResult GeteByname1(string full_name)
        {
            string query = @"
                 select id as ""Id"",
                       full_name as ""full_name"",
                       email as ""email"",
                       cms_role as ""cms_role"",
                       password as ""password"",
                       created_date as ""created_date""
                from users
                where full_name=@full_name 
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@full_name", full_name);
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
        public JsonResult Post(UsersDTO user)
        {

            string query = @"
                insert into users(id,full_name,email,cms_role,password, created_date)
                values (@id,@full_name,@email,@cms_role,@password,@created_date)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", user.id);
                    myCommand.Parameters.AddWithValue("@full_name", user.full_name);
                    myCommand.Parameters.AddWithValue("@email", user.email);
                    myCommand.Parameters.AddWithValue("@cms_role", user.cms_role);
                    myCommand.Parameters.AddWithValue("@password", user.password);
                    myCommand.Parameters.AddWithValue("@created_date", user.created_date);

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
        public JsonResult Put(UsersDTO user)
        {
            string query = @"
                update users
                set full_name = @full_name,
                email = @email,
                cms_role = @cms_role,
                password = @password,
                created_date = @created_date
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
                    myCommand.Parameters.AddWithValue("@id", user.id);
                    myCommand.Parameters.AddWithValue("@full_name", user.full_name);
                    myCommand.Parameters.AddWithValue("@email", user.email);
                    myCommand.Parameters.AddWithValue("@cms_role", user.cms_role);
                    myCommand.Parameters.AddWithValue("@password", user.password);
                    myCommand.Parameters.AddWithValue("@created_date", user.created_date);
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
                delete from users
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
