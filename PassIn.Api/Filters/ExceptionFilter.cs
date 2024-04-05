using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using System.Net;

namespace PassIn.Api.Filters;

public class ExceptionFilter : IExceptionFilter {

    // A classe ExceptionContext serve para tratar exceções e lançar status codes fora de um controller,
    // fornecendo o contexto da exception
    public void OnException(ExceptionContext context) {
        var result = context.Exception is PassInException;

        if (result) {
            HandleProjectException();
        } else {
            ThrowUnknownErrorException(context);
        }

    }

    private void HandleProjectException () {

    }

    private void ThrowUnknownErrorException(ExceptionContext context) {
        context.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson("Unknown error"));
    }

}
