using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Class
{
    public class DPerson
    {
        private readonly dbMunicipalArchiveEntities _dbMunicipalArchiveEntities;

        #region Constructor

        public DPerson()
        {
            _dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
        }

        #endregion

        #region Properties

        public int DId { get; set; }
        public string DName { get; set; }
        public string DFamily { get; set; }
        public string DFatherName { get; set; }
        public string DCode { get; set; }
        public string DBirthday { get; set; }
        public byte? DSex { get; set; }
        public string DMobile { get; set; }
        public string DDescription { get; set; }

        #endregion

        #region Methods

        public void Add()
        {
            var tblPerson = new tblPerson
            {
                Name = DName,
                Family = DFamily,
                FatherName = DFatherName,
                Code = DCode,
                Birthday = DBirthday,
                Sex = DSex,
                Mobile = DMobile,
                Description = DDescription

            };
            _dbMunicipalArchiveEntities.tblPerson.Add(tblPerson);
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public void Edit()
        {
            var result = _dbMunicipalArchiveEntities.tblPerson.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;

            result.Name = DName;
            result.Family = DFamily;
            result.FatherName = DFatherName;
            result.Code = DCode;
            result.Birthday = DBirthday;
            result.Sex = DSex;
            result.Mobile = DMobile;
            result.Description = DDescription;

            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public void Delete()
        {
            var result = _dbMunicipalArchiveEntities.tblPerson.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            _dbMunicipalArchiveEntities.tblPerson.Remove(result);
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public static Task<List<tblPerson>> CheckNationalCode(string nationalCode)
        {
            var dbLoanEntities = new dbMunicipalArchiveEntities();
            return Task.Run(() => dbLoanEntities.tblPerson.AsNoTracking().Where(x => x.Code == nationalCode).ToList());
        }

        public static Task<List<tblPerson>> GetData()
        {
            var dbLoanEntities = new dbMunicipalArchiveEntities();
            return Task.Run(() => dbLoanEntities.tblPerson.AsNoTracking().ToList());
        }

        public static Task<List<viewFilePerson>> GetCreate()
        {
            var dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
            return Task.Run(() => dbMunicipalArchiveEntities.viewFilePerson.AsNoTracking().ToList());
        }
        #endregion
    }
}
