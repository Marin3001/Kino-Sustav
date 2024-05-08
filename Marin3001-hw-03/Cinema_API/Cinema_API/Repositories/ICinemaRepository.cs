/*
**********************************
* Author: Marin Uzinić
* Project Task: Cinema --> Phase 2
**********************************
* Description:
*  
*  Implement `ICinemaRepository` interface
*
**********************************
*/

using Cinema_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_API.Repositories
{
    public interface ICinemaRepository
    {
        bool AddCinema(Cinema cinema);
        bool DeleteCinema(int id);
        List<Cinema> GetAllCinemas();
        Cinema GetCinemaById(int id);
        bool UpdateCinema(int id, Cinema updatedUpdated);

    }
}