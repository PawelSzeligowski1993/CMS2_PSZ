﻿using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using WebApplication1.Models.DTO;

namespace WebApplication1.Controllers.SectionsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class _1PS_BanerController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public _1PS_BanerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //------------------------------------------- GET by name Baner ------------------------------------------------
        //-------------------Get all Baners -------------------
        [HttpGet]
        public JsonResult GetBANER()
        {
            string name = "Baner";

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


        //------------------- Get Baner by title -------------------

        [HttpGet("{Title}")]
        public JsonResult GetBanerByTitle(string title)
        {
            string name = "Baner";
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

        //------------------------------------------- POST by name Baner ------------------------------------------------
        [HttpPost]
        public JsonResult PostInBaner(Page_SectionsDTO pageSect)
        {
            int id = 0;
            string name = "Baner";
            string query = @"
                insert into page_Sections
                (id,name,position,title,img_url,last_mod_date,last_mod_user_id,advantages_id,user_id,service_id)
                values 
                (@id,'Baner',@position,@title,@img_url,@last_mod_date,@last_mod_user_id,@advantages_id,@user_id,@service_id)
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

            return new JsonResult("New Baner Added Successfully");
        }


        //------------------------------------------- PUT (update) IN Baner ------------------------------------------------

        //@name,@position,@title,@img,@last_modification_date,@last_mod_user_id,@advantages_id,@user_id,@service_id
        [HttpPut]
        public JsonResult PutInBaner(Page_SectionsDTO pageSect)
        {
            string name = "Baner";
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
                where (id = @id and name = 'Baner') 
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

            return new JsonResult("Baner Updated Successfully");
        }


        //---------------------------------------------- Delete by Id and name(Baner) ----------------------------------------------
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string name = "Baner";
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
                return new JsonResult("Baner No Deleted Successfully");
        }


    }
}
