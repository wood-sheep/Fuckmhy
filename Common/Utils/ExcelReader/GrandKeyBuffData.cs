namespace Common.Utils.ExcelReader
{
    using Newtonsoft.Json;
    public class GrandKeyBuffData : BaseExcelReader<GrandKeyBuffData, GrandKeyBuffDataExcel>
    {
        public override string FileName { get { return "GrandKeyBuff.json"; } }
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public partial class GrandKeyBuffDataExcel
    {
        [JsonProperty("grandKeyID")]
        public long GrandKeyId { get; set; }

        [JsonProperty("unlockgrandKeyLevel")]
        public long UnlockgrandKeyLevel { get; set; }

        [JsonProperty("breachLevel")]
        public long BreachLevel { get; set; }

        [JsonProperty("HP")]
        public long Hp { get; set; }

        [JsonProperty("SP")]
        public long Sp { get; set; }

        [JsonProperty("attack")]
        public long Attack { get; set; }

        [JsonProperty("defence")]
        public long Defence { get; set; }

        [JsonProperty("critical")]
        public long Critical { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("IsSynchron")]
        public long IsSynchron { get; set; }

        [JsonProperty("side")]
        public long Side { get; set; }

        [JsonProperty("grandKeySkill")]
        public long GrandKeySkill { get; set; }
    }
}
