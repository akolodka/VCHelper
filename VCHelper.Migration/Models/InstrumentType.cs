using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VCHelper.Migration.Models
{
    [Table("typeofInstrument")]
    internal class InstrumentType
    {
        [Key]
        [Column("type_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? TypeId { get; set; }

        [Column("reg_num")]
        public string? RegNumber { get; set; }

        [Column("type_name")]
        public string TypeName { get; set; }

        [Column("full_name")]
        public string? FullName { get; set; }

        [Column("methodic")]
        public string? Methodic { get; set; }

        [Column("manufacturer_id")]
        public int? ManufacturerId { get; set; }
    }
}
