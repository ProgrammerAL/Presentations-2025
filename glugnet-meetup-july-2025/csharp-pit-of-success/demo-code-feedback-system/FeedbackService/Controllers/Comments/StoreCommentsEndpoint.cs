using System.ComponentModel.DataAnnotations;

using FeedbackService.Database;

using Microsoft.AspNetCore.Mvc;

namespace FeedbackService.Controllers.Comments;

[ApiController]
[Route("[controller]")]
public class StoreCommentsEndpoint : ControllerBase
{
    private readonly ICommentsRepository _commentsRepo;
    private readonly ILogger<StoreCommentsEndpoint> _logger;

    public StoreCommentsEndpoint(ICommentsRepository commentsRepo, ILogger<StoreCommentsEndpoint> logger)
    {
        _commentsRepo = commentsRepo;
        _logger = logger;
    }

    [HttpPost(Name = "store")]
    public async Task<IActionResult> StoreComments([FromBody, Required] StoreCommentsRequest request)
    {
        var entity = new CommentsRepository.StoreCommentsEntity(request.Rating, request.Comments, request.ContactInfo);
        var result = await _commentsRepo.StoreCommentsAsync(entity);

        if (result.IsError)
        {
            _logger.LogError("Failed to store comments");
            return StatusCode(500, "Failed to store comments");
        }

        return NoContent();
    }

    public class StoreCommentsRequest
    {
        [Required, Range(minimum: 1, maximum: 5)]
        required public int Rating { get; set; }

        [Required(AllowEmptyStrings = false)]
        required public string Comments { get; set; }

        public string? ContactInfo { get; set; }
    }
}
