using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP_12._2020.Models;
using System.Windows;
using PP_12._2020.ViewsModels;
using System.Collections.ObjectModel;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;

namespace PP_12._2020.Infrastructure
{
    public static class Methods
    {
        static Random random = new Random();
        static int w = 60;
        static int h = 40;
        public static User Authorization(string login, string password, CollegeEntities db)
        {
            return db.Users.FirstOrDefault(u => u.ID ==
            db.Logins_and_passwords.FirstOrDefault(lap => lap.Password == password && lap.Login == login).ID_User);
        }

        public static string newstrCapcha()
        {
            Random rnd = new Random();
            return $"{rnd.Next(0, 9)}{rnd.Next(0, 9)}{rnd.Next(0, 9)}{rnd.Next(0, 9)}";
        }

        public static Captcha_VM newCapchaVM()
        {

            return new Captcha_VM()
            {
                width = w,
                height = h,
                strCapcha = newstrCapcha(),
                l1x1 = random.Next(0, w),
                l1x2 = random.Next(0, w),
                l1y1 = random.Next(0, h),
                l1y2 = random.Next(0, h),
                l2x1 = random.Next(0, w),
                l2x2 = random.Next(0, w),
                l2y1 = random.Next(0, h),
                l2y2 = random.Next(0, h),
                l3x1 = random.Next(0, w),
                l3x2 = random.Next(0, w),
                l3y1 = random.Next(0, h),
                l3y2 = random.Next(0, h),
                l4x1 = random.Next(0, w),
                l4x2 = random.Next(0, w),
                l4y1 = random.Next(0, h),
                l4y2 = random.Next(0, h),
            };

        }
        public static void excel(ObservableCollection<Login_log> login_Log)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();

            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 15;
            int i = 1;
            foreach (Login_log item in login_Log)
            {
                ExcelApp.Cells[i, 1] = $"{item.ID}";
                ExcelApp.Cells[i, 2] = $"{item.ID_user}";
                ExcelApp.Cells[i, 3] = $"{item.Login_date}";
                ExcelApp.Cells[i, 4] = $"{item.Login_date}";
                i++;
            }
            ExcelApp.Visible=true;
        }
        public static void prf(ObservableCollection<Login_log> login_Log)
            {
            iTextSharp.text.Document doc = new iTextSharp.text.Document();

            PdfWriter.GetInstance(doc, new FileStream("pdfTables.pdf", FileMode.Create));

            doc.Open();

            BaseFont baseFont = BaseFont.CreateFont("C:/Windows/Fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
            PdfPTable table = new PdfPTable(4);

            PdfPCell cell = new PdfPCell(new Phrase("История входов"));
            foreach (Login_log item in login_Log)
            {
                cell = new PdfPCell(new Phrase(new Phrase($"{item.ID}", font)));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(new Phrase($"{item.ID_user}", font)));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(new Phrase($"{item.Login_date}", font)));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(new Phrase($"{item.Logout_date}", font)));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
            }
            
            doc.Add(table);

            doc.Close();

        }

    }
}
