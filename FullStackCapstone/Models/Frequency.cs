using System.ComponentModel.DataAnnotations;

namespace FullStackCapstone.Models;

public class Frequency
{
    public int Id { get; set; }

    [Required]
    public string Description { get; set; }

    public static readonly int DailyId = 1;
    public static readonly int WeeklyId = 2;
    public static readonly int BiWeeklyId = 3;
    public static readonly int MonthlyId = 4;
    public static readonly int QuarterlyId = 5;
    public static readonly int AnnuallyId = 6;

    public static readonly string Daily = "Daily";
    public static readonly string Weekly = "Weekly";

    public static readonly string BiWeekly = "Bi-Weekly";

    public static readonly string Monthly = "Monthly";

    public static readonly string Quarterly = "Quarterly";

    public static readonly string Annually = "Annually";

    public static IEnumerable<Frequency> GetPredefinedFrequencies()
    {
        return new[]
        {
            new Frequency { Id = DailyId, Description = Daily },
            new Frequency { Id = WeeklyId, Description = Weekly },
            new Frequency { Id = BiWeeklyId, Description = BiWeekly },
            new Frequency { Id = MonthlyId, Description = Monthly },
            new Frequency { Id = QuarterlyId, Description = Quarterly },
            new Frequency { Id = AnnuallyId, Description = Annually },
        };
    }
}
