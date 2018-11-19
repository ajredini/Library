namespace LibraryMenagmentApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lending")]
    public partial class Lending
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? FK_Book { get; set; }

        public int? FK_Client { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateofreceipt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReturnDate { get; set; }

        public virtual Book Book { get; set; }

        public virtual Client Client { get; set; }
    }
}
