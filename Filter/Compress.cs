using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.IO.Compression;

namespace J7.Filter
{
    /// <summary>
    /// 压缩响应的内容
    /// </summary>                   
    public class CompressAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string acceptEncoding = filterContext.HttpContext.Request.Headers["Accept-Encoding"];
            if (String.IsNullOrEmpty(acceptEncoding)) return;
            var response = filterContext.HttpContext.Response;
            acceptEncoding = acceptEncoding.ToUpperInvariant();

            // 对于服务端发起的子请求(如，Html.Action)没有Filter，跳过压缩
            if (response.Filter != null)
            {
                if (acceptEncoding.Contains("GZIP"))
                {
                    response.AppendHeader("Content-Encoding", "gzip");

                    response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);

                }
                else if (acceptEncoding.Contains("DEFLATE"))
                {
                    response.AppendHeader("Content-Encoding", "deflate");
                    response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
                }
            }
        }
    }
}
