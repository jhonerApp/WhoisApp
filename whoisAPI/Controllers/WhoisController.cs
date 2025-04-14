using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
using static whoisAPI.Model.WhoisModel;



namespace whoisAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WhoisController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public WhoisController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetWhoisData(string domain, string type)
        {
            var client = _httpClientFactory.CreateClient();
            var apiKey = _configuration["WhoisApi:ApiKey"];  // Retrieve the API Key from configuration
            var response = await client.GetAsync($"https://www.whoisxmlapi.com/whoisserver/WhoisService?apiKey={apiKey}&domainName={domain}");


            if (!response.IsSuccessStatusCode)
                return BadRequest("Failed to fetch domain data");

            var xml = await response.Content.ReadAsStringAsync();
            WhoisResponse data;

            try
            {
                var serializer = new XmlSerializer(typeof(WhoisResponse));
                using (var reader = new StringReader(xml))
                {
                    data = (WhoisResponse)serializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {
                return BadRequest("Error parsing Whois data");
            }

            if (type == "domain")
            {
                var createdDate = DateTime.TryParse(data.CreatedDate, out DateTime creationDate)
                                  ? creationDate
                                  : DateTime.UtcNow;
                var expiryDate = DateTime.TryParse(data.ExpiresDate, out DateTime expirationDate)
                                 ? expirationDate
                                 : DateTime.UtcNow.AddYears(1);  // Default expiry date if parsing fails

                var estimatedDomainAge = (DateTime.UtcNow - createdDate).Days / 365;

                var hostnames = data.NameServers?.HostNames?.Addresses ?? new List<string>();

                var formattedHostnames = string.Join(", ", hostnames.Select(h =>
                    h.Length > 25 ? h.Substring(0, 25) + "..." : h));


                return Ok(new WhoisInfoResponse
                {
                    Domain = data.DomainName,
                    Registrar = data.RegistrarName,
                    RegistrationDate = createdDate.ToString("yyyy-MM-dd"),
                    ExpirationDate = expiryDate.ToString("yyyy-MM-dd"),
                    EstimatedDomainAge = estimatedDomainAge,
                    Hostnames = formattedHostnames
                });
            }
            else if (type == "contact")
            {
                return Ok(new WhoisContactResponse
                {
                    RegistrantName = data.Registrant?.Name ?? "N/A",
                    TechnicalContactName = data.TechnicalContact?.Name ?? "N/A",
                    AdministrativeContactName = data.AdministrativeContact?.Name ?? "N/A",
                    ContactEmail = data.Registrant?.Email ?? "N/A"
                });
            }

            return BadRequest("Invalid type specified");
        }



    }

}
