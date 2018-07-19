/*
 CREATE TABLE public.article
(
    id integer NOT NULL,
    title text COLLATE pg_catalog."default",
    content text COLLATE pg_catalog."default",
    CONSTRAINT article_pkey PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.article
    OWNER to goprojects;

CREATE TABLE public.comments
(
    id integer NOT NULL DEFAULT nextval('comments_id_seq'::regclass),
    author text COLLATE pg_catalog."default" NOT NULL,
    content text COLLATE pg_catalog."default" NOT NULL,
    date_created date NOT NULL,
    post_id integer,
    CONSTRAINT comments_pkey PRIMARY KEY (id),
    CONSTRAINT comments_post_id_fkey FOREIGN KEY (post_id)
        REFERENCES public.posts (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.comments
    OWNER to goprojects;
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using Helpers;

namespace Manager
{
    static class DatabaseMethods
    {
        // Database=mydatabase
        public const string ConnectionString =
            "Host=localhost;Username=psycho;Password=640916a;";
        static NpgsqlConnection _npgsqlConnection;


        static DatabaseMethods()
        {
            const string cs = "Host=localhost;Username=psycho;Password=640916a;";
            _npgsqlConnection = new NpgsqlConnection(cs);
        }




        public static NpgsqlConnection GetNpgsqlConnection()
        {
            var connection = new NpgsqlConnection("Host=localhost;Username=psycho;Password=640916a;");

            // await connection.OpenAsync();

            return connection;
        }

        public async static Task<int> CreateDatabase(string connectionString)
        {

            using (var con = new NpgsqlConnection(connectionString))
            {



                var sb = new StringBuilder();
                sb.AppendLine("CREATE SEQUENCE commodities_id_seq;");
                sb.AppendLine("CREATE TABLE IF NOT EXISTS public.commodities");
                sb.AppendLine("(");
                sb.AppendLine("id integer NOT NULL DEFAULT nextval(\'commodities_id_seq\'::regclass),");
                sb.AppendLine("author text COLLATE pg_catalog.\"default\" NOT NULL,");
                sb.AppendLine("content text COLLATE pg_catalog.\"default\" NOT NULL,");
                sb.AppendLine("date_created date NOT NULL,");
                sb.AppendLine("post_id integer,");
                sb.AppendLine("CONSTRAINT comments_pkey PRIMARY KEY (id)");
                sb.AppendLine(")");
                sb.AppendLine("WITH (");
                sb.AppendLine("OIDS = FALSE");
                sb.AppendLine(")");
                sb.AppendLine("TABLESPACE pg_default;");
                sb.AppendLine("ALTER TABLE public.commodities");
                sb.AppendLine("OWNER to psycho;");
                sb.AppendLine("ALTER SEQUENCE commodities_id_seq OWNED BY commodities.id;");


                using (var cmd = new NpgsqlCommand(sb.ToString(), con))
                {
                    return await cmd.ExecuteNonQueryAsync();
                }

            }
        }

        public static void Cleanup()
        {
            if (_npgsqlConnection.State == ConnectionState.Open)
                _npgsqlConnection.Close();
        }
        public async static Task<int> CreateTable()
        {
            /*

             OIDS  

             OIDs basically give you a built-in, 
             globally unique id for every row, 
             contained in a system column (as opposed to a user-space column). 
             That's handy for tables where you don't have a primary key, 
             have duplicate rows, etc. 
             For example, if you have a table with two identical rows, 
             and you want to delete the oldest of the two, 
             you could do that using the oid column.

            In my experience, 
            the feature is generally unused in most postgres-backed applications (probably in part because they're non-standard), 
            and their use is essentially deprecated:


             */
            var sb = new StringBuilder();
            sb.AppendLine("CREATE TABLE products(");
            sb.AppendLine("product_id serial PRIMARY KEY,");
            sb.AppendLine("product_name varchar(100),");
            sb.AppendLine("description text,");
            sb.AppendLine("add_ts timestamp NOT NULL DEFAULT current_timestamp");
            sb.AppendLine(");");
            sb.AppendLine("CREATE INDEX idx_products_product_name ON products USING btree (product_name);");

            var result = 0;
            try
            {
                if (_npgsqlConnection.State == ConnectionState.Closed)
                    await _npgsqlConnection.OpenAsync();

                using (var cmd = new NpgsqlCommand(sb.ToString(), _npgsqlConnection))
                {

                    result = await cmd.ExecuteNonQueryAsync();
                }

            }
            catch (Exception exc)
            {
                DebugHelper.WriteException(exc);

            }
            finally
            {
                if (_npgsqlConnection.State == ConnectionState.Open)
                    _npgsqlConnection.Close();
            }
            return result;




        }

    }
}
