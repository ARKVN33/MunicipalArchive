using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Class
{
    public class DPlaque
    {
        private readonly dbMunicipalArchiveEntities _dbMunicipalArchiveEntities;
        #region Constructor

        public DPlaque()
        {
            _dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
        }

        #endregion

        #region Properties

        public int DId { get; set; }
        public int? DMain { get; set; }
        public int? DSecondary { get; set; }
        public int? DPart { get; set; }
        public string DDescription { get; set; }

        #endregion

        #region Methods
        public void Add()
        {
            var addPlaque = new tblPlaque
            {
                Main = DMain,
                Secondary = DSecondary,
                Part = DPart,
                Description = DDescription
            };
            _dbMunicipalArchiveEntities.tblPlaque.Add(addPlaque);
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public void Edit()
        {
            var result = _dbMunicipalArchiveEntities.tblPlaque.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            result.Main = DMain;
            result.Secondary = DSecondary;
            result.Part = DPart;
            result.Description = DDescription;
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public void Delete()
        {
            var result = _dbMunicipalArchiveEntities.tblPlaque.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            _dbMunicipalArchiveEntities.tblPlaque.Remove(result);
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public static Task<List<tblPlaque>> GetData()
        {
            var dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
            return Task.Run(() => dbMunicipalArchiveEntities.tblPlaque.AsNoTracking().ToList());
        }

        public static Task<List<viewFilePlaque>> GetCreate()
        {
            var dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
            return Task.Run(() => dbMunicipalArchiveEntities.viewFilePlaque.AsNoTracking().ToList());
        }
        #endregion
    }
}
