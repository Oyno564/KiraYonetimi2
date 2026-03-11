using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;



namespace KiraYonetimi.Entities.Common
{
    public abstract  class BaseEntity
    {



        [Key]

        [SwaggerSchema(ReadOnly = true)]
        public Guid   PkId { get; set; }
        public bool IsActive { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public DateTime CreatedDate { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public DateTime UpdatedDate { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public DateTime DeletedDate { get; set; }


      
       

      
     
    }
}
