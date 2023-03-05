using System;
using System.Collections;
using System.Collections.Generic;
using HelpDeskManagement_WPF_MVVM_APP.Models;

internal class UserRoles
{
    public Guid RoleId { get; set; } = Guid.NewGuid();
    public string? RoleName { get; set; } 
}
internal class UsersEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public virtual ICollection<TicketsEntity> Tickets { get; set; } = new HashSet<TicketsEntity>();

    public static implicit operator UsersEntity(Ticket ticket)
    {
        return new UsersEntity
        {
            Id = ticket.UserId,
            Email = ticket.Email,
            FirstName= ticket.FirstName,
            LastName= ticket.LastName,
            
            
        };
    }

    public static implicit operator Ticket(UsersEntity usersEntity)
    {
        TicketsEntity ticketEntity = null!;
        return new Ticket
        {
          
            Email = usersEntity.Email,
            FirstName = usersEntity.FirstName,
            LastName= usersEntity.LastName,
          
        
      
        };
       
    }

   


}

internal class TicketsEntity
{
    public int Id { get; set; }
    public Guid UsersId { get; set; } 
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string TicketCategory { get; set; } = null!;
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    public DateTime? ClosedAt { get; set; }

    public virtual UsersEntity Users { get; set; } = null!;

    public static implicit operator Ticket(TicketsEntity entity)
    {
        return new Ticket
        {
            UserId = entity.Users.Id,
            Email = entity.Users.Email,
            FirstName = entity.Users.FirstName,
            LastName = entity.Users.LastName,
            Title = entity.Title,
            Description = entity.Description,
            TicketCategory = entity.TicketCategory,
            CreatedAt = entity.CreatedAt,

        };
    }

    public static implicit operator TicketsEntity(UsersEntity entity)
    {
        return new TicketsEntity
        {
            UsersId = entity.Id,
            
    
            

        };
    }
}

internal class TicketComments
{
    public int Id { get; set; }
    public int TicketId { get; set; }
    public string CommentsText { get; set; } = null!;
    public DateTime? CreatedAt { get; set; }
    
    public TicketsEntity Tickets { get; set; } = null!;
}

internal class TicketPriorities
{
    public int Id { get; set; } 
    public int TicketId { get; set; }
    public string PriorityName { get; set; } = null!;

    public TicketsEntity Tickets { get; set; } = null!;
}

internal class TicketStatuses
{
    public int Id { get; set; } 
    public int TicketId { get; set; }
    public string StatusName { get; set; } = null!;

    public TicketsEntity Tickets { get; set; } = null!;
}