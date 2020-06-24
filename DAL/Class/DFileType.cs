using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Class
{
    public class DFileType
    {
        private readonly dbMunicipalArchiveEntities _dbMunicipalArchiveEntities;
        #region Constructor

        public DFileType()
        {
            _dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
        }

        #endregion

        #region Properties

        public short DId { get; set; }
        public string DFileTypeName { get; set; }

        #endregion

        #region Methods
        public void Add()
        {
            var addFileType = new tblFileType
            {
                FileType = DFileTypeName
            };
            _dbMunicipalArchiveEntities.tblFileType.Add(addFileType);
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public void Edit()
        {
            var result = _dbMunicipalArchiveEntities.tblFileType.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            result.FileType = DFileTypeName;
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public void Delete()
        {
            var result = _dbMunicipalArchiveEntities.tblFileType.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            _dbMunicipalArchiveEntities.tblFileType.Remove(result);
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public static Task<List<tblFileType>> GetData()
        {
            var dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
            return Task.Run(() => dbMunicipalArchiveEntities.tblFileType.AsNoTracking().ToList());
        }
        #endregion

    }
}
