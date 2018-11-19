namespace LibraryMenagmentApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BookCopy
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? FK_Book { get; set; }

        public int? Numberofcopies { get; set; }

        public int? FK_Library { get; set; }

        public virtual Book Book { get; set; }

        public virtual Library Library { get; set; }
    }
}
