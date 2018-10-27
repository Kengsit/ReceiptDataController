using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using UtilityControllers.Models;

namespace ReceiptDataController
{
    [RoutePrefix("api/ReceiptData")]
    public class ReceiptDataController : ApiController
    {
        [Route("Add")]
        [HttpPost]
        public IHttpActionResult ReceipDataAdd([FromBody] ReceiptDataModel item)
        {
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            if (conn.OpenConnection())
            {
                string SQLString = @"
                   insert into receiptdata (documentbooknumber, documentnumber, documentdate, payername, payerid, housenumber, soi,
                       road, moo, tambon, amphur, province, zipcode, asreceiptto, asreceipttoremark, receiptamount, receiptpaytype,
                       receiptdate, receiptbank, receiptbillnumber, receiptchqbank, receiptchqnumber, receiptother, building, telephone) 
                   values (@documentbooknumber , @documentnumber, @documentdate,
                       @payername, @payerid, @housenumber, @soi, @road, @moo, @tambon, @amphur, @province, @zipcode,
                       @asreceiptto, @asreceipttoremark, @receiptamount, @receiptpaytype, @receiptdate, @receiptbank,
                       @receiptbillnumber, @receiptchqbank, @receiptchqnumber, @receiptother, @building, @telephone) ";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                qExe.Parameters.AddWithValue("@documentbooknumber", item.DocumentBookNumber);
                qExe.Parameters.AddWithValue("@documentnumber", item.DocumentNumber);
                qExe.Parameters.AddWithValue("@documentdate", Convert.ToDateTime(item.DocumentDate, new CultureInfo("en-US")));
                qExe.Parameters.AddWithValue("@payername", item.payerName);
                qExe.Parameters.AddWithValue("@payerid", item.payerid);
                qExe.Parameters.AddWithValue("@housenumber", item.houseNumber);
                qExe.Parameters.AddWithValue("@soi", item.soi);
                qExe.Parameters.AddWithValue("@road", item.road);
                qExe.Parameters.AddWithValue("@moo", item.moo);
                qExe.Parameters.AddWithValue("@tambon", item.tambon);
                qExe.Parameters.AddWithValue("@amphur", item.amphur);
                qExe.Parameters.AddWithValue("@province", item.province);
                qExe.Parameters.AddWithValue("@zipcode", item.zipcode);
                qExe.Parameters.AddWithValue("@asreceiptto", item.asReceiptTo);
                qExe.Parameters.AddWithValue("@asreceipttoremark", item.asReceiptToRemark);
                qExe.Parameters.AddWithValue("@receiptamount", item.receiptAmount);
                qExe.Parameters.AddWithValue("@receiptpaytype", item.receiptPayType);
                qExe.Parameters.AddWithValue("@receiptdate", Convert.ToDateTime(item.receiptDate, new CultureInfo("en-US")));
                qExe.Parameters.AddWithValue("@receiptbank", item.receiptBank);
                qExe.Parameters.AddWithValue("@receiptbillnumber", item.receiptBillNumber);
                qExe.Parameters.AddWithValue("@receiptchqbank", item.receiptChqBank);
                qExe.Parameters.AddWithValue("@receiptchqnumber", item.receiptChqNumber);
                qExe.Parameters.AddWithValue("@receiptother", item.receiptOther);
                qExe.Parameters.AddWithValue("@building", item.building);
                qExe.Parameters.AddWithValue("@telephone", item.telephone);
                qExe.ExecuteNonQuery();
                long returnid = qExe.LastInsertedId;
                conn.CloseConnection();
                return Ok(returnid.ToString());
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }

        [Route("Edit")]
        [HttpPost]
        public IHttpActionResult ReceipDataEdit([FromBody] ReceiptDataModel item)
        {
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            if (conn.OpenConnection())
            {
                string SQLString = @"
                   update receiptdata set documentrunno = @documentrunno,
                                          documentbooknumber = @documentbooknumber, 
                                          documentnumber = @documentnumber, 
                                          documentdate = @documentdate,
                                          payername = @payername, 
                                          payerid = @payerid, 
                                          housenumber = @housenumber, 
                                          soi = @soi, 
                                          road = @road, 
                                          moo = @moo, 
                                          tambon = @tambon, 
                                          amphur = @amphur, 
                                          province = @province, 
                                          zipcode = @zipcode,
                                          asreceiptto = @asreceiptto, 
                                          asreceipttoremark = @asreceipttoremark, 
                                          receiptamount = @receiptamount, 
                                          receiptpaytype = @receiptpaytype, 
                                          receiptdate = @receiptdate, 
                                          receiptbank = @receiptbank,
                                          receiptbillnumber = @receiptbillnumber, 
                                          receiptchqbank = @receiptchqbank,
                                          receiptchqnumber = @receiptchqnumber, 
                                          receiptother = @receiptother,
                                          building = @building,
                                          telephone = @telephone where documentrunno = @documentrunno";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                qExe.Parameters.AddWithValue("@documentrunno", item.DocumentRunno);
                qExe.Parameters.AddWithValue("@documentbooknumber", item.DocumentBookNumber);
                qExe.Parameters.AddWithValue("@documentnumber", item.DocumentNumber);
                qExe.Parameters.AddWithValue("@documentdate", item.DocumentDate);
                qExe.Parameters.AddWithValue("@payername", item.payerName);
                qExe.Parameters.AddWithValue("@payerid", item.payerid);
                qExe.Parameters.AddWithValue("@housenumber", item.houseNumber);
                qExe.Parameters.AddWithValue("@soi", item.soi);
                qExe.Parameters.AddWithValue("@road", item.road);
                qExe.Parameters.AddWithValue("@moo", item.moo);
                qExe.Parameters.AddWithValue("@tambon", item.tambon);
                qExe.Parameters.AddWithValue("@amphur", item.amphur);
                qExe.Parameters.AddWithValue("@province", item.province);
                qExe.Parameters.AddWithValue("@zipcode", item.zipcode);
                qExe.Parameters.AddWithValue("@asreceiptto", item.asReceiptTo);
                qExe.Parameters.AddWithValue("@asreceipttoremark", item.asReceiptToRemark);
                qExe.Parameters.AddWithValue("@receiptamount", item.receiptAmount);
                qExe.Parameters.AddWithValue("@receiptpaytype", item.receiptPayType);
                qExe.Parameters.AddWithValue("@receiptdate", item.receiptDate);
                qExe.Parameters.AddWithValue("@receiptbank", item.receiptBank);
                qExe.Parameters.AddWithValue("@receiptbillnumber", item.receiptBillNumber);
                qExe.Parameters.AddWithValue("@receiptchqbank", item.receiptChqBank);
                qExe.Parameters.AddWithValue("@receiptchqnumber", item.receiptChqNumber);
                qExe.Parameters.AddWithValue("@receiptother", item.receiptOther);
                qExe.ExecuteNonQuery();
                conn.CloseConnection();
                return Ok();
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }
        [Route("Delete")]
        [HttpPost]
        public IHttpActionResult ReceipDataDelete([FromBody] ReceiptDataModel item)
        {
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            if (conn.OpenConnection())
            {
                string SQLString = @"delete from receiptdata where documentrunno = @documentrunno";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                if (string.IsNullOrEmpty(item.DocumentRunno))
                {
                    return BadRequest("Document Key is null!");
                }
                qExe.Parameters.AddWithValue("@documentrunno", item.DocumentRunno);
                qExe.ExecuteNonQuery();
                conn.CloseConnection();
                return Ok();
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }

        [Route("ListbyRunno/{runno}")]
        [HttpGet]
        public IHttpActionResult ReceipDataListbyRunno(string runno)
        {
            ReceiptDataModel result = new ReceiptDataModel();
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            if (conn.OpenConnection())
            {
                string sqlString;
                if (!string.IsNullOrEmpty(runno))
                    sqlString = @"select * from receiptdata where documentrunno = @documentrunno";
                else
                    return Json("Document Number is blank!");

                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = sqlString
                };
                qExe.Parameters.AddWithValue("@documentrunno", runno);

                MySqlDataReader dataReader = qExe.ExecuteReader();
                while (dataReader.Read())
                {
                    result.DocumentRunno = dataReader["documentrunno"].ToString();
                    result.DocumentBookNumber = dataReader["documentbooknumber"].ToString();
                    result.DocumentNumber = dataReader["documentnumber"].ToString();
                    result.DocumentDate = Convert.ToDateTime(dataReader["documentdate"].ToString(), new CultureInfo("en-US"));
                    result.payerName = dataReader["payername"].ToString();
                    result.payerid = dataReader["payerid"].ToString();
                    result.houseNumber = dataReader["housenumber"].ToString();
                    result.soi = dataReader["soi"].ToString();
                    result.road = dataReader["road"].ToString();
                    result.moo = dataReader["moo"].ToString();
                    result.tambon = dataReader["tambon"].ToString();
                    result.amphur = dataReader["amphur"].ToString();
                    result.province = dataReader["province"].ToString();
                    result.zipcode = dataReader["zipcode"].ToString();
                    result.asReceiptTo = dataReader["asreceiptto"].ToString();
                    result.asReceiptToRemark = dataReader["asreceipttoremark"].ToString();
                    result.receiptAmount = double.Parse(dataReader["receiptamount"].ToString());
                    result.receiptPayType = dataReader["receiptpaytype"].ToString();
                    result.receiptDate = Convert.ToDateTime(dataReader["receiptdate"].ToString(), new CultureInfo("en-US"));
                    result.receiptBank = dataReader["receiptbank"].ToString();
                    result.receiptBillNumber = dataReader["receiptbillnumber"].ToString();
                    result.receiptChqBank = dataReader["receiptchqbank"].ToString();
                    result.receiptChqNumber = dataReader["receiptchqnumber"].ToString();
                    result.receiptOther = dataReader["receiptother"].ToString();
                }
                dataReader.Close();
                conn.CloseConnection();
                return Json(result);
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }
        [Route("ListAllReceipt")]
        [HttpGet]
        public IHttpActionResult ReceipDataList()
        {
            List<ReceiptDataModel> result = new List<ReceiptDataModel>();
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            if (conn.OpenConnection())
            {
                string sqlString = @"select * from receiptdata order by documentrunno";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = sqlString
                };

                MySqlDataReader dataReader = qExe.ExecuteReader();
                while (dataReader.Read())
                {
                    ReceiptDataModel detail = new ReceiptDataModel
                    {
                        DocumentRunno = dataReader["documentrunno"].ToString(),
                        DocumentBookNumber = dataReader["documentbooknumber"].ToString(),
                        DocumentNumber = dataReader["documentnumber"].ToString(),
                        DocumentDate = Convert.ToDateTime(dataReader["documentdate"].ToString(), new CultureInfo("en-US")),
                        payerName = dataReader["payername"].ToString(),
                        payerid = dataReader["payerid"].ToString(),
                        houseNumber = dataReader["housenumber"].ToString(),
                        soi = dataReader["soi"].ToString(),
                        road = dataReader["road"].ToString(),
                        moo = dataReader["moo"].ToString(),
                        tambon = dataReader["tambon"].ToString(),
                        amphur = dataReader["amphur"].ToString(),
                        province = dataReader["province"].ToString(),
                        zipcode = dataReader["zipcode"].ToString(),
                        asReceiptTo = dataReader["asreceiptto"].ToString(),
                        asReceiptToRemark = dataReader["asreceipttoremark"].ToString(),
                        receiptAmount = double.Parse(dataReader["receiptamount"].ToString()),
                        receiptPayType = dataReader["receiptpaytype"].ToString(),
                        receiptDate = Convert.ToDateTime(dataReader["receiptdate"].ToString(), new CultureInfo("en-US")),
                        receiptBank = dataReader["receiptbank"].ToString(),
                        receiptBillNumber = dataReader["receiptbillnumber"].ToString(),
                        receiptChqBank = dataReader["receiptchqbank"].ToString(),
                        receiptChqNumber = dataReader["receiptchqnumber"].ToString(),
                        receiptOther = dataReader["receiptother"].ToString(),
                        building = dataReader["building"].ToString(),
                        telephone = dataReader["telephone"].ToString()
                    };
                    result.Add(detail);
                }
                dataReader.Close();
                conn.CloseConnection();
                return Json(result);
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }
        [Route("ListReceipt/{runno}")]
        [HttpGet]
        public IHttpActionResult ReceipDataListbyrunno(string runno)
        {
            ReceiptDataModel result = new ReceiptDataModel();
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            if (conn.OpenConnection())
            {
                string sqlString = @"select * from receiptdata order by documentrunno";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = sqlString
                };

                MySqlDataReader dataReader = qExe.ExecuteReader();
                while (dataReader.Read())
                {
                    result.DocumentRunno = dataReader["documentrunno"].ToString();
                    result.DocumentBookNumber = dataReader["documentbooknumber"].ToString();
                    result.DocumentNumber = dataReader["documentnumber"].ToString();
                    result.DocumentDate = Convert.ToDateTime(dataReader["documentdate"].ToString(), new CultureInfo("en-US"));
                    result.payerName = dataReader["payername"].ToString();
                    result.payerid = dataReader["payerid"].ToString();
                    result.houseNumber = dataReader["housenumber"].ToString();
                    result.soi = dataReader["soi"].ToString();
                    result.road = dataReader["road"].ToString();
                    result.moo = dataReader["moo"].ToString();
                    result.tambon = dataReader["tambon"].ToString();
                    result.amphur = dataReader["amphur"].ToString();
                    result.province = dataReader["province"].ToString();
                    result.zipcode = dataReader["zipcode"].ToString();
                    result.asReceiptTo = dataReader["asreceiptto"].ToString();
                    result.asReceiptToRemark = dataReader["asreceipttoremark"].ToString();
                    result.receiptAmount = double.Parse(dataReader["receiptamount"].ToString());
                    result.receiptPayType = dataReader["receiptpaytype"].ToString();
                    result.receiptDate = Convert.ToDateTime(dataReader["receiptdate"].ToString(), new CultureInfo("en-US"));
                    result.receiptBank = dataReader["receiptbank"].ToString();
                    result.receiptBillNumber = dataReader["receiptbillnumber"].ToString();
                    result.receiptChqBank = dataReader["receiptchqbank"].ToString();
                    result.receiptChqNumber = dataReader["receiptchqnumber"].ToString();
                    result.receiptOther = dataReader["receiptother"].ToString();
                    result.building = dataReader["building"].ToString();
                    result.telephone = dataReader["telephone"].ToString();
                }
                dataReader.Close();
                conn.CloseConnection();
                return Json(result);
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }

    }
}


/*

MySqlCommand command = new MySqlCommand();
string SQL = "INSERT INTO `twMCUserDB` (`mc_userName`, `mc_userPass`, `tw_userName`, `tw_userPass`) VALUES('@mcUserName', '@mcUserPass', '@twUserName', '@twUserPass')";
command.CommandText = SQL;
                command.Parameters.Add("@mcUserName", mcUserNameNew);
                command.Parameters.Add("@mcUserPass", mcUserPassNew);
                command.Parameters.Add("@twUserName", twUserNameNew);
                command.Parameters.Add("@twUserPass", twUserPassNew);
                command.Connection = connection;
                command.ExecuteNonQuery();
                connection.Close();

                //myDateTime = from System/Database Table
                //*** Thai Format
                Globalization.CultureInfo _cultureTHInfo = new Globalization.CultureInfo("th-TH");
                DateTime dateThai = Convert.ToDateTime(myDateTime, _cultureTHInfo);
                this.lblThai.Text = dateThai.ToString("dd MMM yyyy", _cultureTHInfo);

                //*** Eng Format
                Globalization.CultureInfo _cultureEnInfo = new Globalization.CultureInfo("en-US");
                DateTime dateEng = Convert.ToDateTime(myDateTime, _cultureEnInfo);
                this.lblEng.Text = dateEng.ToString("dd MMM yyyy", _cultureEnInfo);
                */
