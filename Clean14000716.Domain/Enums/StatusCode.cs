using System.ComponentModel.DataAnnotations;

namespace Clean14000716.Domain.Enums
{
    public enum StatusCode
    {
        [Display(Description = "درخواست بد")]
        BadRequest = 0,
        [Display(Description = "یافت نشد")]
        NotFound = 1,
        [Display(Description = "موفق")]
        Success = 2,
        [Display(Description = "خطای سرور")]
        ServerError = 3,
        [Display(Description = "خطای منطقی")]
        LogicError = 4,
        [Display(Description = "خطای احراز هویت")]
        UnAuthorized = 5
    }
}