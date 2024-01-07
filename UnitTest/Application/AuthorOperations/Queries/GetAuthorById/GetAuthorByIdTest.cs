using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PatikaAkbankBookstore.Application.AuthorOperations.Queries.GetAuthorsById;
using PatikaAkbankBookstore.Common;
using PatikaAkbankBookstore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.TestSetup;

namespace UnitTest.Application.AuthorOperations.Queries.GetAuthorById
{
    public class GetAuthorByIdTest : IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorByIdTest(CommonTextFixture textFixture)
        {
            _dbContext = textFixture.Context;
            _mapper = textFixture.Mapper;
        }

        [Fact]
        public void WhenIdIsGiven_InvalidOperationException_ShouldReturnError()
        {
            //arrange
            GetAuthorByIdQuery query = new GetAuthorByIdQuery(_dbContext, _mapper);
            query.AuthorId = 12;

            //act & assert
            FluentActions.Invoking(() => query.Handle())
           .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar Bulunamadı");
        }

        [Fact]
        public void WhenIdIsGiven_Input_ShouldNotReturnError()
        {
            // arrange
            GetAuthorByIdQuery query = new GetAuthorByIdQuery(_dbContext, _mapper);
            query.AuthorId = 1;

            //act
            FluentActions
                .Invoking(() => query.Handle()).Invoke();

            //assert
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == query.AuthorId);
            author.Should().NotBeNull();
        }
    }
}
