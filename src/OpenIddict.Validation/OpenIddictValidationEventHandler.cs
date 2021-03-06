﻿/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/openiddict/openiddict-core for more information concerning
 * the license and the contributors participating to this project.
 */

using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace OpenIddict.Validation
{
    /// <summary>
    /// Represents a handler able to process <typeparamref name="TEvent"/> events.
    /// </summary>
    /// <typeparam name="TEvent">The type of the events handled by this instance.</typeparam>
    public class OpenIddictValidationEventHandler<TEvent> : IOpenIddictValidationEventHandler<TEvent>
        where TEvent : class, IOpenIddictValidationEvent
    {
        private readonly Func<TEvent, Task<OpenIddictValidationEventState>> _handler;

        /// <summary>
        /// Creates a new event using the specified handler delegate.
        /// </summary>
        /// <param name="handler">The event handler delegate.</param>
        public OpenIddictValidationEventHandler([NotNull] Func<TEvent, Task<OpenIddictValidationEventState>> handler)
            => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

        /// <summary>
        /// Processes the event.
        /// </summary>
        /// <param name="notification">The event to process.</param>
        /// <returns>
        /// A <see cref="Task"/> that can be used to monitor the asynchronous operation,
        /// whose result determines whether next handlers in the pipeline are invoked.
        /// </returns>
        public Task<OpenIddictValidationEventState> HandleAsync(TEvent notification)
            => _handler(notification ?? throw new ArgumentNullException(nameof(notification)));
    }
}
