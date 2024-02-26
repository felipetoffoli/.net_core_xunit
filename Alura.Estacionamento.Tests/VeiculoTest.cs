using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Tests
{
    public class VeiculoTest
    {

        private Veiculo veiculo;
        public VeiculoTest(){
            veiculo = new Veiculo();
        }

        [Fact]
        public void TestaAcelerarComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaFreiarComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }
        [Fact]
        public void ValidaNomeProprietarioDoVeiculo(){
            
        }

        [Fact]
        public void FichaDeInformacaoVeiculo(){
            //Arrage
           // Veiculo veiculo = new Veiculo();
            veiculo.Proprietario = "Carlos Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "EAP-7419";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Variante";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veiculo:", dados);
        }
        
    }
}
