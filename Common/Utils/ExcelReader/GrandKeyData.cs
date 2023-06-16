namespace Common.Utils.ExcelReader
{
    using Newtonsoft.Json;
    public class GrandKeyData : BaseExcelReader<GrandKeyData, GrandKeyDataExcel>
    {
        public override string FileName { get { return "GrandKey.json"; } }
        public GrandKeyDataExcel? FromId(int id)
        {
            return All.Where(grandKey => grandKey.GrandKeyId == id).FirstOrDefault();
        }
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public partial class GrandKeyDataExcel
    {
        [JsonProperty("maxGrandKeyLv")]
        public long MaxGrandKeyLv { get; set; }

        [JsonProperty("positionNum")]
        public long PositionNum { get; set; }

        [JsonProperty("mainWeaponIdList")]
        public long[] MainWeaponIdList { get; set; }

        [JsonProperty("SubWeaponmainIDlist")]
        public long[] SubWeaponmainIDlist { get; set; }

        [JsonProperty("grandKeyID")]
        public long GrandKeyId { get; set; }
    }

}
