Select utenti.UserName , AspNetUserRoles.RoleId, AspNetRoles.Name
From AspNetUsers AS [utenti],
AspNetRoles ,
AspNetUserRoles 
WHERE
utenti.Id = AspNetUserRoles.UserId 
AND AspNetRoles.Id =AspNetUserRoles.UserId
/* Querri di join Utenti Ruolo */