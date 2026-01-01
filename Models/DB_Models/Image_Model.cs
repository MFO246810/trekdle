using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trekdle.Models.DB_Models; 

[Table("Images")]
public class Image
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Url { get; set; }

    // Maps to ENUM('1'...'5')
    public Level Level { get; set; }

    [Column("Added_By")]
    public long AddedById { get; set; }

    [Column("Question_ID")]
    public long QuestionId { get; set; }

    // Navigation Properties
    [ForeignKey(nameof(AddedById))]
    public virtual Admin AddedBy { get; set; }

    [ForeignKey(nameof(QuestionId))]
    public virtual Wordle_Question Question { get; set; }
}