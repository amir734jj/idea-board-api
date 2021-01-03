using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Configs;
using Dal.Interfaces;
using Mailjet.Client;
using Microsoft.Extensions.Logging;
using Models.Constants;
using RestSharp;
using RestSharp.Authenticators;

namespace Dal.ServiceApi
{
    public class EmailServiceApi : IEmailServiceApi
    {
        private readonly bool _connected;

        private readonly ILogger<EmailServiceApi> _logger;
        
        private readonly IMailjetClient _mailJetClient;

        private readonly GlobalConfigs _globalConfigs;
        
        private readonly MailGunConfig _mailGunConfig;

        public EmailServiceApi()
        {
            _connected = false;
        }

        /// <summary>
        /// Constructor dependency injection
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mailJetClient"></param>
        /// <param name="globalConfigs"></param>
        /// <param name="mailGunConfig"></param>
        public EmailServiceApi(ILogger<EmailServiceApi> logger, IMailjetClient mailJetClient, GlobalConfigs globalConfigs, MailGunConfig mailGunConfig)
        {
            _connected = true;
            _logger = logger;
            _mailJetClient = mailJetClient;
            _globalConfigs = globalConfigs;
            _mailGunConfig = mailGunConfig;
        }

        /// <summary>
        /// Send the email
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="emailSubject"></param>
        /// <param name="emailHtml"></param>
        /// <returns></returns>
        public async Task SendEmailAsync(string emailAddress, string emailSubject, string emailHtml)
        {
            if (_connected && !string.IsNullOrWhiteSpace(emailAddress))
            {
                var client = new RestClient
                {
                    BaseUrl = new Uri("https://api.mailgun.net/v3"),
                    Authenticator = new HttpBasicAuthenticator("api", _mailGunConfig.ApiKey)
                };
                var request = new RestRequest();
                request.AddParameter("domain", _mailGunConfig.Domain, ParameterType.UrlSegment);
                request.Resource = "{domain}/messages";
                request.AddParameter("from", ApiConstants.SiteEmail);
                request.AddParameter("to", emailAddress);
                request.AddParameter("subject", emailSubject);
                request.AddParameter("html", emailHtml);
                request.Method = Method.POST;
                var response = await client.ExecuteAsync(request);
                
                _logger.LogTrace(response.Content);
            }
        }

        /// <summary>
        /// Send the email
        /// </summary>
        /// <param name="emailAddresses"></param>
        /// <param name="emailSubject"></param>
        /// <param name="emailHtml"></param>
        /// <returns></returns>
        public async Task SendEmailAsync(IEnumerable<string> emailAddresses, string emailSubject, string emailHtml)
        {
            var tasks = emailAddresses.Select(x => SendEmailAsync(x, emailSubject, emailHtml)).ToArray();

            await Task.WhenAll(tasks);
        }
    }
}