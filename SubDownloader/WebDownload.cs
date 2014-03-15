using System;
using System.Net;

public class WebDownload : WebClient
{
    public int Timeout { get; set; }

    public WebDownload() : this(20000) { }

    public WebDownload(int timeout)
    {
        this.Timeout = timeout;
    }

    protected override WebRequest GetWebRequest(Uri address)
    {
        var request = base.GetWebRequest(address);
        if (request != null)
        {
            request.Timeout = this.Timeout;
        }
        return request;
    }
}