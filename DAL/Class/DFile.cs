using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Class
{
    public class DFile
    {
        private readonly dbMunicipalArchiveEntities _dbMunicipalArchiveEntities;

        #region Constructor

        public DFile()
        {
            _dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
        }

        #endregion

        #region Properties

        public int DId { get; set; }
        public int? DMainId { get; set; }
        public int? DMarlik { get; set; }
        public byte? DFileTypeId { get; set; }
        public byte? DViolationId { get; set; }
        public int? DFileNum { get; set; }
        public byte? DFileYear { get; set; }
        public int? DPermitNum { get; set; }
        public byte? DPermitYear { get; set; }
        public int? DMantaghe { get; set; }
        public int? DNahie { get; set; }
        public int? DMahaleh { get; set; }
        public int? DBlock { get; set; }
        public int? DMelk { get; set; }
        public int? DRadif { get; set; }
        public string DAddress { get; set; }
        public string DPostalCode { get; set; }
        public string DVoteNum { get; set; }
        public bool? DInArchives { get; set; }
        public int? DSeparation { get; set; }
        public int? DAggregation { get; set; }
        public string DDateInsert { get; set; }
        public string DDescription { get; set; }

        #endregion

        #region Methods

        public Task<int> Add()
        {
            var addFile = new tblFile
            {
                MainId = DMainId,
                Marlik = DMarlik,
                FileType_Id = DFileTypeId,
                Violation_Id = DViolationId,
                FileNum = DFileNum,
                FileYear = DFileYear,
                PermitNum = DPermitNum,
                PermitYear = DPermitYear,
                Mantaghe = DMantaghe,
                Nahie = DNahie,
                Mahaleh = DMahaleh,
                Block = DBlock,
                Melk = DMelk,
                Radif = DRadif,
                Address = DAddress,
                PostalCode = DPostalCode,
                VoteNum = DVoteNum,
                InArchives = DInArchives,
                Separation = DSeparation,
                Aggregation = DAggregation,
                DateInsert = DDateInsert,
                Description = DDescription
            };
            _dbMunicipalArchiveEntities.tblFile.Add(addFile);
            _dbMunicipalArchiveEntities.SaveChanges();
            return Task.Run(() => addFile.Id);
        }

        public void Edit()
        {
            var result = _dbMunicipalArchiveEntities.tblFile.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            result.MainId = DMainId;
            result.Marlik = DMarlik;
            result.FileType_Id = DFileTypeId;
            result.Violation_Id = DViolationId;
            result.FileNum = DFileNum;
            result.FileYear = DFileYear;
            result.PermitNum = DPermitNum;
            result.PermitYear = DPermitYear;
            result.Mantaghe = DMantaghe;
            result.Nahie = DNahie;
            result.Mahaleh = DMahaleh;
            result.Block = DBlock;
            result.Melk = DMelk;
            result.Radif = DRadif;
            result.Address = DAddress;
            result.PostalCode = DPostalCode;
            result.VoteNum = DVoteNum;
            result.InArchives = DInArchives;
            result.Separation = DSeparation;
            result.Aggregation = DAggregation;
            result.DateInsert = DDateInsert;
            result.Description = DDescription;
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public void Delete()
        {
            var result = _dbMunicipalArchiveEntities.tblFile.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            _dbMunicipalArchiveEntities.tblFile.Remove(result);
            _dbMunicipalArchiveEntities.SaveChanges();
        }

        public static Task<List<viewAll>> GetAllData()
        {
            var dbMunicipalArchiveEntities = new dbMunicipalArchiveEntities();
            return Task.Run(() => dbMunicipalArchiveEntities.viewAll.AsNoTracking().ToList());
        }
        #endregion

    }
}
