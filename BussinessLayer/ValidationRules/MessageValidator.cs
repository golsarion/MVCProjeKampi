using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Adresini Girin").EmailAddress().WithMessage("Geçerli Bir Email Adresi Girin");
            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage("Konu Boş Olamaz!").MaximumLength(100).WithMessage("Konu En fazla 100 Karakter olabilir");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("İçerik Boş Olamaz!");
        }
    }
}
