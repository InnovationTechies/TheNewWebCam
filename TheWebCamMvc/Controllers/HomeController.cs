using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TheWebCamMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Capture()
        {
            try
            {
                if (img.Image != null)
                {
                    //Save First
                    Picture pic = new Picture();

                    Bitmap varBmp = new Bitmap(pictureBoxWeb.Image);
                    Bitmap newBitmap = new Bitmap(varBmp);
                    // varBmp.Save(@"C:\Users\s2132\source\repos\WebCamStreaming\WebCamStreaming\Pictures\" + DateTime.Now.ToString() + ".png", ImageFormat.Png);
                    byte[] data;
                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                    {
                        varBmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        data = stream.ToArray();
                    }
                    pic.Image = data;
                    pic.Name = "MyPicture" + DateTime.Now.ToString("yyyymmdd") + '_' + DateTime.Now.ToString("hhmmss");

                    if (pic.SavePicture())
                    {
                        MessageBox.Show("Saved");
                    }


                    //Now Dispose to free the memory
                    varBmp.Dispose();
                    varBmp = null;

                    MessageBox.Show("Picture is saved!", "Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                { MessageBox.Show("null exception"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return View();
        }

    }
}