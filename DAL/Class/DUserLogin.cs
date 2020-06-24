using System.Linq;

namespace DAL.Class
{
    public class DUserLogin
    {
        private readonly dbMunicipalArchiveEntities _dbMunicipalArchiveEntities;

        #region Constructor

        public DUserLogin()
        {
            _dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
        }

        #endregion

        #region Properties

        public string DUserName { get; set; }

        public string DUserPassword { get; set; }

        #endregion

        public bool Login()
        {
            var result = _dbMunicipalArchiveEntities.tblUser.FirstOrDefault(x => x.UserName == DUserName);
            return result != null && result.UserName == DUserName &&
                   BCrypt.Net.BCrypt.Verify(DUserPassword, result.UserPassword);
        }

        public static bool? ChekAdminRegistered()
        {
            var dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
            var result = dbMunicipalArchiveEntities.tblSundry.FirstOrDefault(x => x.Id == 1);
            if (result == null) return false;
            return result.RegisteredAdminPassword;
        }

        public static void SetSecurityAccess()
        {
            var dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
            var result = dbMunicipalArchiveEntities.tblSecurityAccess.FirstOrDefault(x => x.Id == 1);
            if (result == null)
            {
                var tblSecurityAccess = new tblSecurityAccess
                {
                    Id = 1,
                    Time = PersianDateTime.Now.AddMinutes(-10).ToString(),
                    Counter = "0"
                };
                dbMunicipalArchiveEntities.tblSecurityAccess.Add(tblSecurityAccess);
                dbMunicipalArchiveEntities.SaveChanges();
            }
            else if (result.Time == null)
            {
                var tblSecurityAccess = new tblSecurityAccess
                {
                    Id = 1,
                    Time = PersianDateTime.Now.AddMinutes(-10).ToString()
                };
                using (dbMunicipalArchiveEntities)
                {
                    dbMunicipalArchiveEntities.tblSecurityAccess.Attach(tblSecurityAccess);
                    dbMunicipalArchiveEntities.Entry(tblSecurityAccess).Property(x => x.Time).IsModified = true;
                    dbMunicipalArchiveEntities.SaveChanges();
                }
            }

        }

        public static void SaveCounter(int num)//zakhire tedad mavared vorod eshtebah
        {
            var tblSecurityAccess = new tblSecurityAccess
            {
                Id = 1,
                Counter = num.ToString()
            };
            using (var dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities())
            {
                dbMunicipalArchiveEntities.tblSecurityAccess.Attach(tblSecurityAccess);
                dbMunicipalArchiveEntities.Entry(tblSecurityAccess).Property(x => x.Counter).IsModified = true;
                dbMunicipalArchiveEntities.SaveChanges();
            }
        }

        public void StartSecurityTimeAccess()//taeen zaman vorod eshtebah
        {
            var tblSecurityAccess = new tblSecurityAccess
            {
                Id = 1,
                Time = PersianDateTime.Now.ToString()
            };
            using (var dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities())
            {
                dbMunicipalArchiveEntities.tblSecurityAccess.Attach(tblSecurityAccess);
                dbMunicipalArchiveEntities.Entry(tblSecurityAccess).Property(x => x.Time).IsModified = true;
                dbMunicipalArchiveEntities.SaveChanges();
            }
        }

        public static int SecurityAccess(ref int counter)//taeen modat zamani ke az 5 bar eshtbah gozashteh ast
        {
            var dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
            var firstOrDefault = dbMunicipalArchiveEntities.tblSecurityAccess.FirstOrDefault(); //khandan etela-at file
            if (firstOrDefault == null) return 5;
            counter = int.Parse(firstOrDefault.Counter);//zakhireh tedad vorod eshtebah
            var saveDate = firstOrDefault.Time.Split(' ');
            var result = PersianDateTime.Now - PersianDateTime.Parse(saveDate[0], saveDate[1]);
            var checkTimeMinutes = result.Minutes;
            var checkTimeHours = result.Hours;
            var checkTimeDays = result.Days;
            if (checkTimeHours == 0 && checkTimeDays == 0)
            {
                return checkTimeMinutes;
            }
            return 5;
        }

        public static PersianDateTime Date()
        {
            var dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
            var firstOrDefault = dbMunicipalArchiveEntities.tblSecurityAccess.FirstOrDefault(); //khandan etela-at file
            if (firstOrDefault == null) return PersianDateTime.Now;
            var saveDate = firstOrDefault.Time.Split(' ');
            return PersianDateTime.Parse(saveDate[0], saveDate[1]).AddMinutes(+5);
        }
    }
}
