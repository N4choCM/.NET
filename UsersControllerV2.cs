using APIVersionControl.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APIVersionControl.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private const string ApiTestUrl = "https://dummyapi.io/data/v1/user?limit=30";
        private const string AppId = "62dab1f3e8536456c06b31a7";
        private readonly HttpClient _httpClient;

        public UsersController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("2.0")]
        [HttpGet(Name = "GetUsersData")]
        public async Task<IActionResult> GetUserDataAsync()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("app-id", AppId);

            var response = await _httpClient.GetStreamAsync(ApiTestUrl);

            var usersData = await JsonSerializer.DeserializeAsync<UsersResponseData>(response);

            var users = usersData?.data;

            return Ok(users);
        }
    }
}
