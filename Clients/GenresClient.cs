using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GenresClient
{
    private readonly Genre[] genres = [
        new(){
            Id = 1,
            Name = "Fighting"
        }
    ];

    public Genre[] GetGenres() => genres;

  
}
