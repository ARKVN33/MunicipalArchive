using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DAL;
using DAL.Class;
using MunicipalArchive.Class;
using Clipboard = System.Windows.Clipboard;

namespace MunicipalArchive.Windows
{
    public partial class WinPerson
    {
        private List<tblPerson> _personData;
        private List<tblPerson> _personSearchData;

        private bool _selectDgd;
        public WinPerson()
        {
            InitializeComponent();
            _personData = new List<tblPerson>();
            _personSearchData = new List<tblPerson>();
            _selectDgd = false;
        }

        public int PersonId { get; set; }

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
            if (string.IsNullOrEmpty(TxtSearch.Text.Trim()))
            {
                DgdPerson.ItemsSource = _personSearchData;
                TxtSearch.Text = string.Empty;
            }
            else
            {
                TxtSearch_TextChanged(null, null);
            }
            BtnNew_Click(null, null);
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckEmpty() || !Utility.CheckNationalCode(TxtNationalCode.Text) || !CheckRepeatAdd()) return;

            #region AddPerson

            try
            {
                var addPerson = new DPerson
                {
                    DName = TxtFirstName.Text,
                    DFamily = TxtLastName.Text,
                    DFatherName = TxtFatherName.Text.Trim() == string.Empty ? null : TxtFatherName.Text,
                    DSex = (byte?) CboGender.SelectedIndex,
                    DCode = TxtNationalCode.Text,
                    DBirthday = TxtBirthDay.Text == string.Empty ? null : Utility.CurrectDate(TxtBirthDay.Text),
                    DMobile = TxtMobile.Text.Trim() == string.Empty ? null : TxtMobile.Text,
                    DDescription = TxtDescription.Text.Trim() == string.Empty ? null : TxtDescription.Text
                };
                await Task.Run(() => addPerson.Add());
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در ثبت اطلاعات مالک\n" + exception.Message);
                return;
            }

            #endregion

