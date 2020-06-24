using System;
using System.IO;

namespace DAL.Class
{
    public static class Globals
    {
        //public static string ConnetionString = @"Data Source=WIN-J2PEBUJ1NR6;Initial Catalog=dbMunicipalArchive;Persist Security Info=True;User ID=Avin;Password=@vN.18.65";
        public static string ConnetionString = @"data source=.;initial catalog=dbMunicipalArchive;integrated security=True";
        //public static string ConnetionString = @"data source=DESKTOP-BVIRPH2;initial catalog=dbMunicipalArchive;user id=sa;password=alireza7005;integrated security=True";
        //public static string MasterConnetionString = @"Data Source=WIN-J2PEBUJ1NR6;Initial Catalog=Master;Persist Security Info=True;User ID=Avin;Password=@vN.18.65";
        public static string MasterConnetionString = @"data source=.;initial catalog=Master;integrated security=True";
        //public static string MasterConnetionString = @"data source=DESKTOP-BVIRPH2;initial catalog=Master;user id=sa;password=alireza7005;integrated security=True";
        public static string MyAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"ARKVN\MunicipalArchive\");
    }
}
