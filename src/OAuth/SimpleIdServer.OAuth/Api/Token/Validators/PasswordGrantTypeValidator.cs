﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using SimpleIdServer.OAuth.DTOs;
using SimpleIdServer.OAuth.Exceptions;
using SimpleIdServer.OAuth.Extensions;

namespace SimpleIdServer.OAuth.Api.Token.Validators
{
    public interface IPasswordGrantTypeValidator
    {
        void Validate(HandlerContext context);
    }

    public class PasswordGrantTypeValidator : IPasswordGrantTypeValidator
    {
        public void Validate(HandlerContext context)
        {
            if (string.IsNullOrWhiteSpace(context.Request.Data.GetStr(TokenRequestParameters.Username)))
            {
                throw new OAuthException(ErrorCodes.INVALID_REQUEST, string.Format(ErrorMessages.MISSING_PARAMETER, TokenRequestParameters.Username));
            }
            
            if (string.IsNullOrWhiteSpace(context.Request.Data.GetStr(TokenRequestParameters.Password)))
            {
                throw new OAuthException(ErrorCodes.INVALID_REQUEST, string.Format(ErrorMessages.MISSING_PARAMETER, TokenRequestParameters.Password));
            }
        }
    }
}
