using System;

namespace PoConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var sheet = PoSheetReader.Read(@"C:\Users\Wellington\Downloads\Pasta de trabalho.xlsx");
                // var file = PoFileReader.Read(@"C:\Users\Wellington\Downloads\messages.po");
                PoFileWriter.Override(@"C:\Users\Wellington\Downloads\messages.po", sheet);
                MessageHelper.ShowInfo("Operação concluída");
            }
            catch (System.Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }
            finally
            {
                Console.Read();
            }
        }
    }
}
