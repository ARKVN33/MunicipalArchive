using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Class
{
    public class DViolation
    {
        private readonly dbMunicipalArchiveEntities _dbMunicipalArchiveEntities;
        #region Constructor

        public DViolation()
        {
            _dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
        }

        #endregion

        #region Properties

        public short DId { get; set; }
        public string DViolationName { get; set; }

        #endregion

        #region Methods
        public void Add()
        {
            var addViolation = new tblViolation
            {
                Violation = DViolationName
            };
            _dbMunicipalArchiveEntities.tblViolation.Add(addViolation);
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public void Edit()
        {
            var result = _dbMunicipalArchiveEntities.tblViolation.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            result.Violation = DViolationName;
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public void Delete()
        {
            var result = _dbMunicipalArchiveEntities.tblViolation.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            _dbMunicipalArchiveEntities.tblViolation.Remove(result);
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public static Task<List<tblViolation>> GetData()
        {
            var dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
            return Task.Run(() => dbMunicipalArchiveEntities.tblViolation.AsNoTracking().ToList());
        }
        #endregion

    }
}
