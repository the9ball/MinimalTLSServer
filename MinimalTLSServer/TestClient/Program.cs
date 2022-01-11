using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

const string CertificateFilePath = "server.crt";
var certificate = new X509Certificate2(CertificateFilePath);

var handler = new HttpClientHandler();
handler.ClientCertificateOptions = ClientCertificateOption.Manual;
handler.ClientCertificates.Add(certificate);

using var client = new HttpClient(handler);

var r = await client.GetAsync("https://localhost:7088");
var b = await r.Content.ReadAsStringAsync();
Console.WriteLine(b);
