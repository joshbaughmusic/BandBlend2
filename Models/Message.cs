using System.ComponentModel.DataAnnotations.Schema;

namespace BandBlend.Models;

public class Message
{
    public int Id { get; set; }
    public int MessageConversationId { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public string Body { get; set; }
    public DateTime Date { get; set; }
    public bool IsRead { get; set; }
    [ForeignKey("SenderId")]
    public UserProfile Sender { get; set; }
    [ForeignKey("ReceiverId")]
    public UserProfile Receiver { get; set; }
    public MessageConversation MessageConversation { get; set; }
}
