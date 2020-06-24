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
    public partial class WinPlaqueSearch
    {
        private List<tblPlaque> _plaqueData;
        private List<tblPlaque> _plaqueSearchData;
        public int PlaqueId { get; set; }
        public int? PlaqueMain { get; set; }
        public int? PlaqueSecondary { get; set; }
        public int? PlaquePart { get; set; }
        public string PlaqueDescription { get; set; }
        public WinPlaqueSearch()
        {
            InitializeComponent();
            _plaqueData = new List<tblPlaque>();
            _plaqueSearchData = new List<tblPlaque>();
        }

        #region Event

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _plaqueData = await DPlaque.GetData();
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در دریافت اطلاعات\n" + exception.Message);
                Close();
                return;
            }
            _plaqueSearchData = _plaqueData;
            DgdPlaque.ItemsSource = _plaqueSearchData;
        }

        private async void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            var winPlaque = new WinPlaque();
            winPlaque.ShowDialog();
            try
            {
                _plaqueData = await DPlaque.GetData();
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در دریافت اطلاعات\n" + exception.Message);
                Close();
                return;
            }
            _plaqueSearchData = _plaqueData;
            DgdPlaque.ItemsSource = _plaqueSearchData;
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckSelect()) return;
            PlaqueId = _plaqueSearchData[DgdPlaque.SelectedIndex].Id;
            PlaqueMain = _plaqueSearchData[DgdPlaque.SelectedIndex].Main;
            PlaqueSecondary = _plaqueSearchData[DgdPlaque.SelectedIndex].Secondary;
            PlaquePart = _plaqueSearchData[DgdPlaque.SelectedIndex].Part;
            PlaqueDescription = _plaqueSearchData[DgdPlaque.SelectedIndex].Description;
            Close();
        }

        private void DgdPlaque_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private async void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = TxtSearch.Text;
            _plaqueSearchData = _plaqueData;
            _plaqueSearchData =
                await Task.Run(() => _plaqueSearchData.FindAll(
                    t => !string.IsNullOrEmpty(t.Main.ToString() + t.Secondary.ToString() + t.Part.ToString()) &&
                         (t.Main.ToString() + t.Secondary.ToString() + t.Part.ToString()).Contains(search) ||
                         !string.IsNullOrEmpty(t.Description) && t.Description.Contains(search)));

            DgdPlaque.ItemsSource = _plaqueSearchData;
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

        #endregion

        #region Method

        private bool CheckSelect()
        {
            if (DgdPlaque.SelectedIndex == -1)
            {
                Utility.Message("خطا", "موردی را انتخاب کنید", "Stop.png");
                return false;
            }

            return true;
        }

        #endregion


    }
}

