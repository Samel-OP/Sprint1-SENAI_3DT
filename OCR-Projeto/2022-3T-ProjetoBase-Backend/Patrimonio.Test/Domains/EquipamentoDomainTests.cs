
using Patrimonio.Domains;
using Xunit;

namespace Patrimonio.Test.Domains
{
    public class EquipamentoDomainTests
    {
        [Fact] // Descricao
        public void Deve_Retornar_Equipamento()
        {
            // Pré-Condição / Arrange
            Equipamento equipamento = new Equipamento();
            equipamento.Id = 1;
            equipamento.Imagem = "bao";
            equipamento.Descricao = "Muita qualidade";
            equipamento.Ativo = true;
            equipamento.DataCadastro = System.DateTime.Now;
            equipamento.NomePatrimonio = "Notebook da Raizher";

            // Procedimento / Act
            bool resultado = true;

            if(equipamento.Id == 0 || equipamento.Imagem == null || equipamento.Descricao == null || 
               equipamento.Ativo == null || equipamento.NomePatrimonio == null)
            {
                resultado = false;
            }

            // Resultado esperado / Assert
            Assert.True(resultado);
        }
    }
}
