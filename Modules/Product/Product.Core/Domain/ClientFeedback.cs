using System;

namespace Product.Core.Domain;

public class ClientFeedback
{
    /*
    Add UserDto information

    UserName,
    UserProfileImage,
    
    */

    private Guid _Id;
    private double _Raiting = default!;
    private string? _Comment;
    private List<string>? _ProductAdvantages;
    private List<string>? _ProductDisadvantages;
    public DateTime _CreatedDate = DateTime.UtcNow;
    private Guid _ProductId;
    private string? _UserId;



    public Guid Id { get => _Id; set => _Id = value; }
    public double Raiting { get => _Raiting; set => _Raiting = value; }
    public string? Comment { get => _Comment; set => _Comment = value; }

    public List<string>? ProductAdvantages { get => _ProductAdvantages; set => _ProductAdvantages = value; }
    public List<string>? ProductDisadvantages { get => _ProductDisadvantages; set => _ProductDisadvantages = value; }

    public DateTime CreatedDate { get => _CreatedDate; set => _CreatedDate = value; }

    public Guid ProductId { get => _ProductId; set => _ProductId = value; }
    public string? UserId { get => _UserId; set => _UserId = value; }



    public static double? RaitingAverage(List<double> raitings) => raitings.Average();
}
