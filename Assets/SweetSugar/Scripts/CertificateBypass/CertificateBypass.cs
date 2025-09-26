using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CertificateBypass
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void BypassCertificateValidation()
    {
        ServicePointManager.ServerCertificateValidationCallback = 
            (sender, certificate, chain, sslPolicyErrors) =>
            {
                // WARNING: This trusts ALL certificates
                return true;
            };

        Debug.Log("SSL certificate validation bypass enabled (all certs trusted)");
    }
}
