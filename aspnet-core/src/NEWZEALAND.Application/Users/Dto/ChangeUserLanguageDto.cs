using System.ComponentModel.DataAnnotations;

namespace NEWZEALAND.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}