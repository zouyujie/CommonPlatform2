/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* 命名空间名称: Secom.Smp.Web.Home.Controllers
* 文件名: OverViewController.cs
* 创建者: 邹琼俊
* 创建时间: 08/08/2017 16:45:17
* 版权所有： 紫衡技术
******************************************************************/
using Secom.Smp.ViewModel.Home;
using Secom.Smp.Web.Base.Controllers;
using Secom.Smp.Web.Home.Client;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Secom.Smp.Web.Home.Controllers
{
    public class OverViewController : BaseController
    {
        OverViewService service = new OverViewService();

        [HttpGet]
        public override ActionResult Index()
        {
            ViewBag.RepairOrder= service.GetDataList();
            ViewBag.Introduction = @" 
       医院现有职工5869人，正高职称277人，副高职称513人、中级职称1158人；年门急诊量突破490万人次，开放病床2850张，年住院手术人数达7.18 万人次，出院人次达10.61万人次，
病床使用率达95%以上，直接服务病人的范围从广州、广东走向华南地区，并辐射全国、东南亚乃至世界各国。长期以来，医院充分发挥医疗技术力量雄厚的优势，
不断采用各种新技术成功诊断、治疗和抢救了许多危重、疑难和罕见病例，如：成功开展国内首例肾移植手术、首例断趾再植手术；成功实施世界第八例、中国第一例连体婴分离手术；
成功实现国内首例第三代试管婴儿的诞生；成功施行三足婴矫正手术、全国首例连头婴分离手术（被评为2001年中国卫生界十件大事之一）；
成功实施亚洲首例肝肾联合移植手术、首例多器官移植手术（被评为 2004 中国医药科技十大新闻之一）；成功实施国内首例、世界罕见胸腹主动脉瘤、升主动脉夹层动脉瘤腔内治疗手术；
成功开展全球首例异基因脐血干细胞移植治疗假肥大型肌营养不良症术；成功施行国内首例最小年龄心肺联合移植手术、国内首例母子亲体小肠移植术、国内首例在心跳不停的情况下切开心房取出癌栓术、
国内首例双胎输血综合征宫内治疗术；成功救治华南地区首例、国内罕见巨大颌骨肿瘤患者；成功开展DBS手术治疗帕金森病，达国际先进水平；成功发现全国首例 A型胰岛素抵抗综合征；
成功施行世界上年龄最小幼儿（17月）巨大腹主动脉瘤术；成功实施华南地区首例成人右半肝活体肝移植手术、亲属活体双肝移植术、国内首例保留胰腺器官簇移植术等，这些令人瞩目的辉煌成就，
为我国医疗界填补了许多空白。在复旦大学医院管理研究所评审发布的2013年度最佳医院排行榜（综合）中，医院位于全国前10名；在北京大学于2015年5月发布的中国最佳临床学科评估排行榜（共19个专科）中，
我院14个专科进入前15名，数量位列广东第一、全国第四。";
            ViewBag.InfoImg = "/Upload/Organization/1.png";
            return View();
        }

        #region 运维管理
        /// <summary>
        /// 维修统计/巡检统计/保养统计
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string GetTotalOptions()
        {
            return service.GetTotalOptions();
        }
        #endregion
        #region 能耗统计
        /// <summary>
        /// 本月总能耗
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string GetMonthECTotalOptions()
        {
            return service.GetMonthECTotalOptions();
        }
        /// <summary>
        /// 本年总能耗
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string GetYearECTotalOptions()
        {
            return service.GetYearECTotalOptions();
        }
        #endregion
        #region 安全管理
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AirList()
        {
            var list = new List<TestModel>() { new TestModel { Name0 = "台数", Name1 = "0/4", Name2 = "20/24", Name3 = "10/14", Name4 = "15/19" } ,
             new TestModel { Name0="报警",Name1="0",Name2="0",Name3="0",Name4="1"}};

            //构造成Json的格式传递
            var result = new { iTotalRecords = 2, iTotalDisplayRecords = 2, data = list };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 医用冷链列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ColdChains()
        {
            var list = new List<TestModel2>() { new TestModel2 { Test = "温度", Test1 = "3C", Test2 = "4C", Test3 = "5C", Test4 = "7C" },
             new TestModel2 { Test = "报警",Test1 = "0", Test2 = "0", Test3 = "0", Test4 = "0" }};

            //构造成Json的格式传递
            var result = new { iTotalRecords = 2, iTotalDisplayRecords = 2, data = list };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Transformer()
        {
            var list = new List<TestModel1>() { new TestModel1 { TName = "负载率", TName1 = "3B", TName2 = "4B", TName3 = "5B", TName4 = "7B",TName5="20%",TName6="20%",TName7="20%",TName8="20%",TName9="20%" },
             new TestModel1 { TName = "报警", TName1 = "0", TName2 = "0", TName3 = "0", TName4 = "0" ,TName5="0",TName6="0",TName7="0",TName8="0",TName9="0"}};

            //构造成Json的格式传递
            var result = new { iTotalRecords = 2, iTotalDisplayRecords = 2, data = list };
            return Json(result, JsonRequestBehavior.AllowGet);
        } 
        #endregion
    }
}