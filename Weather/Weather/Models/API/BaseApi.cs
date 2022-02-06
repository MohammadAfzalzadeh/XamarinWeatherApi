using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Models.API
{
    public class BaseApi<T>
    {
        protected string url { get; set; }

        protected IDictionary<string, string> getParameters;

        protected IDictionary<string , string> postParameters;

        protected IDictionary<string , string> headers;

        public BaseApi(string url)
        {
            this.url = url;
            getParameters = new Dictionary<string, string>();
            
            postParameters = new Dictionary<string, string>();

            headers = new Dictionary<string, string>();
        }

        protected async Task<T> sendGetReqAndDeserialize()
        {

            HttpRequestMessage requestMessage = new HttpRequestMessage(
                    HttpMethod.Get,
                    url + "?" + getParametersToString() 
                    );

            addHeaders(requestMessage);

            return await sendRequset(requestMessage);

        }

        protected async Task<T> sendPostRequestAndDeserialize()
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(
                    HttpMethod.Post, url);

            requestMessage.Content = new FormUrlEncodedContent(postParameters);

            addHeaders(requestMessage);

            return await sendRequset(requestMessage);
            
        }

        //get string of your getParameter
        private string getParametersToString()
        {
            string paras = "";

            foreach (KeyValuePair<string, string> para in getParameters)
                paras += para.Key + "=" + para.Value + "&";


            if (paras.EndsWith("&"))
                paras = paras.Remove(paras.Length - 1, 1);

            return paras;
        }

        private void addHeaders(HttpRequestMessage request)
        {
            foreach (KeyValuePair<string, string> header in headers)
                request.Headers.Add(header.Key, header.Value);
        }


        private static async Task<T> sendRequset(HttpRequestMessage request)
        {
            HttpClient client = new HttpClient();

            using (HttpResponseMessage response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>
                     (await response.Content.ReadAsStringAsync());
            }

        }

    }
}







//var test = await client.GetAsync(url + "?" + getParametersToString());
//var content =  await test.Content.ReadAsStringAsync();
//return Newtonsoft.Json.JsonConvert.DeserializeObject<T>
//    (content);


// old send get request

//using (WebClient client = new WebClient())
//{
//    string str = url + "?" + getParametersToString();
//    return Newtonsoft.Json.JsonConvert.DeserializeObject < T >(
//        client.DownloadString(url + "?" + getParametersToString()));
//}



//using (WebClient client = new WebClient())
//{
//    string str =  url + "?" + getParametersToString() ;
//    return client.DownloadString(url + "?" + getParametersToString());
//}

// deserialize your json string
//private T deserializeJsonString(string json)
//{
//    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
//}


//protected void addGetParameter(string paraName , string paraVal)
//{
//    getParameters.Add(paraName, paraVal);
//}

//Delete all parameter and add all parameter in array 
// Execption throw when Length of parasName and parasVal not egual
//protected void addAllGetParameter(string[] parasName , string[] parasVal)
//{
//    getParameters = new Dictionary<string, string>();

//    if (parasName.Length != parasVal.Length)
//        throw new Exception("Length of parasName should equal parasVal");

//    for (int i = 0; i < parasName.Length; i++)
//        getParameters.Add(parasName[i], parasVal[i]);   
//}

//protected T sendGetReqAndDeserialize()
//{
//    return deserializeJsonString(sendGetRequestToserverAsync());
//}
