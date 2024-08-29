using System;

namespace Product.Core.Domain;

public class ClientFeedback
{
    /*
    Add UserDto information

    UserName,
    UserProfileImage,
    
    */
    public Guid Id { get; set; }
    public double Raiting { get; set; } = default!;
    public string? Comment { get; set; }
    public List<string>? ProductAdvantages { get; set; }
    public List<string>? ProductDisadvantages { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public string? ProductId { get; set; }
    public string? UserId { get; set; }



    public static double? RaitingAverage(List<double> raitings) => raitings.Average();
}
