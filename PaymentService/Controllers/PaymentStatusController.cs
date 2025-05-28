using Microsoft.AspNetCore.Mvc;

namespace PaymentService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentStatusController : ControllerBase
{
    private static readonly Dictionary<Guid, string> _fakeStatuses = new()
    {
        { Guid.Parse("11111111-1111-1111-1111-111111111111"), "Paid" },
        { Guid.Parse("22222222-2222-2222-2222-222222222222"), "Pending" },
    };

    [HttpGet("{orderId}")]
    public IActionResult GetStatus(Guid orderId)
    {
        if (_fakeStatuses.TryGetValue(orderId, out var status))
        {
            return Ok(new { orderId, status });
        }
        return NotFound();
    }
}