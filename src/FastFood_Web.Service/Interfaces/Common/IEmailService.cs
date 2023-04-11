using FastFood_Web.Service.ViewModel.Helper;

namespace FastFood_Web.Service.Interfaces.Common
{
    public interface IEmailService
    {
        public Task<bool> SendAsync(EmailMessage emailMessage);
    }
}
