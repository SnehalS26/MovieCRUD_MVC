using System.Data.SqlClient;

namespace MovieCRUD_MVC.Models
{
    public class MovieCRUD
    {
        IConfiguration configuration;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public MovieCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(configuration.GetConnectionString("defaultConnection"));
        }

        public IEnumerable<Movie> GetAllMovie()
        {
            List<Movie> list = new List<Movie>();
            string qry = "Select * from Movie where isActive = 1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Movie m = new Movie();
                    m.Id = Convert.ToInt32(dr["id"]);
                    m.Name = dr["name"].ToString();
                    m.Genere = dr["genere"].ToString();
                    m.Release_Date = Convert.ToDateTime(dr["released_date"]);
                    m.StarCast = dr["starcast"].ToString();
                    list.Add(m);
                }
            }
            con.Close();
            return list;
        }
        public Movie GetMovieById(int id)
        {
            Movie m = new Movie();
            string qry = "select * from Movie where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    m.Id = Convert.ToInt32(dr["id"]);
                    m.Name = dr["name"].ToString();
                    m.Genere = dr["genere"].ToString();
                    m.Release_Date = Convert.ToDateTime(dr["released_date"]);
                    m.StarCast = dr["starcast"].ToString();

                }
            }
            con.Close();
            return m;   
        }
        public int AddMovie(Movie movie)
        {
            movie.isActive = 1;
            int result = 0;
            string qry = "insert into Movie values(@name,@genere,@released_date,@starcast,@isActive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", movie.Name);
            cmd.Parameters.AddWithValue("@genere", movie.Genere);
            cmd.Parameters.AddWithValue("@released_date", movie.Release_Date);
            cmd.Parameters.AddWithValue("@starcast", movie.StarCast);
            cmd.Parameters.AddWithValue("@isActive", movie.isActive);
            con.Open();
            result= cmd.ExecuteNonQuery();
            con.Close() ;
            return result;
        }
        public int UpdateMovie(Movie movie)
        {
            movie.isActive = 1;
            int result = 0;
            string qry = "update Movie set name=@name,genere=@genere,released_date=@released_date,starcast=@starcast,isActive=@isActive where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", movie.Name);
            cmd.Parameters.AddWithValue("@genere", movie.Genere);
            cmd.Parameters.AddWithValue("@released_date", movie.Release_Date);
            cmd.Parameters.AddWithValue("@starcast", movie.StarCast);
            cmd.Parameters.AddWithValue("@isActive", movie.isActive);
            cmd.Parameters.AddWithValue("@id", movie.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteMovie(int id)
        {
            int result = 0;
            string qry = "update Movie set isActive=0 where id=@id";
            cmd = new SqlCommand(qry,con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}
