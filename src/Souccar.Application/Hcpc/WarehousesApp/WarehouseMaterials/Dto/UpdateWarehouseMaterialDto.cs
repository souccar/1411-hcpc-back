using Abp.Application.Services.Dto;
using Souccar.Consts;
using Souccar.Validation.Date;
using System;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto
{
    public class UpdateWarehouseMaterialDto :EntityDto<int>
    {
        [Required(ErrorMessage = SouccarAppConstant.Required), ParseToDate(ErrorMessage = SouccarAppConstant.InvalidDate)]
        public string EntryDate { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required), Range(0, double.PositiveInfinity, ErrorMessage = SouccarAppConstant.LessThanZero)]
        public double InitialQuantity { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required), ParseToDate(ErrorMessage = SouccarAppConstant.InvalidDate)]
        public string ExpirationDate { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Code { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required), Range(0, double.PositiveInfinity, ErrorMessage = SouccarAppConstant.LessThanZero)]
        public double Price { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? UnitId { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? UnitPriceId { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? MaterialId { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? SupplierId { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? WarehouseId { get; set; }
    }
}
