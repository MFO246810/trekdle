using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trekdle.Models.DB_Models; 

[Table("Admin")]
public class Admin : IEntity
{
    [Key]
    public long Id { get; set; }

    [Required]
    [MaxLength(255)]
    [Column("username")]
    public string Username { get; set; }

    [Required]
    [MaxLength(255)]
    [Column("password")]
    public string Password { get; set; }

    [Required]
    [MaxLength(255)]
    [Column("email")]
    public string Email { get; set; }

    // Navigation Properties
    public virtual ICollection<Wordle_Question> WordleQuestions { get; set; } = new List<Wordle_Question>();
    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
}