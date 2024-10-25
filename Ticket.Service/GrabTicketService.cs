namespace Ticket.Service;

/// <summary>
/// 搶票服務
/// </summary>
public class GrabTicketService : IGrabTicketService
{
    public async Task<bool> BuyTicketAsync(Guid memberId, Guid ticketId, int quantity = 1)
    {
        // 確認身分
        
        // 檢查售票數
        
        // Lock
        
        // 買票
        
        // 

        return true;
    }
}