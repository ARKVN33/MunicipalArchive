using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Arash;
using DAL;
using DAL.Class;
using MunicipalArchive.Class;

namespace MunicipalArchive.Windows
{
    /// <summary>
    /// Interaction logic for WinFile.xaml
    /// </summary>
    public partial class WinFile
    {
        //private List<spAllData_Result> _fileData;
        //private List<spAllData_Result> _fileSearchData;

        private List<viewAll> _fileAllData;
        private List<viewAll> _fileSearchAllData;

        private List<viewFilePerson> _creatPersonData;
        private List<viewFilePlaque> _creatPlaqueData;

        private List<tblFileType> _fileTypeData;
        private List<tblViolation> _violationData;

        private List<CreatePerson> _createPersons;
        private List<CreatePlaque> _createPlaque;

        public List<int> PersonId { get; set; }
        public List<string> PersonName { get; set; }
        public List<string> PersonFamily { get; set; }
        public List<string> PersonFather { get; set; }
        public List<string> PersonCode { get; set; }

        public List<int> PlaqueId { get; set; }
        public List<int?> PlaqueMain { get; set; }
        public List<int?> PlaqueSecondary { get; set; }
        public List<int?> PlaquePart { get; set; }
        public List<string> PlaqueDescription { get; set; }

        public int? MainId { get; set; }

        private int _searchLength;

        public WinFile()
        {
            InitializeComponent();
            
            //_fileData = new List<spAllData_Result>();
            //_fileSearchData = new List<spAllData_Result>();

            _fileAllData = new List<viewAll>();
            _fileSearchAllData = new List<viewAll>();

            _creatPersonData = new List<viewFilePerson>();
            _creatPlaqueData = new List<viewFilePlaque>();

            _fileTypeData = new List<tblFileType>();
            _violationData = new List<tblViolation>();

            _createPersons = new List<CreatePerson>();
            _createPlaque = new List<CreatePlaque>();

            PersonId = new List<int>();
            PersonName = new List<string>();
            PersonFamily = new List<string>();
            PersonFather = new List<string>();
            PersonCode = new List<string>();

            PlaqueId = new List<int>();
            PlaqueMain = new List<int?>();
            PlaqueSecondary = new List<int?>();
            PlaquePart = new List<int?>();
            PlaqueDescription = new List<string>();

            _searchLength = 0;
        }

