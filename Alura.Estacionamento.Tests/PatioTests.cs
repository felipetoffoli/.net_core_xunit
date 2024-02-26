using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Tests
{
   
    public class PatioTests: IDisposable
    {
        private Veiculo veiculo;
        private Patio estacionamento;
        public ITestOutputHelper SaidaConsoleTeste;
        public PatioTests(ITestOutputHelper _saidaConsoleTeste){
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor Invocado.");
            
            veiculo = new Veiculo();
            estacionamento = new Patio();
            
        }


        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComVeiculo()
        {
            // Arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();

            veiculo.Proprietario = "André Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Vermelo";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            Double faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("André Silva", "ASD-1498", "Preto", "Gol")]
        [InlineData("José Silva", "ASF-1499", "Preto", "Gol")]
        [InlineData("Maria Silva", "ASA-1497", "Cinza", "Gol")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculo(string proprietario,
                                                       string placa,
                                                        string cor,
                                                         string modelo)
        {
            // Arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();

            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            Double faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ASD-1498", "Preto", "Gol")]
        public void LocalizaVeiculoPatioComBaseNaPlaca(string proprietario,
                                                       string placa,
                                                        string cor,
                                                         string modelo)
        {
             // Arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();

            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(veiculo.Placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void AlterarDadosVeiculoDoProprioVeiculo(){
               // Arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();

            veiculo.Proprietario = "André Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Vermelo";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "André Silva";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Preto";
            veiculoAlterado.Modelo = "Fusca";
            veiculoAlterado.Placa = "asd-9999";
            
            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculo.Cor);

        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose Invocado.");
        }
    }

}
