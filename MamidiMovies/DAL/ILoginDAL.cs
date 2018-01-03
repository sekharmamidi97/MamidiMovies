using MamidiMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamidiMovies.DAL
{
    public interface ILoginDAL
    {
        LoginViewModel GetLoginInformationById(int loginId);
        LoginViewModel GetUsername(string username);
        LoginViewModel GetPassword(string password);
        LoginViewModel GetUsernamePassword(string username, string password);
        bool RegisterUser(LoginViewModel user);
    }
}
