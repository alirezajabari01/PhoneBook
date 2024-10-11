using PhoneBook.MediatR.Mediator;

namespace PhoneBook.Application.Contract.PhoneBooks.Commands;

public record DeletePhoneBookCommand(long Id):IBaseCommand;