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

    public void AddError(string? errorMessage)
    {
        _error = errorMessage;
    }

    /// <summary>
    /// Неудачное выполнение операции
    /// </summary>
    /// <param name="errorMessage">Текст ошибки</param>
    /// <returns></returns>
    public static OperationResult Fail(string errorMessage)
    {
        return new OperationResult(errorMessage);
    }

    /// <summary>
    /// Успешное выполнение операции
    /// </summary>
    /// <returns></returns>
    public static OperationResult Success()
    {
        return new OperationResult();
    }

}

/// <summary>
/// Результат выполнения операции, с данными типа T
/// </summary>
public class OperationResult<T> : OperationResult
{
    protected internal OperationResult(T? data, string? errorMessage = null)
        : base(errorMessage)
    {
        Data = data;
    }

    public T? Data { get; private set; } = default!;

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
    public static OperationResult<T> Success(T data)
    {
        return new OperationResult<T>(data);
    }

}
