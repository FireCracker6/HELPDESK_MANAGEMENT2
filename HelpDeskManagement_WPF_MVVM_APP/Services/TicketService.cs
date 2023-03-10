
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


    public async Task<IEnumerable<Ticket>> GetAsync(Guid userId)
    {
        var tickets = await _context.Tickets
            .Where(t => t.UsersId == userId)
            .Include(t => t.Users)
            .ToListAsync();

        //foreach (var ticket in tickets)
        //{
        //    ticket.Comments = await _context.Comments
        //        .Where(c => c.TicketId == ticket.Id)
        //        .ToListAsync();
        //}
        Debug.WriteLine(tickets.Count);
        return tickets.Select(t => (Ticket)t);
    }





}

