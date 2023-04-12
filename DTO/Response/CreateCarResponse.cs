using CQRSMediatRAutoMaperTask.Model;

namespace CQRSMediatRAutoMaperTask.DTO.Response
{
    public class CreateCarResponse
    {
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }

    }
}
