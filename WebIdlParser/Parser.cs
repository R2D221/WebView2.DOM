using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace WebIdlParser
{
	internal partial class Parser
	{
		private static Exception MyException()
		{
			_ = Debugger.Launch();
			return new Exception();
		}

		internal static ImmutableArray<Definition> ParseDefinitions(ReadOnlySpan<char> input)
		{
			try
			{
				IgnoreWhitespaceAndComments(ref input);

				if (input.IsEmpty)
				{
					return ImmutableArray<Definition>.Empty;
				}

				var definitions = new List<Definition>();

				while (input.IsEmpty == false)
				{
					var extendedAttributes = ParseExtendedAttributeList(ref input);

					var definition = ParseDefinition(ref input);

					definition.ExtendedAttributes = extendedAttributes;

					definitions.Add(definition);
				}

				return definitions.ToImmutableArray();
			}
			catch (Exception ex)
			{
				_ = ex;
				throw MyException();
			}
		}

		private static ImmutableArray<ExtendedAttribute> ParseExtendedAttributeList(ref ReadOnlySpan<char> input)
		{
			if (TryParseTerminalSymbol("[", ref input) == false)
			{
				return ImmutableArray<ExtendedAttribute>.Empty;
			}

			var extendedAttributes = new List<ExtendedAttribute>();

			if (input.Length > 0 && input[0] != ']')
			{
				extendedAttributes.Add(ParseExtendedAttribute(ref input));
			}

			while (input.Length > 0 && input[0] != ']')
			{
				ParseTerminalSymbol(",", ref input);
				extendedAttributes.Add(ParseExtendedAttribute(ref input));
			}

			ParseTerminalSymbol("]", ref input);
			return extendedAttributes.ToImmutableArray();
		}

		private static ExtendedAttribute ParseExtendedAttribute(ref ReadOnlySpan<char> input)
		{
			var identifier = ParseIdentifier(ref input);

			if (TryParseTerminalSymbol("=", ref input) == false)
			{
				return new ExtendedAttributeNoArgs
				{
					Name = identifier,
				};
			}

			if (TryParseTerminalSymbol("*", ref input))
			{
				return new ExtendedAttributeWildcard
				{
					Name = identifier,
				};
			}
			else if (TryParseTerminalSymbol("(", ref input))
			{
				var identifiers = new List<string>();

				if (input.Length > 0 && input[0] != ')')
				{
					identifiers.Add(ParseIdentifier(ref input));
				}
				while (input.Length > 0 && input[0] != ')')
				{
					ParseTerminalSymbol(",", ref input);
					identifiers.Add(ParseIdentifier(ref input));
				}
				ParseTerminalSymbol(")", ref input);

				return new ExtendedAttributeIdentList
				{
					Name = identifier,
					Identifiers = identifiers.ToImmutableArray(),
				};
			}
			else if (TryParseIdentifier(ref input) is {/*notnull*/} otherIdentifier)
			{
				if (TryParseTerminalSymbol("(", ref input))
				{
					var arguments = ParseArgumentList(ref input);
					ParseTerminalSymbol(")", ref input);

					return new ExtendedAttributeNamedArgList
					{
						Name = identifier,
						Identifier = otherIdentifier,
						Arguments = arguments,
					};
				}
				else
				{
					return new ExtendedAttributeIdent
					{
						Name = identifier,
						Identifier = otherIdentifier,
					};
				}
			}

			throw MyException();
		}

		private static Definition ParseDefinition(ref ReadOnlySpan<char> input)
		{
			return
				TryParseCallbackOrInterfaceOrMixin(ref input)
				??
				TryParseNamespace(ref input)
				??
				TryParsePartial(ref input)
				??
				TryParseDictionary(ref input)
				??
				TryParseEnum(ref input)
				??
				TryParseTypedef(ref input)
				??
				TryParseIncludesStatement(ref input)
				??
				throw MyException();
		}

		private static Definition? TryParseCallbackOrInterfaceOrMixin(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("callback", ref input))
			{
				if (TryParseKeyword("interface", ref input))
				{
					var identifier = ParseIdentifier(ref input);
					ParseTerminalSymbol("{", ref input);
					var members = ParseCallbackInterfaceMembers(ref input);
					ParseTerminalSymbol("}", ref input);
					ParseTerminalSymbol(";", ref input);

					return new CallbackInterfaceDefinition
					{
						Name = identifier,
						Members = members,
					};
				}
				else
				{
					var identifier = ParseIdentifier(ref input);
					ParseTerminalSymbol("=", ref input);
					var type = ParseType(ref input);
					ParseTerminalSymbol("(", ref input);
					var arguments = ParseArgumentList(ref input);
					ParseTerminalSymbol(")", ref input);
					ParseTerminalSymbol(";", ref input);

					return new CallbackFunctionDefinition
					{
						Name = identifier,
						ReturnType = type,
						Arguments = arguments,
					};
				}
			}

			if (TryParseKeyword("interface", ref input))
			{
				if (TryParseKeyword("mixin", ref input))
				{
					var identifier = ParseIdentifier(ref input);
					ParseTerminalSymbol("{", ref input);
					var members = ParseMixinMembers(ref input);
					ParseTerminalSymbol("}", ref input);
					ParseTerminalSymbol(";", ref input);

					return new InterfaceMixinDefinition
					{
						Name = identifier,
						Members = members,
					};
				}
				else
				{
					var identifier = ParseIdentifier(ref input);
					var inheritance = ParseInheritance(ref input);
					ParseTerminalSymbol("{", ref input);
					var members = ParseInterfaceMembers(ref input);
					ParseTerminalSymbol("}", ref input);
					ParseTerminalSymbol(";", ref input);

					return new InterfaceDefinition
					{
						Name = identifier,
						Inheritance = inheritance,
						Members = members,
					};
				}
			}

			return null;
		}

		private static string? ParseInheritance(ref ReadOnlySpan<char> input)
		{
			if (TryParseTerminalSymbol(":", ref input))
			{
				return ParseIdentifier(ref input);
			}
			else
			{
				return null;
			}
		}

		private static ImmutableArray<Member> ParseInterfaceMembers(ref ReadOnlySpan<char> input)
		{
			var members = new List<Member>();

			while (input.Length > 0 && input[0] != '}')
			{
				members.Add(ParseInterfaceMember(ref input));
			}

			return members.ToImmutableArray();
		}

		private static Member ParseInterfaceMember(ref ReadOnlySpan<char> input)
		{
			var extendedAttributes = ParseExtendedAttributeList(ref input);

			var member =
				TryParseConstructor(ref input)
				??
				TryParsePartialInterfaceMember(ref input)
				??
				throw MyException();

			member.ExtendedAttributes = extendedAttributes;

			return member;
		}

		private static ImmutableArray<Member> ParsePartialInterfaceMembers(ref ReadOnlySpan<char> input)
		{
			var members = new List<Member>();

			while (input.Length > 0 && input[0] != '}')
			{
				members.Add(ParsePartialInterfaceMember(ref input));
			}

			return members.ToImmutableArray();
		}

		private static Member ParsePartialInterfaceMember(ref ReadOnlySpan<char> input)
		{
			var extendedAttributes = ParseExtendedAttributeList(ref input);

			var member = TryParsePartialInterfaceMember(ref input) ?? throw MyException();

			member.ExtendedAttributes = extendedAttributes;

			return member;
		}

		private static Member? TryParsePartialInterfaceMember(ref ReadOnlySpan<char> input)
		{
			return
				TryParseConst(ref input)
				??
				TryParseStringifier(ref input)
				??
				TryParseStaticMember(ref input)
				??
				TryParseIterable(ref input)
				??
				TryParseAsyncIterable(ref input)
				??
				TryParseAttributeOrMaplikeOrSetlike(ref input)
				??
				TryParseInheritAttribute(ref input)
				??
				TryParseOperation(ref input)
				??
				null;
		}

		private static ImmutableArray<Member> ParseMixinMembers(ref ReadOnlySpan<char> input)
		{
			var members = new List<Member>();

			while (input.Length > 0 && input[0] != '}')
			{
				members.Add(ParseMixinMember(ref input));
			}

			return members.ToImmutableArray();
		}

		private static Member ParseMixinMember(ref ReadOnlySpan<char> input)
		{
			var extendedAttributes = ParseExtendedAttributeList(ref input);

			var member =
				TryParseConst(ref input)
				??
				TryParseStringifier(ref input)
				??
				TryParseAttribute(ref input)
				??
				TryParseRegularOperation(ref input)
				??
				throw MyException();

			member.ExtendedAttributes = extendedAttributes;

			return member;
		}

		private static ImmutableArray<Member> ParseCallbackInterfaceMembers(ref ReadOnlySpan<char> input)
		{
			var members = new List<Member>();

			while (input.Length > 0 && input[0] != '}')
			{
				members.Add(ParseCallbackInterfaceMember(ref input));
			}

			return members.ToImmutableArray();
		}

		private static Member ParseCallbackInterfaceMember(ref ReadOnlySpan<char> input)
		{
			var extendedAttributes = ParseExtendedAttributeList(ref input);

			var member =
				TryParseConst(ref input)
				??
				TryParseRegularOperation(ref input)
				??
				throw MyException();

			member.ExtendedAttributes = extendedAttributes;

			return member;
		}

		private static Definition? TryParseNamespace(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("namespace", ref input) == false)
			{
				return null;
			}

			var identifier = ParseIdentifier(ref input);
			ParseTerminalSymbol("{", ref input);
			var members = ParseNamespaceMembers(ref input);
			ParseTerminalSymbol("}", ref input);
			ParseTerminalSymbol(";", ref input);

			return new NamespaceDefinition
			{
				Name = identifier,
				Members = members,
			};
		}

		private static ImmutableArray<Member> ParseNamespaceMembers(ref ReadOnlySpan<char> input)
		{
			var members = new List<Member>();

			while (input.Length > 0 && input[0] != '}')
			{
				members.Add(ParseNamespaceMember(ref input));
			}

			return members.ToImmutableArray();
		}

		private static Member ParseNamespaceMember(ref ReadOnlySpan<char> input)
		{
			var extendedAttributes = ParseExtendedAttributeList(ref input);

			var member =
				TryParseConst(ref input)
				??
				TryParseReadOnlyAttribute(ref input)
				??
				TryParseRegularOperation(ref input)
				??
				throw MyException();

			member.ExtendedAttributes = extendedAttributes;

			return member;
		}

		private static Definition? TryParsePartial(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("partial", ref input) == false) { return null; }

			if (TryParseKeyword("interface", ref input))
			{
				if (TryParseKeyword("mixin", ref input))
				{
					var identifier = ParseIdentifier(ref input);
					ParseTerminalSymbol("{", ref input);
					var members = ParseMixinMembers(ref input);
					ParseTerminalSymbol("}", ref input);
					ParseTerminalSymbol(";", ref input);

					return new Partial
					{
						Definition = new InterfaceMixinDefinition
						{
							Name = identifier,
							Members = members,
						},
					};
				}
				else
				{
					var identifier = ParseIdentifier(ref input);
					ParseTerminalSymbol("{", ref input);
					var members = ParsePartialInterfaceMembers(ref input);
					ParseTerminalSymbol("}", ref input);
					ParseTerminalSymbol(";", ref input);

					return new Partial
					{
						Definition = new InterfaceDefinition
						{
							Inheritance = null,
							Name = identifier,
							Members = members,
						},
					};
				}
			}
			else if (TryParseKeyword("dictionary", ref input))
			{
				var identifier = ParseIdentifier(ref input);
				ParseTerminalSymbol("{", ref input);
				var members = ParseDictionaryMembers(ref input);
				ParseTerminalSymbol("}", ref input);
				ParseTerminalSymbol(";", ref input);

				return new Partial
				{
					Definition = new DictionaryDefinition
					{
						Inheritance = null,
						Name = identifier,
						Members = members,
					},
				};
			}
			else if (TryParseNamespace(ref input) is {/*notnull*/} @namespace)
			{
				return new Partial
				{
					Definition = @namespace,
				};
			}

			return null;
		}

		private static DictionaryDefinition? TryParseDictionary(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("dictionary", ref input) == false) { return null; }

			var identifier = TryParseIdentifier(ref input);

			if (identifier is null) { throw MyException(); }

			var inheritance = ParseInheritance(ref input);
			ParseTerminalSymbol("{", ref input);
			var members = ParseDictionaryMembers(ref input);
			ParseTerminalSymbol("}", ref input);
			ParseTerminalSymbol(";", ref input);

			var dictionary = new DictionaryDefinition
			{
				Name = identifier,
				Inheritance = inheritance,
				Members = members,
			};

			return dictionary;
		}

		private static ImmutableArray<DictionaryMember> ParseDictionaryMembers(ref ReadOnlySpan<char> input)
		{
			var members = new List<DictionaryMember>();

			while (input.Length > 0 && input[0] != '}')
			{
				members.Add(ParseDictionaryMember(ref input));
			}

			return members.ToImmutableArray();
		}

		private static DictionaryMember ParseDictionaryMember(ref ReadOnlySpan<char> input)
		{
			var extendedAttributes = ParseExtendedAttributeList(ref input);

			if (TryParseKeyword("required", ref input))
			{
				var typeWithExtendedAttributes = ParseTypeWithExtendedAttributes(ref input);
				var identifier = ParseIdentifier(ref input);
				ParseTerminalSymbol(";", ref input);

				return new RequiredDictionaryMember
				{
					ExtendedAttributes = extendedAttributes,
					Type = typeWithExtendedAttributes,
					Name = identifier,
				};
			}
			else
			{
				var type = ParseType(ref input);
				var identifier = ParseIdentifier(ref input);
				var defaultValue = ParseDefault(ref input);
				ParseTerminalSymbol(";", ref input);

				return new OptionalDictionaryMember
				{
					ExtendedAttributes = extendedAttributes,
					Type = new(type),
					Name = identifier,
					DefaultValue = defaultValue,
				};
			}
		}

		private static Definition? TryParseEnum(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("enum", ref input) == false) { return null; }

			var identifier = TryParseIdentifier(ref input);

			if (identifier is null) { throw MyException(); }

			ParseTerminalSymbol("{", ref input);
			var values = new List<string>();
			if (input.Length > 0 && input[0] != '}')
			{
				values.Add(TryParseString(ref input) ?? throw MyException());
			}
			while (input.Length > 0 && input[0] != '}')
			{
				ParseTerminalSymbol(",", ref input);
				values.Add(TryParseString(ref input) ?? throw MyException());
			}
			ParseTerminalSymbol("}", ref input);
			ParseTerminalSymbol(";", ref input);

			return new EnumDefinition
			{
				Name = identifier,
				Values = values.ToImmutableArray(),
			};
		}

		private static Definition? TryParseTypedef(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("typedef", ref input) == false) { return null; }

			var type = ParseTypeWithExtendedAttributes(ref input);
			var identifier = ParseIdentifier(ref input);
			ParseTerminalSymbol(";", ref input);

			return new TypedefDefinition
			{
				Name = identifier,
				Type = type,
			};
		}

		private static Definition? TryParseIncludesStatement(ref ReadOnlySpan<char> input)
		{
			if (TryParseIdentifier(ref input) is not {/*notnull*/} identifier)
			{
				return null;
			}

			ParseKeyword("includes", ref input);
			var otherIdentifier = ParseIdentifier(ref input);
			ParseTerminalSymbol(";", ref input);

			return new IncludesDefinition
			{
				Interface = identifier,
				Mixin = otherIdentifier,
			};
		}

		private static Member? TryParseConstructor(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("constructor", ref input) == false)
			{
				return null;
			}

			ParseTerminalSymbol("(", ref input);
			var arguments = ParseArgumentList(ref input);
			ParseTerminalSymbol(")", ref input);
			ParseTerminalSymbol(";", ref input);

			return new Constructor
			{
				Arguments = arguments,
			};
		}

		private static Member? TryParseConst(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("const", ref input) == false)
			{
				return null;
			}

			var type = ParseConstType(ref input);
			var identifier = ParseIdentifier(ref input);
			ParseTerminalSymbol("=", ref input);
			var value = ParseConstValue(ref input);
			ParseTerminalSymbol(";", ref input);

			return new Const
			{
				Type = type,
				Name = identifier,
				Value = value,
			};
		}

		private static Member? TryParseOperation(ref ReadOnlySpan<char> input)
		{
			return
				TryParseSpecialOperation(ref input)
				??
				TryParseRegularOperation(ref input)
				??
				null;
		}

		private static Member? TryParseSpecialOperation(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("getter", ref input))
			{
				var operation = ParseRegularOperation(ref input);
				return new Getter { Operation = operation };
			}
			else if (TryParseKeyword("setter", ref input))
			{
				var operation = ParseRegularOperation(ref input);
				return new Setter { Operation = operation };
			}
			else if (TryParseKeyword("deleter", ref input))
			{
				var operation = ParseRegularOperation(ref input);
				return new Deleter { Operation = operation };
			}

			return null;
		}

		private static Operation ParseRegularOperation(ref ReadOnlySpan<char> input) =>
			TryParseRegularOperation(ref input) ?? throw MyException();

		private static Operation? TryParseRegularOperation(ref ReadOnlySpan<char> input)
		{
			var type = TryParseType(ref input);

			if (type is null) { return null; }

			var optionalOperationName = TryParseIdentifier(ref input);
			ParseTerminalSymbol("(", ref input);
			var arguments = ParseArgumentList(ref input);
			ParseTerminalSymbol(")", ref input);
			ParseTerminalSymbol(";", ref input);

			return new Operation
			{
				ReturnType = type,
				Name = optionalOperationName,
				Arguments = arguments,
			};
		}

		private static Member? TryParseStringifier(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("stringifier", ref input) == false)
			{
				return null;
			}

			if (TryParseTerminalSymbol(";", ref input))
			{
				return Stringifier.Instance;
			}

			var isReadOnly = TryParseTerminalSymbol("readonly", ref input);
			var (type, name) = ParseAttributeRest(ref input);

			return new StringifierAttribute
			{
				Type = type,
				Name = name,
				IsReadOnly = isReadOnly,
			};
		}

		private static Member? TryParseStaticMember(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("static", ref input) == false)
			{
				return null;
			}

			if (TryParseKeyword("readonly", ref input))
			{
				var (type, name) = ParseAttributeRest(ref input);
				return new StaticMember
				{
					Member = new Attribute
					{
						IsReadOnly = true,
						Type = type,
						Name = name,
					},
				};
			}
			else if (TryParseAttributeRest(ref input) is {/*notnull*/} attributeRest)
			{
				var (type, name) = attributeRest;
				return new StaticMember
				{
					Member = new Attribute
					{
						IsReadOnly = false,
						Type = type,
						Name = name,
					},
				};
			}
			else if (TryParseRegularOperation(ref input) is {/*notnull*/} operation)
			{
				return new StaticMember
				{
					Member = operation,
				};
			}

			return null;
		}

		private static Member? TryParseIterable(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("iterable", ref input) == false)
			{
				return null;
			}

			var types = new List<TypeWithExtendedAttributes>();

			ParseTerminalSymbol("<", ref input);
			types.Add(ParseTypeWithExtendedAttributes(ref input));
			if (TryParseTerminalSymbol(",", ref input))
			{
				types.Add(ParseTypeWithExtendedAttributes(ref input));
			}
			ParseTerminalSymbol(">", ref input);
			ParseTerminalSymbol(";", ref input);

			return new Iterable
			{
				TypeArguments = types.ToImmutableArray(),
			};
		}

		private static Member? TryParseAsyncIterable(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("async", ref input) == false)
			{
				return null;
			}

			ParseKeyword("iterable", ref input);

			var types = new List<TypeWithExtendedAttributes>();

			ParseTerminalSymbol("<", ref input);
			types.Add(ParseTypeWithExtendedAttributes(ref input));
			if (TryParseTerminalSymbol(",", ref input))
			{
				types.Add(ParseTypeWithExtendedAttributes(ref input));
			}
			ParseTerminalSymbol(">", ref input);

			ImmutableArray<Argument>? arguments = null;
			if (TryParseTerminalSymbol("(", ref input))
			{
				arguments = ParseArgumentList(ref input);
				ParseTerminalSymbol(")", ref input);
			}

			ParseTerminalSymbol(";", ref input);

			return new AsyncIterable
			{
				TypeArguments = types.ToImmutableArray(),
				Arguments = arguments,
			};
		}

		private static Member? TryParseAttributeOrMaplikeOrSetlike(ref ReadOnlySpan<char> input)
		{
			var isReadOnly = TryParseTerminalSymbol("readonly", ref input);

			if (TryParseAttributeRest(ref input) is {/*notnull*/} attributeRest)
			{
				var (type, name) = attributeRest;

				return new Attribute
				{
					IsReadOnly = isReadOnly,
					Type = type,
					Name = name,
				};
			}
			else if (TryParseTerminalSymbol("maplike", ref input))
			{
				ParseTerminalSymbol("<", ref input);
				var k = ParseTypeWithExtendedAttributes(ref input);
				ParseTerminalSymbol(",", ref input);
				var v = ParseTypeWithExtendedAttributes(ref input);
				ParseTerminalSymbol(">", ref input);
				ParseTerminalSymbol(";", ref input);

				return new Maplike
				{
					IsReadOnly = isReadOnly,
					TKey = k,
					TValue = v,
				};
			}
			else if (TryParseTerminalSymbol("setlike", ref input))
			{
				ParseTerminalSymbol("<", ref input);
				var type = ParseTypeWithExtendedAttributes(ref input);
				ParseTerminalSymbol(">", ref input);
				ParseTerminalSymbol(";", ref input);

				return new Setlike
				{
					IsReadOnly = isReadOnly,
					Type = type,
				};
			}

			return null;
		}

		private static Member? TryParseAttribute(ref ReadOnlySpan<char> input)
		{
			var isReadOnly = TryParseTerminalSymbol("readonly", ref input);

			if (TryParseAttributeRest(ref input) is {/*notnull*/} attributeRest)
			{
				var (type, name) = attributeRest;

				return new Attribute
				{
					IsReadOnly = isReadOnly,
					Type = type,
					Name = name,
				};
			}

			return null;
		}

		private static Member? TryParseReadOnlyAttribute(ref ReadOnlySpan<char> input)
		{
			var isReadOnly = TryParseTerminalSymbol("readonly", ref input);
			if (!isReadOnly) { return null; }

			if (TryParseAttributeRest(ref input) is {/*notnull*/} attributeRest)
			{
				var (type, name) = attributeRest;

				return new Attribute
				{
					IsReadOnly = isReadOnly,
					Type = type,
					Name = name,
				};
			}

			return null;
		}

		private static Member? TryParseInheritAttribute(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("inherit", ref input) == false)
			{
				return null;
			}

			var (type, name) = ParseAttributeRest(ref input);

			return new InheritAttribute
			{
				IsReadOnly = false,
				Type = type,
				Name = name,
			};
		}

		private static (TypeWithExtendedAttributes type, string name) ParseAttributeRest(ref ReadOnlySpan<char> input) =>
			TryParseAttributeRest(ref input) is {/*notnull*/} value
			? value
			: throw MyException();

		private static (TypeWithExtendedAttributes type, string name)? TryParseAttributeRest(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("attribute", ref input) == false)
			{
				return null;
			}

			var type = ParseTypeWithExtendedAttributes(ref input);
			var name = ParseIdentifier(ref input);
			ParseTerminalSymbol(";", ref input);

			return (type, name);
		}

		private static ImmutableArray<Argument> ParseArgumentList(ref ReadOnlySpan<char> input)
		{
			var arguments = new List<Argument>();

			if (input.Length > 0 && input[0] != ')')
			{
				arguments.Add(ParseArgument(ref input));
			}

			while (input.Length > 0 && input[0] != ')')
			{
				ParseTerminalSymbol(",", ref input);
				arguments.Add(ParseArgument(ref input));
			}

			return arguments.ToImmutableArray();
		}

		private static Argument ParseArgument(ref ReadOnlySpan<char> input)
		{
			var extendedAttributes = ParseExtendedAttributeList(ref input);

			if (TryParseKeyword("optional", ref input))
			{
				var type = ParseTypeWithExtendedAttributes(ref input);
				var name = ParseIdentifier(ref input);
				var defaultValue = ParseDefault(ref input);

				return new OptionalArgument
				{
					ExtendedAttributes = extendedAttributes,
					Type = type,
					Name = name,
					DefaultValue = defaultValue,
				};
			}
			else
			{
				var type = ParseType(ref input);
				var isVariadic = TryParseTerminalSymbol("...", ref input);
				var name = ParseIdentifier(ref input);

				if (isVariadic)
				{
					return new VariadicArgument
					{
						ExtendedAttributes = extendedAttributes,
						Type = new(type),
						Name = name,
					};
				}
				else
				{
					return new Argument
					{
						ExtendedAttributes = extendedAttributes,
						Type = new(type),
						Name = name,
					};
				}
			}
		}

		private static string? ParseDefault(ref ReadOnlySpan<char> input)
		{
			if (TryParseTerminalSymbol("=", ref input) == false)
			{
				return null;
			}

			return
				TryParseConstValue(ref input)
				??
				TryParseString(ref input)
				??
				(
					(TryParseTerminalSymbol("[", ref input)
					&&
					TryParseTerminalSymbol("]", ref input))
					?
						"[ ]"
					:
						null
				)
				??
				(
					(TryParseTerminalSymbol("{", ref input)
					&&
					TryParseTerminalSymbol("}", ref input))
					?
						"{ }"
					:
						null
				)
				??
				(TryParseKeyword("null", ref input) ? "null" : null)
				??
				(TryParseKeyword("undefined", ref input) ? "undefined" : null)
				??
				throw MyException();
			;
		}

		private static Type ParseConstType(ref ReadOnlySpan<char> input)
		{
			return
				TryParsePrimitiveType(ref input)
				??
				TryParseIdentifierType(ref input)
				??
				throw MyException();
		}

		private static string? TryParseConstValue(ref ReadOnlySpan<char> input)
		{
			return
				TryParseBooleanLiteral(ref input)
				??
				TryParseFloatLiteral(ref input)
				??
				TryParseInteger(ref input)
				??
				null;
		}

		private static string ParseConstValue(ref ReadOnlySpan<char> input) =>
			TryParseConstValue(ref input) ?? throw MyException();

		private static string? TryParseBooleanLiteral(ref ReadOnlySpan<char> input)
		{
			return
				TryParseKeyword("true", ref input) ? "true" :
				TryParseKeyword("false", ref input) ? "false" :
				null;
		}

		private static string? TryParseFloatLiteral(ref ReadOnlySpan<char> input)
		{
			return
				TryParseKeyword("-Infinity", ref input) ? "-Infinity" :
				TryParseKeyword("Infinity", ref input) ? "Infinity" :
				TryParseKeyword("NaN", ref input) ? "NaN" :
				TryParseDecimal(ref input)
				;
		}

		private static TypeWithExtendedAttributes ParseTypeWithExtendedAttributes(ref ReadOnlySpan<char> input)
		{
			var extendedAttributes = ParseExtendedAttributeList(ref input);

			var type = ParseType(ref input);

			return new TypeWithExtendedAttributes(type, extendedAttributes);
		}

		private static Type ParseType(ref ReadOnlySpan<char> input) =>
			TryParseType(ref input) ?? throw MyException();

		private static Type? TryParseType(ref ReadOnlySpan<char> input)
		{
			if (TryParseTerminalSymbol("(", ref input))
			{
				var unionTypes = new List<TypeWithExtendedAttributes>();

				if (input.Length > 0 && input[0] != ')')
				{
					var extendedAttributes = ParseExtendedAttributeList(ref input);
					var type = TryParseDistinguishableType(ref input) ?? throw MyException();
					unionTypes.Add(new(type, extendedAttributes));
				}

				while (input.Length > 0 && input[0] != ')')
				{
					ParseKeyword("or", ref input);

					var extendedAttributes = ParseExtendedAttributeList(ref input);
					var type = TryParseDistinguishableType(ref input) ?? throw MyException();
					unionTypes.Add(new(type, extendedAttributes));
				}

				ParseTerminalSymbol(")", ref input);

				var isNullable = TryParseTerminalSymbol("?", ref input);

				return new UnionType
				{
					Types = unionTypes.ToImmutableArray(),
					IsNullable = isNullable
				};
			}

			if (input.IsEmpty == false && input[0] == '(')
			{
				// union types
				throw new NotImplementedException();
			}

			return
				(TryParseKeyword("any", ref input) ? Type.Any : null)
				??
				TryParsePromiseType(ref input)
				??
				TryParseDistinguishableType(ref input)
				??
				null;
		}

		private static GenericType? TryParsePromiseType(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("Promise", ref input) == false)
			{
				return null;
			}

			if (TryParseTerminalSymbol("<", ref input) == false)
			{
				throw MyException();
			}

			var type = ParseType(ref input);

			if (TryParseTerminalSymbol(">", ref input) == false)
			{
				throw MyException();
			}

			return new GenericType("Promise", new TypeWithExtendedAttributes(type));
		}

		private static Type? TryParseDistinguishableType(ref ReadOnlySpan<char> input)
		{
			var type =
				TryParsePrimitiveType(ref input)
				??
				TryParseStringType(ref input)
				??
				TryParseSequenceType(ref input)
				??
				TryParseObjectType(ref input)
				??
				TryParseSymbolType(ref input)
				??
				TryParseBufferRelatedType(ref input)
				??
				TryParseFrozenArrayType(ref input)
				??
				TryParseObservableArrayType(ref input)
				??
				TryParseRecordType(ref input)
				??
				TryParseUndefinedType(ref input)
				??
				TryParseIdentifierType(ref input)
				??
				null;

			if (type is null) { return null; }

			type.IsNullable = TryParseTerminalSymbol("?", ref input);

			return type;
		}

		private static Type? TryParsePrimitiveType(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("boolean", ref input))
			{
				return Type.Boolean;
			}
			if (TryParseKeyword("byte", ref input))
			{
				return Type.Byte;
			}
			if (TryParseKeyword("octet", ref input))
			{
				return Type.Octet;
			}
			if (TryParseKeyword("bigint", ref input))
			{
				return Type.BigInt;
			}
			if (TryParseKeyword("float", ref input))
			{
				return Type.Float;
			}
			if (TryParseKeyword("double", ref input))
			{
				return Type.Double;
			}
			if (TryParseKeyword("short", ref input))
			{
				return Type.Short;
			}
			if (TryParseKeyword("long", ref input))
			{
				if (TryParseKeyword("long", ref input))
				{
					return Type.LongLong;
				}
				return Type.Long;
			}

			var originalInput = input;

			if (TryParseKeyword("unrestricted", ref input))
			{
				if (TryParseKeyword("float", ref input))
				{
					return Type.UnrestrictedFloat;
				}
				if (TryParseKeyword("double", ref input))
				{
					return Type.UnrestrictedDouble;
				}

				input = originalInput;
				return null;
			}

			if (TryParseKeyword("unsigned", ref input))
			{
				if (TryParseKeyword("short", ref input))
				{
					return Type.UnsignedShort;
				}
				if (TryParseKeyword("long", ref input))
				{
					if (TryParseKeyword("long", ref input))
					{
						return Type.UnsignedLongLong;
					}
					return Type.UnsignedLong;
				}

				input = originalInput;
				return null;
			}

			return null;
		}

		private static Type? TryParseStringType(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("ByteString", ref input))
			{
				return Type.ByteString;
			}
			if (TryParseKeyword("DOMString", ref input))
			{
				return Type.DOMString;
			}
			if (TryParseKeyword("USVString", ref input))
			{
				return Type.USVString;
			}

			return null;
		}

		private static Type? TryParseSequenceType(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("sequence", ref input) == false)
			{
				return null;
			}

			if (TryParseTerminalSymbol("<", ref input) == false)
			{
				throw MyException();
			}

			var type = ParseTypeWithExtendedAttributes(ref input);

			if (TryParseTerminalSymbol(">", ref input) == false)
			{
				throw MyException();
			}

			return new GenericType("sequence", type);
		}

		private static Type? TryParseObjectType(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("object", ref input))
			{
				return Type.Object;
			}

			return null;
		}

		private static Type? TryParseSymbolType(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("symbol", ref input))
			{
				return Type.Symbol;
			}

			return null;
		}

		private static Type? TryParseBufferRelatedType(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("ArrayBuffer", ref input))
			{
				return Type.ArrayBuffer;
			}
			if (TryParseKeyword("DataView", ref input))
			{
				return Type.DataView;
			}
			if (TryParseKeyword("Int8Array", ref input))
			{
				return Type.Int8Array;
			}
			if (TryParseKeyword("Int16Array", ref input))
			{
				return Type.Int16Array;
			}
			if (TryParseKeyword("Int32Array", ref input))
			{
				return Type.Int32Array;
			}
			if (TryParseKeyword("Uint8Array", ref input))
			{
				return Type.Uint8Array;
			}
			if (TryParseKeyword("Uint16Array", ref input))
			{
				return Type.Uint16Array;
			}
			if (TryParseKeyword("Uint32Array", ref input))
			{
				return Type.Uint32Array;
			}
			if (TryParseKeyword("Uint8ClampedArray", ref input))
			{
				return Type.Uint8ClampedArray;
			}
			if (TryParseKeyword("BigInt64Array", ref input))
			{
				return Type.BigInt64Array;
			}
			if (TryParseKeyword("BigUint64Array", ref input))
			{
				return Type.BigUint64Array;
			}
			if (TryParseKeyword("Float32Array", ref input))
			{
				return Type.Float32Array;
			}
			if (TryParseKeyword("Float64Array", ref input))
			{
				return Type.Float64Array;
			}

			return null;
		}

		private static Type? TryParseFrozenArrayType(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("FrozenArray", ref input) == false)
			{
				return null;
			}

			if (TryParseTerminalSymbol("<", ref input) == false)
			{
				throw MyException();
			}

			var type = ParseTypeWithExtendedAttributes(ref input);

			if (TryParseTerminalSymbol(">", ref input) == false)
			{
				throw MyException();
			}

			return new GenericType("FrozenArray", type);
		}

		private static Type? TryParseObservableArrayType(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("ObservableArray", ref input) == false)
			{
				return null;
			}

			if (TryParseTerminalSymbol("<", ref input) == false)
			{
				throw MyException();
			}

			var type = ParseTypeWithExtendedAttributes(ref input);

			if (TryParseTerminalSymbol(">", ref input) == false)
			{
				throw MyException();
			}

			return new GenericType("ObservableArray", type);
		}

		private static Type? TryParseRecordType(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("record", ref input) == false)
			{
				return null;
			}

			if (TryParseTerminalSymbol("<", ref input) == false)
			{
				throw MyException();
			}

			var k = TryParseStringType(ref input);
			if (k is null) { throw MyException(); }

			if (TryParseTerminalSymbol(",", ref input) == false)
			{
				throw MyException();
			}

			var v = ParseTypeWithExtendedAttributes(ref input);

			if (TryParseTerminalSymbol(">", ref input) == false)
			{
				throw MyException();
			}

			return new GenericType("record", new TypeWithExtendedAttributes(k), v);
		}

		private static Type? TryParseUndefinedType(ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword("undefined", ref input))
			{
				return Type.Undefined;
			}

			return null;
		}

		private static Type? TryParseIdentifierType(ref ReadOnlySpan<char> input)
		{
			var identifier = TryParseIdentifier(ref input);

			if (identifier is not null)
			{
				return new Type(identifier);
			}

			return null;
		}

		//[GeneratedRegex("^-?([1-9][0-9]*|0[Xx][0-9A-Fa-f]+|0[0-7]*)")]
		//private static partial Regex GetIntegerRegex();
		private static readonly Regex _integerRegex = new("^-?([1-9][0-9]*|0[Xx][0-9A-Fa-f]+|0[0-7]*)");
		private static Regex GetIntegerRegex() => _integerRegex;

		//[GeneratedRegex("^-?(([0-9]+\\.[0-9]*|[0-9]*\\.[0-9]+)([Ee][+-]?[0-9]+)?|[0-9]+[Ee][+-]?[0-9]+)")]
		//private static partial Regex GetDecimalRegex();
		private static readonly Regex _decimalRegex = new("^-?(([0-9]+\\.[0-9]*|[0-9]*\\.[0-9]+)([Ee][+-]?[0-9]+)?|[0-9]+[Ee][+-]?[0-9]+)");
		private static Regex GetDecimalRegex() => _decimalRegex;

		//[GeneratedRegex("^[_-]?[A-Za-z][0-9A-Z_a-z-]*")]
		//private static partial Regex GetIdentifierRegex();
		private static readonly Regex _identifierRegex = new("^[_-]?[A-Za-z][0-9A-Z_a-z-]*");
		private static Regex GetIdentifierRegex() => _identifierRegex;

		//[GeneratedRegex("^\"[^\"]*\"")]
		//private static partial Regex GetStringRegex();
		private static readonly Regex _stringRegex = new("^\"[^\"]*\"");
		private static Regex GetStringRegex() => _stringRegex;

		//[GeneratedRegex("^[\t\n\r ]+")]
		//private static partial Regex GetWhitespaceRegex();
		private static readonly Regex _whitespaceRegex = new("^[\t\n\r ]+");
		private static Regex GetWhitespaceRegex() => _whitespaceRegex;

		//[GeneratedRegex("^(\\/\\/.*|\\/\\*(.|\\n)*?\\*\\/)")]
		//private static partial Regex GetCommentRegex();
		private static readonly Regex _commentRegex = new("^(\\/\\/.*|\\/\\*(.|\\n)*?\\*\\/)");
		private static Regex GetCommentRegex() => _commentRegex;

		private static string? TryParseTerminalSymbol(Regex regex, ref ReadOnlySpan<char> input)
		{
			try
			{
				var matches = regex.EnumerateMatches(input);

				foreach (var match in matches)
				{
					if (match.Index != 0) { throw MyException(); }

					var terminalSymbol = input[..match.Length];

					input = input[match.Length..];
					IgnoreWhitespaceAndComments(ref input);

					return new string(terminalSymbol.ToArray());
				}

				return null;
			}
			catch (Exception ex)
			{
				_ = ex;
				throw MyException();
			}
		}

		private static string? TryParseInteger(ref ReadOnlySpan<char> input)
		{
			return TryParseTerminalSymbol(GetIntegerRegex(), ref input);

			//int i = -1;

			//if (input.Length > 0 && input[0] == '-')
			//{
			//	i++;
			//}

			//while ((i += 1) < input.Length)
			//{
			//	switch (input[i])
			//	{
			//	case >= '1' and <= '9': goto @decimal;
			//	case '0': goto octalOrHexadecimal;
			//	default: return null;
			//	}
			//}

			//@decimal:;
			//while ((i += 1) < input.Length)
			//{
			//	switch (input[i])
			//	{
			//	case >= '0' and <= '9': break;
			//	default: goto end;
			//	}
			//}

			//@octalOrHexadecimal:;
			//while ((i += 1) < input.Length)
			//{
			//	switch (input[i])
			//	{
			//	case 'x' or 'X': goto firstHexadecimal;
			//	case >= '0' and <= '7': goto octal;
			//	default: goto end;
			//	}
			//}

			//firstHexadecimal:;
			//while ((i += 1) < input.Length)
			//{
			//	switch (input[i])
			//	{
			//	case >= '0' and <= '9': goto hexadecimal;
			//	case >= 'A' and <= 'F': goto hexadecimal;
			//	case >= 'a' and <= 'f': goto hexadecimal;
			//	default: throw MyException();
			//	}
			//}

			//hexadecimal:;
			//while ((i += 1) < input.Length)
			//{
			//	switch (input[i])
			//	{
			//	case >= '0' and <= '9': break;
			//	case >= 'A' and <= 'F': break;
			//	case >= 'a' and <= 'f': break;
			//	default: goto end;
			//	}
			//}

			//octal:;
			//while ((i += 1) < input.Length)
			//{
			//	switch (input[i])
			//	{
			//	case >= '0' and <= '7': break;
			//	default: goto end;
			//	}
			//}

			//end:;

			//if (i == 0) { return null; }

			//var integer = input[..i];

			//input = input[i..];
			//IgnoreWhitespaceAndComments(ref input);

			//return new string(integer);
		}

		private static string? TryParseDecimal(ref ReadOnlySpan<char> input) =>
			TryParseTerminalSymbol(GetDecimalRegex(), ref input);

		private static string ParseIdentifier(ref ReadOnlySpan<char> input) =>
			TryParseIdentifier(ref input) ?? throw MyException();

		private static string? TryParseIdentifier(ref ReadOnlySpan<char> input)
		{
			return TryParseTerminalSymbol(GetIdentifierRegex(), ref input);
			//int i = -1;

			////underscore:;
			//while ((i += 1) < input.Length)
			//{
			//	switch (input[i])
			//	{
			//	case '_': goto firstLetter;
			//	case '-': goto firstLetter;
			//	case >= 'A' and <= 'Z': goto otherCharacter;
			//	case >= 'a' and <= 'z': goto otherCharacter;
			//	default: return null;
			//	}
			//}

			//firstLetter:;
			//while ((i += 1) < input.Length)
			//{
			//	switch (input[i])
			//	{
			//	case >= 'A' and <= 'Z': goto otherCharacter;
			//	case >= 'a' and <= 'z': goto otherCharacter;
			//	default: return null;
			//	}
			//}

			//otherCharacter:;
			//while ((i += 1) < input.Length)
			//{
			//	switch (input[i])
			//	{
			//	case '_': break;
			//	case '-': break;
			//	case >= 'A' and <= 'Z': break;
			//	case >= 'a' and <= 'z': break;
			//	case >= '0' and <= '9': break;
			//	default: goto end;
			//	}
			//}

			//end:;

			//if (i == 0) { return null; }

			//var identifier = input[..i];

			//input = input[i..];
			//IgnoreWhitespaceAndComments(ref input);

			//return new string(identifier);
		}

		private static string? TryParseString(ref ReadOnlySpan<char> input) =>
			TryParseTerminalSymbol(GetStringRegex(), ref input);












		private static void ParseKeyword(string keyword, ref ReadOnlySpan<char> input)
		{
			if (TryParseKeyword(keyword, ref input) == false)
			{
				throw MyException();
			}
		}

		private static bool TryParseKeyword(string keyword, ref ReadOnlySpan<char> input)
		{
			if (input.IsEmpty) { return false; }
			if (!input.StartsWith(keyword.AsSpan())) { return false; }

			if (input.Length == keyword.Length)
			{
				input = input[keyword.Length..];
				IgnoreWhitespaceAndComments(ref input);
				return true;
			}

			switch (input[keyword.Length])
			{
			case '_':
			case '-':
			case >= 'A' and <= 'Z':
			case >= 'a' and <= 'z':
			case >= '0' and <= '9':
			{
				return false;
			}

			default:
			{
				input = input[keyword.Length..];
				IgnoreWhitespaceAndComments(ref input);
				return true;
			}
			}
		}

		private static void ParseTerminalSymbol(string symbol, ref ReadOnlySpan<char> input)
		{
			if (TryParseTerminalSymbol(symbol, ref input) == false) { throw MyException(); }
		}

		private static bool TryParseTerminalSymbol(string symbol, ref ReadOnlySpan<char> input)
		{
			if (input.IsEmpty) { return false; }
			if (!input.StartsWith(symbol.AsSpan())) { return false; }

			input = input[symbol.Length..];
			IgnoreWhitespaceAndComments(ref input);
			return true;
		}

		private static void IgnoreWhitespaceAndComments(ref ReadOnlySpan<char> input)
		{
			if (input.IsEmpty) { return; }

			var success1 = false;
			var success2 = false;

			do
			{
				success1 = TryIgnoreWhitespace(ref input);
				success2 = TryIgnoreComment(ref input);
			}
			while (success1 || success2);
		}

		private static bool TryIgnoreWhitespace(ref ReadOnlySpan<char> input)
		{
			try
			{
				var matches = GetWhitespaceRegex().EnumerateMatches(input);

				foreach (var match in matches)
				{
					if (match.Index != 0) { throw MyException(); }

					input = input[match.Length..];
					return true;
				}

				return false;
			}
			catch (Exception ex)
			{
				_ = ex;
				throw MyException();
			}

			//int i;
			//for (i = 0; i < input.Length; i++)
			//{
			//	switch (input[i])
			//	{
			//	case ' ': continue;
			//	case '\t': continue;
			//	case '\r': continue;
			//	case '\n': continue;
			//	default: goto end;
			//	}
			//}
			//end:;

			//if (i != 0)
			//{
			//	input = input[i..];
			//	return true;
			//}
			//else
			//{
			//	return false;
			//}
		}

		private static bool TryIgnoreComment(ref ReadOnlySpan<char> input)
		{
			try
			{
				var matches = GetCommentRegex().EnumerateMatches(input);

				foreach (var match in matches)
				{
					if (match.Index != 0)
					{
						throw MyException();
					}

					input = input[match.Length..];
					return true;
				}

				return false;
			}
			catch (Exception ex)
			{
				_ = ex;
				throw MyException();
			}

			//int i;
			//for (i = 0; i < input.Length; i++)
			//{
			//	switch (input[i])
			//	{
			//	case ' ': continue;
			//	case '\t': continue;
			//	case '\r': continue;
			//	case '\n': continue;
			//	default: goto end;
			//	}
			//}
			//end:;

			//if (i != 0)
			//{
			//	input = input[i..];
			//	return true;
			//}
			//else
			//{
			//	return false;
			//}
		}

		//private static bool TryIgnoreInlineComments(ref ReadOnlySpan<char> input)
		//{
		//	if (input.Length < 2) { return false; }

		//	if (input.StartsWith("//"))
		//	{
		//		input = input[2..];

		//		int i;
		//		for (i = 0; i < input.Length; i++)
		//		{
		//			switch (input[i])
		//			{
		//			case '\n': goto end;
		//			default: continue;
		//			}
		//		}
		//		end:;

		//		input = input[i..];
		//		return true;
		//	}
		//	else
		//	{
		//		return false;
		//	}
		//}

		//private static bool TryIgnoreBlockComments(ref ReadOnlySpan<char> input)
		//{
		//	if (input.Length < 4) { return false; }

		//	if (input.StartsWith("/*"))
		//	{
		//		var originalInput = input;
		//		input = input[2..];

		//		int i;
		//		for (i = 0; i < input.Length; i++)
		//		{
		//			if (input[i..(i + 2)].Equals("*/", StringComparison.Ordinal))
		//			{
		//				input = input[(i + 2)..];
		//				return true;
		//			}
		//		}

		//		// if we're here we couldn't find the end of the comment block
		//		input = originalInput;
		//		return false;
		//	}
		//	else
		//	{
		//		return false;
		//	}
		//}
	}
}
