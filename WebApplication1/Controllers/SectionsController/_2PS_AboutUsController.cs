using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using WebApplication1.Models.DTO;

namespace WebApplication1.Controllers.SectionsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class _2PS_AboutUsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public _2PS_AboutUsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        //------------------------------------------- GET by name AboutUs ------------------------------------------------
        //-------------------Get all AboutUs -------------------
        [HttpGet]
        public JsonResult GetAboutUs()
        {
            string name = "AboutUs";

            string query = @"
                select id as ""id"",
                        name as ""name"",
                        position as ""position"",
                        title as ""title"",
                        img_url as ""img_url"",
                        last_mod_date as ""last_mod_date"",
                        last_mod_user_id as ""last_mod_user_id"",
                        advantages_id as ""advantages_id"",
                        user_id as ""user_id"",
                        service_id as ""service_id""    
                from page_sections
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


        //------------------- Get AboutUs by title -------------------

        [HttpGet("{Title}")]
        public JsonResult GetAboutUsByTitle(string title)
        {
            string name = "AboutUs";
            string query = @"
                 select id as ""id"",
                        name as ""name"",
                        position as ""position"",
                        title as ""title"",
                        img_url as ""img_url"",
                        last_mod_date as ""last_mod_date"",
                        last_mod_user_id as ""last_mod_user_id"",
                        advantages_id as ""advantages_id"",
                        user_id as ""user_id"",
                        service_id as ""service_id""
                from page_sections
                where (name=@name and title=@title)
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
                    myCommand.Parameters.AddWithValue("@title", title);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult(table);
        }

        //------------------------------------------- POST by name AboutUs ------------------------------------------------
        [HttpPost]
        public JsonResult PostInAboutUs(Page_SectionsDTO pageSect)
        {
            int id = 0;
            string name = "AboutUs";
            string query = @"
                insert into page_Sections
                (id,name,position,title,img_url,last_mod_date,last_mod_user_id,advantages_id,user_id,service_id)
                values 
                (@id,'AboutUs',@position,@title,@img_url,@last_mod_date,@last_mod_user_id,@advantages_id,@user_id,@service_id)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", pageSect.id);
                    myCommand.Parameters.AddWithValue(name, pageSect.name);
                    myCommand.Parameters.AddWithValue("@position", pageSect.position);
                    myCommand.Parameters.AddWithValue("@title", pageSect.title);
                    myCommand.Parameters.AddWithValue("@img_url", pageSect.img_url);
                    myCommand.Parameters.AddWithValue("@last_mod_date", pageSect.last_mod_date);
                    myCommand.Parameters.AddWithValue("@last_mod_user_id", pageSect.last_mod_user_id);
                    myCommand.Parameters.AddWithValue("@advantages_id", pageSect.advantages_id);
                    myCommand.Parameters.AddWithValue("@user_id", pageSect.user_id);
                    myCommand.Parameters.AddWithValue("@service_id", pageSect.service_id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("New AboutUs Added Successfully");
        }


        //------------------------------------------- PUT (update) IN AboutUs ------------------------------------------------

        //@name,@position,@title,@img,@last_modification_date,@last_mod_user_id,@advantages_id,@user_id,@service_id
        [HttpPut]
        public JsonResult PutInAboutUs(Page_SectionsDTO pageSect)
        {
            string name = "AboutUs";
            string query = @"
                update page_Sections
                
                set position = @position,
                title = @title,
                img_url = @img_url,
                last_mod_date = @last_mod_date,
                last_mod_user_id = @last_mod_user_id,
                advantages_id = @advantages_id,
                user_id = @user_id,
                service_id = @service_id
                where (id = @id and name = 'AboutUs') 
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", pageSect.id);
                    myCommand.Parameters.AddWithValue(name, pageSect.name);
                    myCommand.Parameters.AddWithValue("@position", pageSect.position);
                    myCommand.Parameters.AddWithValue("@title", pageSect.title);
                    myCommand.Parameters.AddWithValue("@img_url", pageSect.img_url);
                    myCommand.Parameters.AddWithValue("@last_mod_date", pageSect.last_mod_date);
                    myCommand.Parameters.AddWithValue("@last_mod_user_id", pageSect.last_mod_user_id);
                    myCommand.Parameters.AddWithValue("@advantages_id", pageSect.advantages_id);
                    myCommand.Parameters.AddWithValue("@user_id", pageSect.user_id);
                    myCommand.Parameters.AddWithValue("@service_id", pageSect.service_id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("AboutUs Updated Successfully");
        }


        //---------------------------------------------- Delete by Id and name(AboutUs) ----------------------------------------------
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string name = "AboutUs";
            string query = @"
                delete from page_sections
                where (id=@id and name=@name);
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
                    myCommand.Parameters.AddWithValue("@name", name);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("AboutUs Deleted Successfully");
        }


    }
}
