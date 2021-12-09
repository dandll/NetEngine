﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Common
{

    /// <summary>
    /// 针对string字符串常用操作方法
    /// </summary>
    public class StringHelper
    {


        /// <summary>
        /// 生成一个订单号
        /// </summary>
        /// <returns></returns>
        public static string GetOrderNo(string sign)
        {
            Random ran = new();
            int RandKey = ran.Next(10000, 99999);


            string orderno = sign + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") + RandKey;
            return orderno;
        }



        /// <summary>
        /// 移除字符串中的全部标点符号
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemovePunctuation(string text)
        {
            text = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            return text;
        }



        /// <summary>
        /// 判断字符串中是否包含中文
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsContainsCN(string text)
        {
            Regex reg = new(@"[\u4e00-\u9fa5]");//正则表达式

            if (reg.IsMatch(text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// 从传入的HTML代码中提取文本内容
        /// </summary>
        /// <param name="htmlText"></param>
        /// <returns></returns>
        public static string NoHtml(string htmlText)
        {
            if (!string.IsNullOrEmpty(htmlText))
            {
                //删除脚本

                htmlText = Regex.Replace(htmlText, @"<script[^>]*?>.*?</script>", "",

                RegexOptions.IgnoreCase);

                //删除HTML

                htmlText = Regex.Replace(htmlText, @"<(.[^>]*)>", "",

                RegexOptions.IgnoreCase);

                htmlText = Regex.Replace(htmlText, @"([\r\n])[\s]+", "",

                RegexOptions.IgnoreCase);

                htmlText = Regex.Replace(htmlText, @"-->", "", RegexOptions.IgnoreCase);

                htmlText = Regex.Replace(htmlText, @"<!--.*", "", RegexOptions.IgnoreCase);

                htmlText = Regex.Replace(htmlText, @"&(quot|#34);", "\"",

                RegexOptions.IgnoreCase);

                htmlText = Regex.Replace(htmlText, @"&(amp|#38);", "&",

                RegexOptions.IgnoreCase);

                htmlText = Regex.Replace(htmlText, @"&(lt|#60);", "<",

                RegexOptions.IgnoreCase);

                htmlText = Regex.Replace(htmlText, @"&(gt|#62);", ">",

                RegexOptions.IgnoreCase);

                htmlText = Regex.Replace(htmlText, @"&(nbsp|#160);", " ",

                RegexOptions.IgnoreCase);

                htmlText = Regex.Replace(htmlText, @"&(iexcl|#161);", "\xa1",

                RegexOptions.IgnoreCase);

                htmlText = Regex.Replace(htmlText, @"&(cent|#162);", "\xa2",

                RegexOptions.IgnoreCase);

                htmlText = Regex.Replace(htmlText, @"&(pound|#163);", "\xa3",

                RegexOptions.IgnoreCase);

                htmlText = Regex.Replace(htmlText, @"&(copy|#169);", "\xa9",

                RegexOptions.IgnoreCase);

                htmlText = Regex.Replace(htmlText, @"&#(\d+);", "",

                RegexOptions.IgnoreCase);

                htmlText = htmlText.Replace("<", "");

                htmlText = htmlText.Replace(">", "");

                htmlText = htmlText.Replace("\r\n", "");

                htmlText = WebUtility.HtmlEncode(htmlText).Trim();

                return htmlText;
            }
            else
            {
                return htmlText;
            }
        }




        /// <summary>
        /// 对文本进行指定长度截取并添加省略号
        /// </summary>
        /// <param name="NeiRong"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubstringText(string NeiRong, int length)
        {
            //先对字符串做一次HTML解码
            NeiRong = HttpUtility.HtmlDecode(NeiRong);

            if (NeiRong.Length > length)
            {
                NeiRong = NeiRong[..length];

                NeiRong += "...";

                return NoHtml(NeiRong);
            }
            else
            {
                return NoHtml(NeiRong);
            }
        }



        /// <summary>
        /// 对字符串进行脱敏处理
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string TextStars(string text)
        {
            if (text.Length >= 3)
            {
                int group = text.Length / 3;

                string stars = text.Substring(group, group);

                string pstars = "";

                for (int i = 0; i < group; i++)
                {
                    pstars += "*";
                }

                text = text.Replace(stars, pstars);
            }
            else
            {

                string stars = text.Substring(1, 1);

                string pstars = "";

                for (int i = 0; i < 1; i++)
                {
                    pstars += "*";
                }

                text = text.Replace(stars, pstars);
            }

            return text;
        }


        /// <summary>
        /// Unicode转换中文
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string UnicodeToString(string text)
        {
            return Regex.Unescape(text);
        }




        /// <summary>
        /// 去掉字符串中的数字
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string RemoveNumber(string key)
        {
            return System.Text.RegularExpressions.Regex.Replace(key, @"\d", "");
        }



        /// <summary>
        /// 去掉字符串中的非数字
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string RemoveNotNumber(string key)
        {
            return System.Text.RegularExpressions.Regex.Replace(key, @"[^\d]*", "");
        }
    }
}
