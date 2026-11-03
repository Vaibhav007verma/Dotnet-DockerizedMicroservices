using Microsoft.AspNetCore.Mvc;
using NotificationService.Model;
using NotificationService.Services;

namespace NotificationService.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationController : Controller
    {
        private readonly IEmailService _emailService;
        public NotificationController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        
        
        [HttpPost("email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            try
            {
                await _emailService.SendEmailAsync(request);

                return Ok(new
                {
                    Message = "Email sent successfully"
                }); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "Failed to send email",
                    Error = ex.Message
                });
            }


        }


    }
}
