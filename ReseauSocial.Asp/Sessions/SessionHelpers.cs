using ReseauSocial.Asp.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.Sessions
{
    public class SessionHelpers : ISessionHelpers
    {
        private readonly ISession _session;

        public SessionHelpers(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }


        public UserSession CurentUser
        {
            get
            {
                if (!_session.Keys.Contains(nameof(CurentUser)))
                    return null;

                if (_session.GetString(nameof(CurentUser)) is null)
                    return null;

                return JsonConvert.DeserializeObject<UserSession>(_session.GetString(nameof(CurentUser)));
            }
            set
            {
                _session.SetString(nameof(CurentUser), JsonConvert.SerializeObject(value));
            }
        }


        public void clearUserSession()
        {
            _session.Remove(nameof(CurentUser));
        }

    }
}
