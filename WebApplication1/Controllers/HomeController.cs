using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Tren()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Tren(string KisiSayisi, bool FarkliVagon, String VagonBilgileri)
        {
            string[] VagonSayisi = VagonBilgileri.Split(';');
            string GeciciCikti = " ";
            string Cikti = " ";
            int kisisayisi_int = Int32.Parse(KisiSayisi);
            for (int i = 0; i < VagonSayisi.Length; i++)
            {
                string[] iVagonBilgileri = VagonSayisi[i].Split(',');
                int ivagonmax = Int32.Parse(iVagonBilgileri[1]) * 7 / 10;
                int ivagonbosyer = ivagonmax - int.Parse(iVagonBilgileri[2]);

                if (FarkliVagon == false)
                {
                            int c = kisisayisi_int - ivagonbosyer;                            
                             if(c<=0)
                            {
                                GeciciCikti += "Vagon Adı: " + iVagonBilgileri[0] + " Kişi Sayısı:" + kisisayisi_int;
                                kisisayisi_int = 0;
                            }
            
                }

                else
                {
                            int c = kisisayisi_int - ivagonbosyer;
                            if (c >= 0)
                            {
                                GeciciCikti += "Vagon Adı: " + iVagonBilgileri[0] + " Kişi Sayısı:" + ivagonbosyer;
                                kisisayisi_int = c;
                            }
                            else if(c<0)
                            {
                                GeciciCikti += "Vagon Adı: " + iVagonBilgileri[0] + " Kişi Sayısı:" + kisisayisi_int;
                                kisisayisi_int = 0;
                            }
                   
                }
                
            }
            if (kisisayisi_int == 0)
            {
                Cikti += GeciciCikti;
                
            }
            else {
                Cikti += "Rezervasyon yapılamaz";
            }
            ViewBag.Items = Cikti;
            return View();
        }


    }
}
