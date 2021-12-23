using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tshop.Utility
{  // 1. add following code ref to docs : https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-6.0#:~:text=public%20static%20class,Deserialize%3CT%3E(value)%3B%0A%20%20%20%20%7D%0A%7D
    // 2. add this Addsession service to Startup.cs :  
    public static class SessionExtentions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)             //  got rid of the ? after T 
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }


    }
}
