using System.ComponentModel;

namespace PicPayChallenge.Authentication.Domain.Users.Enums
{
    public enum UserTypeEnum
    {
        [Description("Common")]
        Comum = 0,
        [Description("Store")]
        Lojista = 1,
    }
}
