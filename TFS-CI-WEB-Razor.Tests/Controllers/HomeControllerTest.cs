using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TFS_CI_WEB_Razor;
using TFS_CI_WEB_Razor.Controllers;
using TFS_CI_WEB_Razor.Models;

namespace TFS_CI_WEB_Razor.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }


        [TestMethod]
        public void IndexSuma2Numeros()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;
            Assert.AreEqual("Home Page", result.ViewBag.Title);

            ModelSuma Sumamodel = new ModelSuma();

            Sumamodel.NumeroB = 2;
            Sumamodel.NumeroA = 1;



            ViewResult result2 = controller.ClickSubmitSuma(Sumamodel) as ViewResult;
            Assert.AreEqual(result.ViewBag.ResultadoSuma,"3");
        }



    }
}
