using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityControllers.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ทดสอบเพิ่มใบรับเงิน()
        {
            ReceiptDataController.ReceiptDataController service = new ReceiptDataController.ReceiptDataController();
            ReceiptDataModel itemData = new ReceiptDataModel
            {
                DocumentNumber = "1",
                DocumentBookNumber = "1",
                DocumentDate = new DateTime(2018, 10, 21),
                payerName = "สมาชิก ใจดี",
                payerid = "1234567890123",
                houseNumber = "123",
                soi = "",
                moo = "1",
                road = "ถนน",
                tambon = "ตำบล",
                amphur = "อำเภอ",
                province = "กรุงเทพฯ",
                zipcode = "12345",
                asReceiptTo = "ค่าธรรมเนียม",
                asReceiptToRemark = "ช่องอื่น ๆ",
                receiptAmount = 8000,
                receiptPayType = "เงินโอน",
                receiptDate = new DateTime(2018, 10, 21),
                receiptBank = "ธนาคารกสิกรไทย",
                receiptBillNumber = "",
                receiptChqBank = "",
                receiptChqNumber = "",
                receiptOther = ""
            };


            var result = service.ReceipDataAdd(itemData);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ทดสอบแก้ไขเอกสารใบรับเงิน()
        {
            ReceiptDataController.ReceiptDataController service = new ReceiptDataController.ReceiptDataController();
            ReceiptDataModel itemData = new ReceiptDataModel
            {
                DocumentRunno = "1",
                DocumentNumber = "1",
                DocumentBookNumber = "1",
                DocumentDate = new DateTime(2018, 10, 21),
                payerName = "สมาชิก คนใหม่มาจ่าย",
                payerid = "9534567890123",
                houseNumber = "456",
                soi = "อยู่ลึก",
                moo = "5",
                road = "ถนนหน้าบ้าน",
                tambon = "ตำบลหลุม",
                amphur = "อำเภอบ่อ",
                province = "กรุงเทพฯ",
                zipcode = "78345",
                asReceiptTo = "ค่าบำรุง",
                asReceiptToRemark = "ช่องอื่น ๆ",
                receiptAmount = 18000,
                receiptPayType = "เงินสด",
                receiptDate = null,
                receiptBank = "",
                receiptBillNumber = "",
                receiptChqBank = "",
                receiptChqNumber = "",
                receiptOther = ""
            };


            var result = service.ReceipDataEdit(itemData);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ทดสอบลบข้อมูลใบรับเงิน()
        {
            ReceiptDataController.ReceiptDataController service = new ReceiptDataController.ReceiptDataController();
            ReceiptDataModel itemData = new ReceiptDataModel {DocumentRunno = "1"};
            var result = service.ReceipDataDelete(itemData);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ทดสอบดึงข้อมูลใบรับเงินตามเลขที่()
        {
            ReceiptDataController.ReceiptDataController service = new ReceiptDataController.ReceiptDataController();            
            var result = service.ReceipDataListbyRunno("2");
            Assert.IsNotNull(result);
        }
    }
}
