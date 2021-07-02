using ShopOnlineConnection;
using Startup_ShopOnline.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Startup_ShopOnline.Areas.Admin.Controllers
{
    public class SanPhamAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Admin/SanPhamAdmin
        public ActionResult Index()
        {
            return View(ShopOnlineBUS.DanhSachSP());
        }

        // GET: Admin/SanPhamAdmin/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Admin/SanPhamAdmin/Create
        public ActionResult Create()
        {
            ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNhaSanXuat", "TenNhaSanXuat");
            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham");
            return View();
        }

        // POST: Admin/SanPhamAdmin/Create
        [HttpPost]
        public ActionResult Create(SanPham sp)
        {
            try
            {
                sp.TinhTrang = "0";
                sp.SoLuongDaBan = 0;
                sp.LuotView = 0;
                sp.TinhTrang = "0";
                XElement xElement = new XElement("Images");
                xElement.Add(new XElement("Images", "/Asset/data/images/HinhChinh.jpg"));
                // TODO: Add insert logic here
                ShopOnlineBUS.InsertSP(sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPhamAdmin/Edit/5
        public ActionResult Edit(String id)
        {
            ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNhaSanXuat", "TenNhaSanXuat", ShopOnlineBUS.ChiTiet(id).MaNhaSanXuat);
            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham", ShopOnlineBUS.ChiTiet(id).MaLoaiSanPham);
            return View(ShopOnlineBUS.ChiTiet(id));
        }

        // POST: Admin/SanPhamAdmin/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(String id, SanPham sp)
        {
            //var tam = ShopOnlineBUS.ChiTiet(id);
            try
            {
                // TODO: Add update logic here
                //if (sp.SoLuongDaBan > 10000)
                //{
                //    sp.SoLuongDaBan = 0;
                //}
                //else { sp.SoLuongDaBan = tam.SoLuongDaBan; }
                //if (sp.LuotView > 10000) { sp.LuotView = 0; } else { sp.LuotView = tam.LuotView; }
                //sp.TinhTrang = tam.TinhTrang;
                sp.SoLuongDaBan = 0;
                sp.LuotView = 0;
                //XElement xElement = new XElement("Images");
                //xElement.Add(new XElement("Images", "/Asset/data/images/HinhChinh.jpg"));
                ShopOnlineBUS.UpdateSP(id, sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPhamAdmin/Delete/5
        public ActionResult Delete(String id)
        {
            return View(ShopOnlineBUS.ChiTiet(id));
        }

        // POST: Admin/SanPhamAdmin/Delete/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Delete(String id, SanPham sp)
        {
            //var tam = ShopOnlineBUS.ChiTiet(id);
            try
            {
                //if (tam.SoLuongDaBan > 10000)
                //{
                //    tam.SoLuongDaBan = 0;
                //}
                //if (tam.LuotView > 10000)
                //{
                //    tam.LuotView = 0;
                //}
                //if (tam.TinhTrang == "1")
                //{
                //    tam.TinhTrang = "0";
                //}
                //else
                //{
                //    tam.TinhTrang = "1";
                //}
                sp.TinhTrang = "1";
                // TODO: Add delete logic here
                ShopOnlineBUS.UpdateSP(id, sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
