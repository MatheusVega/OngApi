using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace AM.Amil.PeNaAreia.Domain.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Recupera a descrição de cada atributo de um Enum
        /// </summary>
        /// <param name="enumValue">Enum alvo</param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumValue)
        {
            return enumValue.GetType()
                       .GetMember(enumValue.ToString())
                       .First()
                       .GetCustomAttribute<DescriptionAttribute>()?
                       .Description ?? string.Empty;
        }
    }
}
