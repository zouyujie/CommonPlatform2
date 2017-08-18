using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Secom.Smp.Web.Home.Controllers;

namespace Secom.Smp.Web.Home.Controllers
{
    [TestClass]
    public class HomeControllerTest:Controller
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            //ViewResult result = controller.Index() as ViewResult;

            //// Assert
            //Assert.IsNotNull(result);
        }
        public JsonResult GetAlarmTotalInfo(string type)
        {
            OverViewController controller = new OverViewController();
            return controller.GetAlarmTotalInfo(type);
        }
    }
}
