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
    /// Interaction logic for WinPlaque.xaml
    /// </summary>
    public partial class WinPlaque
    {
        private List<tblPlaque> _plaqueData;
        private List<tblPlaque> _plaqueSearchData;

        private bool _add = true;
        public int Counter;
        public WinPlaque()
        {
            InitializeComponent();
            _plaqueData = new List<tblPlaque>();
            _plaqueSearchData = new List<tblPlaque>();
        }



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
            if (string.IsNullOrEmpty(TxtSearch.Text.Trim()) || _add)
            {
                DgdData.ItemsSource = _plaqueSearchData;
                TxtSearch.Text = string.Empty;
            }
            else
            {
                TxtSearch_TextChanged(null, null);
            }
            DgdData.ItemsSource = _plaqueSearchData;

            BtnNew_Click(null, null);
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckEmpty()) return;

            #region AddPlaque

            try
            {
                var addPlaque = new DPlaque
                {
                    DMain = string.IsNullOrEmpty(TxtMain.Text) ? (int?)null : int.Parse(TxtMain.Text),
                    DSecondary = string.IsNullOrEmpty(TxtSecondary.Text) ? (int?)null : int.Parse(TxtSecondary.Text),
                    DPart = string.IsNullOrEmpty(TxtPart.Text) ? (int?)null : int.Parse(TxtPart.Text),
                    DDescription = string.IsNullOrEmpty(TxtDescription.Text) ? null : TxtDescription.Text
                };
                await Task.Run(() => addPlaque.Add());
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در ثبت اطلاعات\n" + exception.Message);
            }
            Window_Loaded(null, null);
            Utility.Message("پیام", "اطلاعات با موفقیت ثبت گردید", "Correct.png");

            #endregion
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            TxtSearch.Focus();

            TxtMain.Text = string.Empty;
            TxtSecondary.Text = string.Empty;
            TxtPart.Text = string.Empty;
            TxtDescription.Text = string.Empty;
            BtnAdd.IsEnabled = true;
            DgdData.SelectedIndex = -1;
            Counter = 1;
            _add = true;
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

            DgdData.ItemsSource = _plaqueSearchData;
        }

        private void DgdPlaque_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgdData.SelectedIndex == -1) return;

            BtnAdd.IsEnabled = false;
            var selectItem = _plaqueSearchData[DgdData.SelectedIndex];
            TxtMain.Text = selectItem.Main.ToString();
            TxtSecondary.Text = selectItem.Secondary.ToString();
            TxtPart.Text = selectItem.Part.ToString();
            TxtDescription.Text = selectItem.Description;
        }

        private async void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckSelectEdit() || !CheckEmpty()) return;
            var selectItem = _plaqueSearchData[DgdData.SelectedIndex];
            try
            {
                var editPlaque = new DPlaque
                {
                    DId = selectItem.Id,
                    DMain = string.IsNullOrEmpty(TxtMain.Text) ? (int?)null : int.Parse(TxtMain.Text),
                    DSecondary = string.IsNullOrEmpty(TxtSecondary.Text) ? (int?)null : int.Parse(TxtSecondary.Text),
                    DPart = string.IsNullOrEmpty(TxtPart.Text) ? (int?)null : int.Parse(TxtPart.Text),
                    DDescription = string.IsNullOrEmpty(TxtDescription.Text) ? null : TxtDescription.Text
                };
                await Task.Run(() => editPlaque.Edit());
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در ویرایش اطلاعات\n" + exception.Message);
                return;
            }
            Window_Loaded(null, null);
            Utility.Message("پیام", "اطلاعات با موفقیت ویرایش گردید", "Correct.png");
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckSelectDelete()) return;
            var selectItem = _plaqueSearchData[DgdData.SelectedIndex];
            if (!await CheckCanDelete(selectItem.Id)) return;
            Utility.MyMessageBox("هشدار", "آیا از حذف اطمینان دارید؟ ", "Warning.png", false);
            if (!Utility.YesNo) return;
            try
            {
                var deletePlaque = new DPlaque
                {
                    DId = selectItem.Id
                };
                await Task.Run(() => deletePlaque.Delete());
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در حذف اطلاعات\n" + exception.Message);
                return;
            }
            Window_Loaded(null, null);
            Utility.Message("پیام", "اطلاعات با موفقیت حذف گردید", "Correct.png");
        }



        #region Method

        private bool CheckSelectDelete()
        {
            if (DgdData.SelectedIndex == -1)
            {
                Utility.Message("اخطار", "موردی را برای حذف انتخاب کنید", "Warning.png");
                return false;
            }
            return true;
        }

        private bool CheckSelectEdit()
        {
            if (DgdData.SelectedIndex == -1)
            {
                Utility.Message("اخطار", "موردی را برای ویرایش انتخاب کنید", "Warning.png");
                return false;
            }
            return true;
        }

        private bool CheckEmpty()
        {
            if (TxtMain.Text.Trim() == string.Empty)
            {
                Utility.Message("خطا", "لطفا شماره اصلی را وارد کنید", "Stop.png");
                return false;
            }

            if (TxtSecondary.Text.Trim() == string.Empty)
            {
                Utility.Message("خطا", "لطفا شماره فرعی را وارد کنید", "Stop.png");
                return false;
            }

            return true;
        }
        private async Task<bool> CheckCanDelete(int plaqueId)
        {
            if (await DFilePlaque.CanDelete(plaqueId))
            {
                Utility.Message("اخطار", "به دلیل موجود بودن سوابق از این پلاک ثبتی، قادر به حذف نیستید", "Warning.png");
                return false;
            }
            return true;
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
    }
}