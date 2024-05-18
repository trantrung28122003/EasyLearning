using EasyLearning.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EasyLearning.WebApp.Controllers
{
    public class testController : Controller
    {
        [HttpPost]    
            public async Task<IActionResult> SubmitQuizResults(string trainingPartId)
            {
                try
                {

                    return Ok();
                }
                catch (Exception ex)
                {

                    return StatusCode(500, $"Lỗi: {ex.Message}");
                }
            }
        }
    }

