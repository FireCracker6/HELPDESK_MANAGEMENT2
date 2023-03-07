
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HelpDeskManagement_WPF_MVVM_APP.Contexts;
using HelpDeskManagement_WPF_MVVM_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskManagement_WPF_MVVM_APP.Services;

internal class TicketService
{
    private readonly DataContext _context;

    public TicketService()
    {
        _context = new DataContext();
    }
    public async Task CreateAsync(Ticket ticket, string email)
    {
        UsersEntity usersEntity = ticket;
        usersEntity.Email = email;

        _context.Add(usersEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Ticket>> GetAll()
    {
        var _list = new List<Ticket>();

        foreach (var userEntity in await _context.Users.Include(x => x.Tickets).ToListAsync())
        //   foreach (var userEntity in await _context.Users.ToListAsync())
        {


            _list.Add(userEntity);
        }
        return _list;
    }

    //public async Task<IEnumerable<Ticket>> GetAsync(Guid userId)
    //{
    //    var ticketsEntities = await _context.Tickets
    //        .Include(t => t.Users)
    //        .Where(t => t.UsersId == userId)
    //        .ToListAsync();

    //    var tickets = ticketsEntities.Select(te => new Ticket
    //    {
    //        Id = te.Id,
    //        UsersId = te.Users.Id,
    //        FirstName = te.Users.FirstName,
    //        LastName = te.Users.LastName,
    //        Email = te.Users.Email,
    //        PhoneNumber = te.Users.PhoneNumber,
    //        Title = te.Title,
    //        Description = te.Description,
    //        CreatedAt = te.CreatedAt
    //    });

    //    return tickets;
    //}

    public async Task<IEnumerable<Ticket>> GetAsync(Guid userId)
    {
        var ticketsEntities = await _context.Tickets
            .Include(t => t.Users)
            .Include(t => t.Comments)
            .Where(t => t.UsersId == userId)
            .ToListAsync();

        var tickets = ticketsEntities.Select(te => new Ticket
        {
            Id = te.Id,
            UsersId = te.Users.Id,
            FirstName = te.Users.FirstName,
            LastName = te.Users.LastName,
            Email = te.Users.Email,
            PhoneNumber = te.Users.PhoneNumber,
            Title = te.Title,
            Description = te.Description,
            CreatedAt = te.CreatedAt,
            Comments = new List<TicketComments>
        {
            new TicketComments
            {
                Id = te.Comments.Id,
                TicketId = te.Comments.TicketId,
                CommentsText = te.Comments.CommentsText,
                CreatedAt = te.Comments.CreatedAt
            }
        }
        });

        return tickets;
    }














}
