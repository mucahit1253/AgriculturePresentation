using AgriculturePresentation.Areas.Admin.Models;
using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AgriculturePresentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ReportController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IAnnouncementService _announcement;

        public ReportController(IContactService contactService, IAnnouncementService announcement)
        {
            _contactService = contactService;
            _announcement = announcement;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticReport()
        {
            OfficeOpenXml.ExcelPackage.License.SetNonCommercialPersonal("Mucahit");
            ExcelPackage excelPackage = new ExcelPackage();
            var workBook = excelPackage.Workbook.Worksheets.Add("Dosya1");

            workBook.Cells[1, 1].Value = "Ürün Adı";
            workBook.Cells[1, 2].Value = "Ürün Kategorisi";
            workBook.Cells[1, 3].Value = "Ürün Stok";

            workBook.Cells[2, 1].Value= "Mercimek";
            workBook.Cells[2, 2].Value= "Bakliyat";
            workBook.Cells[2, 3].Value= "785 kg";

            workBook.Cells[3, 1].Value = "Buğday";
            workBook.Cells[3, 2].Value = "Bakliyat";
            workBook.Cells[3, 3].Value = "1.989 kg";

            workBook.Cells[4, 1].Value = "Havuç";
            workBook.Cells[4, 2].Value = "Sebze";
            workBook.Cells[4, 3].Value = "600 kg";

            var bytes = excelPackage.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "UrunRaporu.xlsx");
        }
        public List<ContactModel> ContactList()
        {
            //ilk yontem
            // List<ContactModel> contactModels = new List<ContactModel>();

            //var values=  _contactService.GetListAll();
            // foreach (var item in values)
            // {
            //     contactModels.Add(new ContactModel
            //     {
            //         ContactId = item.ContactId,
            //         ContactName=item.Name,
            //         ContactMail=item.Mail,
            //         ContactMessage=item.Message,
            //         ContactDate=item.Date
            //     });

            // }
            // return contactModels;
            //ikinci yöntem
            return _contactService.GetListAll().Select(p => new ContactModel
            {
                ContactId = p.ContactId,
                ContactName = p.Name,
                ContactMail = p.Mail,
                ContactMessage = p.Message,
                ContactDate = p.Date
            }).ToList();
        }
        public IActionResult MessageRaport()
        { 
            using(var workBook=new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Mesaj Listesi");
                workSheet.Cell(1, 1).Value = "Mesaj ID";
                workSheet.Cell(1, 2).Value = "Mesaj Gönderen";
                workSheet.Cell(1, 3).Value = "Mail Adresi";
                workSheet.Cell(1, 4).Value = "Mesaj İçeriği";
                workSheet.Cell(1, 5).Value = "Mesaj Tarihi";

                int contactRowCount = 2;
                foreach (var item in ContactList())
                {
                    workSheet.Cell(contactRowCount,1).Value= item.ContactId;
                    workSheet.Cell(contactRowCount,2).Value= item.ContactName;
                    workSheet.Cell(contactRowCount,3).Value= item.ContactMail;
                    workSheet.Cell(contactRowCount,4).Value= item.ContactMessage;
                    workSheet.Cell(contactRowCount,5).Value= item.ContactDate;
                    contactRowCount++;
                }
                using (var stream= new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MesajRapor.xlsx");
                }
            }
          

        }
        public List<AnnouncementModel> AnnouncementList()
        {
            return _announcement.GetListAll()
                .Select(p => new AnnouncementModel
                {
                    Id = p.AnnouncementId,
                    Title = p.Title,
                    Description = p.Description,
                    Date = p.Date,
                    Status = p.Status
                }).ToList();
        }
        public IActionResult DuyurRaport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Duyuru Listesi");
                workSheet.Cell(1, 1).Value = "Duyuru ID";
                workSheet.Cell(1, 2).Value = "Duyuru Başlık";
                workSheet.Cell(1, 3).Value = "Duyuru Açıklama";
                workSheet.Cell(1, 4).Value = "Duyuru Tarih";
                workSheet.Cell(1, 5).Value = "Duyuru Durum";

                int row = 2;
                foreach (var item in AnnouncementList())
                {
                    workSheet.Cell(row, 1).Value = item.Id;
                    workSheet.Cell(row, 2).Value = item.Title;
                    workSheet.Cell(row, 3).Value = item.Description;
                    workSheet.Cell(row, 4).Value = item.Date;
                    workSheet.Cell(row, 5).Value = item.Status;
                    row++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DuyuruRapor.xlsx");
                }
            }
            
           

        }
    }
}
