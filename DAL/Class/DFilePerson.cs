using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Class
{
    public class DFilePerson
    {
        private readonly dbMunicipalArchiveEntities _dbMunicipalArchiveEntities;

        #region Constructor

        public DFilePerson()
        {
            _dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
        }

        #endregion

        #region Properties

        public int DFileId { get; set; }
        public int DPersonId { get; set; }

        #endregion

        #region Methods

        public void Add()
        {
            var tblFilePerson = new tblFilePerson
            {
                File_Id = DFileId,
                Person_Id = DPersonId
            };
            _dbMunicipalArchiveEntities.tblFilePerson.Add(tblFilePerson);
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public void Edit()
        {
            var result = _dbMunicipalArchiveEntities.tblFilePerson.SingleOrDefault(x => x.File_Id == DFileId && x.Person_Id == DPersonId);
            if (result == null) return;

            result.File_Id = DFileId;
            result.Person_Id = DPersonId;

            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public void Delete()
        {
            var result = _dbMunicipalArchiveEntities.tblFilePerson.Where(x => x.File_Id == DFileId);
            _dbMunicipalArchiveEntities.tblFilePerson.RemoveRange(result);
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public static Task<List<tblPerson>> GetData()
        {
            var dbLoanEntities = new dbMunicipalArchiveEntities();
            return Task.Run(() => dbLoanEntities.tblPerson.AsNoTracking().ToList());
        }

        public static Task<bool> CanDelete(int personId)
        {
            var dbLoanEntities = new dbMunicipalArchiveEntities();
            return Task.Run(() => dbLoanEntities.tblFilePerson.AsNoTracking().Any(x=>x.Person_Id == personId));
        }

        #endregion
    }
}
