using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Entities
{
    public class SessionToken
    {
        public SessionToken() { }
        public SessionToken(string jti,DateTime expirationDate,int userId)
        {
            this.Jti = jti;
            this.ExpirationDate = expirationDate;
            this.UserId = userId;
        }
        [Key]
        public string Jti { get; set; }
        public DateTime ExpirationDate { get; set; }

        public int UserId { get; set;}
        
        public User User { get; set; }


    }
}
