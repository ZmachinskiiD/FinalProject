using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework;
using ATframework3demo.BaseFramework.BitrixCPinterraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.TestEntities
{
    public class User
    {
        public User(bool organizer = false, string password = "123456", string name = "Иван", string lastName = "Иванов")
        {
            LoginAkaEmail = HelperMethods.GetDateTimeSaltString(false,10) + "@gmail.com";
            Password = password;
            Name = name + HelperMethods.GetDateTimeSaltString(false, 8);
            LastName = lastName + HelperMethods.GetDateTimeSaltString(false, 8);
            Organizer = organizer;
        }

        public string LoginAkaEmail { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool Organizer { get; set; }
        public string NameLastName => Name + " " + LastName;

        public string GetDBid(Uri portalUri, User adminUser)
        {
            var result = PortalDatabaseExecutor.ExecuteQuery("select ID from b_user where EMAIL = '" + LoginAkaEmail + "'", portalUri, adminUser);
            return result.Count == 0 ? null : result[0].ID;
        }
        public static string GetRegisteredEmail(Uri portalUri, User adminUser)
        {
            var result = PortalDatabaseExecutor.ExecuteQuery("select login from b_user where login like '%@%' limit 1", portalUri, adminUser);
            
            return result[0].login;
        }
        public static void CreateUser(User user)
        {
            var phpExecutor = new PHPcommandLineExecutor(TestCase.RunningTestCase.TestPortal.PortalUri,
                TestCase.RunningTestCase.TestPortal.PortalAdmin.LoginAkaEmail,
                TestCase.RunningTestCase.TestPortal.PortalAdmin.Password);
            var usergroup = user.Organizer ? 6 :7;
            string phpCodeCreateUser = "$user = new CUser;" +
                $"$arFields = Array('NAME' => '{user.Name}'," +
                $"'LAST_NAME' => '{user.LastName}'," +
                $"'EMAIL'  => '{user.LoginAkaEmail}'," +
                $"'LOGIN'  => '{user.LoginAkaEmail}'," +
                $"'GROUP_ID'=> array({usergroup})," +
                $"'PASSWORD' => '{user.Password}'," +
                $"'CONFIRM_PASSWORD'  => '{user.Password}');" +
                $"$ID = $user->Add($arFields);";
            phpExecutor.Execute(phpCodeCreateUser);
        }
    }
}
