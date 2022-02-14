
using Patrimonio.Domains;
using Patrimonio.Utils;
using Xunit;

namespace Patrimonio.Test.Domains
{
    public class UsuarioDomainTest
    {
        [Fact] // Descrição
        public void Deve_Retornar_Usuario()
        {
            // Pré-Condição 
            Usuario usuario = new Usuario();
            usuario.Email = "paulo@email.com";
            usuario.Senha = "123456789";

            // Procedimento
            bool resultado = true;

            if(usuario.Senha == null || usuario.Senha == null)
            {
                resultado = false;
            }

            // Resultado esperado
            Assert.True(resultado);
        }
    }
}
