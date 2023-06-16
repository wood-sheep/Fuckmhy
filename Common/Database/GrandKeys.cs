using Common.Resources.Proto;
using Common.Utils.ExcelReader;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Common.Database
{
    internal class GrandKeys
    {
        public static readonly IMongoCollection<GrandKeysScheme> collection = Global.db.GetCollection<GrandKeysScheme>("GrandKeys");

        public static GrandKeysScheme FromUid(uint uid)
        {
            return collection.AsQueryable().Where(collection => collection.OwnerUid == uid).FirstOrDefault() ?? Create(uid);
        }
        public static GrandKeysScheme Create(uint uid)
        {
            GrandKeysScheme? tryGrandKeys = collection.AsQueryable().Where(collection => collection.OwnerUid == uid).FirstOrDefault();
            if (tryGrandKeys != null) { return tryGrandKeys; }
            GrandKeysScheme grandKeys = new(){};

            collection.InsertOne(grandKeys);

            return grandKeys;
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public class GrandKeysScheme
        {
            public ObjectId Id { get; set; }
            public uint OwnerUid { get; set; }
            public List<GrandKey> GrandKeyList { get; set; }
            public void Save()
            {
                GrandKeys.collection.ReplaceOne(Builders<GrandKeysScheme>.Filter.Eq(grandKey => grandKey.Id, Id), this);
            }
            public GrandKey AddGrandKey(int grandKeyId)
            {
                GrandKeyDataExcel? grandKeyData = GrandKeyData.GetInstance().FromId(grandKeyId);
                if (grandKeyData == null) { throw new ArgumentException("Invalid grandKeyId"); }

                GrandKey grandKey = new()
                {
                    Id = (uint)grandKeyData.GrandKeyId,
                    Level = 1,
                    EndTime = 0,//unix time
                    UnlockLevel = 50, //50, 65
                    ActivateLevel = 0,
                    BreachLevel = 0, //0, 1, 2
                    Skill = { SkillId = 1 },
                    ScoinNum = 0 //no idea
                };

                GrandKeyList.Add(grandKey);
                return grandKey;
            }
            public void LevelUpGrandKey(int id) 
            {
                GrandKeyList.ForEach(grandKey =>
                    {if (grandKey.Id == id) grandKey.Level++;});
            }
            public void ActivateGrandKeySkill(int keyId, int skillId, int lastTime) { }
            public void SetGrandKeySkill(int keyId, int skillId) { }
        }
        
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
