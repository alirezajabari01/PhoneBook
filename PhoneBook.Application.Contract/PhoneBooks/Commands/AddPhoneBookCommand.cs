using PhoneBook.MediatR.Mediator;

namespace PhoneBook.Application.Contract.PhoneBooks.Commands;

public record AddPhoneBookCommand(string UserName, string PhoneNumber) : IBaseCommand;