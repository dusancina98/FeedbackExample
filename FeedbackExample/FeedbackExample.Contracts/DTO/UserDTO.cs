using FeedbackExample.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackExample.Contracts.DTO
{
    //Koristi se pri kreiranju objekta sa klijenta, u principu klijentska strana ne treba da zna da postoji bilo kakav Id, iz tog razloga je bolje na ovaj nacin slati podatka
    public class UserDTO
    {
        public string Username { get; set; }
    }
}
