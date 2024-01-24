namespace Souccar.Hcpc.Units.Dto.Units
{
    public class UnitBaseDto
    {
        public string Name { get; set; }
        public int? ParentUnitId { get; set; }
        public ParentUnitDto ParentUnit { get; set; }
    }
}
