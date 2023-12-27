using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PatikaAkbankBookstore.Common;
using PatikaAkbankBookstore.DbOperations;

namespace PatikaAkbankBookstore.BookOperations.GetBookById
{
    public class GetBookByIdCommandValidator : AbstractValidator<GetByIdCommand>
    {
        public GetBookByIdCommandValidator()
        {
            RuleFor(command => command.bookId).GreaterThan(0);
          
        }

    }
}