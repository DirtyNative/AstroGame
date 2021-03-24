using AstroGame.Shared.Models.Players;
using AutoMapper;
using System;

namespace AstroGame.Api.Communication.Models.Players
{
    [AutoMap(typeof(PlayerSpeciesPerk))]
    public class AddPlayerSpeciesPerkRequest
    {
        public Guid PerkId { get; set; }
    }
}