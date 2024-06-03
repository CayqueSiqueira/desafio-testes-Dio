using System;
using Xunit;
using NewTalents;

namespace TestNewTalents;

public class UnitTest1
{
    public Calculadora construirClasse() 
    {
        string data = "02/06/2024";
        Calculadora calc = new Calculadora(data);

        return calc;
    }

    [Theory]
    [InlineData(2, 2, 4)]
    [InlineData(9, 1, 10)]
    public void TestSomar(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse(); 
        int resultadoCalculadora = calc.somar(val1 , val2);
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(2, 1, 1)]
    [InlineData(7, 1, 6)]
    public void TestSubtrair(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();
        int resultadoCalculadora = calc.subtrair(val1 , val2);
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(1, 25, 25)]
    [InlineData(2, 3, 6)]
    public void TestMultiplicar(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();
        int resultadoCalculadora = calc.multiplicar(val1 , val2);
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(2, 2, 1)]
    [InlineData(10, 2, 5)]
    public void TestDividir(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();
        int resultadoCalculadora = calc.dividir(val1 , val2);
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Fact]
    public void TestarDivisaoPorZero()
    {
        Calculadora calc = construirClasse();
        Assert.Throws<DivideByZeroException>(() => calc.dividir(3, 0));
    }

    [Fact]
    public void TestarHistorico()
    {
        Calculadora calc = construirClasse();

        calc.somar(1, 2);
        calc.somar(2, 8);
        calc.somar(3, 7);
        calc.somar(4, 1);

        var lista = calc.historico();

        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count);
    }


}

