using System.Collections.Generic;

namespace PoConverter
{
    public class PoSheet
    {
        public static readonly int StartLine = 0;
        public static readonly string KeyIdentifier = "msgid";
        public static readonly string ValueIdentifier = "msgstr";

        public List<PoRecord> Records { get; private set; } = new List<PoRecord>();

        public void AddRecord(PoRecord record)
        {
            Records.Add(record);
        }
    }
}
