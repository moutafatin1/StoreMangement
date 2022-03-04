﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Domain.Exceptions.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;

namespace StoreMangement.API.Extensions;
public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(appError => {
            appError.Run(async context => {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null) {

                    context.Response.StatusCode = contextFeature.Error switch {
                        NotFoundException => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    await context.Response.WriteAsync(new ErrorDetails {

                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message

                    }.ToString());
                }
            });
        });
    }
}
