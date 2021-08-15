using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MarsRover.Core.Enum
{
    public static class EnumProvider
    {
        [Description("Verilen Enum Değerinden Sonra Gelen Enum Değerini Döndüren Metot")]
        public static T Next<T>(this T v) where T : struct
        {
            return System.Enum.GetValues(v.GetType()).Cast<T>().Concat(new[] { default(T) }).SkipWhile(e => !v.Equals(e)).Skip(1).First();
        }

        [Description("Verilen Enum Değerinden Önce Gelen Enum Değerini Döndüren Metot")]
        public static T Previous<T>(this T v) where T : struct
        {
            return System.Enum.GetValues(v.GetType()).Cast<T>().Concat(new[] { default(T) }).Reverse().SkipWhile(e => !v.Equals(e)).Skip(1).First();
        }
    }
}
