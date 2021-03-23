using System;

namespace AstroGame.Shared.Models.Players
{
    public class Credentials
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
       
    }
}
