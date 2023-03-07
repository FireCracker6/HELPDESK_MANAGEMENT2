SELECT *
FROM Tickets t
INNER JOIN Users u ON t.UsersId = u.Id
LEFT JOIN Comments c ON t.Id = c.TicketId

WHERE t.UsersId = 'f8c381a5-d569-4e40-8d5a-859b9e0f7524'
