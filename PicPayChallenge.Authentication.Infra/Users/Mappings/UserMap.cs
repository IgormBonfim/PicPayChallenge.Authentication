using FluentNHibernate.Mapping;
using PicPayChallenge.Authentication.Domain.Users.Entities;
using PicPayChallenge.Authentication.Domain.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Authentication.Infra.Users.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("User");
            Id(x => x.Id).Column("UserId").GeneratedBy.Identity();
            Map(x => x.FullName).Column("FullName");
            Map(x => x.DocumentNumber).Column("DocumentNumber");
            Map(x => x.Email).Column("Email");
            Map(x => x.Password).Column("Password");
            Map(x => x.UserType).Column("UserType").CustomType<UserTypeEnum>();
            Map(x => x.CreatedAt).Column("CreatedAt");
            Map(x => x.UpdatedAt).Column("UpdatedAt");
        }
    }
}