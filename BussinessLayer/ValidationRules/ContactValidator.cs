using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresini Boş Olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Olamaz");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj Boş Olamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(x => x.Message).MaximumLength(1000).WithMessage("Mesaj en fazla 1000 karakter olabilir.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Mesajın konusu en fazla 50 karakter olabilir.");
        }
    }
}
