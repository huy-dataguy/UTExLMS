using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace UTExLMS.Models.DBContext
{
    public class UpdateProfileDBContext : DbContext
    {

        //public DbSet<Lecturer> lecturer { get; set; }

        //public void UpdateUser(int userId, string firstName, string lastName, string email, DateTime birthday, string gender, string phoneNum, string password)
        //{
        //    var IdParameter = new SqlParameter("@IdLecturer", userId);
        //    var firstNameParameter = new SqlParameter("@FirstName", firstName);
        //    var lastNameParameter = new SqlParameter("@LastName", lastName);
        //    var emailParameter = new SqlParameter("@Email", email);
        //    var birthdayParameter = new SqlParameter("@Birthday", birthday);
        //    var genderParameter = new SqlParameter("@Gender", gender);
        //    var phoneNumParameter = new SqlParameter("@PhoneNum", phoneNum);
        //    var passwordParameter = new SqlParameter("@Password", password);

        //    this.Database.ExecuteSqlRaw("EXEC UpdateUser @IdLecturer, @FirstName, @LastName, @Email, @Birthday, @Gender, @PhoneNum, @Password",
        //        IdParameter, firstNameParameter, lastNameParameter, emailParameter, birthdayParameter, genderParameter, phoneNumParameter, passwordParameter);
        //}

    }
}
