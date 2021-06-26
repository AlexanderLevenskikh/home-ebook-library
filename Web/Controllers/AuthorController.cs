using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;
using Web.ViewModels.Author;

namespace Web.Controllers
{
    [ApiController]
    [Route("/api/author")]
    public class AuthorController
    {
        public async Task<DtoList<AuthorDto>> GetAuthors(
            [FromQuery]
            GetAuthorsRequestDto request
        )
        {
                
        }
    }
}
