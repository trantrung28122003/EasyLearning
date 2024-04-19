using EasyLearning.Application.Services;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace EasyLearning.WebApp.Areas.admin.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public async Task<IActionResult> Index()
        {
            int amount = 50000;
            var url = await _paymentService.doPayment(amount.ToString(),"Cảm ơn quý khách");
            return Redirect(url);
        }

        public ActionResult ConfirmPaymentClient(MomoResult result)
        {
            //lấy kết quả Momo trả về và hiển thị thông báo cho người dùng (có thể lấy dữ liệu ở đây cập nhật xuống db)
            string rMessage = result.message;
            string rOrderId = result.orderId;
            string rErrorCode = result.errorCode; // = 0: thanh toán thành công
            if (rErrorCode == "0")
            {
                return View("SuccessPayment");
            }
            else
            {
                return View("FailurePayment");
            }
        }
    }
}
