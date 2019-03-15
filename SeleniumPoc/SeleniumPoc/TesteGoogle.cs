using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

public class Tests
{
    public static IWebDriver driver;

    [OneTimeSetUp]
    public void Setup()
    {
        //Inicializando o Driver
        if (driver == null)
            driver = new ChromeDriver(@"c:\Chromedriver");
    }

    [Test]
    public void TemperaturaGoogle()
    {
        //Inicializar Navegador
        driver.Navigate().GoToUrl("http://www.google.com");

        //Localizar Elemento e Preencher Campo
        driver.FindElement(By.Name("q")).SendKeys("weather");

        //Clicar Botao Submit
        driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);

        //Tempo de Espera
        Thread.Sleep(1000);
    }

    //Teste Com Sucesso
    [Test]
    public void CadastrarDados()
    {
        //Inicializar Navegador
        driver.Navigate().GoToUrl("https://automacaocombatista.herokuapp.com/users/new");

        //Preencher Campos
        //Nome
        driver.FindElement(By.Id("user_name")).SendKeys("Antonio");

        Thread.Sleep(1000);

        //SobreNome
        driver.FindElement(By.Id("user_lastname")).SendKeys("Lopes");

        Thread.Sleep(1000);

        //email
        driver.FindElement(By.Id("user_email")).SendKeys("antoniogeilson.ca@gmail.com");

        Thread.Sleep(1000);

        //Clicar Botao Criar
        driver.FindElement(By.Name("commit")).Click();

        Thread.Sleep(1000);

        //Assert de Validacao
        var textoMensagem = driver.FindElement(By.Id("notice")).Text;
        var textoEsperado = "Usuário Criado com sucesso";
        Assert.AreEqual(textoEsperado.Trim().ToLower(), textoMensagem.Trim().ToLower());
    }

    //Teste Falho
    [Test]
    public void AtualizarDados()
    {
        //Inicializar Navegador
        driver.Navigate().GoToUrl("https://automacaocombatista.herokuapp.com/users/6466/edit");

        //Nome
        var nome = driver.FindElement(By.Id("user_name"));
        nome.Clear();
        nome.SendKeys("Jose");

        Thread.Sleep(1000);

        //SobreNome
        var sobreNome = driver.FindElement(By.Id("user_lastname"));
        sobreNome.Clear();
        sobreNome.SendKeys("Pereira");

        Thread.Sleep(1000);

        //email
        var email = driver.FindElement(By.Id("user_email"));
        email.Clear();
        email.SendKeys("josePereira.ca@gmail.com");

        //Clicar Botao Criar
        driver.FindElement(By.Name("commit")).Click();

        Thread.Sleep(3000);

        //Assert de Validacao
        var textoMensagem = driver.FindElement(By.Id("notice")).Text;
        var textoEsperado = "Seu Usuário foi Atualizadoa!";
        Assert.AreEqual(textoEsperado.Trim().ToLower(), textoMensagem.Trim().ToLower());
    }
        
    [OneTimeTearDown]
    public void CleanUp()
    {
        driver.Quit();
    }
    
}
