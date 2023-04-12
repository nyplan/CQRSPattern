using System.Collections.Generic;

namespace CQRSMediatRAutoMaperTask.Model
{
    public class Brand : BaseEntity
    {
        public ICollection<Car> Cars { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
