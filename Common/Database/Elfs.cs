using Common.Resources.Proto;
using Common.Utils.ExcelReader;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Common.Database
{
    internal class Elfs
    {
        public static readonly IMongoCollection<ElfsScheme> collection = Global.db.GetCollection<ElfsScheme>("Elfs");

        public static ElfsScheme FromUid(uint uid)
        {
            return collection.AsQueryable().Where(collection => collection.OwnerUid == uid).FirstOrDefault() ?? Create(uid);
        }
        public static ElfsScheme Create(uint uid)
        {
            ElfsScheme? tryElfs = collection.AsQueryable().Where(collection => collection.OwnerUid == uid).FirstOrDefault();
            if (tryElfs != null) { return tryElfs; }
            ElfsScheme elfs = new() { };

            collection.InsertOne(elfs);

            return elfs;
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public class ElfsScheme
        {
            public ObjectId Id { get; set; }
            public uint OwnerUid { get; set; }
            public List<Elf> Elves { get; set; }
            public void Save()
            {
                Elfs.collection.ReplaceOne(Builders<ElfsScheme>.Filter.Eq(elfs => elfs.Id, Id), this);
            }
            public Elf AddElf(int elfId)
            {
                ElfDataExcel? elfData = ElfData.GetInstance().FromId(elfId);
                if (elfData == null) { throw new ArgumentException("Invalid ElfId"); }
                Elf elf = new()
                {
                    ElfId = (uint)elfData.ElfId,
                    Level = 1,
                    Exp = 0,
                    Star = (uint)elfData.UnlockStar,
                    SkillLists = {}

                };

                Elves.Add(elf);
                return elf;
            }
            public void LevelUpElf(int id)
            {
                Elves.ForEach(elf =>
                { if (elf.ElfId == id) elf.Level++; });
            }
            public void SetElfLevel(int id, uint level){ Elves.Find(elf => elf.ElfId == id).Level = level; }
        }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}