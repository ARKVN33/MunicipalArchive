using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using DAL;
using DAL.Class;
using MunicipalArchive.Class;

namespace MunicipalArchive.Windows
{
    /// <summary>
    /// Interaction logic for WinAccount.xaml
    /// </summary>
    public partial class WinFileSearch
    {
        private List<viewAll> _fileAllData;
        private List<viewAll> _fileSearchAllData;

        private List<viewFilePerson> _creatPersonData;
        private List<viewFilePlaque> _creatPlaqueData;

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

        public int? FileId { get; set; }
        public int? Marlik { get; set; }
        private int _searchLength;

        public WinFileSearch()
        {
            InitializeComponent();
            _fileAllData = new List<viewAll>();
            _fileSearchAllData = new List<viewAll>();

            _creatPersonData = new List<viewFilePerson>();
            _creatPlaqueData = new List<viewFilePlaque>();

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
                _fileAllData = await DFile.GetAllData();
                _creatPersonData = await DPerson.GetCreate();
                _creatPlaqueData = await DPlaque.GetCreate();
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در دریافت اطلاعات\n" + exception.Message);
                Close();
                return;
            }
            _fileSearchAllData = _fileAllData;
            DgdFile.ItemsSource = _fileSearchAllData;
            FileId = 0;
            New();
        }

        private void New()
        {
            TxtSearch.Focus();
            LblVoteNum.Content = LblMarlik.Content = LblFileType.Content = LblViolation.Content =
                LblDate.Content = LblPostalCode.Content = TxtSearch.Text = string.Empty;
            
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

            _searchLength = 0;
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckSelect()) return;
            FileId = _fileSearchAllData[DgdFile.SelectedIndex].Id;
            Marlik = _fileSearchAllData[DgdFile.SelectedIndex].Marlik;

            Close();
        }
        private async void DgdFile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgdFile.SelectedIndex == -1) return;

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

            LblFileType.Content = selectItem.FileType;
            LblViolation.Content = selectItem.Violation;
            LblVoteNum.Content = selectItem.VoteNum;
            LblPostalCode.Content = selectItem.PostalCode;
            LblDate.Content = selectItem.DateInsert;
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
                _createPlaque.Add(new CreatePlaque(PlaqueId[i], PlaqueMain[i], PlaqueSecondary[i], PlaquePart[i], PlaqueDescription[i]));
            }
            DgdPlaque.ItemsSource = _createPlaque;
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
                    !string.IsNullOrEmpty(t.Reconstruction) && t.Reconstruction.Contains(search) ||
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

        //baraye shomare gozari datagrid
        private void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
            e.Row.Foreground = _fileSearchAllData[e.Row.GetIndex()].InArchives == false ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Black);
        }
        #endregion

        #region Method

        private bool CheckSelect()
        {
            if (DgdFile.SelectedIndex == -1)
            {
                Utility.Message("خطا", "شخصی را انتخاب کنید", "Stop.png");
                return false;
            }

            return true;
        }

        #endregion
    }
}

