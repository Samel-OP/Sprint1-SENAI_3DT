using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Patrimonio.Test.Controllers
{
    public class LoginControllerTests
    {
        [Fact]
        public void Deve_Retornar_Usuario_Invalido()
        {
            // Pré-Condição
            var fakeRepo = new Mock<IUsuarioRepository>();
            fakeRepo
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((Usuario)null);

            var fakeViewModel = new LoginViewModel();
            fakeViewModel.Email = "samuel@email.com";
            fakeViewModel.Senha = "123456789";

            var controller = new LoginController(fakeRepo.Object);

            // Procedimento
            var resultado = controller.Login(fakeViewModel);

            // Resultado esperado
            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }

        [Fact]
        public void Deve_Retornar_Usuario_Valido()
        {
            Usuario fakeUsuario = new Usuario();
            fakeUsuario.Email = "paulo@gmail.com";

            //Arrange
            var fakeRepo = new Mock<IUsuarioRepository>();
            fakeRepo.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                    .Returns(fakeUsuario);

            var fakeViewModel = new LoginViewModel();
            fakeViewModel.Email = "paulo@gmail.com";
            fakeViewModel.Senha = "987654321";

            var controller = new LoginController(fakeRepo.Object);
            //Act
            var resultado = controller.Login(fakeViewModel);


            //Asert
            Assert.IsType<OkObjectResult>(resultado);
        }
    }
}
