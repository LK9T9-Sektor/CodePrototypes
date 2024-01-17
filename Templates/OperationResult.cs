namespace Templates;

/// <summary>
/// Результат выполнения операции
/// </summary>
public class OperationResult
{
    public const string ErrorWithoutDescription = "[Ошибка без описания]";

    protected OperationResult(string? errorMessage = null)
    {
        _error = errorMessage;
    }

    protected string? _error = string.Empty;
    public string? Error => _error;

    public bool IsSuccess => string.IsNullOrEmpty(_error);

    /// <summary>
    /// Неудачное выполнение операции
    /// </summary>
    /// <param name="errorMessage">Текст ошибки</param>
    /// <returns></returns>
    public static OperationResult Fail(string? errorMessage)
    {
        if (string.IsNullOrEmpty(errorMessage))
        {
            errorMessage = ErrorWithoutDescription;
        }

        return new OperationResult(errorMessage);
    }

    /// <summary>
    /// Успешное выполнение операции
    /// </summary>
    /// <returns></returns>
    public static OperationResult Ok()
    {
        return new OperationResult();
    }

}

public class OperationResult<T> : OperationResult
{
    protected internal OperationResult(T? data, string? errorMessage = null)
        : base(errorMessage)
    {
        Data = data;
    }

    public T? Data { get; set; } = default!;

    public new bool IsSuccess => Data is not null && string.IsNullOrEmpty(_error);

    /// <summary>
    /// Неудачное выполнение операции
    /// </summary>
    /// <param name="errorMessage">Текст ошибки</param>
    /// <returns></returns>
    public static new OperationResult<T> Fail(string? errorMessage)
    {
        if (string.IsNullOrEmpty(errorMessage))
        {
            errorMessage = ErrorWithoutDescription;
        }

        return new OperationResult<T>(default, errorMessage);
    }

    /// <summary>
    /// Успешное выполнение операции
    /// </summary>
    /// <param name="data">Данные</param>
    /// <returns></returns>
    public static OperationResult<T> Ok(T data)
    {
        return new OperationResult<T>(data);
    }

}
