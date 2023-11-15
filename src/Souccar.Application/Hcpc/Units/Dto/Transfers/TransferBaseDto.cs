using Souccar.Hcpc.Units.Dto.Units;

namespace Souccar.Hcpc.Units.Dto.Transfers
{
    public class TransferBaseDto
    {
        public int FromId { get; set; }
        public int ToId { get; set; }
        public double Value { get; set; }
    }
}
