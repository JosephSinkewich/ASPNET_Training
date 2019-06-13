using System;

namespace TrnAPI_01.Models
{
    public class CreateRecordViewModel
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int PictureId { get; set; }
    }
}