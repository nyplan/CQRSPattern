
using System.Collections.Generic;
using System.Data;

namespace CQRSMediatRAutoMaperTask.Model
{
    public class Car : BaseEntity
    {
        public int Price { get; set; }
        public string Color { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
       
    }
}
