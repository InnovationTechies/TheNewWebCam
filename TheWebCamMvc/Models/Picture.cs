using System.ComponentModel.DataAnnotations;

namespace TheWebCamMvc
{
    public class Picture
    {
        [Key]
        public int thePicID { get; set; }
        public byte[] Image { get;  set; }
        public string Name { get;  set; }

    }
}