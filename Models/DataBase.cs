using Microsoft.Data.SqlClient;

namespace FlouristStudio.Models
{
    public class DataBase
    {
        private static readonly SqlConnection Con = new(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=FloristStudio;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public static bool RegisterNewUser(SignUp s)
        {
            Con.Open();
            SqlCommand Cmd = new("Insert into [UserBase] (Name,UserName, Password, Email) Values(@name,@username,@password,@email)",Con);
            Cmd.Parameters.Add(new("name", s.Name));
            Cmd.Parameters.Add(new("username", s.UserName));
            Cmd.Parameters.Add(new("password", s.Password));
            Cmd.Parameters.Add(new("email", s.Email));
            int status = Cmd.ExecuteNonQuery();
            Con.Close();
            return status != 0;
        }
        public static List<SignUp> GetUsers()
        {
            Con.Open();
            SqlCommand Cmd = new("select * from [UserBase]", Con);
            SqlDataReader dr = Cmd.ExecuteReader();
            List<SignUp> list = new();
            if(dr.HasRows)
            {
                while (dr.Read())
                {
                    list.Add(new SignUp((String)dr[1], (String)dr[2], (String)dr[3], (String)dr[3], (String)dr[4])); //nme, usernme, pssword, emil
                }
            }
            Con.Close();
            return list;
        }
        public static bool VerifyUser(SignIn s)
        {
            List<SignUp> users = GetUsers();
            foreach(SignUp User in users)
            {
                if (User.UserName == s.UserName && User.Password == s.Password)
                    return true;
            }
            return false;
        }
        public static bool UniqueUser(SignUp s)
        {
            List<SignUp> users = GetUsers();
            foreach (SignUp User in users)
            {
                if (User.UserName == s.UserName)
                    return false;
            }
            return true;
        }
    }
}
