using AstroGame.Shared.Models.Chats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Conversations
{
    public class ConversationParticipantEntityTypeConfiguration : IEntityTypeConfiguration<ConversationParticipant>
    {
        public void Configure(EntityTypeBuilder<ConversationParticipant> builder)
        {
            builder.ToTable("ConversationParticipants");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.Conversation)
                .WithMany(e => e.Participants)
                .HasForeignKey(e => e.ConversationId);

            builder.HasOne(e => e.Player)
                .WithMany()
                .HasForeignKey(e => e.PlayerId);
        }
    }
}
