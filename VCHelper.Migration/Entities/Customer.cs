using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace VCHelper.Migration.Entities
{
    [Table("customer")]
    internal class Customer
    {
        [Key]
        [Column("customer_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? CustomerId { get; set; }

        [Column("keyword")]
        public string? Keyword { get; set; }

        [Column("short_name")]
        public string ShortName { get; set; }

        [Column("full_name")]
        public string? FullName { get; set; }

        [Column("country")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Country { get; set; }

        [Column("legal_address")]
        public string LegalAddress { get; set; }

        [Column("inn")]
        public long? INN { get; set; }
    }
}
