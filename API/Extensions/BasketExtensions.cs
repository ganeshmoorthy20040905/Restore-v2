using System;
using API.DTOs;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class BasketExtensions
{
    public static BasketDto ToDto(this Basket basket)
    {
        return new BasketDto
        {
            BasketId = basket.BasketId,
            ClientSecret = basket.ClientSecret,
            paymenIntentId = basket.PaymentIntentId,
            Items = basket.Items.Select(x => new BasketItemDto
            {
                ProductId = x.ProductId,
                Name = x.Product.Name,
                Price = x.Product.Price,
                PictureUrl = x.Product.PictureUrl,
                Brand = x.Product.Brand,
                Type = x.Product.Type,
                Quantity = x.Quantity
            }).ToList()
        };
    }     
 
        public static async Task<Basket> GetBaksetWithItems(this IQueryable<Basket> query, string? basketId)
    {
          return await query
           .Include(x => x.Items)
           .ThenInclude(x => x.Product)
           .FirstOrDefaultAsync(x => x.BasketId == basketId) 
                ?? throw new Exception("cannot get basket ");
    }
}
