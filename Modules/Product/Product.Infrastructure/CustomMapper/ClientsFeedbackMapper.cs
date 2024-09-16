using System;
using Product.Core.Domain;
using Shared.Core.ProductShared.Dto;

namespace Product.Infrastructure.CustomMapper;

public class ClientsFeedbackMapper
{
    public static ClientFeedbackDto ClientFeedbackToClientFeedbackDto(ClientFeedback clientFeedback)
        => new ClientFeedbackDto
        {
            Id = clientFeedback.Id,
            Raiting = clientFeedback.Raiting,
            Comment = clientFeedback.Comment,
            ProductAdvantages = clientFeedback.ProductAdvantages,
            ProductDisadvantages = clientFeedback.ProductDisadvantages,
            UserId = clientFeedback.UserId,
            ProductId = clientFeedback.ProductId
        };
    public static IEnumerable<ClientFeedbackDto> ClientFeedbackToClientFeedbackDto(IEnumerable<ClientFeedback> clientFeedbacks)
        => clientFeedbacks.Select(clientFeedback => new ClientFeedbackDto
            {
                Id = clientFeedback.Id,
                Raiting = clientFeedback.Raiting,
                Comment = clientFeedback.Comment,
                ProductAdvantages = clientFeedback.ProductAdvantages,
                ProductDisadvantages = clientFeedback.ProductDisadvantages,
                UserId = clientFeedback.UserId,
                ProductId = clientFeedback.ProductId
        });
    }
