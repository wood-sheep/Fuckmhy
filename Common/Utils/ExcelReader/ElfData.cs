namespace Common.Utils.ExcelReader
{
    using Newtonsoft.Json;
    public class ElfData : BaseExcelReader<ElfData, ElfDataExcel>
    {
        public override string FileName { get { return "ElfData.json"; } }
        public ElfDataExcel? FromId(int id)
        {
            return All.Where(elf => elf.ElfId == id).FirstOrDefault();
        }
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public partial class ElfDataExcel
    {
        [JsonProperty("Index")]
        public int Index { get; set; }

        [JsonProperty("ElfRegistryKey")]
        public string ElfRegistryKey { get; set; }

        [JsonProperty("UnlockStar")]
        public int UnlockStar { get; set; }

        [JsonProperty("Rarity")]
        public int Rarity { get; set; }

        [JsonProperty("elfCardID")]
        public int ElfCardId { get; set; }

        [JsonProperty("elfFragmentID")]
        public int ElfFragmentId { get; set; }

        [JsonProperty("CarryPlayerLevel")]
        public int CarryPlayerLevel { get; set; }

        [JsonProperty("TrialStageActivityList")]
        public int[] TrialStageActivityList { get; set; }

        [JsonProperty("CaptainSkillIDs")]
        public int[] CaptainSkillIDs { get; set; }

        [JsonProperty("ElfID")]
        public int ElfId { get; set; }
    }
}
