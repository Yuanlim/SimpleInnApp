namespace SimpleInnApp.Domain.Interfaces;

public interface IValidator<T, R>
{
    public R? IsValid(T command);
}