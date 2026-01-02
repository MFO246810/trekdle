using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trekdle.Models.DB_Models; 

[Table("Wordle_Question")]
public class Wordle_Question
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Required]
    [MaxLength(255)]
    [Column("Series_Name")]
    public string SeriesName { get; set; }

    [Column("Season_Number")]
    public int SeasonNumber { get; set; }

    [Column("Episode_Number")]
    public int EpisodeNumber { get; set; }

    [Required]
    [MaxLength(255)]
    [Column("Episode_Title")]
    public string EpisodeTitle { get; set; }

    [Column("Added_By")]
    public long AddedById { get; set; }

    // Navigation Properties
    [ForeignKey(nameof(AddedById))]
    public virtual Admin AddedBy { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    public virtual ICollection<Daily_Questions> DailyQuestions { get; set; } = new List<Daily_Questions>();
}