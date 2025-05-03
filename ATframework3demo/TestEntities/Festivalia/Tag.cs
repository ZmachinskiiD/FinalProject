using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework;
using ATframework3demo.BaseFramework.BitrixCPinterraction;

namespace ATframework3demo.TestEntities.Festivalia
{
    public class Tag
    {
        public string Name { get; set; }
        public PortalInfo PortalInfo { get; }
        public Tag(string name = "", PortalInfo? portalInfo = null) 
        {
            Name = name=="" ? HelperMethods.GetDateTimeSaltString(true, 12) : name;
            PortalInfo = portalInfo;
        }
        public string InsertTag()
        {
            PortalDatabaseExecutor.ExecuteQuery($"INSERT INTO up_festivaliya_tag (TITLE) VALUES('{Name}')", PortalInfo.PortalUri,PortalInfo.PortalAdmin);
            var result = PortalDatabaseExecutor.ExecuteQuery($"Select ID FROM up_festivaliya_tag WHERE TITLE='{Name}'", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
            return result.Count == 0 ? null : result[0].ID;
        }
        public string GetTagID()
        {
            var result = PortalDatabaseExecutor.ExecuteQuery($"select ID from up_festivaliya_tag where title = '{Name}'", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
            return result.Count == 0 ? null : result[0].ID;
        }
        public string GetOneTag()
        {
            var result = PortalDatabaseExecutor.ExecuteQuery($"select ID from up_festivaliya_tag", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
            return result.Count == 0 ? null : result[0].ID;
        }


    }
}
