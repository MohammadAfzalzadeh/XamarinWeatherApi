using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Models.API
{
    public class TranslateApi : BaseApi<TranslateInfo>
    {
        public TranslateApi() : base("https://google-translate1.p.rapidapi.com/language/translate/v2")
        {
            headers.Add("x-rapidapi-host" , "google-translate1.p.rapidapi.com");
            headers.Add("x-rapidapi-key",
                "b3e1ffdd2bmshf79106664e641f8p194cbajsnd0c6a3829dcb");
        }

        public async Task<string> traslateAllToEnglish(string phrase)
        {
            return await translate(phrase , "en");
        }

        public async Task<string> translate(string phrase , string targetLanguage , string srcLanguage = null)
        {
            postParameters.Add("q", phrase);
            postParameters.Add("target", targetLanguage);
            if (srcLanguage != null && srcLanguage != "")
                postParameters.Add("source", srcLanguage);

            TranslateInfo translateInfo = await sendPostRequestAndDeserialize();
            return translateInfo.data.translations[0].translatedText;

        }

    }
}
