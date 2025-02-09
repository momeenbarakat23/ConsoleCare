using System.ComponentModel.DataAnnotations;

namespace Console_Care.Models
{
    public class Materials
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "الاسم")]
        public string Name { get; set; }
        [Display(Name = "المخزن")]
        public string Storage { get; set; }
        [Display(Name = "الكميه")]
        public int Quantity { get; set; }
        [Display(Name = "الكميه في المخزن")] public int? Quantityinstorage { get; set; }
        [Display(Name = "سعر الشراء")] public int priceForbuy { get; set; }
        [Display(Name = "سعر البيع المنزلي")]
        public int priceForHome { get; set; }
        [Display(Name = "سعر البيع للبلايستيشن")]
        public int priceForPs { get; set; }
        [Display(Name = "اقل كميه قبل الشراء")]
        public int minQuantity { get; set; }
        //public int MinQuantityToBuy { get; set; }

        public List<EmployeeMaterials>? employeeMaterialsmaterials { get; set; }
    }
}
