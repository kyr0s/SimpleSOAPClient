﻿#region License
// The MIT License (MIT)
// 
// Copyright (c) 2016 João Simões
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion
namespace SimpleSOAPClient.Handlers
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.V1Dot1;

    /// <summary>
    /// SOAP Handler that exposes delegates for each handling operation.
    /// </summary>
    public sealed class DelegatingSoapHandler : ISoapHandler
    {
        #region OnSoapEnvelopeRequestAction

        /// <summary>
        /// Delegate for <see cref="ISoapHandler.OnSoapEnvelopeV1Dot1Request"/> method.
        /// </summary>
        public Action<ISoapClient, OnSoapEnvelopeV1Dot1RequestArguments> OnSoapEnvelopeV1Dot1RequestAction { get; set; }

        /// <summary>
        /// Delegate for <see cref="ISoapHandler.OnSoapEnvelopeV1Dot1RequestAsync"/> method.
        /// </summary>
        public Func<ISoapClient, OnSoapEnvelopeV1Dot1RequestArguments, CancellationToken, Task> OnSoapEnvelopeV1Dot1RequestAsyncAction { get; set; }

        /// <summary>
        /// Delegate for <see cref="ISoapHandler.OnSoapEnvelopeV1Dot2Request"/> method.
        /// </summary>
        public Action<ISoapClient, OnSoapEnvelopeV1Dot2RequestArguments> OnSoapEnvelopeV1Dot2RequestAction { get; set; }

        /// <summary>
        /// Delegate for <see cref="ISoapHandler.OnSoapEnvelopeV1Dot1RequestAsync"/> method.
        /// </summary>
        public Func<ISoapClient, OnSoapEnvelopeV1Dot2RequestArguments, CancellationToken, Task> OnSoapEnvelopeV1Dot2RequestAsyncAction { get; set; }

        #endregion

        #region OnHttpRequestAction

        /// <summary>
        /// Delegate for <see cref="ISoapHandler.OnHttpRequest"/> method.
        /// </summary>
        public Action<ISoapClient, OnHttpRequestArguments> OnHttpRequestAction { get; set; }

        /// <summary>
        /// Delegate for <see cref="ISoapHandler.OnHttpRequestAsync"/> method.
        /// </summary>
        public Func<ISoapClient, OnHttpRequestArguments, CancellationToken, Task> OnHttpRequestAsyncAction { get; set; }

        #endregion

        #region OnHttpResponseAction

        /// <summary>
        /// Delegate for <see cref="ISoapHandler.OnHttpResponse"/> method.
        /// </summary>
        public Action<ISoapClient, OnHttpResponseArguments> OnHttpResponseAction { get; set; }

        /// <summary>
        /// Delegate for <see cref="ISoapHandler.OnHttpResponseAsync"/> method.
        /// </summary>
        public Func<ISoapClient, OnHttpResponseArguments, CancellationToken, Task> OnHttpResponseAsyncAction { get; set; }

        #endregion

        #region OnSoapEnvelopeResponseAction

        /// <summary>
        /// Delegate for <see cref="ISoapHandler.OnSoapEnvelopeV1Dot1Response"/> method.
        /// </summary>
        public Action<ISoapClient, OnSoapEnvelopeV1Dot1ResponseArguments> OnSoapEnvelopeV1Dot1ResponseAction { get; set; }

        /// <summary>
        /// Delegate for <see cref="ISoapHandler.OnSoapEnvelopeV1Dot1ResponseAsync"/> method.
        /// </summary>
        public Func<ISoapClient, OnSoapEnvelopeV1Dot1ResponseArguments, CancellationToken, Task> OnSoapEnvelopeV1Dot1ResponseAsyncAction { get; set; }

        /// <summary>
        /// Delegate for <see cref="ISoapHandler.OnSoapEnvelopeV1Dot2Response"/> method.
        /// </summary>
        public Action<ISoapClient, OnSoapEnvelopeV1Dot2ResponseArguments> OnSoapEnvelopeV1Dot2ResponseAction { get; set; }

        /// <summary>
        /// Delegate for <see cref="ISoapHandler.OnSoapEnvelopeV1Dot2ResponseAsync"/> method.
        /// </summary>
        public Func<ISoapClient, OnSoapEnvelopeV1Dot2ResponseArguments, CancellationToken, Task> OnSoapEnvelopeV1Dot2ResponseAsyncAction { get; set; }

        #endregion

        #region Implementation of ISoapHandler

        /// <summary>
        /// The order for which the handler will be executed
        /// </summary>
        public int Order { get; set; }

        #region OnSoapEnvelopeRequest

        /// <summary>
        /// Method invoked before serializing a <see cref="SoapEnvelope"/>. 
        /// Useful to add properties like <see cref="SoapHeader"/>.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        public void OnSoapEnvelopeV1Dot1Request(ISoapClient client, OnSoapEnvelopeV1Dot1RequestArguments arguments)
        {
            OnSoapEnvelopeV1Dot1RequestAction?.Invoke(client, arguments);
        }

        /// <summary>
        /// Method invoked before serializing a <see cref="SoapEnvelope"/>. 
        /// Useful to add properties like <see cref="SoapHeader"/>.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>Task to be awaited</returns>
        public async Task OnSoapEnvelopeV1Dot1RequestAsync(ISoapClient client, OnSoapEnvelopeV1Dot1RequestArguments arguments, CancellationToken ct)
        {
            if (OnSoapEnvelopeV1Dot1RequestAsyncAction != null)
                await OnSoapEnvelopeV1Dot1RequestAsyncAction(client, arguments, ct);
        }

        /// <summary>
        /// Method invoked before serializing a <see cref="SoapEnvelope"/>. 
        /// Useful to add properties like <see cref="SoapHeader"/>.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        public void OnSoapEnvelopeV1Dot2Request(ISoapClient client, OnSoapEnvelopeV1Dot2RequestArguments arguments)
        {
            OnSoapEnvelopeV1Dot2RequestAction?.Invoke(client, arguments);
        }

        /// <summary>
        /// Method invoked before serializing a <see cref="SoapEnvelope"/>. 
        /// Useful to add properties like <see cref="SoapHeader"/>.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>Task to be awaited</returns>
        public async Task OnSoapEnvelopeV1Dot2RequestAsync(ISoapClient client, OnSoapEnvelopeV1Dot2RequestArguments arguments, CancellationToken ct)
        {
            if (OnSoapEnvelopeV1Dot2RequestAsyncAction != null)
                await OnSoapEnvelopeV1Dot2RequestAsyncAction(client, arguments, ct);
        }

        #endregion

        #region OnHttpRequest

        /// <summary>
        /// Method invoked before sending the <see cref="HttpRequestMessage"/> to the server.
        /// Useful to log the request or change properties like HTTP headers.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        public void OnHttpRequest(ISoapClient client, OnHttpRequestArguments arguments)
        {
            OnHttpRequestAction?.Invoke(client, arguments);
        }

        /// <summary>
        /// Method invoked before sending the <see cref="HttpRequestMessage"/> to the server.
        /// Useful to log the request or change properties like HTTP headers.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>Task to be awaited</returns>
        public async Task OnHttpRequestAsync(ISoapClient client, OnHttpRequestArguments arguments, CancellationToken ct)
        {
            if (OnHttpRequestAsyncAction != null)
                await OnHttpRequestAsyncAction(client, arguments, ct);
        }

        #endregion

        #region OnHttpResponse

        /// <summary>
        /// Method invoked after receiving a <see cref="HttpResponseMessage"/> from the server.
        /// Useful to log the response or validate HTTP headers.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        public void OnHttpResponse(ISoapClient client, OnHttpResponseArguments arguments)
        {
            OnHttpResponseAction?.Invoke(client, arguments);
        }

        /// <summary>
        /// Method invoked after receiving a <see cref="HttpResponseMessage"/> from the server.
        /// Useful to log the response or validate HTTP headers.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>Task to be awaited</returns>
        public async Task OnHttpResponseAsync(ISoapClient client, OnHttpResponseArguments arguments, CancellationToken ct)
        {
            if (OnHttpResponseAsyncAction != null)
                await OnHttpResponseAsyncAction(client, arguments, ct);
        }

        #endregion

        #region OnSoapEnvelopeResponse

        /// <summary>
        /// Method invoked after deserializing a <see cref="SoapEnvelope"/> from the server response. 
        /// Useful to validate properties like <see cref="SoapHeader"/>.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        public void OnSoapEnvelopeV1Dot1Response(ISoapClient client, OnSoapEnvelopeV1Dot1ResponseArguments arguments)
        {
            OnSoapEnvelopeV1Dot1ResponseAction?.Invoke(client, arguments);
        }

        /// <summary>
        /// Method invoked after deserializing a <see cref="SoapEnvelope"/> from the server response. 
        /// Useful to validate properties like <see cref="SoapHeader"/>.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>Task to be awaited</returns>
        public async Task OnSoapEnvelopeV1Dot1ResponseAsync(ISoapClient client, OnSoapEnvelopeV1Dot1ResponseArguments arguments, CancellationToken ct)
        {
            if (OnSoapEnvelopeV1Dot1ResponseAsyncAction != null)
                await OnSoapEnvelopeV1Dot1ResponseAsyncAction(client, arguments, ct);
        }

        /// <summary>
        /// Method invoked after deserializing a <see cref="SoapEnvelope"/> from the server response. 
        /// Useful to validate properties like <see cref="SoapHeader"/>.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        public void OnSoapEnvelopeV1Dot2Response(ISoapClient client, OnSoapEnvelopeV1Dot2ResponseArguments arguments)
        {
            OnSoapEnvelopeV1Dot2ResponseAction?.Invoke(client, arguments);
        }

        /// <summary>
        /// Method invoked after deserializing a <see cref="SoapEnvelope"/> from the server response. 
        /// Useful to validate properties like <see cref="SoapHeader"/>.
        /// </summary>
        /// <param name="client">The client sending the request</param>
        /// <param name="arguments">The method arguments</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>Task to be awaited</returns>
        public async Task OnSoapEnvelopeV1Dot2ResponseAsync(ISoapClient client, OnSoapEnvelopeV1Dot2ResponseArguments arguments, CancellationToken ct)
        {
            if (OnSoapEnvelopeV1Dot2ResponseAsyncAction != null)
                await OnSoapEnvelopeV1Dot2ResponseAsyncAction(client, arguments, ct);
        }

        #endregion

        #endregion
    }
}