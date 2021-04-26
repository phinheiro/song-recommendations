namespace Conexia.SR.WebAPI.Extensions
{
    public class JwtAppSettings
    {
        public string Secret { get; set; }
        public int ExpirationHours { get; set; }
        public string Issuer { get; set; }
        public string ValidAt { get; set; }
    }
}
