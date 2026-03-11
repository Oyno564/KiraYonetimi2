using KiraYonetimi.Entities.Common;
using KiraYonetimi.Entities.Entities;
using System.Collections.Generic;



namespace KiraYonetimi.Entities.Entities
{
    public class User : BaseEntity
    {
        public User() { }

        // Sadece scalar (mapped) property’ler ctor’da olabilir
        public User(int userId, string? fullName, string? password, string tcNo,
                    string? email, string phone, string? plakaNo, bool role, Guid PkId)
        {
            UserId = userId;
            FullName = fullName;
            Password = password;
            TcNo = tcNo;
            Email = email;
            Phone = phone;
            PlakaNo = plakaNo;
            Role = role;
            this.PkId = PkId;
        }


        // BaseEntity zaten [Key] Guid PkId verdiği için BURADA [Key] KULLANMA.
        public int UserId { get; set; }  // PK değil, normal alan

        public string? FullName { get; set; }
        public string TcNo { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string Phone { get; set; }
        public string? PlakaNo { get; set; }
        public bool Role { get; set; } // 1 admin, 0 user

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ApartUser? ApartUser { get; set; }
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    }

}