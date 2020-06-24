using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DAL;
using DAL.Class;
using MunicipalArchive.Class;

namespace MunicipalArchive.Windows
{
    /// <summary>
    /// Interaction logic for WinAccount.xaml
    /// </summary>
    public partial class WinPersonSearch
    {
        private List<tblPerson> _personData;
        private List<tblPerson> _personSearchData;
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonFamily { get; set; }
        public string PersonFather { get; set; }
        public string PersonCode { get; set; }
        public WinPersonSearch()
        {
            InitializeComponent();
            _personData = new List<tblPerson>();
            _personSearchData = new List<tblPerson>();
        }

        #region Event

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _personData = await DPerson.GetData();
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در دریافت اطلاعات\n" + exception.Message);
                Close();
                return;
            }
            _personSearchData = _personData;
            DgdPerson.ItemsSource = _personSearchData;
        }

        private async void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            var winPerson = new WinPerson();
            winPerson.ShowDialog();
            try
            {
                _personData = await DPerson.GetData();
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در دریافت اطلاعات\n" + exception.Message);
                Close();
                return;
            }
            _personSearchData = _personData;
            DgdPerson.ItemsSource = _personSearchData;
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckSelect()) return;
            PersonId = _personSearchData[DgdPerson.SelectedIndex].Id;
            PersonName = _personSearchData[DgdPerson.SelectedIndex].Name;
            PersonFamily = _personSearchData[DgdPerson.SelectedIndex].Family;
            PersonFather = _personSearchData[DgdPerson.SelectedIndex].FatherName;
            PersonCode = _personSearchData[DgdPerson.SelectedIndex].Code;
            Close();
        }

        private void DgdPerson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgdPerson.SelectedIndex == -1) return;

            var selectItem = _personSearchData[DgdPerson.SelectedIndex];
            LblName.Content = selectItem.Name;
            LblFamily.Content = selectItem.Family;
            LblCode.Content = selectItem.Code;
            LblMobile.Content = selectItem.Mobile;
        }

        private async void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LblName.Content = LblFamily.Content = LblCode.Content = LblMobile.Content = string.Empty;

            var search = TxtSearch.Text;
            _personSearchData = _personData;
            _personSearchData = await Task.Run(() => _personSearchData.FindAll(t =>
                !string.IsNullOrEmpty(t.Name) && t.Name.Contains(search) ||
                !string.IsNullOrEmpty(t.Family) && t.Family.Contains(search) ||
                !string.IsNullOrEmpty(t.FatherName) && t.FatherName.Contains(search) ||
                !string.IsNullOrEmpty(t.Code) && t.Code.Contains(search) ||
                !string.IsNullOrEmpty(t.Mobile) && t.Mobile.Contains(search) ||
                !string.IsNullOrEmpty(t.Birthday) && t.Birthday.Contains(search) ||
                !string.IsNullOrEmpty(t.Description) && t.Description.Contains(search)));

            DgdPerson.ItemsSource = _personSearchData;
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
        }

        #endregion

        #region Method

        private bool CheckSelect()
        {
            if (DgdPerson.SelectedIndex == -1)
            {
                Utility.Message("خطا", "شخصی را انتخاب کنید", "Stop.png");
                return false;
            }

            return true;
        }

        #endregion


    }
}

