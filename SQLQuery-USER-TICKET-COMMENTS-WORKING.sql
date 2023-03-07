SELECT *
FROM Tickets
INNER JOIN Comments
    ON Tickets.Id = Comments.TicketsId
INNER JOIN Users
    ON Tickets.UsersId = Users.Id;