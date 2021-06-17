using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Bırakılamaz");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar Adı En Fazla 50 Karakter Olabilir");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Soyadı Boş Bırakılamaz");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Yazar Soyadı En Fazla 50 Karakter Olabilir");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adresi Boş Bırakılamaz");
            RuleFor(x => x.WriterMail).MaximumLength(50).WithMessage("Yazar Mail Adresi En Fazla 50 Karakter Olabilir");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan Boş Bırakılamaz");
            RuleFor(x => x.WriterTitle).MaximumLength(50).WithMessage("Yazar Ünvanı En Fazla 50 Karakter Olabilir");
        }
    }
}
