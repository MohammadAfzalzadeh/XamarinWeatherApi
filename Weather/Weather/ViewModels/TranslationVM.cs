using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Models;
using Weather.Models.API;

namespace Weather.ViewModels
{
    public class TranslationVM
    {
        public TranslateInfo translateInfo { get; set; }

        public async Task<string> translateToEn(string phrase)
        {
            return await (new TranslateApi().traslateAllToEnglish(phrase));
        }
    }
}