        #region Event

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //_fileData = await DFile.GetData();
                _fileAllData = await DFile.GetAllData();
                _fileTypeData = await DFileType.GetData();
                _violationData = await DViolation.GetData();
                _creatPersonData = await DPerson.GetCreate();
                _creatPlaqueData = await DPlaque.GetCreate();
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در دریافت اطلاعات\n" + exception.Message);
                Close();
                return;
            }
            //_fileSearchData = _fileData;
            _fileSearchAllData = _fileAllData;
            CboFileType.ItemsSource = _fileTypeData;
            CboViolation.ItemsSource = _violationData;
            DgdFile.ItemsSource = _fileSearchAllData;
            BtnNew_Click(null, null);
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckEmpty()) return;
            var fileId = 0;
            #region AddFile

            try
            {
                var addFile = new DFile
                {
                    DMainId = MainId,
                    DMarlik = int.Parse(TxtMarlik.Text),
                    DFileTypeId = CboFileType.SelectedIndex == -1 ? (byte?)null : ((tblFileType)CboFileType.SelectedItem).Id,
                    DViolationId = CboViolation.SelectedIndex == -1 ? (byte?) null : ((tblViolation)CboViolation.SelectedItem).Id,
                    DFileNum = string.IsNullOrEmpty(TxtFileNum.Text) ? (int?) null : int.Parse(TxtFileNum.Text),
                    DFileYear = string.IsNullOrEmpty(TxtFileYear.Text) ? (byte?) null : byte.Parse(TxtFileYear.Text),
                    DPermitNum = string.IsNullOrEmpty(TxtPermitNum.Text) ? (int?) null : int.Parse(TxtPermitNum.Text),
                    DPermitYear = string.IsNullOrEmpty(TxtPermitYear.Text) ? (byte?) null : byte.Parse(TxtPermitYear.Text),
                    DMantaghe = string.IsNullOrEmpty(TxtMantaghe.Text) ? (int?) null : int.Parse(TxtMantaghe.Text),
                    DNahie = string.IsNullOrEmpty(TxtNahie.Text) ? (int?) null : int.Parse(TxtNahie.Text),
                    DMahaleh = string.IsNullOrEmpty(TxtMahaleh.Text) ? (int?) null : int.Parse(TxtMahaleh.Text),
                    DBlock = string.IsNullOrEmpty(TxtBlock.Text) ? (int?) null : int.Parse(TxtBlock.Text),
                    DMelk = string.IsNullOrEmpty(TxtMelk.Text) ? (int?) null : int.Parse(TxtMelk.Text),
                    DRadif = string.IsNullOrEmpty(TxtRadif.Text) ? (int?) null : int.Parse(TxtRadif.Text),
                    DAddress = string.IsNullOrEmpty(TxtAddress.Text) ? null : TxtAddress.Text,
                    DPostalCode = string.IsNullOrEmpty(TxtPostalCode.Text) ? null : TxtPostalCode.Text,
                    DVoteNum = string.IsNullOrEmpty(TxtVoteNum.Text) ? null : TxtVoteNum.Text,
                    DInArchives = CheckBox.IsChecked,
                    DSeparation = null,
                    DAggregation = null,
                    DDateInsert = string.IsNullOrEmpty(TxtDate.Text) ? null : Utility.CurrectDate(TxtDate.Text),
                    DDescription = string.IsNullOrEmpty(TxtDescription.Text) ? null : TxtDescription.Text
                };
                fileId = Convert.ToInt32(await addFile.Add());
                _fileAllData = null;
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در ثبت اطلاعات\n" + exception.Message);
            }

            try
            {
                var addFilePerson = new DFilePerson();
                foreach (var variable in _createPersons)
                {
                    addFilePerson.DFileId = fileId;
                    addFilePerson.DPersonId = variable.Id;
                    await Task.Run(() => addFilePerson.Add());
                }
                var addFilePlaque = new DFilePlaque();
                foreach (var variable in _createPlaque)
                {
                    addFilePlaque.DFileId = fileId;
                    addFilePlaque.DPlaqueId = variable.Id;
                    await Task.Run(() => addFilePlaque.Add());
                }
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در ثبت اطلاعات\n" + exception.Message);
            }


            Window_Loaded(null, null);
            Utility.Message("پیام", "اطلاعات با موفقیت ثبت گردید", "Correct.png");

            #endregion
        }

        private async void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckSelectEdit() || !CheckEmpty()) return;

            var selectItem = _fileSearchAllData[DgdFile.SelectedIndex];
            try
            {
                if (selectItem.Id != null)
                {
                    var editFile = new DFile
                    {
                        DId = (int) selectItem.Id,
                        DMainId = MainId,
                        DMarlik = int.Parse(TxtMarlik.Text),
                        DFileTypeId = CboFileType.SelectedIndex == -1 ? (byte?)null : ((tblFileType)CboFileType.SelectedItem).Id,
                        DViolationId = CboViolation.SelectedIndex == -1 ? (byte?)null : ((tblViolation)CboViolation.SelectedItem).Id,
                        DFileNum = string.IsNullOrEmpty(TxtFileNum.Text) ? (int?)null : int.Parse(TxtFileNum.Text),
                        DFileYear = string.IsNullOrEmpty(TxtFileYear.Text) ? (byte?)null : byte.Parse(TxtFileYear.Text),
                        DPermitNum = string.IsNullOrEmpty(TxtPermitNum.Text) ? (int?)null : int.Parse(TxtPermitNum.Text),
                        DPermitYear = string.IsNullOrEmpty(TxtPermitYear.Text) ? (byte?)null : byte.Parse(TxtPermitYear.Text),
                        DMantaghe = string.IsNullOrEmpty(TxtMantaghe.Text) ? (int?)null : int.Parse(TxtMantaghe.Text),
                        DNahie = string.IsNullOrEmpty(TxtNahie.Text) ? (int?)null : int.Parse(TxtNahie.Text),
                        DMahaleh = string.IsNullOrEmpty(TxtMahaleh.Text) ? (int?)null : int.Parse(TxtMahaleh.Text),
                        DBlock = string.IsNullOrEmpty(TxtBlock.Text) ? (int?)null : int.Parse(TxtBlock.Text),
                        DMelk = string.IsNullOrEmpty(TxtMelk.Text) ? (int?)null : int.Parse(TxtMelk.Text),
                        DRadif = string.IsNullOrEmpty(TxtRadif.Text) ? (int?)null : int.Parse(TxtRadif.Text),
                        DAddress = string.IsNullOrEmpty(TxtAddress.Text) ? null : TxtAddress.Text,
                        DPostalCode = string.IsNullOrEmpty(TxtPostalCode.Text) ? null : TxtPostalCode.Text,
                        DVoteNum = string.IsNullOrEmpty(TxtVoteNum.Text) ? null : TxtVoteNum.Text,
                        DInArchives = CheckBox.IsChecked,
                        DSeparation = selectItem.Separation,
                        DAggregation = selectItem.Aggregation,
                        DDateInsert = string.IsNullOrEmpty(TxtDate.Text) ? PersianDate.Today.ToString() : Utility.CurrectDate(TxtDate.Text),
                        DDescription = string.IsNullOrEmpty(TxtDescription.Text) ? null : TxtDescription.Text
                    };
                    await Task.Run(() => editFile.Edit());
                }
                _fileAllData = null;
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در ویرایش اطلاعات پزشک\n" + exception.Message);
                return;
            }
            try
            {
                if (selectItem.Id != null)
                {
                    var deleteFilePerson = new DFilePerson
                    {
                        DFileId = (int) selectItem.Id
                    };
                    await Task.Run(() => deleteFilePerson.Delete());


                    var deleteFilePlaque = new DFilePlaque
                    {
                        DFileId = (int) selectItem.Id
                    };
                    await Task.Run(() => deleteFilePlaque.Delete());
                }
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در حذف اطلاعات\n" + exception.Message);
            }
            try
            {
                var addFilePerson = new DFilePerson();
                foreach (var variable in _createPersons)
                {
                    if (selectItem.Id != null) addFilePerson.DFileId = (int) selectItem.Id;
                    addFilePerson.DPersonId = variable.Id;
                    await Task.Run(() => addFilePerson.Add());
                }
                var addFilePlaque = new DFilePlaque();
                foreach (var variable in _createPlaque)
                {
                    if (selectItem.Id != null) addFilePlaque.DFileId = (int) selectItem.Id;
                    addFilePlaque.DPlaqueId = variable.Id;
                    await Task.Run(() => addFilePlaque.Add());
                }
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در ثبت اطلاعات\n" + exception.Message);
            }

            Window_Loaded(null, null);
            Utility.Message("پیام", "اطلاعات با موفقیت ویرایش گردید", "Correct.png");
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckSelectDelete()) return;
            var selectItem = _fileSearchAllData[DgdFile.SelectedIndex];
            if (!CanDelete(selectItem.Id))return;
            Utility.MyMessageBox("هشدار", "آیا از حذف اطمینان دارید؟ ", "Warning.png", false);
            if (!Utility.YesNo) return;
            try
            {
                if (selectItem.Id != null)
                {
                    var deleteFile = new DFile
                    {
                        DId = (int) selectItem.Id
                    };
                    await Task.Run(() => deleteFile.Delete());
                }
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در حذف اطلاعات\n" + exception.Message);
                return;
            }

            try
            {
                if (selectItem.Id != null)
                {
                    var deleteFilePerson = new DFilePerson
                    {
                        DFileId = (int) selectItem.Id
                    };
                    await Task.Run(() => deleteFilePerson.Delete());


                    var deleteFilePlaque = new DFilePlaque
                    {
                        DFileId = (int) selectItem.Id
                    };
                    await Task.Run(() => deleteFilePlaque.Delete());
                }
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در حذف اطلاعات\n" + exception.Message);
            }

            Window_Loaded(null, null);
            Utility.Message("پیام", "اطلاعات با موفقیت حذف گردید", "Correct.png");
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            TxtSearch.Focus();
            TxtFileNum.Text = TxtFileYear.Text = TxtPermitNum.Text = TxtPermitYear.Text = TxtMarlik.Text =
                TxtVoteNum.Text = TxtMantaghe.Text = TxtNahie.Text = TxtMahaleh.Text = TxtBlock.Text =
                    TxtMelk.Text = TxtRadif.Text = TxtPostalCode.Text =
                        TxtAddress.Text = TxtDescription.Text = TxtSearch.Text = string.Empty;
            TxtDate.Text = PersianDate.Today.ToString();

            LblMarlik.Content = null;

            DgdPerson.ItemsSource = null;
            DgdPlaque.ItemsSource = null;

            _createPersons = null;
            _createPlaque = null;

            PersonId = null;
            PersonName = null;
            PersonFamily = null;
            PersonFather = null;
            PersonCode = null;

            PlaqueId = null;
            PlaqueMain = null;
            PlaqueSecondary = null;
            PlaquePart = null;
            PlaqueDescription = null;

            _createPersons = new List<CreatePerson>();
            _createPlaque = new List<CreatePlaque>();

            PersonId = new List<int>();
            PersonName = new List<string>();
            PersonFamily = new List<string>();
            PersonFather = new List<string>();
            PersonCode = new List<string>();

            PlaqueId = new List<int>();
            PlaqueMain = new List<int?>();
            PlaqueSecondary = new List<int?>();
            PlaquePart = new List<int?>();
            PlaqueDescription = new List<string>();

            DgdPerson.SelectedIndex = DgdPlaque.SelectedIndex = DgdFile.SelectedIndex = -1;

            CboFileType.SelectedIndex = CboViolation.SelectedIndex = -1;
            _searchLength = 0;

            BtnAdd.IsEnabled = true;
        }

        private void BtnSelectPerson_Click(object sender, RoutedEventArgs e)
        {
            var winPersonSearch = new WinPersonSearch();
            winPersonSearch.ShowDialog();
            if (winPersonSearch.PersonId == 0) return;

            if (PersonId.Contains(winPersonSearch.PersonId))
            {
                Utility.Message("خطا", "این شخص یک‌بار انتخاب شده است", "Stop.png");
                return;
            }
            PersonId.Add(winPersonSearch.PersonId); 
            PersonName.Add(winPersonSearch.PersonName);
            PersonFamily.Add(winPersonSearch.PersonFamily);
            PersonFather.Add(winPersonSearch.PersonFather);
            PersonCode.Add(winPersonSearch.PersonCode);
            _createPersons = new List<CreatePerson>();
            for (var i = 0; i < PersonId.Count; i++)
            {
                _createPersons.Add(new CreatePerson(PersonId[i], PersonName[i], PersonFamily[i], PersonFather[i],
                    PersonCode[i]));
            }
            DgdPerson.ItemsSource = _createPersons;
        }

        private void BtnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            if (DgdPerson.SelectedIndex == -1) return;
            PersonId.RemoveAt(DgdPerson.SelectedIndex);
            PersonName.RemoveAt(DgdPerson.SelectedIndex);
            PersonFamily.RemoveAt(DgdPerson.SelectedIndex);
            PersonFather.RemoveAt(DgdPerson.SelectedIndex);
            PersonCode.RemoveAt(DgdPerson.SelectedIndex);
            _createPersons = new List<CreatePerson>();
            for (var i = 0; i < PersonId.Count; i++)
            {
                _createPersons.Add(new CreatePerson(PersonId[i], PersonName[i], PersonFamily[i], PersonFather[i],
                    PersonCode[i]));
            }
            DgdPerson.ItemsSource = _createPersons;
        }

        private void BtnSelectPlaque_Click(object sender, RoutedEventArgs e)
        {
            var winPlaqueSearch = new WinPlaqueSearch();
            winPlaqueSearch.ShowDialog();
            if (winPlaqueSearch.PlaqueId == 0) return;

            if (PlaqueId.Contains(winPlaqueSearch.PlaqueId))
            {
                Utility.Message("خطا", "این پلاک یک‌بار انتخاب شده است", "Stop.png");
                return;
            }
            PlaqueId.Add(winPlaqueSearch.PlaqueId);
            PlaqueMain.Add(winPlaqueSearch.PlaqueMain);
            PlaqueSecondary.Add(winPlaqueSearch.PlaqueSecondary);
            PlaquePart.Add(winPlaqueSearch.PlaquePart);
            PlaqueDescription.Add(winPlaqueSearch.PlaqueDescription);

            _createPlaque = new List<CreatePlaque>();
            for (var i = 0; i < PlaqueId.Count; i++)
            {
                _createPlaque.Add(new CreatePlaque(PlaqueId[i], PlaqueMain[i], PlaqueSecondary[i], PlaquePart[i], PlaqueDescription[i]));
            }
            DgdPlaque.ItemsSource = _createPlaque;
        }

        private void BtnDeletePlaque_Click(object sender, RoutedEventArgs e)
        {
            if (DgdPlaque.SelectedIndex == -1) return;
            _createPlaque.RemoveAt(DgdPlaque.SelectedIndex);
            PlaqueId.RemoveAt(DgdPlaque.SelectedIndex);
            PlaqueMain.RemoveAt(DgdPlaque.SelectedIndex);
            PlaqueSecondary.RemoveAt(DgdPlaque.SelectedIndex);
            PlaquePart.RemoveAt(DgdPlaque.SelectedIndex);
            PlaqueDescription.RemoveAt(DgdPlaque.SelectedIndex);

            _createPlaque = new List<CreatePlaque>();
            for (var i = 0; i < PlaqueId.Count; i++)
            {
                _createPlaque.Add(new CreatePlaque(PersonId[i], PlaqueMain[i], PlaqueSecondary[i], PlaquePart[i], PlaqueDescription[i]));
            }
            DgdPlaque.ItemsSource = _createPlaque;
        }

        private async void BtnSelectFileType_Click(object sender, RoutedEventArgs e)
        {
            var winFileType = new WinFileType();
            winFileType.ShowDialog();
            try
            {
                _fileTypeData = await DFileType.GetData();
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در دریافت اطلاعات\n" + exception.Message);
                Close();
                return;
            }
            CboFileType.ItemsSource = _fileTypeData;
        }

        private async void BtnSelectViolation_Click(object sender, RoutedEventArgs e)
        {
            var winViolation = new WinViolation();
            winViolation.ShowDialog();
            try
            {
                _violationData = await DViolation.GetData();
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در دریافت اطلاعات\n" + exception.Message);
                Close();
                return;
            }
            CboViolation.ItemsSource = _violationData;
        }

        private void BtnSelectMainFile_Click(object sender, RoutedEventArgs e)
        {
            var winFileSearch = new WinFileSearch();
            winFileSearch.ShowDialog();
            if (winFileSearch.FileId == null || winFileSearch.FileId == 0 ) return;
            MainId = winFileSearch.FileId;
            LblMarlik.Content = winFileSearch.Marlik;
        }

        private async void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = TxtSearch.Text;

            if (_searchLength > search.Length || string.IsNullOrEmpty(search))
            {
                _fileSearchAllData = _fileAllData;
                //_fileSearchData = _fileData;
            }
            
            if (!string.IsNullOrEmpty(search))
            {
                _fileSearchAllData = await Task.Run(() => _fileSearchAllData.FindAll(t =>
                    !string.IsNullOrEmpty(t.FullName) && t.FullName.Contains(search) ||
                    !string.IsNullOrEmpty(t.FatherName) && t.FatherName.Contains(search) ||
                    !string.IsNullOrEmpty(t.Code) && t.Code.Contains(search) ||
                    !string.IsNullOrEmpty(t.Birthday) && t.Birthday.Contains(search) ||
                    !string.IsNullOrEmpty(t.PersonDescription) && t.PersonDescription.Contains(search) ||
                    !string.IsNullOrEmpty(t.FileType) && t.FileType.Contains(search) ||
                    !string.IsNullOrEmpty(t.Violation) && t.Violation.Contains(search) ||
                    !string.IsNullOrEmpty(t.PlaqueNum) && t.PlaqueNum.Contains(search) ||
                    !string.IsNullOrEmpty(t.PlaqueDescription) && t.PlaqueDescription.Contains(search) ||
                    !string.IsNullOrEmpty(t.Mobile) && t.Mobile.Contains(search) ||
                    !string.IsNullOrEmpty(t.Marlik.ToString()) && t.Marlik.ToString().Contains(search) ||
                    !string.IsNullOrEmpty(t.FileNumber) && t.FileNumber.Contains(search) ||
                    !string.IsNullOrEmpty(t.Reconstruction) && t.Reconstruction .Contains(search) ||
                    !string.IsNullOrEmpty(t.PermitNumber) && t.PermitNumber.Contains(search) ||
                    !string.IsNullOrEmpty(t.Address) && t.Address.Contains(search) ||
                    !string.IsNullOrEmpty(t.VoteNum) && t.VoteNum.Contains(search) ||
                    !string.IsNullOrEmpty(t.PostalCode) && t.PostalCode.Contains(search) ||
                    !string.IsNullOrEmpty(t.DateInsert) && t.DateInsert.Contains(search) ||
                    !string.IsNullOrEmpty(t.FileDescription) && t.FileDescription.Contains(search)));

                //var s = _fileSearchAllData.Select(variable => variable.Id).ToList();
                //_fileSearchData = _fileSearchData.FindAll(r => s.Contains(r.Id));

            }
            _searchLength = search.Length;
            DgdFile.ItemsSource = _fileSearchAllData;
        }

        private async void DgdFile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgdFile.SelectedIndex == -1) return;

            BtnAdd.IsEnabled = false;

            DgdPerson.ItemsSource = null;
            _createPersons = null;
            _createPlaque = null;
            PersonId = null;
            PlaqueId = null;
            PersonName = null;
            PersonFamily = null;
            PersonFather = null;
            PersonCode = null;
            PlaqueDescription = null;
            PlaqueMain = null;
            PlaqueSecondary = null;
            PlaquePart = null;

            _createPersons = new List<CreatePerson>();
            _createPlaque = new List<CreatePlaque>();

            PersonId = new List<int>();
            PlaqueId = new List<int>();

            PersonName = new List<string>();
            PersonFamily = new List<string>();
            PersonFather = new List<string>();
            PersonCode = new List<string>();
            PlaqueDescription = new List<string>();

            PlaqueMain = new List<int?>();
            PlaqueSecondary = new List<int?>();
            PlaquePart = new List<int?>();

            var selectItem = _fileSearchAllData[DgdFile.SelectedIndex];

            CboFileType.SelectedValue = selectItem.FileType_Id;
            CboViolation.SelectedValue = selectItem.Violation_Id;

            TxtFileNum.Text = selectItem.FileNum.ToString();
            TxtFileYear.Text = selectItem.FileYear.ToString();
            TxtPermitNum.Text = selectItem.PermitNum.ToString();
            TxtPermitYear.Text = selectItem.PermitYear.ToString();
            TxtMarlik.Text = selectItem.Marlik.ToString();
            TxtVoteNum.Text = selectItem.VoteNum;
            TxtMantaghe.Text = selectItem.Mantaghe.ToString();
            TxtNahie.Text = selectItem.Nahie.ToString();
            TxtMahaleh.Text = selectItem.Mahaleh.ToString();
            TxtBlock.Text = selectItem.Block.ToString();
            TxtMelk.Text = selectItem.Melk.ToString();
            TxtRadif.Text = selectItem.Radif.ToString();
            TxtPostalCode.Text = selectItem.PostalCode;
            TxtAddress.Text = selectItem.Address;
            TxtDescription.Text = selectItem.FileDescription;
            TxtDate.Text = selectItem.DateInsert;
            CheckBox.IsChecked = selectItem.InArchives ?? true;
            if (selectItem.MainId != null)
            {
                LblMarlik.Content = (await Task.Run(() => _fileAllData.FirstOrDefault(t => t.MainId == selectItem.MainId))).Marlik.ToString();
            }

            var selectPersonData = _creatPersonData.Where(x => x.File_Id == selectItem.Id);
            var selectPlaqueData = _creatPlaqueData.Where(x => x.File_Id == selectItem.Id);

            foreach (var t in selectPersonData)
            {
                PersonId.Add(t.Person_Id);
                PersonName.Add(t.Name);
                PersonFamily.Add(t.Family);
                PersonFather.Add(t.FatherName);
                PersonCode.Add(t.Code); 
            }
            _createPersons = new List<CreatePerson>();
            for (var i = 0; i < PersonId.Count; i++)
            {
                _createPersons.Add(new CreatePerson(PersonId[i], PersonName[i], PersonFamily[i], PersonFather[i],
                    PersonCode[i]));
            }
            DgdPerson.ItemsSource = _createPersons;

            foreach (var t in selectPlaqueData)
            {
                PlaqueId.Add(t.Id);
                PlaqueMain.Add(t.Main);
                PlaqueSecondary.Add(t.Secondary);
                PlaquePart.Add(t.Part);
                PlaqueDescription.Add(t.Description);
            }
            for (var i = 0; i < PlaqueId.Count; i++)
            {
                _createPlaque.Add(new CreatePlaque(PlaqueId[i], PlaqueMain[i],PlaqueSecondary[i], PlaquePart[i], PlaqueDescription[i]));
            }
            DgdPlaque.ItemsSource = _createPlaque;
        }

        #endregion

        #region FixedEvent

        private void DragMove(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void NumberInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DisablePaste(object sender, ExecutedRoutedEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = e.Command == ApplicationCommands.Paste && regex.IsMatch(Clipboard.GetText());
        }

        private void DateInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"[^0-9^\/]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DisablePasteDate(object sender, ExecutedRoutedEventArgs e)
        {
            var regex = new Regex(@"[^0-9^\/]+");
            e.Handled = e.Command == ApplicationCommands.Paste && regex.IsMatch(Clipboard.GetText());
        }
        //baraye shomare gozari datagrid
        private void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
            e.Row.Foreground = _fileSearchAllData[e.Row.GetIndex()].InArchives == false ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Black);
        }
        #endregion

        #region Method


        private bool CheckSelectDelete()
        {
            if (DgdFile.SelectedIndex != -1) return true;
            Utility.Message("اخطار", "موردی را برای حذف انتخاب کنید", "Warning.png");
            return false;
        }
        private bool CanDelete(int? selectItemId)
        {
            if (_fileAllData.FirstOrDefault(x => x.MainId == selectItemId) != null)
            {
                Utility.Message("اخطار", "بخاطر این که این پرونده مادر پرونده دیگریست قادر به حذف آن نیستید", "Warning.png");
                return false;
            }
            return true;
        }
        private bool CheckSelectEdit()
        {
            if (DgdFile.SelectedIndex == -1)
            {
                Utility.Message("اخطار", "موردی را برای ویرایش انتخاب کنید", "Warning.png");
                return false;
            }
            return true;
        }

        private bool CheckEmpty()
        {
            if (_createPersons.Count == 0)
            {
                Utility.Message("خطا", "لطفا حداقل یک مالک انتخاب کنید", "Stop.png");
                return false;
            }
            if (_createPlaque.Count == 0)
            {
                Utility.Message("خطا", "لطفا حداقل یک پلاک ثبتی انتخاب کنید", "Stop.png");
                return false;
            }
            if (string.IsNullOrEmpty(TxtFileNum.Text) || string.IsNullOrEmpty(TxtFileYear.Text))
            {
                Utility.Message("خطا", "لطفا یک شماره کلاسه صحیح وارد کنید", "Stop.png");
                return false;
            }
            if (string.IsNullOrEmpty(TxtPermitNum.Text) || string.IsNullOrEmpty(TxtPermitYear.Text))
            {
                Utility.Message("خطا", "لطفا یک شماره پروانه صحیح وارد کنید", "Stop.png");
                return false;
            }
            if (string.IsNullOrEmpty(TxtMarlik.Text))
            {
                Utility.Message("خطا", "لطفا شماره مارلیک را وارد کنید", "Stop.png");
                return false;
            }

            
            return true;
        }

        #endregion
    }
}
