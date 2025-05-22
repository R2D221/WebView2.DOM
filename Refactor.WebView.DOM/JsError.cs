using System;

namespace Refactor.WebView2.DOM;

public class JsError : Exception
{
	public JsError() { }
	public JsError(string? message) : base(message) { }
	public JsError(string message, Exception innerException) : base(message, innerException) { }
}

public class EvalError : JsError
{
	public EvalError() { }
	public EvalError(string? message) : base(message) { }
	public EvalError(string message, Exception innerException) : base(message, innerException) { }
}

public class RangeError : JsError
{
	public RangeError() { }
	public RangeError(string? message) : base(message) { }
	public RangeError(string message, Exception innerException) : base(message, innerException) { }
}

public class ReferenceError : JsError
{
	public ReferenceError() { }
	public ReferenceError(string? message) : base(message) { }
	public ReferenceError(string message, Exception innerException) : base(message, innerException) { }
}

public class TypeError : JsError
{
	public TypeError() { }
	public TypeError(string? message) : base(message) { }
	public TypeError(string message, Exception innerException) : base(message, innerException) { }
}

public class SyntaxError : JsError
{
	public SyntaxError() { }
	public SyntaxError(string? message) : base(message) { }
	public SyntaxError(string message, Exception innerException) : base(message, innerException) { }
}

public class URIError : JsError
{
	public URIError() { }
	public URIError(string? message) : base(message) { }
	public URIError(string message, Exception innerException) : base(message, innerException) { }
}

public class DOMException : JsError
{
	public DOMException() { }
	public DOMException(string? message) : base(message) { }
	public DOMException(string message, Exception innerException) : base(message, innerException) { }
}

public class IndexSizeError : DOMException
{
	public IndexSizeError() { }
	public IndexSizeError(string? message) : base(message) { }
	public IndexSizeError(string message, Exception innerException) : base(message, innerException) { }
}

public class HierarchyRequestError : DOMException
{
	public HierarchyRequestError() { }
	public HierarchyRequestError(string? message) : base(message) { }
	public HierarchyRequestError(string message, Exception innerException) : base(message, innerException) { }
}

public class WrongDocumentError : DOMException
{
	public WrongDocumentError() { }
	public WrongDocumentError(string? message) : base(message) { }
	public WrongDocumentError(string message, Exception innerException) : base(message, innerException) { }
}

public class InvalidCharacterError : DOMException
{
	public InvalidCharacterError() { }
	public InvalidCharacterError(string? message) : base(message) { }
	public InvalidCharacterError(string message, Exception innerException) : base(message, innerException) { }
}

public class NoModificationAllowedError : DOMException
{
	public NoModificationAllowedError() { }
	public NoModificationAllowedError(string? message) : base(message) { }
	public NoModificationAllowedError(string message, Exception innerException) : base(message, innerException) { }
}

public class NotFoundError : DOMException
{
	public NotFoundError() { }
	public NotFoundError(string? message) : base(message) { }
	public NotFoundError(string message, Exception innerException) : base(message, innerException) { }
}

public class NotSupportedError : DOMException
{
	public NotSupportedError() { }
	public NotSupportedError(string? message) : base(message) { }
	public NotSupportedError(string message, Exception innerException) : base(message, innerException) { }
}

public class InUseAttributeError : DOMException
{
	public InUseAttributeError() { }
	public InUseAttributeError(string? message) : base(message) { }
	public InUseAttributeError(string message, Exception innerException) : base(message, innerException) { }
}

public class InvalidStateError : DOMException
{
	public InvalidStateError() { }
	public InvalidStateError(string? message) : base(message) { }
	public InvalidStateError(string message, Exception innerException) : base(message, innerException) { }
}

public class DOMExceptionSyntaxError : DOMException
{
	public DOMExceptionSyntaxError() { }
	public DOMExceptionSyntaxError(string? message) : base(message) { }
	public DOMExceptionSyntaxError(string message, Exception innerException) : base(message, innerException) { }
}

public class InvalidModificationError : DOMException
{
	public InvalidModificationError() { }
	public InvalidModificationError(string? message) : base(message) { }
	public InvalidModificationError(string message, Exception innerException) : base(message, innerException) { }
}

public class NamespaceError : DOMException
{
	public NamespaceError() { }
	public NamespaceError(string? message) : base(message) { }
	public NamespaceError(string message, Exception innerException) : base(message, innerException) { }
}

public class InvalidAccessError : DOMException
{
	public InvalidAccessError() { }
	public InvalidAccessError(string? message) : base(message) { }
	public InvalidAccessError(string message, Exception innerException) : base(message, innerException) { }
}

