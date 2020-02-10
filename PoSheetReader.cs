using System;
using System.Linq;
using IronXL;

namespace PoConverter
{
    public static class PoSheetReader
    {
        public static PoSheet Read(string filePath)
        {
            var file = new PoSheet();

            WorkBook workbook = WorkBook.Load(filePath);
            WorkSheet sheet = workbook.WorkSheets.First();

            var lines = sheet.Rows;
            for (int i = PoSheet.StartLine; i < lines.Count; i++)
            {
                var line = lines[i];
                var currentRecord = new PoRecord() 
                { 
                    msgid = line.Columns[0].StringValue,
                    msgstr = line.Columns[1].StringValue
                };
                file.AddRecord(currentRecord);

            }
            return file;
        }
    }
}
