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

using Npgsql;

namespace Manager
{
    class Methods
    {
        // Database=mydatabase
        public const string ConnectionString = 
            "Host=localhost;Username=psycho;Password=640916a;";


        public async static Task<int> CreateDatabase(string connectionString)
        {

            using (var con = new NpgsqlConnection(connectionString))
            {
                await con.OpenAsync();


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


    }
}
