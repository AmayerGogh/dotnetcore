using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RupengIM.Common
{
    public static class CommonHelper
    {
        public static string GenerateSalt(int length)
        {
            char[] chs = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^&*./".ToCharArray();
        }
    }
}
