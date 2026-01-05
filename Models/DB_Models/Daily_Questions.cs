using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trekdle.Models.DB_Models;

[Table("Daily_Questions")]
public class Daily_Questions: IEntity
{
    [Key]
    public long Id { get; set;}

    [Required]
    [Column("Question_ID")]
    public long QuestionId { get; set;}

    [Required]
    [Column("Date")]
    public DateTime Date{ get; set;}

    [ForeignKey(nameof(QuestionId))]
    public virtual Wordle_Question Question { get; set; }
}