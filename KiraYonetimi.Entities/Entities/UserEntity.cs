using KiraYonetimi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiraYonetimi.Entities.Common;
using System.ComponentModel.DataAnnotations;




namespace KiraYonetimi.Entities.Entities
{
    public class User : BaseEntity<bool>
    {



        public User(int userId, string? fullName, int tcNo, string? email, int phone, string? plakaNo, bool role, ICollection<Payment>? payments, ApartUser? apartUser, ICollection<Message>? messages)
        {
            UserId = userId;
            FullName = fullName;
            TcNo = tcNo;
            Email = email;
            Phone = phone;
            PlakaNo = plakaNo;
            Role = role;
            Payments = payments;
            ApartUser = apartUser;
            Messages = messages;
        }
        [Key]
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public int TcNo { get; set; }
        public string? Email { get; set; }

        public int Phone { get; set; }

        public string? PlakaNo { get; set; }

        public bool Role { get; set; } // 1 ise admin, 0 ise user

        public virtual ICollection<Payment>? Payments { get; set; } = new List<Payment>();

        public virtual ApartUser? ApartUser { get; set; }



        public virtual ICollection<Message>? Messages { get; set; }

    };
};