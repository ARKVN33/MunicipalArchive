using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Class
{
    public class DUser
    {
        private readonly dbMunicipalArchiveEntities _dbMunicipalArchiveEntities;

        #region Constructor

        public DUser()
        {
            _dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
        }

        #endregion

        #region Properties

        public int DId { get; set; }

        public byte? DPostTypeId { get; set; }

        public byte DSecurityQuestionId { get; set; }

        public string DFirstName { get; set; }

        public string DLastName { get; set; }

        public string DUserName { get; set; }

        public string DPassword { get; set; }

        public string DMobile { get; set; }

        public string DEmail { get; set; }

        public string DAnswer { get; set; }

        public string DRegistrationDate { get; set; }

        public string DImage { get; set; }

        public string DDescription { get; set; }


        #endregion

        #region Methods

        public void AddAdmin()
        {
            var tblUser = new tblUser
            {
                User_PostType_Id = DPostTypeId,
                User_SecurityQuestion_Id = DSecurityQuestionId,
                UserFirstName = DFirstName,
                UserLastName = DLastName,
                UserName = DUserName,
                UserPassword = BCrypt.Net.BCrypt.HashPassword(DPassword),
                UserMobileNumber = DMobile,
                UserEmail = DEmail,
                UserAnswer = BCrypt.Net.BCrypt.HashPassword(DAnswer),
                UserRegistrationDate = DRegistrationDate,
                UserImage = DImage,
                UserDescription = DDescription
            };
            _dbMunicipalArchiveEntities.tblUser.Add(tblUser);
            _dbMunicipalArchiveEntities.SaveChanges();
            var sundry = _dbMunicipalArchiveEntities.tblSundry.ToList();
            if (sundry.Count != 0) return;
            var tblSundry = new tblSundry
            {
                Id = 1,
                RegisteredAdminPassword = true
            };
            _dbMunicipalArchiveEntities.tblSundry.Add(tblSundry);
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public static Task<List<string>> GetQuestion()
        {
            var dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
            return Task.Run(() => dbMunicipalArchiveEntities.tblSecurityQuestion.Select(x => x.SecurityQuestion).ToList());
        }

        public void ChangePassword()
        {
            var tblUser = new tblUser
            {
                Id = 1,
                UserName = DUserName,
                UserPassword = BCrypt.Net.BCrypt.HashPassword(DPassword)
            };

            using (var dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities())
            {
                dbMunicipalArchiveEntities.tblUser.Attach(tblUser);
                dbMunicipalArchiveEntities.Entry(tblUser).Property(x => x.UserName).IsModified = true;
                dbMunicipalArchiveEntities.Entry(tblUser).Property(x => x.UserPassword).IsModified = true;
                dbMunicipalArchiveEntities.SaveChanges();
            }
        }

        private static List<tblPostType> GetPostdata()
        {
            var dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
            return dbMunicipalArchiveEntities.tblPostType.ToList();
        }

        public static Task<List<tblUser>> GetData()
        {
            var dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
            return Task.Run(() => dbMunicipalArchiveEntities.tblUser.ToList());
        }
        #endregion
    }
}
