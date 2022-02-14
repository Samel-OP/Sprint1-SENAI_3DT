
using Patrimonio.Utils;
using System.Text.RegularExpressions;
using Xunit;

namespace Patrimonio.Test.Utils
{
    public class CriptografiaTests
    {
        [Fact]
        public void Deve_Retornar_Hash_Em_BCrypt()
        {
            // Pré-Condição / Arrange
            var senha = Criptografia.GerarHash("MinhaSenha5285795");
            var regex = new Regex(@"^\$2[ayb]\$.{56}$");

            // Procedimento / Act
            var retorno = regex.IsMatch(senha);

            // Resultado esperado / Assert
            Assert.True(retorno);
        }

        [Fact]
        public void Deve_Retornar_Comparacao_Valida()
        {
            // Pré-Condição / Arrange
            var senha = "123456789";
            var hashBanco = "$2a$11$1HCuu94uJlFavk7P1W91xei3TkEtQpvlH5zGB.KgJDNdxTOjjC6DW";

            // Procedimento / Act
            var comparacao = Criptografia.Comparar(senha, hashBanco);

            // Resultado esperado / Assert
            Assert.True(comparacao);
        }
    }
}
