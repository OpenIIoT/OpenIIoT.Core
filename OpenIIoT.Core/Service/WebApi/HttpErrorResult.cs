/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄█    █▄                                     ▄████████                                        ▄████████
      █     ███    ███                                   ███    ███                                       ███    ███
      █     ███    ███       ██        ██       █████▄   ███    █▀     █████    █████  ██████     █████  ▄███▄▄▄▄██▀    ▄█████   ▄█████ ██   █   █           ██
      █    ▄███▄▄▄▄███▄▄ ▀███████▄ ▀███████▄   ██   ██  ▄███▄▄▄       ██  ██   ██  ██ ██    ██   ██  ██ ▀▀███▀▀▀▀▀     ██   █    ██  ▀  ██   ██ ██       ▀███████▄
      █   ▀▀███▀▀▀▀███▀      ██  ▀     ██  ▀   ██   ██ ▀▀███▀▀▀      ▄██▄▄█▀  ▄██▄▄█▀ ██    ██  ▄██▄▄█▀ ▀███████████  ▄██▄▄      ██     ██   ██ ██           ██  ▀
      █     ███    ███       ██        ██    ▀██████▀    ███    █▄  ▀███████ ▀███████ ██    ██ ▀███████   ███    ███ ▀▀██▀▀    ▀███████ ██   ██ ██           ██
      █     ███    ███       ██        ██      ██        ███    ███   ██  ██   ██  ██ ██    ██   ██  ██   ███    ███   ██   █     ▄  ██ ██   ██ ██▌    ▄     ██
      █     ███    █▀       ▄██▀      ▄██▀    ▄███▀      ██████████   ██  ██   ██  ██  ██████    ██  ██   ███    ███   ███████  ▄████▀  ██████  ████▄▄██    ▄██▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Data Transfer Object used when returning error messages.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016-2017 JP Dillingham (jp@dillingham.ws)
      █
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

namespace OpenIIoT.Core.Service.WebApi
{
    using System.Collections.Generic;
    using System.Linq;
    using OpenIIoT.SDK.Common.OperationResult;

    /// <summary>
    ///     Data Transfer Object used when relaying error messages.
    /// </summary>
    public class HttpErrorResult
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="HttpErrorResult"/> class with the specified <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The error message.</param>
        public HttpErrorResult(string message)
            : this(message, default(IResult))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HttpErrorResult"/> class with the specified <paramref name="message"/>
        ///     and the details contained within the specified <paramref name="result"/>.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="result">The <see cref="IResult"/> instance preceding the error.</param>
        public HttpErrorResult(string message, IResult result)
        {
            Message = message;
            Details = new List<string>();

            if (result != default(IResult))
            {
                Details = result.Messages.Select(m => m.Text).ToList();
            }
        }

        /// <summary>
        ///     Gets the list of error details.
        /// </summary>
        public IList<string> Details { get; }

        /// <summary>
        ///     Gets the error message.
        /// </summary>
        public string Message { get; }

        #endregion Public Constructors
    }
}