using System;
using System.Collections.Generic;
using System.Text;

namespace SAVI.wSClientLib
{
    public class SoapWebService
    {

		private String _baseUrl = null;

		public String getBaseUrl()
		{
			return _baseUrl;
		}

		public void setBaseUrl(String b)
		{
			_baseUrl = b;
		}

		private String _url = null;

		public String getUrl()
		{
			return _url;
		}

		public void setUrl(String url)
		{
			_url = url;
		}
	}
}
