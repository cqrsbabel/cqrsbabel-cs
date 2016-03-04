using System;

namespace CQRSBabel
{
  public interface IRequest
  {
    Guid Id { get; set; }
    object Token { get; set; }
    object Response { get; set; }
  }
}
