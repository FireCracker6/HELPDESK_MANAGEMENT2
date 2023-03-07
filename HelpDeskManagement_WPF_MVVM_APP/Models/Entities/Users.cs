using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using HelpDeskManagement_WPF_MVVM_APP.Contexts;
using HelpDeskManagement_WPF_MVVM_APP.Models;
using Microsoft.EntityFrameworkCore;

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

    public DbContext Context { get; set; } // Add this line

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
    private readonly DataContext _context;

    public TicketsEntity(DataContext context)
    {
        _context = context;
    }

    // ot

    public int Id { get; set; }
    public Guid UsersId { get; set; } 
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string TicketCategory { get; set; } = null!;
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    public DateTime? ClosedAt { get; set; }

    public virtual UsersEntity Users { get; set; } = null!;
    public virtual TicketComments Comments { get; set; } = null!;

    public static implicit operator Ticket(TicketsEntity entity)
    {

        Debug.WriteLine("Converting TicketsEntity to Ticket: " + entity.UsersId);
        var context = entity._context;
        
        var ticket = new Ticket
        {
            Id = entity.Id,
            UsersId = entity.UsersId, // convert the UsersId property to the UserId property
            Email = entity.Users.Email,
            FirstName = entity.Users.FirstName,
            LastName = entity.Users.LastName,
            Title = entity.Title,
            Description = entity.Description,
            TicketCategory = entity.TicketCategory,
         
            CreatedAt = entity.CreatedAt,
        };

        var comments = context.Comments.Where(c => c.TicketId == entity.Id).ToList();


        foreach (var comment in comments)
        {
            ticket.Comments.Add(new TicketComments
            {
                Id = comment.Id,
                TicketId = comment.TicketId,
                CommentsText = comment.CommentsText,
                CreatedAt = comment.CreatedAt,
            });
        }

        return ticket;
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