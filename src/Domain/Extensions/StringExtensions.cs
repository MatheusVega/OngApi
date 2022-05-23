using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AM.Amil.PeNaAreia.Domain.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Remove acentos de uma string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoverAcentos(this string value)
        {
            return string.Concat(
                value.Normalize(NormalizationForm.FormD)
                .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) !=
                                              UnicodeCategory.NonSpacingMark)
              ).Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Retorna apenas números
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ApenasNumeros(this string source)
        {
            string sResult = Regex.Replace(source, @"[^0-9]", "").ToLower();
            return sResult;
        }

        /// <summary>
        /// Retorna apenas o texto
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ApenasTexto(this string source)
        {
            string sResult = Regex.Replace(source, @"[^a-zA-Z]", "").ToLower();
            return sResult;
        }

        /// <summary>
        /// Retorna apenas texto e números
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string RemoverCaracteresEspeciais(this Guid source)
        {
            string sResult = Regex.Replace(source.ToString(), @"[^a-zA-Z0-9]", "").ToLower();
            return sResult;
        }
    }
}

