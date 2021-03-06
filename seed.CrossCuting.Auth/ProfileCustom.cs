using Common.Domain.Model;
using IdentityModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Seed.CrossCuting
{
    public class ProfileCustom
    {

        enum Role
        {
            Admin = 1,
            Tenant = 2,
            Owner = 3,
        }

        public static Dictionary<string, object> Claims(Dictionary<string, object> _claims)
        {

            var role = GetRole(_claims);

            if (role.ToLower() == Role.Admin.ToString().ToLower())
                _claims.AddRange(ClaimsForAdmin());

            return _claims;
        }

        private static string GetRole(Dictionary<string, object> _claims)
        {
            var role = _claims.Where(_ => _.Key == "role").SingleOrDefault();
            return role.Value.IsNotNull() ? role.Value.ToString() : "--";
        }

        public static Dictionary<string, object> ClaimsForAdmin()
        {
            var tools = new List<dynamic>
            {
                new { Icon = "fa fa-edit", Name = "Sample", Route = "/sample" },
                new { Icon = "fa fa-edit", Name = "SampleType", Route = "/sampletype" },
                new { Icon = "fa fa-edit", Name = "SampleTag", Route = "/sampletag" },
                new { Icon = "fa fa-edit", Name = "ManySampleType", Route = "/manysampletype" },
                new { Icon = "fa fa-edit", Name = "SampleDash", Route = "/sampledash" },

            };
            var _toolsForAdmin = JsonConvert.SerializeObject(tools);
            return new Dictionary<string, object>
            {
                { "tools", _toolsForAdmin }
            };
        }

        public static Dictionary<string, object> ClaimsForTenant(int tenantId, string name, string email)
        {

            var tools = new List<dynamic>
            {
                new { Icon = "fa fa-edit", Name = "Tool", Route = "#/Url" },
            };

            var _toolsForSubscriber = JsonConvert.SerializeObject(tools);
            return new Dictionary<string, object>
            {
                { "tools", _toolsForSubscriber }
            };
        }

    }
}
