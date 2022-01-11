using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebHost.CreateDefaultBuilder(args);

const string CertificateFilePath = "server.crt";
const string CertificateKeyFilePath = "server.key";
var certificate = System.Security.Cryptography.X509Certificates.X509Certificate2.CreateFromPemFile(CertificateFilePath, CertificateKeyFilePath);
builder.UseKestrel(
    options =>
    {
        options.ConfigureEndpointDefaults(
            o =>
            {
                o.Protocols = HttpProtocols.Http2;
                o.UseHttps(certificate);
            });
    });

builder.UseStartup<MinimalTLSServer.Startup>().Build().Run();
