using System;
using System.Net;

public class WebClientPlus : WebClient
{
    private CookieContainer outboundCookies = new CookieContainer();
    
    public int Timeout { get; set; }
    public bool IgnoreRedirects { get; set; }

    public CookieContainer OutboundCookies { get { return outboundCookies; } }
    
    public WebClientPlus() : this(20000) { }

    public WebClientPlus(int timeout)
    {
        this.Timeout = timeout;
    }

    protected override WebRequest GetWebRequest(Uri address)
    {
        var request = base.GetWebRequest(address);
        //TryAddCookie(request, new Cookie("au", "136935---196e84b42fa1ccbb4ed0ac031104d9f4b4460f3a", "/", "legendas.tv"));
        if (request != null)
        {
            request.Timeout = this.Timeout;
        }

        if (request is HttpWebRequest)
        {
            (request as HttpWebRequest).CookieContainer = outboundCookies;
            (request as HttpWebRequest).AllowAutoRedirect = !IgnoreRedirects;
        }

        return request;
    }

    private static bool TryAddCookie(WebRequest webRequest, Cookie cookie)
    {
        HttpWebRequest httpRequest = webRequest as HttpWebRequest;
        if (httpRequest == null)
        {
            return false;
        }

        if (httpRequest.CookieContainer == null)
        {
            httpRequest.CookieContainer = new CookieContainer();
        }

        httpRequest.CookieContainer.Add(cookie);
        return true;
    }
}