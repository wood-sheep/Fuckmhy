namespace Common.Utils.ExcelReader
{
    using Newtonsoft.Json;
    public class ElfSkillTreeData : BaseExcelReader<ElfSkillTreeData, ElfSkillTreeDataExcel>
    {
        public override string FileName { get { return "ElfSkillTreeData.json"; } }
        public ElfSkillTreeDataExcel? FromId(uint id)
        {
            return All.Where(skillTree => skillTree.ElfSkillId == id).FirstOrDefault();
        }
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public partial class ElfSkillTreeDataExcel
    {
        [JsonProperty("LevelUpPreSkill")]
        public LevelUpPreSkill[] LevelUpPreSkill { get; set; }

        [JsonProperty("LevelUpStar")]
        public uint LevelUpStar { get; set; }

        [JsonProperty("NeedElfLevel")]
        public uint NeedElfLevel { get; set; }

        [JsonProperty("LevelUpMaterialList")]
        public LevelUpMaterialList[] LevelUpMaterialList { get; set; }

        [JsonProperty("ElfSkillID")]
        public uint ElfSkillId { get; set; }

        [JsonProperty("elfSkillLv")]
        public uint ElfSkillLv { get; set; }
    }

    public partial class LevelUpMaterialList
    {
        [JsonProperty("MaterialID")]
        public uint MaterialId { get; set; }

        [JsonProperty("Number")]
        public uint Number { get; set; }
    }

    public partial class LevelUpPreSkill
    {
        [JsonProperty("Lv")]
        public uint Lv { get; set; }

        [JsonProperty("SkillID")]
        public uint SkillId { get; set; }
    }
}
