using CQRSBabel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CQRSBabelTests
{
  public class Class3 : IDisposable
  {
    Primeiro test;

    public Class3()
    {
      test = new Primeiro();
    }

    public void Dispose()
    {
      test = null;
    }

    [Fact]
    public void PrimeiroTesteDoCommand4()
    {
      var query = new Primeiro.Query { Total = 20, Nome = "Daniel" };

      string retorno = Hub.Publish(query) as string;

      Assert.False(string.IsNullOrEmpty(retorno));
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
      public Handler() : base()
      {

      }
      //private readonly Teste _teste;
      //private readonly Outro _outro;

      //public Handler(Teste teste, Outro outro) : base()
      //{
      //  _teste = teste;
      //  _outro = outro;
      //}

      public override void Handle(Query message)
      {
        //_teste.NM_USUARIO = "Daniel";
        //message.Response = _teste;


        message.Response = "daniadsnisdani";

        Console.WriteLine("Message Recieved with ID: " + message.Id);
      }
    }


  }

}
