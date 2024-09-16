using System;

namespace Shared.Core.ProductShared.Dto;

public class ClientFeedbackDto
{

    public Guid Id { get; set; }
    public double Raiting { get; set; }
    public string? Comment { get; set; }

    public List<string>? ProductAdvantages { get; set; }
    public List<string>? ProductDisadvantages { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid ProductId { get; set; }
    public string? UserId { get; set; }

}
