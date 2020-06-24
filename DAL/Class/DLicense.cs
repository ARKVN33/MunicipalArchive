using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Class
{
    public class DLicense
    {
        private readonly dbMunicipalArchiveEntities _dbMunicipalArchiveEntities;

        #region Constructor

        public DLicense()
        {
            _dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
        }

        #endregion

        #region Properties

        public string DAppLicense { get; set; }

        #endregion

        #region Methods

        public void Add()
        {
            var tblLicense = new tblLicense
            {
                AppLicense = DAppLicense
            };
            _dbMunicipalArchiveEntities.tblLicense.Add(tblLicense);
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public static List<tblLicense> GetData()
        {
            var dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
            return dbMunicipalArchiveEntities.tblLicense.ToList();
        }

        #endregion
    }
}
