using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Class
{
    public class DFilePlaque
    {
        
        private readonly dbMunicipalArchiveEntities _dbMunicipalArchiveEntities;

        #region Constructor

        public DFilePlaque()
        {
            _dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
        }

        #endregion

        #region Properties

        public int DFileId { get; set; }
        public int DPlaqueId { get; set; }

        #endregion

        #region Methods

        public void Add()
        {
            var tblFilePlaque = new tblFilePlaque
            {
                File_Id = DFileId,
                Plaque_Id = DPlaqueId
            };
            _dbMunicipalArchiveEntities.tblFilePlaque.Add(tblFilePlaque);
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public void Edit()
        {
            var result = _dbMunicipalArchiveEntities.tblFilePlaque.SingleOrDefault(x => x.File_Id == DFileId && x.Plaque_Id==DPlaqueId);
            if (result == null) return;

            result.File_Id = DFileId;
            result.Plaque_Id = DPlaqueId;

            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public void Delete()
        {
            var result = _dbMunicipalArchiveEntities.tblFilePlaque.Where(x => x.File_Id == DFileId );
            _dbMunicipalArchiveEntities.tblFilePlaque.RemoveRange(result);
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public static Task<List<tblPerson>> GetData()
        {
            var dbLoanEntities = new dbMunicipalArchiveEntities();
            return Task.Run(() => dbLoanEntities.tblPerson.AsNoTracking().ToList());
        }

        public static Task<bool> CanDelete(int plaqueId)
        {
            var dbLoanEntities = new dbMunicipalArchiveEntities();
            return Task.Run(() => dbLoanEntities.tblFilePlaque.AsNoTracking().Any(x => x.Plaque_Id == plaqueId));
        }
        #endregion
    }
}
