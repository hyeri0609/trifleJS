﻿using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TrifleJS
{
    public static class Extensions
    {
        /// <summary>
        /// Returns a unix timestamp
        /// </summary>
        /// <returns></returns>
        public static int ToUnixTimestamp(this DateTime date) {
            if (date >= new DateTime(1970, 1, 1, 0, 0, 0, 0))
            {
                TimeSpan span = (date - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
                return (int)span.TotalSeconds;
            }
            return -1;
        }

        /// <summary>
        /// Gets an entry in a dictionary by specifying its type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(this Dictionary<string, object> dictionary, string key)
        {
            try
            {
                if (dictionary.ContainsKey(key)) {
                    return (T)Convert.ChangeType(dictionary[key], typeof(T));
                }
            }
            catch { }
            return default(T);
        }

    }
}
