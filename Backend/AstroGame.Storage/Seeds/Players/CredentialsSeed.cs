using AstroGame.Shared.Models.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Players
{
    public class CredentialsSeed : IEntityTypeConfiguration<Credentials>
    {
        public void Configure(EntityTypeBuilder<Credentials> builder)
        {
            var passwordBytes = new byte[]
            {
                214,
                212,
                211,
                33,
                140,
                160,
                231,
                162,
                57,
                199,
                64,
                131,
                187,
                201,
                119,
                192,
                203,
                109,
                243,
                123,
                229,
                56,
                47,
                180,
                17,
                5,
                138,
                178,
                72,
                221,
                137,
                25,
                69,
                173,
                181,
                157,
                202,
                130,
                182,
                172,
                20,
                121,
                129,
                43,
                136,
                74,
                120,
                242,
                126,
                100,
                62,
                207,
                24,
                9,
                244,
                206,
                7,
                166,
                63,
                155,
                128,
                118,
                47,
                81
            };
            var saltBytes = new byte[]
            {
                193,
                79,
                225,
                80,
                112,
                24,
                191,
                243,
                40,
                86,
                90,
                75,
                6,
                166,
                103,
                215,
                30,
                13,
                70,
                153,
                161,
                73,
                23,
                145,
                154,
                13,
                46,
                5,
                245,
                103,
                100,
                241
            };

            builder.HasData(
                new Credentials()
                {
                    Id = Guid.Parse("00000000-0000-0000-1110-000000000000"),
                    PlayerId = Guid.Parse("22222222-0000-0000-0000-000000000000"),
                    Email = "daniel@dirtyandnative.de",
                    Password = passwordBytes,
                    Salt = saltBytes,
                },
                new Credentials()
                {
                    Id = Guid.Parse("00000000-0000-0000-1110-000000000001"),
                    PlayerId = Guid.Parse("22222222-0000-0000-0000-000000000001"),
                    Email = "test1@dirtyandnative.de",
                    Password = passwordBytes,
                    Salt = saltBytes,
                },
                new Credentials()
                {
                    Id = Guid.Parse("00000000-0000-0000-1110-000000000002"),
                    PlayerId = Guid.Parse("22222222-0000-0000-0000-000000000002"),
                    Email = "test2@dirtyandnative.de",
                    Password = passwordBytes,
                    Salt = saltBytes,
                }
            );
        }
    }
}