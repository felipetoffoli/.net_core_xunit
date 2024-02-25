using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Tests
{
    public class VeiculoTest
    {
        [Fact (DisplayName = "Teste numero 1")]
        [Trait ("Funcionalidade", "Acelerar")]
        public void TestaAcelerar()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact (DisplayName = "Teste numero 2")]
        [Trait ("Funcionalidade", "Frear")]
        public void TestaFreiar()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }
        [Fact (DisplayName = "Teste numero 3", Skip = "Teste ainda não implementado")]
        public void ValidaNomeProprietario(){
            
        }

        
    }
}
