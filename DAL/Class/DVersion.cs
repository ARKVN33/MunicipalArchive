using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Class
{
    public class DVersion
    {
        private readonly dbMunicipalArchiveEntities _dbMunicipalArchiveEntities;

        #region Constructor

        public DVersion()
        {
            _dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
        }

        #endregion

        #region Properties


        public string DAppVersion { get; set; }

        #endregion

        #region Methods

        public void Edit()
        {
            var result = _dbMunicipalArchiveEntities.tblAppVersion.SingleOrDefault(x => x.Id == 1);
            if (result == null) return;
            result.AppVersion = DAppVersion;
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public static Task<List<tblAppVersion>> GetData()
        {
            var dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
            return Task.Run(() => dbMunicipalArchiveEntities.tblAppVersion.ToList());
        }

        #endregion
    }
}