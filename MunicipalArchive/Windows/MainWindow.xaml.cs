using System;
using System.Windows;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using MunicipalArchive.Class;
using DAL.Class;
using Application = System.Windows.Application;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace MunicipalArchive.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private bool _okClose;

        public MainWindow()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("fa-Ir"));

        }

        private void Close(object sender, RoutedEventArgs e)
        {
            _okClose = true;
            //BtnBackUp_MouseLeftButtonDown(null, null);
            Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            _okClose = true;
            //BtnBackUp_MouseLeftButtonDown(null, null);
            e.Cancel = false;
            Application.Current.Shutdown();
        }

        private void BtnBackUp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var fileName = PersianDateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

            if (_okClose == false)
            {
                var savefd = new SaveFileDialog
                {
                    Filter = "Backup File (*.Bak)|*.Bak",
                    FileName = fileName
                };
                var result = savefd.ShowDialog();
                if (result != true) return;
                var directoryName = Path.GetDirectoryName(savefd.FileName) + "\\" + fileName;
                Directory.CreateDirectory(directoryName);
                var winWait = new WinWait
                {
                    DirectoryName = directoryName,
                    FileName = fileName,
                    OkBackUp = true,
                    OkRestore = false,
                    CloseOk = false

                };

                winWait.ShowDialog();
            }
            else
            {
                var directoryPath = Path.Combine(Globals.MyAppData, @"BackUp\" + fileName);

                Directory.CreateDirectory(directoryPath);
                var winWait = new WinWait
                {
                    DirectoryName = directoryPath,
                    FileName = fileName,
                    OkBackUp = true,
                    OkRestore = false,
                    CloseOk = true
                };

                winWait.ShowDialog();
            }

        }

        private void BtnRestore_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string extractPath = null;
            try
            {
                var openFileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Filter = @"Zip Files (*.Zip) |*.Zip",
                    Title = @"انتخاب مسیر فایل پشتیبان"
                };

                if (openFileDialog.ShowDialog() != true) return;

                var fileName = Path.GetFileName(openFileDialog.FileName);
                var fullPath = Path.GetFullPath(openFileDialog.FileName);
                extractPath = Path.ChangeExtension(fullPath, null);
                Directory.CreateDirectory(extractPath);
                ZipFile.ExtractToDirectory(fullPath, extractPath);
                var winWait = new WinWait
                {
                    FileName = fileName,
                    WExtractPath = extractPath,
                    OkBackUp = false,
                    OkRestore = true
                };

                winWait.ShowDialog();
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بازنشانی اطلاعات", exception.Message);
                if (Directory.Exists(extractPath))
                {
                    try
                    {
                        Directory.Delete(extractPath, true);
                    }
                    catch (Exception exception1)
                    {
                        Utility.MyMessageBox("خطا در حذف فایل ایجاد شده", exception1.Message);
                    }
                }
            }
        }

        private void BtnAutoBackUp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Utility.MyMessageBox("مواردی که باید بدانید", @"پشتیبان های خودکار شامل حداکثر 30 عدد فایل پشتیبان است که به ازای هربار بسته شدن نرم افزار ایجاد می شوند.
این پشتیبان ها را باید در مکانی ذخیره کنید و سپس با استفاده از گزینه -بازنشانی فایل پشتیبان- اقدام به بازنشانی فایل پشتیبان کنید.", "AboutUs.png");

            if (!Utility.Ok) return;
            var dialog = new FolderBrowserDialog
            { Description = @"انتخاب مسیر ذخیره سازی فایل های پشتیبان" };
            var result = dialog.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK) return;


            var directoryName = Path.GetFullPath(dialog.SelectedPath);


            var winWait = new WinWait
            {
                DirectoryName = directoryName,
                OkAutoBackUp = true
            };
            winWait.ShowDialog();
        }

        private void BtnChangePassword_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var winChangePassword = new WinChangePassword();
            winChangePassword.ShowDialog();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        #region FixedEvent

        private void DragMove(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        #endregion

        private void BtnFile_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var winFile = new WinFile();
            winFile.ShowDialog();
        }

        private void BtnPerson_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var winPerson=new WinPerson();
            winPerson.ShowDialog();
        }
        private void BtnSearch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var winFileSearch = new WinFileSearch
            {
                DgdFile = {Height = 432},
                BtnSelect = {Visibility = Visibility.Collapsed}
            };
            winFileSearch.ShowDialog();
        }

        private void BtnClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _okClose = true;
            //BtnBackUp_MouseLeftButtonDown(null, null);
            Application.Current.Shutdown();
        }

        private void BtnAddUser_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var winAddAdmin = new WinAddAdmin {PostTypeId = null};
            winAddAdmin.ShowDialog();
        }
    }
}
