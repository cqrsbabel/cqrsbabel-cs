namespace CQRSBabel
{
  public interface IIoC
  {
    T Resolve<T>() where T : class;
    bool TryResolve<T>(out T resolvedType) where T : class;
  }
}