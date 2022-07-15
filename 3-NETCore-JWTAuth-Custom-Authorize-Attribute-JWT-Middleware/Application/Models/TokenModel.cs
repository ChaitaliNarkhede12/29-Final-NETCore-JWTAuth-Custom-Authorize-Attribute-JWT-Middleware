using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class TokenModel
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiryTime { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
    }
}
