using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoCalidad.Domain.Entities {
    //This entity consist of: 
    public class AuditLog {
        [Key]
        public Guid AuditLogID { get; set; }

        [Required]
        [MaxLength (50)]
        public string UserID { get; set; }

        [Required]
        public DateTime EventDateUTC { get; set; }

        [Required]
        [MaxLength (1)]
        public string EventType { get; set; }

        [Required]
        [MaxLength (100)]
        public string TableName { get; set; }

        [Required]
        [MaxLength (100)]
        public string RecordID { get; set; }

        [Required]
        [MaxLength (100)]
        public string ColumnName { get; set; }

        public string OriginalValue { get; set; }

        public string NewValue { get; set; }
    }
}