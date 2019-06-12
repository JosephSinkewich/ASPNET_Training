using System;
using System.Collections.Generic;

namespace Common.Model
{
    public class Record
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int PictureId { get; set; }
    }
}
