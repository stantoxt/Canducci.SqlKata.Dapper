﻿using System;
using System.Data.SqlClient;
using System.Data;
using SqlKata.Compilers;
using Canducci.SqlKata.Dapper.MySql;
using MySql.Data.MySqlClient;
using Canducci.SqlKata.Dapper;
using Models;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {


            //MYSQLSERVER TEST
            string strConnection = "Server=localhost;Database=testdb;Uid=root;Pwd=senha;SslMode=none";            

            using (IDbConnection connection = new MySqlConnection(strConnection))
            {
                var r = connection.Update("car")
                    .Set("description", "Maverick")
                    .Where("id", 2)
                    .Save();

                var a = 1;
                //connection.Update("car")
                //    .Set("description", "Parati")
                //    .Where("id", 2)
                //    .Save();


                //connection.Update("car")
                //    .Set("description", "Parati Super")                                        
                //    .Where(x => x.Where("id", 2))
                //    .Save();


                //connection.Delete("car")
                //    .Where("id", 1)
                //    .Save();

                //var cars = connection.Query("car").List<Car>();

                //var credits = connection.Query("credit")
                //        .List<Credit>();
                //var ab = 10;

                //People p0 = connection
                //    .Query()
                //    .From("people")
                //    .Where("id", 1)
                //    .First<People>();

                //var listPeople = connection
                //    .Query("people")
                //    .OrderBy("name")
                //    .List<People>();

                //var result0 = connection
                //        .Insert("people")
                //        .Set("name", "Salvando de novo")
                //        .SetNull("created")
                //        .Set("active", true)
                //        .Save();

                //var result1 = connection
                //    .Insert("people")
                //    .Set(new { name = "Salomão", created = default(DateTime?), active = true })
                //    .Save();

                //People p = new People
                //{
                //    Active = true,
                //    Created = DateTime.Parse("02/01/1990"),
                //    Name = "Sr. Riston Rockets"
                //};

                //Credit cr = new Credit
                //{
                //    Created = null,
                //    Description = "Datena Novo Programa null Created 123"
                //};

                //Notice nt = new Notice
                //{
                //    Id = Guid.NewGuid().ToString(),
                //    Text = "Text 101",
                //    Title = "Title 101"
                //};

                //nt = connection.Insert(nt);
                //cr = connection.Insert(cr);

                //Car c = new Car
                //{
                //    Description = "Busão"
                //};

                //connection.Insert(c);


                var cr = connection.Query()
                    .From("car")
                    .Where("id", 2)
                    .First<Car>();

                if (cr != null)
                {
                    cr.Description = "Busão Muito Louco 2";
                    var result = connection.Update(cr);
                }

                var nt = connection.Query()
                    .From("notice")
                    .Where("id", "247fd9fa-69c2-4497-a65f-244d11d42944")
                    .First<Notice>();

                if (nt != null)
                {
                    nt.Title = "Title Update 101 ++++";
                    nt.Text = "Text Update 101 +++";
                    var result = connection.Update(nt);
                }


            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Execução finalizada com sucesso !!!");
            Console.WriteLine("");
            Console.ReadKey();
        }

        public static void Clean()
        {
            //MYSQLSERVER TEST
            //string strConnection = "Server=localhost;Database=testdb;Uid=root;Pwd=senha;SslMode=none";
            //Compiler compiler = new MySqlCompiler();

            //SQLSERVER TEST
            string strConnection = "Server=.\\SqlExpress;Database=QueryBuilderDatabase;User Id=sa;Password=senha;MultipleActiveResultSets=true;";
            Compiler compiler = new SqlServerCompiler();

            //POSTGRESQL TEST
            //string strConnection = "Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=senha;";                        
            //Compiler compiler = new PostgresCompiler();

            //using (MySqlConnection connection = new MySqlConnection(strConnection))
            using (IDbConnection connection = new SqlConnection(strConnection))
            //using (NpgsqlConnection connection = new NpgsqlConnection(strConnection))
            {

                //var db = new QueryBuilderDapper(connection, compiler, "People");
                /*
                var result0 = db.Select("*")
                    .Where("Id", "IN", x => x.From("Bank").Select("PeopleId"))
                    .Query();
               */

                //var result1 = db.Join("Bank", "Bank.PeopleId", "People.Id")
                //    .Query();

                //var result2 = db
                //    .GroupBy("PeopleId")                    
                //    .From()
                //    .SelectRaw("PeopleId, Count(Id) as Quant")
                //    .Query();


                //var result3 = connection
                //    .SoftBuild("Bank")
                //    .List<dynamic>();
                //.From(x => x.From("Bank").Where("PeopleId", ">", 0), "b")                                        


                //var r = db.Insert(new Dictionary<string, object>
                //{
                //    ["Name"] = Guid.NewGuid().ToString(),
                //    ["Created"] = DateTime.Now.AddDays(-6),
                //    ["Active"] = false
                //})
                //.SaveInsertGetByIdInserted<long>();

                //var db = new QueryBuilderDapper(connection, compiler, "Credit");
                //var r = db.Insert(new Dictionary<string, object>
                //{
                //    ["Description"] = "Credit - teste" + Guid.NewGuid().ToString(),                    
                //})




                //Console.WriteLine($"Resultado: {result.ToString()}");

                //var c = new QueryBuilderSoftDapper(connection, compiler);

                //var reader = c.QueryBuilderMultipleCollection();
                //    .AddQuery(x => x.From("People").OrderBy("Id"))
                //    .AddQuery(x => x.From("Credit").OrderBy("Id"))
                //    .AddQuery(x => x.From("People").Where("Id", 1))
                //    .AddQuery(x => x.From("People").AsCount())
                //    .Results();

                //IList<People> peoples0 = reader.Read<People>().ToList();
                //IList<Credit> credit0 = reader.Read<Credit>().ToList();
                //People peoples1 = reader.ReadFirst<People>();
                //int count = reader.ReadFirst<int>();


                //var b = 10;

                //var peoples = r.Read<People>();
                //var credits = r.Read<Credit>();
                //int countPeople = r.ReadFirst<int>();

                //var result = c.AddQuery<Credit>(x =>
                //    x.From("Credit")
                //        .AsInsert(new Dictionary<string, object>
                //        {
                //            ["Description"] = "Testando 123",
                //            ["Created"] = DateTime.Now.AddDays(-1)
                //        })
                //    )
                //    .AddQuery<Credit>(x =>
                //    x.From("Credit")
                //        .AsInsert(new Dictionary<string, object>
                //        {
                //            ["Description"] = "Testando 345",
                //            ["Created"] = DateTime.Now.AddDays(-2)
                //        }))
                //        .Results();
            }
        }
    }
}
