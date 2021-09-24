using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.UI;
using CoreApp.Models;
using Kendo.Mvc.Extensions;
using System;

namespace CoreApp.Controllers
{
    public class GridController : Controller
    {

        public static List<ProductViewModel> dbProducts = Enumerable.Range(1, 50).Select(i => new ProductViewModel
        {
            ProductID = i,
            Price = i * 10,
            Discontinued = i % 2 ==0? true:false,
            UnitsInStock = i * 2,
            ProductName = "ProductName " + i
        }).ToList();

        public ActionResult Products_Read([DataSourceRequest] DataSourceRequest request)
        {
            var dsResult = dbProducts.ToDataSourceResult(request);
            return Json(dsResult);
        }

        public ActionResult Products_Create([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            product.ProductID = dbProducts.Count + 1;
            dbProducts.Add(product);
            return Json(new object[] { product }.ToDataSourceResult(request));
        }

        public ActionResult Products_Destroy([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            var productToDelete = dbProducts.Find(o=> o.ProductID == product.ProductID);
            for (int i = 0; i < dbProducts.Count; i++)
            {
                if (dbProducts[i].ProductID == product.ProductID)
                {
                    dbProducts.Remove(dbProducts[i]);
                    break;
                }
            }
            return Json(new object[] { product }.ToDataSourceResult(request));
        }

        public ActionResult Products_Update([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            var productToUpdate = dbProducts.Find(o => o.ProductID == product.ProductID);
            for (int i = 0; i < dbProducts.Count; i++)
            {
                if (dbProducts[i].ProductID == product.ProductID) {
                    dbProducts[i] = product;
                    break;
                }
            }
            return Json(new object[] { product }.ToDataSourceResult(request));
        }

        public JsonResult ListTest(int idTrang)
        {           
                Console.WriteLine("Id trang :" + idTrang);               
                List<TestModel> listTest = new List<TestModel>();
                listTest.Add(new TestModel("nghia", 40, 30.22f));
                listTest.Add(new TestModel("Oanh", 40, 36.21f));
                listTest.Add(new TestModel("Tan", 40, 32.75f));
                listTest.Add(new TestModel("Minh", 40, 34));
                listTest.Add(new TestModel("Long", 40, 30));
                listTest.Add(new TestModel("Truong", 40, 28));
                listTest.Add(new TestModel("Hai", 40, 36));
                listTest.Add(new TestModel("Khanh", 40, 32));
                listTest.Add(new TestModel("Dung", 40, 36));
                listTest.Add(new TestModel("Hao", 40, 40));
                listTest.Add(new TestModel("Oanh", 40, 36));
                listTest.Add(new TestModel("nghia", 40, 30.22f));
                listTest.Add(new TestModel("Oanh", 40, 36.21f));
                listTest.Add(new TestModel("Tan", 40, 32.75f));
                listTest.Add(new TestModel("Minh", 40, 34));
                listTest.Add(new TestModel("Long", 40, 30));
                listTest.Add(new TestModel("Truong", 40, 28));
               
                
            return Json(listTest);            
        }

            public ActionResult Months_Read([DataSourceRequest] DataSourceRequest request,int thang)
        {
            Console.WriteLine("Thang -"+thang);
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                List<DmThang> dmThangs = new List<DmThang>();
                dmThangs = context.DmThangs.ToList();
                if(dmThangs.Count>0)
                {
                    DataSourceResult dataSourceResult = dmThangs.ToDataSourceResult(request, month => new {
                        month.Id,
                        month.TenThang,
                        month.NgayBatDau,
                        month.NgayKetThuc
                    });
                    return Json(dataSourceResult);
                }
                else
                {
                    List<DmThang> listThang = new List<DmThang>();
                    DataSourceResult dataSourceResult = listThang.ToDataSourceResult(request, month => new {
                        month.Id,
                        month.TenThang,
                        month.NgayBatDau,
                        month.NgayKetThuc
                    });
                    return Json(dataSourceResult);
                }
                
            }
        }
        [HttpGet]
        public ActionResult Months_Read([DataSourceRequest] DataSourceRequest request)
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                IQueryable<DmThang> dmThangs = context.DmThangs;
                //if(dmThangs !=null)
                //{
                //    DataSourceResult dataSourceResult = dmThangs.ToDataSourceResult(request, month => new {
                //        month.Id,
                //        month.TenThang,
                //        month.NgayBatDau,
                //        month.NgayKetThuc
                //    });
                //    return Json(dataSourceResult);
                //}
                //else
                //{
                    List<DmThang> dmthang = new List<DmThang>();
                    DataSourceResult dataSourceResult = dmThangs.ToDataSourceResult(request, month => new {
                        month.Id,
                        month.TenThang,
                        month.NgayBatDau,
                        month.NgayKetThuc
                    });
                    return Json(dataSourceResult);
               // }
            }
        }

        public ActionResult Weeks_Read([DataSourceRequest] DataSourceRequest request, int idThang)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                //IQueryable<DmTuan> dmTuans = context.DmTuans.Where(tuan => tuan.Idthang==idThang);
                List<DmTuan> dmTuans = new List<DmTuan>();
                dmTuans = context.DmTuans.Where(tuan => tuan.Idthang == idThang).ToList();
                if(dmTuans.Count>0)
                {
                    DataSourceResult dataSourceResult = dmTuans.ToDataSourceResult(request, tuan => new {
                        tuan.Id,
                        tuan.Idthang,
                        tuan.SoThuTu,
                        tuan.TenTuan,
                        tuan.IsDaKhoa,
                        tuan.TuNgay,
                        tuan.DenNgay

                    });
                    return Json(dataSourceResult);
                }
                else
                {
                    List<DmTuan> dsTuan = new List<DmTuan>();
                    DataSourceResult dataSourceResult = dsTuan.ToDataSourceResult(request, tuan => new {
                        tuan.Id,
                        tuan.Idthang,
                        tuan.SoThuTu,
                        tuan.TenTuan,
                        tuan.IsDaKhoa,
                        tuan.TuNgay,
                        tuan.DenNgay

                    });
                    return Json(dataSourceResult);
                }
            }
        }

    }
}
