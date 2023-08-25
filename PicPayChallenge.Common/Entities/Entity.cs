using PicPayChallenge.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Common.Entities
{
    public abstract class Entity
    {
        public virtual int Id { get; protected set; }

        public Entity() { }

        public Entity(int id) 
        {
            SetId(id);
        }

        public virtual void SetId(int id) 
        {
            if (id <= 0)
                throw new BadRequestException("Id must have be a positive number");
        }
    }
}
