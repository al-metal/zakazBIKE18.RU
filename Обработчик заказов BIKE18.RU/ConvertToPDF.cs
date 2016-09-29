using Aspose.Cells;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;


namespace Обработчик_заказов_BIKE18.RU
{
    class ConvertToPDF
    {

        public  void ConvertExcelToPdf(string inputFile, string outputFileName)
        {
            //Convert xlsx in PDF
            Workbook workbook = new Workbook(inputFile);
            workbook.Save(outputFileName, SaveFormat.Pdf);

            //delete trial string in pdf
            PdfDocument document = PdfReader.Open(outputFileName);
            if (document.Version < 14)
                document.Version = 14;

            PdfPage page = document.Pages[0];
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XImage img = XImage.FromFile("wl.jpg");
            gfx.DrawImage(img, 0, 0);
            document.Save(outputFileName);

            //old functions
//            Microsoft.Office.Interop.Excel.Application excelApp =
//            new Microsoft.Office.Interop.Excel.Application();
//            excelApp.Visible = false;
//            Workbook workbook = null;
//            Workbooks workbooks = null;
//            try
//            {
//                workbooks = excelApp.Workbooks;
//                workbook = workbooks.Open(inputFile);
//                workbook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF ,outputFileName,
//XlFixedFormatQuality.xlQualityStandard, true, true, Type.Missing,Type.Missing, false,Type.Missing);
//            }
//            finally
//            {
//                if (workbook != null)
//                {
//                    try {
//                        workbook.Close(XlSaveAction.xlDoNotSaveChanges);
//                        while (Marshal.FinalReleaseComObject(workbook) != 0) { };
//                        workbook = null;
//                    }
//                    catch { }
//                }
//                if (workbooks != null)
//                {
//                    try {
//                        workbooks.Close();
//                        while (Marshal.FinalReleaseComObject(workbooks) != 0) { };
//                        workbooks = null;
//                    }
//                    catch { }
//                }
//                if (excelApp != null)
//                {
//                    try {
//                        excelApp.Quit();
//                        excelApp.Application.Quit();
//                        while (Marshal.FinalReleaseComObject(excelApp) != 0) { };
//                        excelApp = null;
//                    }
//                    catch { }
//                }
//            }
            
          
        }
    }
}
