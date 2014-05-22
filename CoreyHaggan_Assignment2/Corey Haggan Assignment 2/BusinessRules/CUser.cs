using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace BusinessRules
{
    public class CUser
    {
        SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["strConn"].ConnectionString);
          private SqlCommand objCmd;

        //add some properties of our class that can be read / set from the caller
        private int mCourseID;
        private string mStudentName;
        private string mCourseName;
        private string mCourseTime;

        public int CourseID
        {
            get { return mCourseID; }
            set { mCourseID = value; }
        }

        public string StudentName
        {
            get { return mStudentName; }
            set { mStudentName = value; }
        }

        public string CourseName
        {
            get { return mCourseName; }
            set { mCourseName = value; }
        }

        public string CourseTime
        {
            get { return mCourseTime; }
            set { mCourseTime = value; }
        }

        public SqlDataReader getUsers()
        {
            //select suppliers from db

            //connect to db
            objConn.Open();

            //set up and run the sql
            objCmd = new SqlCommand("SELECT * FROM Courses ORDER BY StudentName", objConn);

            //execute the sql and store the results in an sqldatareader to send back to the caller
            SqlDataReader objRdr;

            objRdr = objCmd.ExecuteReader();

            return objRdr;

        }

        public void getCourse() {
            //connect to db
            objConn.Open();

            //set up and run the sql
            objCmd = new SqlCommand("SELECT * FROM Courses WHERE CourseID = " + CourseID.ToString(), objConn);

            //execute the sql and store the results in an sqldatareader to send back to the caller
            SqlDataReader objRdr;

            objRdr = objCmd.ExecuteReader();

            //loop through the columns and fill the properties of the User object
            while (objRdr.Read())
            {
                StudentName = objRdr.GetString(1);
                CourseName = objRdr.GetString(0);
                CourseTime = objRdr.GetString(2);
                //address = objRdr.GetString(2);
            }

            objRdr.Close();
            objCmd.Dispose();
            objConn.Close();
        }

        public void saveUsers()
        {
            //connect to db
            objConn.Open();

            //set up and run the sql
            if (CourseID == 0)
            {
                objCmd = new SqlCommand("INSERT INTO Courses (StudentName, CourseName, CourseTime) VALUES ('" + StudentName + "', '" + CourseName + "', '" + CourseTime+ "')", objConn);
            }
            else
            {
                objCmd = new SqlCommand("UPDATE Courses SET CompanyName = '" + StudentName + "','" + CourseName + "', '" + CourseTime + "' WHERE CourseD = " + CourseID.ToString(), objConn);
            }
            objCmd.ExecuteNonQuery();

            //clean up
            objCmd.Dispose();
            objConn.Close();
        }


        public void deleteUsers()
        {
            //connect to db
            objConn.Open();

            //set up and run the sql
            objCmd = new SqlCommand("DELETE FROM Courses WHERE CourseID = " + CourseID.ToString(), objConn);
            objCmd.ExecuteNonQuery();

            //clean up
            objCmd.Dispose();
            objConn.Close();
        }
        /*c# code for hashing and salting - credit Dino Esposito at http://devproconnections.com/aspnet/aspnet-web-security-protect-user-passwords-hashing-and-salt?page=2 */

        public string hashPassword(string password, string salt)
        {
            var combinedPassword = String.Concat(password, salt);
            var sha256 = new SHA256Managed();
            var bytes = UTF8Encoding.UTF8.GetBytes(combinedPassword);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public string getRandomSalt(Int32 size = 12)
        {
            var random = new RNGCryptoServiceProvider();
            var salt = new Byte[size];
            random.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public bool validatePassword(string enteredPassword, string storedHash, string storedSalt)
        {
            // Consider this function as an internal function where parameters like
            // storedHash and storedSalt are read from the database and then passed.

            var hash = hashPassword(enteredPassword, storedSalt);
            return String.Equals(storedHash, hash);
        }

        public void register(string username, string password, string role)
        {
            //generate a unique salt value then combine it to hash the plain password
            string salt = getRandomSalt(20);
            string hashedPassword = hashPassword(password, salt);

            //connect to db & add the record
            objConn.Open();
            string strSQL = "INSERT INTO Users (Username, Password, SaltString, Role) VALUES ('" +
                username + "','" + hashedPassword + "','" + salt + "','" + role + "')";

            SqlCommand objCmd = new SqlCommand(strSQL, objConn);
            objCmd.ExecuteNonQuery();

            //clean up
            objCmd.Dispose();
            objConn.Close();
        }

        public string login(string username, string password)
        {
            string role = "";

            //check the db for this user
            objConn.Open();
            string strSQL = "SELECT * FROM Users WHERE Username = '" + username + "'";

            SqlCommand objCmd = new SqlCommand(strSQL, objConn);
            SqlDataReader objRdr = objCmd.ExecuteReader();

            //salt and hash entered password and compare to password in db
            while (objRdr.Read())
            {
                if (validatePassword(password, objRdr.GetString(1), objRdr.GetString(2))) {
                    //if we found a match
                    role = objRdr.GetString(3);
                }
            }

            //clean up
            objRdr.Close();
            objCmd.Dispose();
            objConn.Close();
            return role;
        }

    }
}
