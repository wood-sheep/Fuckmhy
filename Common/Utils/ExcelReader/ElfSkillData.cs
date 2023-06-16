namespace Common.Utils.ExcelReader
{
    using Newtonsoft.Json;
    public class ElfSkillData : BaseExcelReader<ElfSkillData, ElfSkillDataExcel>
    {
        public override string FileName { get { return "ElfSkillData.json"; } }
        public ElfSkillDataExcel? FromId(uint id)
        {
            return All.Where(skill => skill.ElfSkillId == id).FirstOrDefault();
        }
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public partial class ElfSkillDataExcel
    {
        [JsonProperty("ElfID")]
        public long ElfId { get; set; }

        [JsonProperty("MaxLv")]
        public long MaxLv { get; set; }

        [JsonProperty("UnlockStar")]
        public long UnlockStar { get; set; }

        [JsonProperty("hasNoRestrictionAbility")]
        public long HasNoRestrictionAbility { get; set; }

        [JsonProperty("ElfSkillID")]
        public long ElfSkillId { get; set; }
    }
}
