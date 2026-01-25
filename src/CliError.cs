namespace UtilityCli;

/// <summary>
/// Represents the kind of error that occurred during CLI parsing.
/// </summary>
public enum CliErrorKind
{
    /// <summary>A required argument was not provided.</summary>
    MissingRequiredArgument,

    /// <summary>A required option was not provided.</summary>
    MissingRequiredOption,

    /// <summary>An argument value could not be converted to the expected type.</summary>
    InvalidArgumentValue,

    /// <summary>An option value could not be converted to the expected type.</summary>
    InvalidOptionValue,

    /// <summary>Options were accessed after arguments, causing ambiguity.</summary>
    OptionsAfterArguments,

    /// <summary>An option was accessed with an incompatible type.</summary>
    OptionTypeMismatch,
}

/// <summary>
/// Contains detailed information about a CLI parsing error.
/// </summary>
public sealed class CliError
{
    /// <summary>
    /// Gets the kind of error that occurred.
    /// </summary>
    public CliErrorKind Kind { get; }

    /// <summary>
    /// Gets the error message describing what went wrong.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Gets the exception that will be thrown after the error callback completes.
    /// </summary>
    public Exception Exception { get; }

    /// <summary>
    /// Gets the name of the option that caused the error, if applicable.
    /// </summary>
    public string? OptionName { get; }

    /// <summary>
    /// Gets the expected type for the argument or option value.
    /// </summary>
    public Type? ExpectedType { get; }

    /// <summary>
    /// Gets the raw value that could not be parsed, if applicable.
    /// </summary>
    public string? RawValue { get; }

    internal CliError(
        CliErrorKind kind,
        string message,
        Exception exception,
        string? optionName = null,
        Type? expectedType = null,
        string? rawValue = null)
    {
        Kind = kind;
        Message = message;
        Exception = exception;
        OptionName = optionName;
        ExpectedType = expectedType;
        RawValue = rawValue;
    }
}
