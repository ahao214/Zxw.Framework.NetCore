﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Zxw.Framework.Website.ViewModels
{
    public class ExcutedResult
    {
        public bool success { get; set; }

        public string msg { get; set; }

        public object rows { get; set; }

        public ExcutedResult(bool success, string msg, object rows)
        {
            this.success = success;
            this.msg = msg;
            this.rows = rows;
        }

        public static ExcutedResult SuccessResult(object rows)
        {
            return new ExcutedResult(true, null, rows);
        }

        public static ExcutedResult FailedResult(string msg)
        {
            return new ExcutedResult(false, msg, null);
        }
    }

    public class PaginationResult : ExcutedResult
    {
        /// <summary>
        /// 总条数
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 每页条数
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int index { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int pages => total % size == 0 ? total / size : total / size + 1;

        public PaginationResult(bool success, string msg, object rows) : base(success, msg, rows)
        {
        }

        public static PaginationResult PagedResult(object rows, int total, int size, int index)
        {
            return new PaginationResult(true, null, rows)
            {
                total = total,
                size = size,
                index = index
            };
        }
    }
}
