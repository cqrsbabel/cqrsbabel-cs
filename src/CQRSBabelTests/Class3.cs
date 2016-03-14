using CQRSBabel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TinyIoC;
using Xunit;

namespace CQRSBabelTests
{
  public class Class3 : IDisposable
  {
    //Primeiro test;
    MessengerHub _hub;

    public Class3()
    {
      var IoC = new IoC();
      _hub = IoC.Resolve<MessengerHub>();
      //_hub = TinyIoCContainer.Current.Resolve<MessengerHub>();
      //test = new Primeiro();

    }

    public void Dispose()
    {
      //test = null;
    }

    [Fact]
    public void PrimeiroTesteDoCommand4()
    {
      var query = new Primeiro.Query { Total = 20, Nome = "Daniel" };
      var query2 = new Primeiro.Query { Total = 10, Nome = "Marques" };

      string retorno = _hub.Publish(query) as string;

      string retorno2 = _hub.Publish(query2) as string;

      Assert.False(string.IsNullOrEmpty(retorno));
      Assert.False(string.IsNullOrEmpty(retorno2));
    }
  }

  class Primeiro
  {
    public class Query : Request<Handler>
    {
      public string Nome { get; set; }

      [Required(ErrorMessage = "Total is required!")]
      [Range(5, 20, ErrorMessage = "Must be between 5 and 20!")]
      public int? Total { get; set; }
    }

    public class Handler : CommandHandler<Query>
    {
      //private readonly Teste _teste;
      //private readonly Outro _outro;

      //public Handler(Teste teste, Outro outro) : base()
      //{
      //  _teste = teste;
      //  _outro = outro;
      //}

      public override void Handle(Query message)
      {
                //throw new Exception("teste erro");
        //_teste.NM_USUARIO = "Daniel";
        //message.Response = _teste;


        message.Response = "daniadsnisdani";

        Console.WriteLine("Message Recieved with ID: " + message.Id);
      }
    }


  }

}