            Window_Loaded(null, null);
            Utility.Message("پیام", "مشخصات با موفقیت ثبت گردید", "Correct.png");
        }

        private async void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckSelect() || !CheckEmpty() || !Utility.CheckNationalCode(TxtNationalCode.Text)) return;

            var selectItem = _personSearchData[DgdPerson.SelectedIndex];

            if (!CheckRepeatEdit(selectItem.Code)) return;

            #region EditPerson

            try
            {
                var ediPerson = new DPerson
                {
                    DId = selectItem.Id,
                    DName = TxtFirstName.Text,
                    DFamily = TxtLastName.Text,
                    DFatherName = TxtFatherName.Text.Trim() == string.Empty ? null : TxtFatherName.Text,
                    DSex = (byte?) CboGender.SelectedIndex,
                    DCode = TxtNationalCode.Text,
                    DBirthday = TxtBirthDay.Text == string.Empty ? null : Utility.CurrectDate(TxtBirthDay.Text),
                    DMobile = TxtMobile.Text.Trim() == string.Empty ? null : TxtMobile.Text,
                    DDescription = TxtDescription.Text.Trim() == string.Empty ? null : TxtDescription.Text
                };
                await Task.Run(() => ediPerson.Edit());
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در ویرایش اطلاعات شخصی\n" + exception.Message);
                return;
            }

            #endregion

            Window_Loaded(null, null);
            Utility.Message("پیام", "مشخصات با موفقیت ویرایش گردید", "Correct.png");
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckSelect()) return;
            var selectItem = _personSearchData[DgdPerson.SelectedIndex];

            if (!await CheckCanDelete(selectItem.Id)) return;
            Utility.MyMessageBox("هشدار",
                "آیا از حذف " + TxtFirstName.Text + " " + TxtLastName.Text + " با شماره ملی " + TxtNationalCode.Text +
                " اطمینان دارید؟ ", "Warning.png", false);
            if (!Utility.YesNo) return;
            try
            {
                var deletePerson = new DPerson
                {
                    DId = selectItem.Id
                };
                await Task.Run(() => deletePerson.Delete());
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در حذف اطلاعات\n" + exception.Message);
                return;
            }
            Window_Loaded(null, null);
            Utility.Message("پیام", "اطلاعات با موفقیت حذف گردید", "Correct.png");

        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            TxtSearch.Focus();
            TxtSearch.Text = TxtFirstName.Text = TxtLastName.Text = TxtFatherName.Text = TxtNationalCode.Text =
                TxtBirthDay.Text = TxtMobile.Text = TxtDescription.Text = string.Empty;
            BtnAdd.IsEnabled = true;
            _selectDgd = false;
            DgdPerson.SelectedIndex = -1;
            CboGender.SelectedIndex = 0;
        }

        private void DgdPerson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgdPerson.SelectedIndex == -1) return;
            _selectDgd = true;
            BtnAdd.IsEnabled = false;
            var selectItem = _personSearchData[DgdPerson.SelectedIndex];
            TxtFirstName.Text = selectItem.Name;
            TxtLastName.Text = selectItem.Family;
            TxtFatherName.Text = selectItem.FatherName;
            TxtNationalCode.Text = selectItem.Code;
            if (selectItem.Sex != null) CboGender.SelectedIndex = (byte) selectItem.Sex;
            TxtBirthDay.Text = selectItem.Birthday;
            TxtMobile.Text = selectItem.Mobile;

            TxtDescription.Text = selectItem.Description;
        }

        private async void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
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

        private async void TxtNationalCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtNationalCode.Text.Length < 10 || _selectDgd) return;
            _selectDgd = false;
            var search = TxtNationalCode.Text;
            _personSearchData = _personData;
            _personSearchData = await Task.Run(() => _personSearchData.FindAll(t =>
                !string.IsNullOrEmpty(t.Name) && t.Name.Contains(search) ||
                !string.IsNullOrEmpty(t.Family) && t.Family.Contains(search) ||
                !string.IsNullOrEmpty(t.FatherName) && t.FatherName.Contains(search) ||
                !string.IsNullOrEmpty(t.Code) && t.Code.Contains(search) ||
                !string.IsNullOrEmpty(t.Mobile) && t.Mobile.Contains(search) ||
                !string.IsNullOrEmpty(t.Birthday) && t.Birthday.Contains(search) ||
                !string.IsNullOrEmpty(t.Description) && t.Description.Contains(search)));
            var count = _personSearchData.Count;
            _personSearchData = _personData;
            if (count == 0) return;

            Utility.MyMessageBox("هشدار",
                "اطلاعات " + TxtFirstName.Text + " " + TxtLastName.Text + " با شماره ملی " + TxtNationalCode.Text +
                "در سیستم موجود می‌باشد\n آیا مایل به ویرایش اطلاعات ایشان هستید؟", "Warning.png", false);

            if (!Utility.YesNo) return;
            DgdPerson.ItemsSource = _personSearchData;
            DgdPerson.SelectedIndex = 0;
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

        private void DateInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"[^0-9^\/]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DisablePaste(object sender, ExecutedRoutedEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = e.Command == ApplicationCommands.Paste && regex.IsMatch(Clipboard.GetText());
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
        }

        #endregion

        #region Method

        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(TxtFirstName.Text.Trim()))
            {
                Utility.Message("خطا", "لطفا نام را وارد کنید", "Stop.png");
                return false;
            }

            if (string.IsNullOrEmpty(TxtLastName.Text.Trim()))
            {
                Utility.Message("خطا", "لطفا نام خانوادگی را وارد کنید", "Stop.png");
                return false;
            }

            if (TxtNationalCode.Text.Trim() == string.Empty)
            {
                Utility.Message("خطا", "لطفا کد ملی را وارد کنید", "Stop.png");
                return false;
            }

            if (!string.IsNullOrEmpty(TxtBirthDay.Text) && !Utility.CheckDate(TxtBirthDay.Text))
            {
                Utility.Message("خطا", "لطفا یک تاریخ صحیح برای تاریخ تولد انتخاب کنید", "Stop.png");
                return false;
            }
            return true;
        }

        private bool CheckRepeatAdd()
        {
            if (_personData.Any(t => t.Code == TxtNationalCode.Text))
            {
                Utility.Message("اخطار", "شخصی با این کد ملی قبلا ثبت گردیده است", "Warning.png");
                return false;
            }

            _personSearchData = _personData.FindAll(t =>
                t.Name == TxtFirstName.Text && t.Family == TxtLastName.Text && t.FatherName == TxtFatherName.Text);

            if (_personSearchData.Count > 0)
            {
                Utility.MyMessageBox("هشدار",
                    "اطلاعات " + TxtFirstName.Text + " " + TxtLastName.Text + " با نام پدر " + TxtFatherName.Text +
                    "در سیستم موجود می‌باشد\n آیا مایل به ویرایش اطلاعات ایشان هستید؟", "Warning.png", false);
                if (!Utility.YesNo) return true;
                DgdPerson.ItemsSource = _personSearchData;
                DgdPerson.SelectedIndex = 0;
                return false;
            }
            return true;

        }
        private bool CheckRepeatEdit(string nationalCode)
        {
            if (TxtNationalCode.Text != nationalCode && _personData.Any(t => t.Code == TxtNationalCode.Text))
            {
                Utility.Message("اخطار", "شخصی با این کد ملی قبلا ثبت گردیده است", "Warning.png");
                return false;
            }
            return true;
        }
        private bool CheckSelect()
        {
            if (DgdPerson.SelectedIndex != -1) return true;
            Utility.Message("اخطار", "شخصی را انتخاب کنید", "Warning.png");
            return false;
        }

        private async Task<bool> CheckCanDelete(int personId)
        {
            if (await DFilePerson.CanDelete(personId))
            {
                Utility.Message("اخطار", "به دلیل موجود بودن سوابق از این مالک، قادر به حذف نیستید", "Warning.png");
                return false;
            }
            return true;
        }

        #endregion
    }
}