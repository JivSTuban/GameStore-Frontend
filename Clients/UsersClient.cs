using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class UsersClient(HttpClient httpClient)
{
    public async Task<HttpResponseMessage> LoginUser(UserDetails user) { 
        return await httpClient.PostAsJsonAsync("login?useCookies=true", user); 
    }
}