public class TypeMismatchError : DOMException
{
	public TypeMismatchError() { }
	public TypeMismatchError(string? message) : base(message) { }
	public TypeMismatchError(string message, Exception innerException) : base(message, innerException) { }
}

public class SecurityError : DOMException
{
	public SecurityError() { }
	public SecurityError(string? message) : base(message) { }
	public SecurityError(string message, Exception innerException) : base(message, innerException) { }
}

public class NetworkError : DOMException
{
	public NetworkError() { }
	public NetworkError(string? message) : base(message) { }
	public NetworkError(string message, Exception innerException) : base(message, innerException) { }
}

public class AbortError : DOMException
{
	public AbortError() { }
	public AbortError(string? message) : base(message) { }
	public AbortError(string message, Exception innerException) : base(message, innerException) { }
}

public class URLMismatchError : DOMException
{
	public URLMismatchError() { }
	public URLMismatchError(string? message) : base(message) { }
	public URLMismatchError(string message, Exception innerException) : base(message, innerException) { }
}

public class QuotaExceededError : DOMException
{
	public QuotaExceededError() { }
	public QuotaExceededError(string? message) : base(message) { }
	public QuotaExceededError(string message, Exception innerException) : base(message, innerException) { }
}

public class TimeoutError : DOMException
{
	public TimeoutError() { }
	public TimeoutError(string? message) : base(message) { }
	public TimeoutError(string message, Exception innerException) : base(message, innerException) { }
}

public class InvalidNodeTypeError : DOMException
{
	public InvalidNodeTypeError() { }
	public InvalidNodeTypeError(string? message) : base(message) { }
	public InvalidNodeTypeError(string message, Exception innerException) : base(message, innerException) { }
}

public class DataCloneError : DOMException
{
	public DataCloneError() { }
	public DataCloneError(string? message) : base(message) { }
	public DataCloneError(string message, Exception innerException) : base(message, innerException) { }
}

public class EncodingError : DOMException
{
	public EncodingError() { }
	public EncodingError(string? message) : base(message) { }
	public EncodingError(string message, Exception innerException) : base(message, innerException) { }
}

public class NotReadableError : DOMException
{
	public NotReadableError() { }
	public NotReadableError(string? message) : base(message) { }
	public NotReadableError(string message, Exception innerException) : base(message, innerException) { }
}

public class UnknownError : DOMException
{
	public UnknownError() { }
	public UnknownError(string? message) : base(message) { }
	public UnknownError(string message, Exception innerException) : base(message, innerException) { }
}

public class ConstraintError : DOMException
{
	public ConstraintError() { }
	public ConstraintError(string? message) : base(message) { }
	public ConstraintError(string message, Exception innerException) : base(message, innerException) { }
}

public class DataError : DOMException
{
	public DataError() { }
	public DataError(string? message) : base(message) { }
	public DataError(string message, Exception innerException) : base(message, innerException) { }
}

public class TransactionInactiveError : DOMException
{
	public TransactionInactiveError() { }
	public TransactionInactiveError(string? message) : base(message) { }
	public TransactionInactiveError(string message, Exception innerException) : base(message, innerException) { }
}

public class ReadOnlyError : DOMException
{
	public ReadOnlyError() { }
	public ReadOnlyError(string? message) : base(message) { }
	public ReadOnlyError(string message, Exception innerException) : base(message, innerException) { }
}

public class VersionError : DOMException
{
	public VersionError() { }
	public VersionError(string? message) : base(message) { }
	public VersionError(string message, Exception innerException) : base(message, innerException) { }
}

public class OperationError : DOMException
{
	public OperationError() { }
	public OperationError(string? message) : base(message) { }
	public OperationError(string message, Exception innerException) : base(message, innerException) { }
}

public class NotAllowedError : DOMException
{
	public NotAllowedError() { }
	public NotAllowedError(string? message) : base(message) { }
	public NotAllowedError(string message, Exception innerException) : base(message, innerException) { }
}

public class BreakError : DOMException
{
	public BreakError() { }
	public BreakError(string? message) : base(message) { }
	public BreakError(string message, Exception innerException) : base(message, innerException) { }
}

public class BufferOverrunError : DOMException
{
	public BufferOverrunError() { }
	public BufferOverrunError(string? message) : base(message) { }
	public BufferOverrunError(string message, Exception innerException) : base(message, innerException) { }
}

public class FramingError : DOMException
{
	public FramingError() { }
	public FramingError(string? message) : base(message) { }
	public FramingError(string message, Exception innerException) : base(message, innerException) { }
}

public class ParityError : DOMException
{
	public ParityError() { }
	public ParityError(string? message) : base(message) { }
	public ParityError(string message, Exception innerException) : base(message, innerException) { }
}