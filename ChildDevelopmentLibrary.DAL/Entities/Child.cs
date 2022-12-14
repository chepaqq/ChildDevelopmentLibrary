using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChildDevelopmentLibrary.DAL.Entities
{
    public enum Status
    {
        Signed,
        IsStudying,
        CompletedStudies
    }
    public class Child
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public Status Status { get; set; } = Status.CompletedStudies;

        public int? ProgramId { get; set; }
        public EducationalProgram Program { get; set; }
    }
}
