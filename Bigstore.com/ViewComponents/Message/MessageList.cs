using Business.Abstract;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace Bigstore.com.ViewComponents.Message
{
    public class MessageList : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly AppDBContext _dBContext;

		public MessageList(IMessageService messageService, AppDBContext dBContext)
		{
			_messageService = messageService;
			_dBContext = dBContext;
		}

		public IViewComponentResult Invoke()
        {
            ViewBag.MessageCount = _dBContext.Messages.Count();
            var values = _messageService.GetAll();
            return View(values.OrderByDescending(r=>r.ID));
        }
    }
}
