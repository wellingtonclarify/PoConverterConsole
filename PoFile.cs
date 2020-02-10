using System.Collections.Generic;

namespace PoConverter
{
    public class PoFile
    {
        public static readonly int StartLine = 11;
        public static readonly string KeyIdentifier = "msgid";
        public static readonly string ValueIdentifier = "msgstr";

        public List<PoRecord> Records { get; private set; } = new List<PoRecord>();

        public void AddRecord(PoRecord record)
        {
            Records.Add(record);
        }
    }
}
