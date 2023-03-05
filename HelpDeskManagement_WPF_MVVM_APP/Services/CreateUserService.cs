using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskManagement_WPF_MVVM_APP.Services
{
    internal class CreateUserService
    {
        public CreateUserService() { 
        
        
        }  
        public async Task CreateUser()
        {
         
                var userService = new UserService();

                var userEntity = new UsersEntity();

                var ticketUserService = new TickerUserService();

                var ticket = new UsersEntity()
                {


                    FirstName = "Tommy",
                    LastName = "Johansson",
                    Email = "tommy@domain.com",

                };

                UsersEntity usersEntity = ticket;

                userEntity = await userService.CreateAsync(ticket);

                TicketsEntity ticketUserEntity = ticket;
                ticketUserEntity.UsersId = usersEntity.Id;

           
        }
    }
}
