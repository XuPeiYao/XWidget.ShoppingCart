﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LightUp.Cashier {
    /// <summary>
    /// 收銀機
    /// </summary>
    public class DefaultCashier<TId> {
        public List<ICoupon<TId>> CouponList = new List<ICoupon<TId>>();
        public void Checkout(Order<TId> order) {
            IEnumerable<ICoupon<TId>> allowCoupons = null;
            while ((allowCoupons = CouponList.Where(x => x.Vaild(order))).Count() > 0) {
                foreach (var coupon in allowCoupons) {
                    if (coupon.Vaild(order)) { // 依舊必須要在檢查一次
                        coupon.Use(order);
                    }
                }
            }
        }
    }
}