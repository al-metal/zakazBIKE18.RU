using System;
using System.IO;
using OfficeOpenXml;

using Slepov.Russian.СуммаПрописью;

namespace Обработчик_заказов_BIKE18.RU
{
    class Epplus
    {
        ConvertToPDF converti = new ConvertToPDF();
        
        public void Zapis_shablona(string adres, string name, string pasport, string koment, string email, string phone, string nomer_zakaza, string cena, bool pochta, bool tech, string name_pozic)
        {
            FileInfo file = new FileInfo("Шаблон.xlsx");
            ExcelPackage package = new ExcelPackage(file);
            ExcelWorksheet w = package.Workbook.Worksheets[1];
            w.Cells["C16"].Value = name + ", " + phone + ", " + email + ", " + adres + ", " + pasport;
            w.Cells["C17"].Value = w.Cells["C16"].Value;
            w.Cells["B20"].Value = "Товар по Заказу №" + nomer_zakaza;
            w.Cells["H20"].Value = cena;
            w.Cells["C12"].Value = nomer_zakaza;
            w.Cells["E12"].Value = DateTime.Now;

            if (pochta == true)
            {
                w.Cells["A21"].Value = "2.";
                w.Cells["B21"].Value = "Доставка почтой России";
                w.Cells["F21"].Value = "1";
                w.Cells["G21"].Value = "шт.";
                w.Cells["H21"].Value = "350";
                w.Cells["I21"].Value = "350";
                w.Cells["I22"].Value = (Convert.ToInt32(cena) + 350).ToString() + " руб.";
                w.Cells["A24"].Value = "Всего наименований 2, на сумму " + w.Cells["I22"].Value;
            }
            else
            {
                w.Cells["A21"].Value = "";
                w.Cells["B21"].Value = "";
                w.Cells["F21"].Value = "";
                w.Cells["G21"].Value = "";
                w.Cells["H21"].Value = "";
                w.Cells["I21"].Value = "";
                w.Cells["I22"].Value = cena + " руб.";
                w.Cells["A24"].Value = "Всего наименований 1, на сумму " + w.Cells["I22"].Value;
            }

          

           
           string sum_prop =  Сумма.Пропись(Convert.ToDecimal(w.Cells["I22"].Value.ToString().Substring(0, w.Cells["I22"].Value.ToString().Length - 5)), Валюта.Рубли, Заглавные.Первая);
            w.Cells["A25"].Value = sum_prop;
            package.Save();
            


          
            converti.ConvertExcelToPdf(Directory.GetCurrentDirectory()+"\\Шаблон.xlsx", Directory.GetCurrentDirectory()+"\\Шаблон счет.pdf");



        }

    }
}
