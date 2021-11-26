﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Interface;
using WebApplicationDemo.Services;
using WebApplicationDemo.Utils.AutofacExtension;

namespace WebApplicationDemo.Controllers
{
    public class SixController : Controller
    {
        #region 属性注入
        //[CustomPropertyAttribute]
        //private IServiceA serviceA { get; set; }
        //private IServiceB serviceB { get; set; }
        //private IServiceC serviceC { get; set; }
        //private IServiceD serviceD { get; set; }
        #endregion

        #region 构造函数注入
        //private readonly IServiceA _serviceA;
        //private readonly IServiceB _serviceB;
        //private readonly IServiceC _serviceC;
        //private readonly IServiceD _serviceD;

        //public SixController(IServiceA serviceA, IServiceB serviceB, IServiceC serviceC, IServiceD serviceD)
        //{
        //    _serviceA = serviceA;
        //    _serviceB = serviceB;
        //    _serviceC = serviceC;
        //    _serviceD = serviceD;
        //}
        #endregion


        #region 单抽象多实例
        //private readonly IServiceA serviceA;

        //private readonly ServiceA serviceA1;
        //private readonly ServiceAA serviceAA;
        //// 获取注册的多个实例
        //private readonly IEnumerable<IServiceA> serviceAList;

        //public SixController(IServiceA serviceA, IEnumerable<IServiceA> serviceAs,
        //    ServiceA serviceA1,
        //    ServiceAA serviceAA)
        //{
        //    this.serviceA = serviceA;
        //    this.serviceAList = serviceAs;
        //    this.serviceAA = serviceAA;
        //}
        #endregion

        #region 支持AOP
        private readonly IServiceA _iServiceA;
        private readonly IServiceA _iServiceAA;
        //private readonly ServiceAA _serviceAA;
        private readonly IEnumerable<IServiceA> _iServiceAList;

        public SixController(IServiceA iServiceA, IServiceA iServiceAA, IEnumerable<IServiceA> iServiceAList)
        {
            _iServiceA = iServiceA;
            _iServiceAA = iServiceAA;
            _iServiceAList = iServiceAList;
        }
        #endregion

        public IActionResult Index()
        {
            _iServiceA.Show();
            _iServiceAA.Show();
            _iServiceAList.ToList()[0].Show();
            _iServiceAList.ToList()[1].Show();
            _iServiceAList.ToList()[2].Show();

            return View();
        }

    }
}
