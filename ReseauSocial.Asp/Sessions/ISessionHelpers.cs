using ReseauSocial.Asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.Sessions
{
    public interface ISessionHelpers
    {
        UserSession CurentUser { get; set; }
        void clearUserSession();


    }
}
