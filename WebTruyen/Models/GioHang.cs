using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebTruyen.Models;

namespace WebTruyen.Models
{
    public class GioHang
    {
        WebTruyenDataContext data = new WebTruyenDataContext();
        public int matruyen { get; set; }

        [ Display(Name = "Tên truyện" ) ]
        public string tentruyen { get; set; }

        [Display(Name = "Ảnh bìa")]
        public string hinh { get; set; }

        [Display(Name = "Giá bán")]
        public Double giaban { get; set; }

        [Display(Name = "Số lượng")]
        public int iSoluong { get; set; }

        [Display(Name = "Thành tiền")]
        public Double dThanhtien
        {
            get { return iSoluong * giaban; }
        }

        public GioHang(int id)
        {
            matruyen = id;
            Truyen truyen = data.Truyens.Single(n => n.matruyen == matruyen);
            tentruyen = truyen.tentruyen;
            hinh = truyen.hinh;
            giaban = double.Parse(truyen.giaban.ToString());
            iSoluong = 1;
        }

    }
}