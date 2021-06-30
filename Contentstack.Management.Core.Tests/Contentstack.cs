﻿using System;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Contentstack.Management.Core.Tests
{
    public class Contentstack
    {
        private static readonly Lazy<ContentstackClient>
        client =
        new Lazy<ContentstackClient>(() =>
        {
            ContentstackClientOptions options = Config.GetSection("Contentstack").Get<ContentstackClientOptions>();
            return new ContentstackClient(new OptionsWrapper<ContentstackClientOptions>(options));
        });


        private static readonly Lazy<IConfigurationRoot>
        config =
        new Lazy<IConfigurationRoot>(() =>
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        });

        private static readonly Lazy<NetworkCredential> credential =
        new Lazy<NetworkCredential>(() =>
        {
            return Config.GetSection("Contentstack:Credentials").Get<NetworkCredential>();
        });

        public static ContentstackClient Client { get { return client.Value; } }
        public static IConfigurationRoot Config{ get { return config.Value; } }
        public static NetworkCredential Credential { get { return credential.Value; } }

    }
}